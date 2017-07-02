namespace AutoShut
{
    partial class Last_Chance_to_Cancel
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
            this.timerLast = new System.Windows.Forms.Timer(this.components);
            this.lbLastChance = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timerLast
            // 
            this.timerLast.Enabled = true;
            this.timerLast.Interval = 60000;
            this.timerLast.Tick += new System.EventHandler(this.timerLast_Tick);
            // 
            // lbLastChance
            // 
            this.lbLastChance.AutoSize = true;
            this.lbLastChance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastChance.Location = new System.Drawing.Point(12, 9);
            this.lbLastChance.Name = "lbLastChance";
            this.lbLastChance.Size = new System.Drawing.Size(312, 46);
            this.lbLastChance.TabIndex = 0;
            this.lbLastChance.Text = "Thời gian đếm ngược đã hết\r\nMáy sẽ tắt trong vòng 1 phút....";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(68, 78);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(176, 78);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel AutoShut";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Last_Chance_to_Cancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 126);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbLastChance);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Last_Chance_to_Cancel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerLast;
        private System.Windows.Forms.Label lbLastChance;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}