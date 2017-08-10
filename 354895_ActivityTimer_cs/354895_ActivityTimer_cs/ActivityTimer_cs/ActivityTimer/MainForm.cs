using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ActivityTimer
{
    public partial class MainForm : Form
    {
        private bool exiting = false;
        public MainForm()
        {
            InitializeComponent();

            idleThresholdNumericUpDown.Value = userTimer.IdleThreshold / 1000;
        }

        /// <summary>
        /// Handles the Click event for the Reset button.  Resets the elapsed time ActivityTimer object to zero.
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {
            userTimer.Reset();
        }

        /// <summary>
        /// Handles the Tick event of the updateTimer object to update the UI with active time
        /// </summary>
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = userTimer.ActiveTime;

            // Not necessary to update the status label since the active/idle events to it
            statusLabel.Text = userTimer.UserActiveState.ToString();

            string totalActive = string.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);

            timerLabel.Text = string.Format("{0} since {1}",
                totalActive, userTimer.LastResetTime.ToShortTimeString());

            appNotifyIcon.Text = string.Format("Coding 4 Fun - User Activity - Active {0}", totalActive);
        }

        /// <summary>
        /// Handles the Click event of the Enable menu item.  Enables/disables the ActivityTimer
        /// </summary>
        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableToolStripMenuItem.Checked = !enableToolStripMenuItem.Checked;

            userTimer.Enabled = enableToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the Click event of the Reset menu item.  Resets the elapsed time ActivityTimer object to zero. 
        /// </summary>
        private void resetTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userTimer.Reset();
        }

        /// <summary>
        /// Handles the Click event of the Quit menu item.  Exits the application
        /// </summary>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appNotifyIcon.Visible = false;
            exiting = true;
            this.Close();
        }

        /// <summary>
        /// Handles the ValueChanged event of the IdleThresholdNumericUpDown control.  Changes the 
        /// number of seconds until inactivity considers the user to be considered Idle.
        /// </summary>
        private void idleThresholdNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            userTimer.IdleThreshold = (long)idleThresholdNumericUpDown.Value * 1000;
        }

        /// <summary>
        /// Handles the UserIdleEvent of the ActivityTimer class.  Updates the UI for the Active state
        /// </summary>
        private void userTimer_UserActiveEvent(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { userTimer_UserActiveEvent(sender, e); });
                return;
            }
            else
            {
                statusLabel.Text = "UserActiveEvent";
            }
        }

        /// <summary>
        /// Handles the UserIdleEvent of the ActivityTimer class.  Updates the UI for the Idle state
        /// </summary>
        private void userTimer_UserIdleEvent(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { userTimer_UserIdleEvent(sender, e); });
                return;
            }
            else
            {
                statusLabel.Text = "UserIdleEvent";
            }
        }

        /// <summary>
        /// Handles the MouseDoubleClick event when the user double-clicks the notification icon
        /// </summary>
        private void appNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
        }

        /// <summary>
        /// Handles the FormClosing event to hide the form or allow it to close
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If exiting is set, application is intended to exit.  Otherwise,
            // just hide the form and discard the event.
            if (!exiting)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }

    }
}