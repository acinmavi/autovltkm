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
    public partial class ActivePorts : Form
    {
        RemoteObject.ScreenObject hostInstance;
        public ActivePorts(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.hostInstance = hostInstance;
        }

        private void refresnToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            while (hostInstance.GetActivePorts() == string.Empty)
            {
                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
            }
            string data = hostInstance.GetActivePorts();
            string[] rows = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string row in rows)
            {
                if (row != string.Empty)
                {
                    string[] fields = row.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    ListViewItem item = new ListViewItem(fields[0]);
                    item.SubItems.Add(fields[1].Substring(0, fields[1].LastIndexOf(":")));
                    item.SubItems.Add(fields[1].Substring(fields[1].LastIndexOf(":") + 1));

                    
                    item.SubItems.Add(fields[2].Substring(0, fields[2].LastIndexOf(":")));
                    item.SubItems.Add(fields[2].Substring(fields[2].LastIndexOf(":") + 1));
                    if (fields.Count() == 4)
                    {
                        item.SubItems.Add("");
                        item.SubItems.Add(fields[3]);
                        
                    }
                    else
                    {
                        item.SubItems.Add(fields[3]);
                        item.SubItems.Add(fields[4]);
                    }
                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }

    }
}
