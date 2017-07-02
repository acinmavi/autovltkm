namespace AutoShut
{
    partial class frmAutoShut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoShut));
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnShutNow = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTomorrow = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.cmbWeeks = new System.Windows.Forms.ComboBox();
            this.cmbDays = new System.Windows.Forms.ComboBox();
            this.cmbHours = new System.Windows.Forms.ComboBox();
            this.rdWeeks = new System.Windows.Forms.RadioButton();
            this.rdDays = new System.Windows.Forms.RadioButton();
            this.rdHours = new System.Windows.Forms.RadioButton();
            this.rdMinutes = new System.Windows.Forms.RadioButton();
            this.cmbMinutes = new System.Windows.Forms.ComboBox();
            this.rdShutdownAfter = new System.Windows.Forms.RadioButton();
            this.rdShutdownExactly = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbTimer = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbPlaySound = new System.Windows.Forms.CheckBox();
            this.cmbRemindMinutes = new System.Windows.Forms.ComboBox();
            this.cbRemind = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyIcon1.BalloonTipText = "AutoShut đang chạy dưới khay hệ thống";
            this.NotifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon1.Icon")));
            this.NotifyIcon1.Text = "AutoShut";
            this.NotifyIcon1.Visible = true;
            this.NotifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnAbout);
            this.groupBox1.Controls.Add(this.btnResume);
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.btnShutNow);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnMinimize);
            this.groupBox1.Location = new System.Drawing.Point(12, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(225, 19);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(225, 49);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 8;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(105, 19);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(98, 23);
            this.btnResume.TabIndex = 7;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnPause
            // 
            this.btnPause.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPause.Location = new System.Drawing.Point(105, 19);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(98, 23);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnShutNow
            // 
            this.btnShutNow.Location = new System.Drawing.Point(105, 49);
            this.btnShutNow.Name = "btnShutNow";
            this.btnShutNow.Size = new System.Drawing.Size(98, 23);
            this.btnShutNow.TabIndex = 3;
            this.btnShutNow.Text = "Shutdown Now!";
            this.btnShutNow.UseVisualStyleBackColor = true;
            this.btnShutNow.Click += new System.EventHandler(this.btnShutNow_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(6, 49);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Location = new System.Drawing.Point(6, 19);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(75, 23);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTomorrow);
            this.groupBox2.Controls.Add(this.btnToday);
            this.groupBox2.Controls.Add(this.cmbWeeks);
            this.groupBox2.Controls.Add(this.cmbDays);
            this.groupBox2.Controls.Add(this.cmbHours);
            this.groupBox2.Controls.Add(this.rdWeeks);
            this.groupBox2.Controls.Add(this.rdDays);
            this.groupBox2.Controls.Add(this.rdHours);
            this.groupBox2.Controls.Add(this.rdMinutes);
            this.groupBox2.Controls.Add(this.cmbMinutes);
            this.groupBox2.Controls.Add(this.rdShutdownAfter);
            this.groupBox2.Controls.Add(this.rdShutdownExactly);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 204);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnTomorrow
            // 
            this.btnTomorrow.Location = new System.Drawing.Point(222, 23);
            this.btnTomorrow.Name = "btnTomorrow";
            this.btnTomorrow.Size = new System.Drawing.Size(66, 23);
            this.btnTomorrow.TabIndex = 13;
            this.btnTomorrow.Text = "Ngày mai";
            this.btnTomorrow.UseVisualStyleBackColor = true;
            this.btnTomorrow.Click += new System.EventHandler(this.btnTomorrow_Click);
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(154, 23);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(66, 23);
            this.btnToday.TabIndex = 12;
            this.btnToday.Text = "Hôm nay";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // cmbWeeks
            // 
            this.cmbWeeks.FormattingEnabled = true;
            this.cmbWeeks.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmbWeeks.Location = new System.Drawing.Point(188, 174);
            this.cmbWeeks.Name = "cmbWeeks";
            this.cmbWeeks.Size = new System.Drawing.Size(100, 21);
            this.cmbWeeks.TabIndex = 11;
            // 
            // cmbDays
            // 
            this.cmbDays.FormattingEnabled = true;
            this.cmbDays.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cmbDays.Location = new System.Drawing.Point(188, 151);
            this.cmbDays.Name = "cmbDays";
            this.cmbDays.Size = new System.Drawing.Size(100, 21);
            this.cmbDays.TabIndex = 10;
            // 
            // cmbHours
            // 
            this.cmbHours.FormattingEnabled = true;
            this.cmbHours.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbHours.Location = new System.Drawing.Point(188, 128);
            this.cmbHours.Name = "cmbHours";
            this.cmbHours.Size = new System.Drawing.Size(100, 21);
            this.cmbHours.TabIndex = 9;
            // 
            // rdWeeks
            // 
            this.rdWeeks.AutoSize = true;
            this.rdWeeks.Location = new System.Drawing.Point(116, 174);
            this.rdWeeks.Name = "rdWeeks";
            this.rdWeeks.Size = new System.Drawing.Size(53, 17);
            this.rdWeeks.TabIndex = 8;
            this.rdWeeks.TabStop = true;
            this.rdWeeks.Text = "Tuần:";
            this.rdWeeks.UseVisualStyleBackColor = true;
            this.rdWeeks.CheckedChanged += new System.EventHandler(this.rdWeeks_CheckedChanged);
            // 
            // rdDays
            // 
            this.rdDays.AutoSize = true;
            this.rdDays.Location = new System.Drawing.Point(116, 151);
            this.rdDays.Name = "rdDays";
            this.rdDays.Size = new System.Drawing.Size(53, 17);
            this.rdDays.TabIndex = 7;
            this.rdDays.TabStop = true;
            this.rdDays.Text = "Ngày:";
            this.rdDays.UseVisualStyleBackColor = true;
            this.rdDays.CheckedChanged += new System.EventHandler(this.rdDays_CheckedChanged);
            // 
            // rdHours
            // 
            this.rdHours.AutoSize = true;
            this.rdHours.Location = new System.Drawing.Point(116, 128);
            this.rdHours.Name = "rdHours";
            this.rdHours.Size = new System.Drawing.Size(44, 17);
            this.rdHours.TabIndex = 6;
            this.rdHours.TabStop = true;
            this.rdHours.Text = "Giờ:";
            this.rdHours.UseVisualStyleBackColor = true;
            this.rdHours.CheckedChanged += new System.EventHandler(this.rdHours_CheckedChanged);
            // 
            // rdMinutes
            // 
            this.rdMinutes.AutoSize = true;
            this.rdMinutes.Location = new System.Drawing.Point(116, 104);
            this.rdMinutes.Name = "rdMinutes";
            this.rdMinutes.Size = new System.Drawing.Size(50, 17);
            this.rdMinutes.TabIndex = 5;
            this.rdMinutes.TabStop = true;
            this.rdMinutes.Text = "Phút:";
            this.rdMinutes.UseVisualStyleBackColor = true;
            this.rdMinutes.CheckedChanged += new System.EventHandler(this.rdMinutes_CheckedChanged);
            // 
            // cmbMinutes
            // 
            this.cmbMinutes.FormattingEnabled = true;
            this.cmbMinutes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.cmbMinutes.Location = new System.Drawing.Point(188, 104);
            this.cmbMinutes.Name = "cmbMinutes";
            this.cmbMinutes.Size = new System.Drawing.Size(100, 21);
            this.cmbMinutes.TabIndex = 4;
            // 
            // rdShutdownAfter
            // 
            this.rdShutdownAfter.AutoSize = true;
            this.rdShutdownAfter.Location = new System.Drawing.Point(17, 81);
            this.rdShutdownAfter.Name = "rdShutdownAfter";
            this.rdShutdownAfter.Size = new System.Drawing.Size(168, 17);
            this.rdShutdownAfter.TabIndex = 3;
            this.rdShutdownAfter.TabStop = true;
            this.rdShutdownAfter.Text = "Tắt máy sau khoảng thời gian:";
            this.rdShutdownAfter.UseVisualStyleBackColor = true;
            this.rdShutdownAfter.CheckedChanged += new System.EventHandler(this.rdShutdownAfter_CheckedChanged);
            // 
            // rdShutdownExactly
            // 
            this.rdShutdownExactly.AutoSize = true;
            this.rdShutdownExactly.Location = new System.Drawing.Point(17, 23);
            this.rdShutdownExactly.Name = "rdShutdownExactly";
            this.rdShutdownExactly.Size = new System.Drawing.Size(123, 17);
            this.rdShutdownExactly.TabIndex = 2;
            this.rdShutdownExactly.TabStop = true;
            this.rdShutdownExactly.Text = "Tắt máy tại thời điểm";
            this.rdShutdownExactly.UseVisualStyleBackColor = true;
            this.rdShutdownExactly.CheckedChanged += new System.EventHandler(this.rdShutdownExactly_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MMM-yy @h:mm tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(154, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbTimer);
            this.groupBox3.Location = new System.Drawing.Point(11, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(309, 77);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimer.Location = new System.Drawing.Point(29, 16);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(251, 45);
            this.lbTimer.TabIndex = 0;
            this.lbTimer.Text = "00:00:00:00";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Blue;
            this.btnStart.Location = new System.Drawing.Point(12, 282);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(309, 33);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Bắt đầu tính giờ";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbPlaySound);
            this.groupBox4.Controls.Add(this.cmbRemindMinutes);
            this.groupBox4.Controls.Add(this.cbRemind);
            this.groupBox4.Location = new System.Drawing.Point(12, 207);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(309, 69);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // cbPlaySound
            // 
            this.cbPlaySound.AutoSize = true;
            this.cbPlaySound.Location = new System.Drawing.Point(46, 42);
            this.cbPlaySound.Name = "cbPlaySound";
            this.cbPlaySound.Size = new System.Drawing.Size(123, 17);
            this.cbPlaySound.TabIndex = 15;
            this.cbPlaySound.Text = "Phát tiếng báo động";
            this.cbPlaySound.UseVisualStyleBackColor = true;
            // 
            // cmbRemindMinutes
            // 
            this.cmbRemindMinutes.FormattingEnabled = true;
            this.cmbRemindMinutes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60"});
            this.cmbRemindMinutes.Location = new System.Drawing.Point(188, 19);
            this.cmbRemindMinutes.Name = "cmbRemindMinutes";
            this.cmbRemindMinutes.Size = new System.Drawing.Size(100, 21);
            this.cmbRemindMinutes.TabIndex = 14;
            // 
            // cbRemind
            // 
            this.cbRemind.AutoSize = true;
            this.cbRemind.Location = new System.Drawing.Point(6, 19);
            this.cbRemind.Name = "cbRemind";
            this.cbRemind.Size = new System.Drawing.Size(185, 17);
            this.cbRemind.TabIndex = 0;
            this.cbRemind.Text = "Báo động trước khi tắt máy(Phút):";
            this.cbRemind.UseVisualStyleBackColor = true;
            this.cbRemind.CheckedChanged += new System.EventHandler(this.cbRemind_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmAutoShut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnPause;
            this.ClientSize = new System.Drawing.Size(331, 484);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAutoShut";
            this.Text = "AutoShut";
            this.Resize += new System.EventHandler(this.frmAutoShut_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShutNow;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbMinutes;
        private System.Windows.Forms.RadioButton rdShutdownAfter;
        private System.Windows.Forms.RadioButton rdShutdownExactly;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rdWeeks;
        private System.Windows.Forms.RadioButton rdDays;
        private System.Windows.Forms.RadioButton rdHours;
        private System.Windows.Forms.RadioButton rdMinutes;
        private System.Windows.Forms.ComboBox cmbWeeks;
        private System.Windows.Forms.ComboBox cmbDays;
        private System.Windows.Forms.ComboBox cmbHours;
        private System.Windows.Forms.Button btnTomorrow;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbPlaySound;
        private System.Windows.Forms.ComboBox cmbRemindMinutes;
        private System.Windows.Forms.CheckBox cbRemind;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnReset;
    }
}

