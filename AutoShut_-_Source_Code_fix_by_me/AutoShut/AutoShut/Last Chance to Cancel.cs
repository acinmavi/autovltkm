using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoShut
{
    public partial class Last_Chance_to_Cancel : Form
    {
        public Last_Chance_to_Cancel()
        {
            InitializeComponent();
            timerLast.Start(); //start a 10 second count down as soon as the message gets shown
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if the user acknowledged the message, tick the timer
            timerLast_Tick(sender, e);
        }

        private void timerLast_Tick(object sender, EventArgs e)
        {
            //stop the timer, close the dialog, shutdown the system
            timerLast.Stop();
            timerLast.Enabled = false;
            this.Close();
            System.Diagnostics.Process.Start("shutdown", "/s /t 0 /f");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //if the user pressed cancel before the timer ticks, stop the timer, and close the dialog
            timerLast.Stop();
            timerLast.Enabled = false;
            this.Close();
        }
    }
}
