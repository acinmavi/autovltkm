namespace Mang_Trojan.form
{
    partial class RemoteDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteDesktop));
            this.chkMouse = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkKeyboard = new System.Windows.Forms.CheckBox();
            this.picCast = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbRefreshRate = new System.Windows.Forms.TrackBar();
            this.lblRefreshRate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCompression = new System.Windows.Forms.ComboBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTopMenu = new System.Windows.Forms.Panel();
            this.cbRealMouse = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pbarProgress = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.castTimer = new System.Windows.Forms.Timer(this.components);
            this.bgWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCast)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRefreshRate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlTopMenu.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkMouse
            // 
            this.chkMouse.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMouse.ImageIndex = 2;
            this.chkMouse.ImageList = this.imageList1;
            this.chkMouse.Location = new System.Drawing.Point(4, 13);
            this.chkMouse.Name = "chkMouse";
            this.chkMouse.Size = new System.Drawing.Size(32, 32);
            this.chkMouse.TabIndex = 9;
            this.toolTip1.SetToolTip(this.chkMouse, "Enable / Disable Mouse Control");
            this.chkMouse.UseVisualStyleBackColor = true;
            this.chkMouse.CheckedChanged += new System.EventHandler(this.chkMouse_CheckedChanged);
            this.chkMouse.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.interface_PreviewKeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "media_play_green.ico");
            this.imageList1.Images.SetKeyName(1, "media_stop_red.ico");
            this.imageList1.Images.SetKeyName(2, "mouse.ico");
            this.imageList1.Images.SetKeyName(3, "keyboard_key.ico");
            this.imageList1.Images.SetKeyName(4, "brush4.ico");
            this.imageList1.Images.SetKeyName(5, "about.ico");
            this.imageList1.Images.SetKeyName(6, "clipboard.ico");
            this.imageList1.Images.SetKeyName(7, "clipboard_next.ico");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkMouse);
            this.groupBox3.Controls.Add(this.chkKeyboard);
            this.groupBox3.Location = new System.Drawing.Point(311, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(73, 49);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Điều khiển";
            // 
            // chkKeyboard
            // 
            this.chkKeyboard.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkKeyboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkKeyboard.ImageIndex = 3;
            this.chkKeyboard.ImageList = this.imageList1;
            this.chkKeyboard.Location = new System.Drawing.Point(36, 13);
            this.chkKeyboard.Name = "chkKeyboard";
            this.chkKeyboard.Size = new System.Drawing.Size(32, 32);
            this.chkKeyboard.TabIndex = 10;
            this.toolTip1.SetToolTip(this.chkKeyboard, "Enable / Disable Keyboard Control");
            this.chkKeyboard.UseVisualStyleBackColor = true;
            this.chkKeyboard.CheckedChanged += new System.EventHandler(this.chkKeyboard_CheckedChanged);
            this.chkKeyboard.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.interface_PreviewKeyDown);
            // 
            // picCast
            // 
            this.picCast.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picCast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picCast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCast.Location = new System.Drawing.Point(0, 55);
            this.picCast.Name = "picCast";
            this.picCast.Size = new System.Drawing.Size(765, 432);
            this.picCast.TabIndex = 4;
            this.picCast.TabStop = false;
            this.picCast.Click += new System.EventHandler(this.picCast_Click);
            this.picCast.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCast_MouseDown);
            this.picCast.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCast_MouseMove);
            this.picCast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCast_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.titleLabel);
            this.groupBox2.Location = new System.Drawing.Point(3, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 49);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server";
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.ImageIndex = 0;
            this.btnConnect.ImageList = this.imageList1;
            this.btnConnect.Location = new System.Drawing.Point(101, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(93, 30);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            this.btnConnect.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.interface_PreviewKeyDown);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(-1, 23);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(104, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Điều khiển màn hình";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbRefreshRate);
            this.groupBox5.Controls.Add(this.lblRefreshRate);
            this.groupBox5.Location = new System.Drawing.Point(390, 1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(216, 50);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Refresh Rate";
            // 
            // tbRefreshRate
            // 
            this.tbRefreshRate.AutoSize = false;
            this.tbRefreshRate.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbRefreshRate.Location = new System.Drawing.Point(6, 15);
            this.tbRefreshRate.Maximum = 10000;
            this.tbRefreshRate.Minimum = 1;
            this.tbRefreshRate.Name = "tbRefreshRate";
            this.tbRefreshRate.Size = new System.Drawing.Size(160, 32);
            this.tbRefreshRate.SmallChange = 10;
            this.tbRefreshRate.TabIndex = 5;
            this.tbRefreshRate.TickFrequency = 1000;
            this.tbRefreshRate.Value = 1;
            this.tbRefreshRate.Scroll += new System.EventHandler(this.tbRefreshRate_Scroll);
            this.tbRefreshRate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.interface_PreviewKeyDown);
            // 
            // lblRefreshRate
            // 
            this.lblRefreshRate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRefreshRate.Location = new System.Drawing.Point(166, 15);
            this.lblRefreshRate.Name = "lblRefreshRate";
            this.lblRefreshRate.Size = new System.Drawing.Size(47, 32);
            this.lblRefreshRate.TabIndex = 6;
            this.lblRefreshRate.Text = "1 ms";
            this.lblRefreshRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRefreshRate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.interface_PreviewKeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCompression);
            this.groupBox1.Location = new System.Drawing.Point(206, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 49);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nén dữ liệu";
            // 
            // cmbCompression
            // 
            this.cmbCompression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCompression.FormattingEnabled = true;
            this.cmbCompression.Items.AddRange(new object[] {
            "BMP",
            "GIF",
            "PNG",
            "JPEG"});
            this.cmbCompression.Location = new System.Drawing.Point(3, 15);
            this.cmbCompression.Name = "cmbCompression";
            this.cmbCompression.Size = new System.Drawing.Size(97, 21);
            this.cmbCompression.TabIndex = 8;
            this.cmbCompression.SelectedIndexChanged += new System.EventHandler(this.cmbCompression_SelectedIndexChanged);
            this.cmbCompression.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.interface_PreviewKeyDown);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInput.Location = new System.Drawing.Point(237, 0);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(13, 13);
            this.lblInput.TabIndex = 3;
            this.lblInput.Text = "..";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "control_panel.ico");
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlTopMenu.Controls.Add(this.cbRealMouse);
            this.pnlTopMenu.Controls.Add(this.groupBox5);
            this.pnlTopMenu.Controls.Add(this.groupBox3);
            this.pnlTopMenu.Controls.Add(this.groupBox2);
            this.pnlTopMenu.Controls.Add(this.groupBox1);
            this.pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Size = new System.Drawing.Size(765, 55);
            this.pnlTopMenu.TabIndex = 3;
            // 
            // cbRealMouse
            // 
            this.cbRealMouse.AutoSize = true;
            this.cbRealMouse.Location = new System.Drawing.Point(624, 18);
            this.cbRealMouse.Name = "cbRealMouse";
            this.cbRealMouse.Size = new System.Drawing.Size(83, 17);
            this.cbRealMouse.TabIndex = 20;
            this.cbRealMouse.Text = "Real Mouse";
            this.cbRealMouse.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMessage.Location = new System.Drawing.Point(224, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(13, 13);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "..";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblInput);
            this.pnlBottom.Controls.Add(this.lblMessage);
            this.pnlBottom.Controls.Add(this.pbarProgress);
            this.pnlBottom.Controls.Add(this.label3);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 487);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(765, 18);
            this.pnlBottom.TabIndex = 5;
            this.pnlBottom.Visible = false;
            // 
            // pbarProgress
            // 
            this.pbarProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbarProgress.Location = new System.Drawing.Point(85, 0);
            this.pbarProgress.Name = "pbarProgress";
            this.pbarProgress.Size = new System.Drawing.Size(139, 18);
            this.pbarProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbarProgress.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dữ liệu nhận về:";
            // 
            // castTimer
            // 
            this.castTimer.Interval = 1;
            this.castTimer.Tick += new System.EventHandler(this.castTimer_Tick);
            // 
            // bgWorker1
            // 
            this.bgWorker1.WorkerReportsProgress = true;
            this.bgWorker1.WorkerSupportsCancellation = true;
            this.bgWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker1_DoWork);
            // 
            // RemoteDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 505);
            this.Controls.Add(this.picCast);
            this.Controls.Add(this.pnlTopMenu);
            this.Controls.Add(this.pnlBottom);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RemoteDesktop";
            this.Text = "RemoteDesktop";
            this.Load += new System.EventHandler(this.RemoteDesktop_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.picCast_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.picCast_KeyUp);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCast)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbRefreshRate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.pnlTopMenu.ResumeLayout(false);
            this.pnlTopMenu.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMouse;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkKeyboard;
        private System.Windows.Forms.PictureBox picCast;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TrackBar tbRefreshRate;
        private System.Windows.Forms.Label lblRefreshRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCompression;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.ProgressBar pbarProgress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer castTimer;
        private System.ComponentModel.BackgroundWorker bgWorker1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox cbRealMouse;

    }
}