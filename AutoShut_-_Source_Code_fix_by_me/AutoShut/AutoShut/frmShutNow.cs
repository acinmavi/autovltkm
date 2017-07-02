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
    public partial class frmShutNow : Form
    {
        private frmAutoShut mainForm = null;
        public frmShutNow(Form callingForm)
        {
            //make contact with the main form
            mainForm = callingForm as frmAutoShut;
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            //shutdown when the user accepts the message
            this.Close();
            System.Diagnostics.Process.Start("shutdown", "/s /t 0 /f");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close the message, don't shutdown, and pause the main form timer if it was running
            this.Close();
            this.mainForm.btnPause_Click(sender, e);
        }
    }
}
