namespace Mang_Trojan.form
{
    partial class Fun
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
            this.btRestoreControl = new System.Windows.Forms.Button();
            this.btBlockControl = new System.Windows.Forms.Button();
            this.btRestoreMouse = new System.Windows.Forms.Button();
            this.btReverseMouse = new System.Windows.Forms.Button();
            this.btCloseCD = new System.Windows.Forms.Button();
            this.btOpenCd = new System.Windows.Forms.Button();
            this.btEnableMng = new System.Windows.Forms.Button();
            this.btDisableTaskMng = new System.Windows.Forms.Button();
            this.btnRestartComp = new System.Windows.Forms.Button();
            this.btnShutdonwComp = new System.Windows.Forms.Button();
            this.btnShowTaskBar = new System.Windows.Forms.Button();
            this.btnHideTaskBar = new System.Windows.Forms.Button();
            this.btnLogOff = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btHideIcon = new System.Windows.Forms.Button();
            this.btResumeIcon = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRestoreControl
            // 
            this.btRestoreControl.Location = new System.Drawing.Point(148, 171);
            this.btRestoreControl.Name = "btRestoreControl";
            this.btRestoreControl.Size = new System.Drawing.Size(132, 32);
            this.btRestoreControl.TabIndex = 30;
            this.btRestoreControl.Text = "Điều khiển bình thường";
            this.btRestoreControl.UseVisualStyleBackColor = true;
            this.btRestoreControl.Click += new System.EventHandler(this.btRestoreControl_Click);
            // 
            // btBlockControl
            // 
            this.btBlockControl.Location = new System.Drawing.Point(5, 171);
            this.btBlockControl.Name = "btBlockControl";
            this.btBlockControl.Size = new System.Drawing.Size(132, 32);
            this.btBlockControl.TabIndex = 29;
            this.btBlockControl.Text = "Khóa điều khiển";
            this.btBlockControl.UseVisualStyleBackColor = true;
            this.btBlockControl.Click += new System.EventHandler(this.btBlockControl_Click);
            // 
            // btRestoreMouse
            // 
            this.btRestoreMouse.Location = new System.Drawing.Point(148, 132);
            this.btRestoreMouse.Name = "btRestoreMouse";
            this.btRestoreMouse.Size = new System.Drawing.Size(132, 32);
            this.btRestoreMouse.TabIndex = 28;
            this.btRestoreMouse.Text = "Chuột bình thường";
            this.btRestoreMouse.UseVisualStyleBackColor = true;
            this.btRestoreMouse.Click += new System.EventHandler(this.btRestoreMouse_Click);
            // 
            // btReverseMouse
            // 
            this.btReverseMouse.Location = new System.Drawing.Point(5, 132);
            this.btReverseMouse.Name = "btReverseMouse";
            this.btReverseMouse.Size = new System.Drawing.Size(132, 32);
            this.btReverseMouse.TabIndex = 27;
            this.btReverseMouse.Text = "Đảo chuột";
            this.btReverseMouse.UseVisualStyleBackColor = true;
            this.btReverseMouse.Click += new System.EventHandler(this.btReverseMouse_Click);
            // 
            // btCloseCD
            // 
            this.btCloseCD.Location = new System.Drawing.Point(148, 94);
            this.btCloseCD.Name = "btCloseCD";
            this.btCloseCD.Size = new System.Drawing.Size(132, 32);
            this.btCloseCD.TabIndex = 26;
            this.btCloseCD.Text = "Đóng ổ đĩa";
            this.btCloseCD.UseVisualStyleBackColor = true;
            this.btCloseCD.Click += new System.EventHandler(this.btCloseCD_Click);
            // 
            // btOpenCd
            // 
            this.btOpenCd.Location = new System.Drawing.Point(5, 94);
            this.btOpenCd.Name = "btOpenCd";
            this.btOpenCd.Size = new System.Drawing.Size(132, 32);
            this.btOpenCd.TabIndex = 25;
            this.btOpenCd.Text = "Mở ổ đĩa CDROM";
            this.btOpenCd.UseVisualStyleBackColor = true;
            this.btOpenCd.Click += new System.EventHandler(this.btOpenCd_Click);
            // 
            // btEnableMng
            // 
            this.btEnableMng.Location = new System.Drawing.Point(148, 56);
            this.btEnableMng.Name = "btEnableMng";
            this.btEnableMng.Size = new System.Drawing.Size(132, 32);
            this.btEnableMng.TabIndex = 24;
            this.btEnableMng.Text = "Cho phép TaskManager";
            this.btEnableMng.UseVisualStyleBackColor = true;
            this.btEnableMng.Click += new System.EventHandler(this.btEnableMng_Click);
            // 
            // btDisableTaskMng
            // 
            this.btDisableTaskMng.Location = new System.Drawing.Point(5, 56);
            this.btDisableTaskMng.Name = "btDisableTaskMng";
            this.btDisableTaskMng.Size = new System.Drawing.Size(132, 32);
            this.btDisableTaskMng.TabIndex = 23;
            this.btDisableTaskMng.Text = "Vô hiệu TaskManager";
            this.btDisableTaskMng.UseVisualStyleBackColor = true;
            this.btDisableTaskMng.Click += new System.EventHandler(this.btDisableTaskMng_Click);
            // 
            // btnRestartComp
            // 
            this.btnRestartComp.Location = new System.Drawing.Point(10, 56);
            this.btnRestartComp.Name = "btnRestartComp";
            this.btnRestartComp.Size = new System.Drawing.Size(147, 32);
            this.btnRestartComp.TabIndex = 19;
            this.btnRestartComp.Text = "Khởi động lại máy tính(*)";
            this.btnRestartComp.UseVisualStyleBackColor = true;
            this.btnRestartComp.Click += new System.EventHandler(this.btnRestartComp_Click);
            // 
            // btnShutdonwComp
            // 
            this.btnShutdonwComp.Location = new System.Drawing.Point(10, 18);
            this.btnShutdonwComp.Name = "btnShutdonwComp";
            this.btnShutdonwComp.Size = new System.Drawing.Size(147, 32);
            this.btnShutdonwComp.TabIndex = 18;
            this.btnShutdonwComp.Text = "Tắt máy tính(*)";
            this.btnShutdonwComp.UseVisualStyleBackColor = true;
            this.btnShutdonwComp.Click += new System.EventHandler(this.btnShutdonwComp_Click);
            // 
            // btnShowTaskBar
            // 
            this.btnShowTaskBar.Location = new System.Drawing.Point(148, 18);
            this.btnShowTaskBar.Name = "btnShowTaskBar";
            this.btnShowTaskBar.Size = new System.Drawing.Size(132, 32);
            this.btnShowTaskBar.TabIndex = 17;
            this.btnShowTaskBar.Text = "Hiện Taskbar";
            this.btnShowTaskBar.UseVisualStyleBackColor = true;
            this.btnShowTaskBar.Click += new System.EventHandler(this.btnShowTaskBar_Click);
            // 
            // btnHideTaskBar
            // 
            this.btnHideTaskBar.Location = new System.Drawing.Point(5, 18);
            this.btnHideTaskBar.Name = "btnHideTaskBar";
            this.btnHideTaskBar.Size = new System.Drawing.Size(132, 32);
            this.btnHideTaskBar.TabIndex = 16;
            this.btnHideTaskBar.Text = "Ẩn Taskbar";
            this.btnHideTaskBar.UseVisualStyleBackColor = true;
            this.btnHideTaskBar.Click += new System.EventHandler(this.btnHideTaskBar_Click);
            // 
            // btnLogOff
            // 
            this.btnLogOff.Location = new System.Drawing.Point(10, 93);
            this.btnLogOff.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.Size = new System.Drawing.Size(147, 32);
            this.btnLogOff.TabIndex = 31;
            this.btnLogOff.Text = "Thoát người dùng";
            this.btnLogOff.UseVisualStyleBackColor = true;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btResumeIcon);
            this.groupBox1.Controls.Add(this.btHideIcon);
            this.groupBox1.Controls.Add(this.btnHideTaskBar);
            this.groupBox1.Controls.Add(this.btDisableTaskMng);
            this.groupBox1.Controls.Add(this.btRestoreControl);
            this.groupBox1.Controls.Add(this.btOpenCd);
            this.groupBox1.Controls.Add(this.btBlockControl);
            this.groupBox1.Controls.Add(this.btnShowTaskBar);
            this.groupBox1.Controls.Add(this.btRestoreMouse);
            this.groupBox1.Controls.Add(this.btEnableMng);
            this.groupBox1.Controls.Add(this.btReverseMouse);
            this.groupBox1.Controls.Add(this.btCloseCD);
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(296, 311);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnShutdonwComp);
            this.groupBox2.Controls.Add(this.btnRestartComp);
            this.groupBox2.Controls.Add(this.btnLogOff);
            this.groupBox2.Location = new System.Drawing.Point(334, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(170, 139);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 182);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 34;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btHideIcon
            // 
            this.btHideIcon.Location = new System.Drawing.Point(5, 222);
            this.btHideIcon.Name = "btHideIcon";
            this.btHideIcon.Size = new System.Drawing.Size(132, 32);
            this.btHideIcon.TabIndex = 31;
            this.btHideIcon.Text = "Ẩn biểu tượng";
            this.btHideIcon.UseVisualStyleBackColor = true;
            this.btHideIcon.Click += new System.EventHandler(this.btHideIcon_Click);
            // 
            // btResumeIcon
            // 
            this.btResumeIcon.Location = new System.Drawing.Point(148, 222);
            this.btResumeIcon.Name = "btResumeIcon";
            this.btResumeIcon.Size = new System.Drawing.Size(132, 32);
            this.btResumeIcon.TabIndex = 32;
            this.btResumeIcon.Text = "Như cũ";
            this.btResumeIcon.UseVisualStyleBackColor = true;
            this.btResumeIcon.Click += new System.EventHandler(this.btResumeIcon_Click);
            // 
            // Fun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(580, 333);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Fun";
            this.Text = "Fun";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRestoreControl;
        private System.Windows.Forms.Button btBlockControl;
        private System.Windows.Forms.Button btRestoreMouse;
        private System.Windows.Forms.Button btReverseMouse;
        private System.Windows.Forms.Button btCloseCD;
        private System.Windows.Forms.Button btOpenCd;
        private System.Windows.Forms.Button btEnableMng;
        private System.Windows.Forms.Button btDisableTaskMng;
        private System.Windows.Forms.Button btnRestartComp;
        private System.Windows.Forms.Button btnShutdonwComp;
        private System.Windows.Forms.Button btnShowTaskBar;
        private System.Windows.Forms.Button btnHideTaskBar;
        private System.Windows.Forms.Button btnLogOff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btResumeIcon;
        private System.Windows.Forms.Button btHideIcon;
    }
}