namespace Mang_Trojan.form
{
    partial class Record
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
            this.m_pSeparator1 = new System.Windows.Forms.GroupBox();
            this.btPlayFile = new System.Windows.Forms.Button();
            this.m_pToggleRun = new System.Windows.Forms.Button();
            this.m_pRecordFileBrowse = new System.Windows.Forms.Button();
            this.m_pRecordFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_pRecord = new System.Windows.Forms.CheckBox();
            this.m_pLocalPort = new System.Windows.Forms.NumericUpDown();
            this.m_pLoacalIP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_pCodec = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_pOutDevices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_pSeparator2 = new System.Windows.Forms.GroupBox();
            this.m_pBytesReceived = new System.Windows.Forms.Label();
            this.m_pPacketsReceived = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_pTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btStartServer = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbServerInputDevices = new System.Windows.Forms.ComboBox();
            this.m_pSeparator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pLocalPort)).BeginInit();
            this.m_pSeparator2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pSeparator1
            // 
            this.m_pSeparator1.Controls.Add(this.btPlayFile);
            this.m_pSeparator1.Controls.Add(this.m_pToggleRun);
            this.m_pSeparator1.Controls.Add(this.m_pRecordFileBrowse);
            this.m_pSeparator1.Controls.Add(this.m_pRecordFile);
            this.m_pSeparator1.Controls.Add(this.label4);
            this.m_pSeparator1.Controls.Add(this.m_pRecord);
            this.m_pSeparator1.Controls.Add(this.m_pLocalPort);
            this.m_pSeparator1.Controls.Add(this.m_pLoacalIP);
            this.m_pSeparator1.Controls.Add(this.label3);
            this.m_pSeparator1.Controls.Add(this.m_pCodec);
            this.m_pSeparator1.Controls.Add(this.label2);
            this.m_pSeparator1.Controls.Add(this.m_pOutDevices);
            this.m_pSeparator1.Controls.Add(this.label1);
            this.m_pSeparator1.Location = new System.Drawing.Point(0, -1);
            this.m_pSeparator1.Name = "m_pSeparator1";
            this.m_pSeparator1.Size = new System.Drawing.Size(434, 225);
            this.m_pSeparator1.TabIndex = 0;
            this.m_pSeparator1.TabStop = false;
            // 
            // btPlayFile
            // 
            this.btPlayFile.Location = new System.Drawing.Point(259, 176);
            this.btPlayFile.Name = "btPlayFile";
            this.btPlayFile.Size = new System.Drawing.Size(109, 32);
            this.btPlayFile.TabIndex = 24;
            this.btPlayFile.Text = "Chạy tập tin";
            this.btPlayFile.UseVisualStyleBackColor = true;
            this.btPlayFile.Click += new System.EventHandler(this.btPlayFile_Click);
            // 
            // m_pToggleRun
            // 
            this.m_pToggleRun.Location = new System.Drawing.Point(119, 176);
            this.m_pToggleRun.Name = "m_pToggleRun";
            this.m_pToggleRun.Size = new System.Drawing.Size(109, 32);
            this.m_pToggleRun.TabIndex = 23;
            this.m_pToggleRun.Text = "Bắt đầu lắng nghe";
            this.m_pToggleRun.UseVisualStyleBackColor = true;
            this.m_pToggleRun.Click += new System.EventHandler(this.m_pToggleRun_Click);
            // 
            // m_pRecordFileBrowse
            // 
            this.m_pRecordFileBrowse.Enabled = false;
            this.m_pRecordFileBrowse.Location = new System.Drawing.Point(375, 147);
            this.m_pRecordFileBrowse.Name = "m_pRecordFileBrowse";
            this.m_pRecordFileBrowse.Size = new System.Drawing.Size(34, 23);
            this.m_pRecordFileBrowse.TabIndex = 22;
            this.m_pRecordFileBrowse.Text = "...";
            this.m_pRecordFileBrowse.UseVisualStyleBackColor = true;
            this.m_pRecordFileBrowse.Click += new System.EventHandler(this.m_pRecordFileBrowse_Click);
            // 
            // m_pRecordFile
            // 
            this.m_pRecordFile.Enabled = false;
            this.m_pRecordFile.Location = new System.Drawing.Point(119, 150);
            this.m_pRecordFile.Name = "m_pRecordFile";
            this.m_pRecordFile.Size = new System.Drawing.Size(249, 20);
            this.m_pRecordFile.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tên tập tin ghi âm";
            // 
            // m_pRecord
            // 
            this.m_pRecord.AutoSize = true;
            this.m_pRecord.Location = new System.Drawing.Point(119, 120);
            this.m_pRecord.Name = "m_pRecord";
            this.m_pRecord.Size = new System.Drawing.Size(148, 17);
            this.m_pRecord.TabIndex = 19;
            this.m_pRecord.Text = "Ghi âm dữ liệu nhận được";
            this.m_pRecord.UseVisualStyleBackColor = true;
            this.m_pRecord.CheckedChanged += new System.EventHandler(this.m_pRecord_CheckedChanged);
            // 
            // m_pLocalPort
            // 
            this.m_pLocalPort.Location = new System.Drawing.Point(329, 84);
            this.m_pLocalPort.Name = "m_pLocalPort";
            this.m_pLocalPort.Size = new System.Drawing.Size(80, 20);
            this.m_pLocalPort.TabIndex = 18;
            // 
            // m_pLoacalIP
            // 
            this.m_pLoacalIP.FormattingEnabled = true;
            this.m_pLoacalIP.Location = new System.Drawing.Point(119, 84);
            this.m_pLoacalIP.Name = "m_pLoacalIP";
            this.m_pLoacalIP.Size = new System.Drawing.Size(195, 21);
            this.m_pLoacalIP.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Địa chỉ IP : Cổng";
            // 
            // m_pCodec
            // 
            this.m_pCodec.FormattingEnabled = true;
            this.m_pCodec.Location = new System.Drawing.Point(119, 52);
            this.m_pCodec.Name = "m_pCodec";
            this.m_pCodec.Size = new System.Drawing.Size(132, 21);
            this.m_pCodec.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Codec:";
            // 
            // m_pOutDevices
            // 
            this.m_pOutDevices.FormattingEnabled = true;
            this.m_pOutDevices.Location = new System.Drawing.Point(119, 19);
            this.m_pOutDevices.Name = "m_pOutDevices";
            this.m_pOutDevices.Size = new System.Drawing.Size(290, 21);
            this.m_pOutDevices.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Thiết bị đầu ra:";
            // 
            // m_pSeparator2
            // 
            this.m_pSeparator2.Controls.Add(this.m_pBytesReceived);
            this.m_pSeparator2.Controls.Add(this.m_pPacketsReceived);
            this.m_pSeparator2.Controls.Add(this.label6);
            this.m_pSeparator2.Controls.Add(this.label5);
            this.m_pSeparator2.Location = new System.Drawing.Point(440, -1);
            this.m_pSeparator2.Name = "m_pSeparator2";
            this.m_pSeparator2.Size = new System.Drawing.Size(245, 90);
            this.m_pSeparator2.TabIndex = 1;
            this.m_pSeparator2.TabStop = false;
            // 
            // m_pBytesReceived
            // 
            this.m_pBytesReceived.AutoSize = true;
            this.m_pBytesReceived.Location = new System.Drawing.Point(144, 54);
            this.m_pBytesReceived.Name = "m_pBytesReceived";
            this.m_pBytesReceived.Size = new System.Drawing.Size(13, 13);
            this.m_pBytesReceived.TabIndex = 3;
            this.m_pBytesReceived.Text = "0";
            // 
            // m_pPacketsReceived
            // 
            this.m_pPacketsReceived.AutoSize = true;
            this.m_pPacketsReceived.Location = new System.Drawing.Point(144, 18);
            this.m_pPacketsReceived.Name = "m_pPacketsReceived";
            this.m_pPacketsReceived.Size = new System.Drawing.Size(13, 13);
            this.m_pPacketsReceived.TabIndex = 2;
            this.m_pPacketsReceived.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Dữ liệu nhận(Bytes):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Gói tin nhận:";
            // 
            // m_pTimer
            // 
            this.m_pTimer.Interval = 1000;
            this.m_pTimer.Tick += new System.EventHandler(this.m_pTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btStartServer);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbServerInputDevices);
            this.groupBox1.Location = new System.Drawing.Point(0, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 73);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin về máy chủ";
            // 
            // btStartServer
            // 
            this.btStartServer.Location = new System.Drawing.Point(340, 23);
            this.btStartServer.Name = "btStartServer";
            this.btStartServer.Size = new System.Drawing.Size(60, 28);
            this.btStartServer.TabIndex = 24;
            this.btStartServer.Text = "Bắt đầu";
            this.btStartServer.UseVisualStyleBackColor = true;
            this.btStartServer.Click += new System.EventHandler(this.btStartServer_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Thiết bị đầu vào máy chủ";
            // 
            // cbServerInputDevices
            // 
            this.cbServerInputDevices.FormattingEnabled = true;
            this.cbServerInputDevices.Location = new System.Drawing.Point(139, 30);
            this.cbServerInputDevices.Name = "cbServerInputDevices";
            this.cbServerInputDevices.Size = new System.Drawing.Size(195, 21);
            this.cbServerInputDevices.TabIndex = 0;
            // 
            // Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 302);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_pSeparator2);
            this.Controls.Add(this.m_pSeparator1);
            this.Name = "Record";
            this.Text = "Record";
            this.Load += new System.EventHandler(this.Record_Load);
            this.m_pSeparator1.ResumeLayout(false);
            this.m_pSeparator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pLocalPort)).EndInit();
            this.m_pSeparator2.ResumeLayout(false);
            this.m_pSeparator2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_pSeparator1;
        private System.Windows.Forms.Button m_pToggleRun;
        private System.Windows.Forms.Button m_pRecordFileBrowse;
        private System.Windows.Forms.TextBox m_pRecordFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_pRecord;
        private System.Windows.Forms.NumericUpDown m_pLocalPort;
        private System.Windows.Forms.ComboBox m_pLoacalIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox m_pCodec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_pOutDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox m_pSeparator2;
        private System.Windows.Forms.Label m_pBytesReceived;
        private System.Windows.Forms.Label m_pPacketsReceived;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer m_pTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btStartServer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbServerInputDevices;
        private System.Windows.Forms.Button btPlayFile;
    }
}