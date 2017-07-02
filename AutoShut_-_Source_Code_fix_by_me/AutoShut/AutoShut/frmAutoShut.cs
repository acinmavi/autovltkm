using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace AutoShut
{
    public partial class frmAutoShut : Form
    {
        //Global Variables
        Timer Clock = new Timer();
        TimeSpan AutoShutTimeSpan;
        DateTime AutoShutDateTime;
        DateTime pausetime;
        bool timer2WasEnabled;

        public frmAutoShut()
        {
            //Show and hide the following on start
            InitializeComponent();
            NotifyIcon1.Visible = true;
            rdDays.Hide();
            rdHours.Hide();
            rdMinutes.Hide();
            rdWeeks.Hide();
            cmbDays.Hide();
            cmbHours.Hide();
            cmbMinutes.Hide();
            cmbWeeks.Hide();
            btnToday.Hide();
            btnTomorrow.Hide();
            dateTimePicker1.Hide();
            cmbRemindMinutes.Hide();
            cbPlaySound.Hide();
            btnResume.Hide();
        }

        private void frmAutoShut_Resize(object sender, EventArgs e) //minimize to tray
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
                NotifyIcon1.ShowBalloonTip(200);
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) //restore window from tray
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void rdShutdownExactly_CheckedChanged(object sender, EventArgs e)
        {
            //when selecting "Shutdown Exactly At:" radio button, show and hide the following:
            btnToday.Show();
            btnTomorrow.Show();
            dateTimePicker1.Show();
            rdDays.Hide();
            rdHours.Hide();
            rdMinutes.Hide();
            rdWeeks.Hide();
            cmbDays.Hide();
            cmbHours.Hide();
            cmbMinutes.Hide();
            cmbWeeks.Hide();
        }

        private void rdShutdownAfter_CheckedChanged(object sender, EventArgs e)
        {
            //when selecting "Shutdown After:" radio button, show and hide the following:
            btnToday.Hide();
            btnTomorrow.Hide();
            dateTimePicker1.Hide();
            rdDays.Show();
            rdHours.Show();
            rdMinutes.Show();
            rdWeeks.Show();
            cmbDays.Hide();
            cmbHours.Hide();
            cmbMinutes.Hide();
            cmbWeeks.Hide();

        }

        private void rdMinutes_CheckedChanged(object sender, EventArgs e)
        {
            //when selecting rdMinutes radio button, show and hide the following:
            cmbDays.Hide();
            cmbHours.Hide();
            cmbMinutes.Show();
            cmbWeeks.Hide();
        }

        private void rdHours_CheckedChanged(object sender, EventArgs e)
        {
            //when selecting rdHours radio button, show and hide the following:
            cmbDays.Hide();
            cmbHours.Show();
            cmbMinutes.Hide();
            cmbWeeks.Hide();
        }

        private void rdDays_CheckedChanged(object sender, EventArgs e)
        {
            //when selecting rdDays radio button, show and hide the following:
            cmbDays.Show();
            cmbHours.Hide();
            cmbMinutes.Hide();
            cmbWeeks.Hide();
        }

        private void rdWeeks_CheckedChanged(object sender, EventArgs e)
        {
            //when selecting rdWeeks radio button, show and hide the following:
            cmbDays.Hide();
            cmbHours.Hide();
            cmbMinutes.Hide();
            cmbWeeks.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;

            //Show a message to warn the user about the shutdown, and shutdown wether he responds or not. but gives him a chance to cancel (10 seconds)...
            Last_Chance_to_Cancel frmLast = new Last_Chance_to_Cancel();
            frmLast.ShowDialog();
            frmLast.Activate();
            frmLast.BringToFront();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //if the button was clicked twice, timers should be stoped and reseted
            timer1.Stop();
            timer2.Stop();

            //Show and hide the following
            btnPause.Show();
            btnResume.Hide();

            //===============================================================================================================================================
            //Checking radio buttons
            if (rdShutdownExactly.Checked) //"Shutdown Exactly At:" Radion Button
            {
                AutoShutDateTime = dateTimePicker1.Value;
                update_timespan(); //set the time span (the time between now and AutoShut time entered by the user)

                if (AutoShutTimeSpan.TotalMilliseconds <= 0) //if the time picked is in the past, show an error message and exit the eventhandler
                {
                    MessageBox.Show("Invalid Time! \n" +"Please pick a time after: " + System.DateTime.Now.ToString());
                    goto flag;
                }

                //else, set the timer to required time and start counting
                timer1.Interval = (int) AutoShutTimeSpan.TotalMilliseconds;
                timer1.Enabled = true;
                timer1.Start();
            }
            else if (rdMinutes.Checked && cmbMinutes.Text != "" && !cmbMinutes.Text.Contains('.')) //"Shutdown After:" and Minutes Radio Buttons
            {
                AutoShutDateTime = System.DateTime.Now.AddMinutes(int.Parse(cmbMinutes.Text)); //AutoShut time is now plus minutes selected from cmbMinutes
                update_timespan(); //set the time span (the time between now and AutoShut time)

                //set the timer to required time and start counting
                timer1.Interval = 60000 * int.Parse(cmbMinutes.Text);
                timer1.Enabled = true;
                timer1.Start();
            }
            else if (rdHours.Checked && cmbHours.Text != "" && !cmbHours.Text.Contains('.')) //"Shutdown After:" and Hours Radio Buttons
            {
                AutoShutDateTime = System.DateTime.Now.AddHours(int.Parse(cmbHours.Text)); //AutoShut time is now plus hours selected from cmbHours
                update_timespan(); //set the time span (the time between now and AutoShut time)

                //set the timer to required time and start counting
                timer1.Interval = 3600000 * int.Parse(cmbHours.Text);
                timer1.Enabled = true;
                timer1.Start();
            }
            else if (rdDays.Checked && cmbDays.Text != "" && !cmbDays.Text.Contains('.')) //"Shutdown After:" and Days Radio Buttons
            {
                AutoShutDateTime = System.DateTime.Now.AddDays(int.Parse(cmbDays.Text)); //AutoShut time is now plus Days selected from cmbDays
                update_timespan(); //set the time span (the time between now and AutoShut time)

                //set the timer to required time and start counting
                timer1.Interval = 86400000 * int.Parse(cmbDays.Text);
                timer1.Enabled = true;
                timer1.Start();
            }
            else if (rdWeeks.Checked && cmbWeeks.Text != "" && !cmbWeeks.Text.Contains('.')) //"Shutdown After:" and Weeks Radio Buttons
            {
                AutoShutDateTime = System.DateTime.Now.AddDays(int.Parse(cmbWeeks.Text) * 7); //AutoShut time is now plus 7 Days per week selected from cmbWeeks
                update_timespan(); //set the time span (the time between now and AutoShut time)

                //set the timer to required time and start counting
                timer1.Interval = 86400000 * (7 * int.Parse(cmbWeeks.Text));
                timer1.Enabled = true;
                timer1.Start();
            }
            else //in other cases like no data where selected from comboboxes, an error message will appear and exits the eventhandler
            {
                MessageBox.Show("Please Choose a valid AutoShut Time");
                goto flag;
            }

            //===============================================================================================================================================
            //Checking "Remind me before" CheckBox

            if (cbRemind.Checked)
                {
                update_timespan(); //update the time span (the time between now and AutoShut time)

                if (AutoShutTimeSpan.TotalSeconds <= 60) // if a reminder is to be set 1 minute before AutoShut, don't accept it, and show an error message
                    MessageBox.Show("Can not set a reminder now!");
                else if (cmbRemindMinutes.Text == "") //if a reminder is to be set and no value is entered or choosen from cmbRemindMinutes, show an error message and exit the event handler
                {
                    MessageBox.Show("Please choose or enter a value for the reminder");
                    goto flag;
                }
                else if (cmbRemindMinutes.Text.Contains('.'))
                {
                    MessageBox.Show("Invalid Reminder");
                    goto flag;
                }
                else if (int.Parse(cmbRemindMinutes.Text) >= AutoShutTimeSpan.TotalMinutes)
                {
                    MessageBox.Show("Reminder is set after AutoShut time");
                    goto flag;
                }
                else //set a timer to show a message to the user reminding him about the AutoShut before a given time
                {
                    timer2.Enabled = true;
                    timer2.Interval = timer1.Interval - (60 * 1000 * int.Parse(cmbRemindMinutes.Text));
                    timer2.Start();
                }
                }
            //===============================================================================================================================================
            //Count Down
            //set the count down timer, and update it every 1ms

            Clock.Interval = 1;
            Clock.Start();
            Clock.Tick += new EventHandler(Timer_Tick);

            //===============================================================================================================================================
            //Error Detection (Escape)
            flag: ;
        }

        private void cbRemind_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRemind.Checked) //when checking cbRemind checkbox, show and hide the following:
            {
                cbPlaySound.Show();
                cmbRemindMinutes.Show();
            }
            else if (cbRemind.Checked == false) //when unchecking cbRemind checkbox, show and hide the following:
            {
                cmbRemindMinutes.Hide();
                cbPlaySound.Hide();
                cbPlaySound.Checked = false;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer2.Enabled = false;

            //play a sound if cbPlaySound is checked
            if (cbPlaySound.Checked == true)
            {
                SoundPlayer sound1 = new SoundPlayer(@"C:\Windows\Media\notify.wav");
                sound1.Play();
            }

            //show this message when timer2 ticks, and disable it
            MessageBox.Show("Warning: \n" + cmbRemindMinutes.Text + " Minute(s) remaining before AutoShut!");
            
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = System.DateTime.Now;
        }

        private void btnTomorrow_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = System.DateTime.Now.AddDays(1.0);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public string GetTime()
        {
            update_timespan();
            string TimeInString = "";
            int hour = AutoShutTimeSpan.Hours + (24 * AutoShutTimeSpan.Days);
            int min = AutoShutTimeSpan.Minutes;
            int sec = AutoShutTimeSpan.Seconds;
            int miliSec = AutoShutTimeSpan.Milliseconds;

            if (AutoShutTimeSpan.Days >= 1)
                miliSec = 0;
            
            TimeInString = (hour < 10) ? "0" + hour.ToString() : hour.ToString();
            TimeInString += ":" + ((min < 10) ? "0" + min.ToString() : min.ToString());
            TimeInString += ":" + ((sec < 10) ? "0" + sec.ToString() : sec.ToString());
            TimeInString += ":" + ((miliSec < 10) ? "0" + miliSec.ToString() : miliSec.ToString());
            return TimeInString;
        }
        
        public void Timer_Tick(object sender, EventArgs eArgs)
        {
            //update lbTimer Label every Tick and stop when timespan reaches 0
            if (sender == Clock && AutoShutTimeSpan.TotalSeconds > 0)
                lbTimer.Text = GetTime();

            //change the color of the count down to red in the last minute of counting, but keep it black other wise
            if (AutoShutTimeSpan.TotalSeconds <= 60)
                lbTimer.ForeColor = System.Drawing.Color.Red;
            else
                lbTimer.ForeColor = System.Drawing.Color.Black;

            //reset the counter when the timespan reaches zero or below
            if (AutoShutTimeSpan.TotalMilliseconds <= 0)
                lbTimer.Text = "00:00:00:00";
        }

        public void update_timespan()
        {
            //set the time span (the time between now and AutoShut time entered by the user)
            AutoShutTimeSpan =  AutoShutDateTime - System.DateTime.Now;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnPause_Click(object sender, EventArgs e)
        {
            //if the user wants to pause AutoSh
            if (AutoShutTimeSpan.TotalMilliseconds > 0)
            {
                //capture the time when pausing
                pausetime = System.DateTime.Now;

                //show and hide the following
                btnResume.Show();
                btnPause.Hide();

                //check if timer2 is enabled or disabled
                /*bool*/timer2WasEnabled = timer2.Enabled;

                //stop all timers
                Clock.Stop();
                timer1.Stop();
                timer2.Stop();

                //testing
                //label2.Text += "\ntimer1: " + timer1.Interval.ToString() + "\ntimer2: " + timer2.Interval.ToString() + "\nAutoShutDateTime: " + AutoShutDateTime.ToString() + "\nAutoShutTimeSpan: " + AutoShutTimeSpan.ToString();
            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            //show and hide the following
            btnResume.Hide();
            btnPause.Show();

            //capture the time when resuming
            DateTime resumetime;
            resumetime = System.DateTime.Now;

            //calculate the time span of the pause, by subtracting the resume time from the pause time
            TimeSpan pauseDuration = resumetime.Subtract(pausetime);

            //add the pause duration to the AutoShut time (postpone AutoShut), and update the AutoShut time span
            AutoShutDateTime += pauseDuration;
            update_timespan();

            //postpone the timers as well
            int reminderIntervalDifference = timer1.Interval - timer2.Interval;
            timer1.Interval = (int) AutoShutTimeSpan.TotalMilliseconds; //(int)pauseDuration.TotalMilliseconds;
            if (timer2WasEnabled)
                timer2.Interval = timer1.Interval - reminderIntervalDifference;

            //testing
            //label2.Text += "\ntimer1: " + timer1.Interval.ToString() + "\ntimer2: " + timer2.Interval.ToString() + "\nPauseDuration: " + pauseDuration.ToString() + "\nAutoShutDateTime: " + AutoShutDateTime.ToString() + "\nAutoShutTimeSpan: " + AutoShutTimeSpan.ToString();

            //start all timers back
            Clock.Start();
            timer1.Start();
            if (timer2WasEnabled) //start timer 2 only if it was running before pause
                timer2.Start();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void btnShutNow_Click(object sender, EventArgs e)
        {
            //give the user a message to make sure he wants to shutdown now
            frmShutNow frmSure = new frmShutNow(this);
            frmSure.ShowDialog(this);
            frmSure.Activate();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            timer2.Stop();
            timer2.Enabled = false;
            Clock.Stop();
            Clock.Enabled = false;
            rdShutdownExactly.Checked = false;
            rdShutdownAfter.Checked = false;
            rdMinutes.Checked = false;
            rdHours.Checked = false;
            rdDays.Checked = false;
            rdWeeks.Checked = false;
            cbPlaySound.Checked = false;
            cbRemind.Checked = false;
            rdDays.Hide();
            rdHours.Hide();
            rdMinutes.Hide();
            rdWeeks.Hide();
            cmbDays.Hide();
            cmbHours.Hide();
            cmbMinutes.Hide();
            cmbWeeks.Hide();
            btnToday.Hide();
            btnTomorrow.Hide();
            dateTimePicker1.Hide();
            cmbRemindMinutes.Hide();
            cbPlaySound.Hide();
            btnResume.Hide();
            lbTimer.Text = "00:00:00:00";
        }

    }

}
