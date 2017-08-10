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
    public partial class Windows : Form
    {
        RemoteObject.ScreenObject hostInstance;
        ListViewHitTestInfo selected = null;
        public Windows(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.hostInstance = hostInstance;
            this.Text ="Quản lý cửa sổ "+ hostInstance.GetComputerName();
            Renew();
        }

        private void Renew()
        {
            listView1.Items.Clear();
            string windows = hostInstance.GetWindows();
            string[] fields = windows.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);

            foreach (string field in fields)
            {
                if (field!= string.Empty)
                {
                    string[] windowItem = field.Split(new string[] { "|*|" }, StringSplitOptions.None);
                    ListViewItem listItem = new ListViewItem(windowItem[0]);
                    for (int i = 1; i < windowItem.Length; i++)
                    {
                        listItem.SubItems.Add(windowItem[i]);
                    }
                    listView1.Items.Add(listItem);
                }
            }
           // MessageBox.Show(windows);
        }
       
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Renew();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hostInstance.ChangeViewWindow(selected.Item.Text, "CLOSE");
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hostInstance.ChangeViewWindow(selected.Item.Text, "HIDE");
        }

        private void minimineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hostInstance.ChangeViewWindow(selected.Item.Text, "MINIMIZE");
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hostInstance.ChangeViewWindow(selected.Item.Text, "MAXIMIZE");
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hostInstance.ChangeViewWindow(selected.Item.Text, "NORMAL");
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(listView1, e.Location);
                selected = listView1.HitTest(e.X, e.Y);
            }

        }
    }
}
