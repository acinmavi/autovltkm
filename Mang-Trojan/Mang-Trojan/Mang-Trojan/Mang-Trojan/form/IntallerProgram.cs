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
    public partial class IntallerProgram : Form
    {
        RemoteObject.ScreenObject hostInstance;
        ListViewHitTestInfo selected = null;

        public IntallerProgram(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.hostInstance = hostInstance;
            this.Text = "Các chương trình đã cài đặt:" + hostInstance.GetComputerName();
            Renew();
        }

        private void Renew()
        {
            listView1.Items.Clear();
            String IntallPro = hostInstance.GetInstalledPrograms();
            string[] fields = IntallPro.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            
            //MessageBox.Show(IntallPro);

            foreach (string field in fields)
            {
                if (field != string.Empty)
                {
                    string[] IntallProItem = field.Split(new string[] { "|*|" }, StringSplitOptions.None);
                    ListViewItem list = new ListViewItem(IntallProItem[0]);
                    for (int i = 1; i < IntallProItem.Length; i++)
                    {
                        list.SubItems.Add(IntallProItem[i]);
                    }
                    listView1.Items.Add(list);
                }
            }

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Renew();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
            {
                contextMenuStrip1.Show(listView1,e.Location);
                selected = listView1.HitTest(e.X, e.Y);
            }
        }

      

    }
}
