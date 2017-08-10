using NetPing.Common;
using NetPing.AddIns;
using System.Windows.Forms;
namespace NetPing
{
	partial class MainForm
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
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.startAddress1TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.endAddressTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.startAddress2TextBox = new System.Windows.Forms.TextBox();
            this.startAddress3TextBox = new System.Windows.Forms.TextBox();
            this.startAddress4TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.endAddressLabel = new System.Windows.Forms.Label();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(12, 41);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(789, 302);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Address";
            this.columnHeader1.Width = 191;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Response Time";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 90;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // ConnectToolStripMenuItem
            // 
            this.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem";
            this.ConnectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ConnectToolStripMenuItem.Text = "Connect";
            this.ConnectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start address:";
            // 
            // startAddress1TextBox
            // 
            this.startAddress1TextBox.Location = new System.Drawing.Point(94, 14);
            this.startAddress1TextBox.MaxLength = 3;
            this.startAddress1TextBox.Name = "startAddress1TextBox";
            this.startAddress1TextBox.Size = new System.Drawing.Size(24, 21);
            this.startAddress1TextBox.TabIndex = 0;
            this.startAddress1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End address:";
            // 
            // endAddressTextBox
            // 
            this.endAddressTextBox.Location = new System.Drawing.Point(376, 14);
            this.endAddressTextBox.MaxLength = 3;
            this.endAddressTextBox.Name = "endAddressTextBox";
            this.endAddressTextBox.Size = new System.Drawing.Size(24, 21);
            this.endAddressTextBox.TabIndex = 4;
            this.endAddressTextBox.Text = "255";
            this.endAddressTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(726, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // startAddress2TextBox
            // 
            this.startAddress2TextBox.Location = new System.Drawing.Point(124, 14);
            this.startAddress2TextBox.MaxLength = 3;
            this.startAddress2TextBox.Name = "startAddress2TextBox";
            this.startAddress2TextBox.Size = new System.Drawing.Size(24, 21);
            this.startAddress2TextBox.TabIndex = 1;
            this.startAddress2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startAddress3TextBox
            // 
            this.startAddress3TextBox.Location = new System.Drawing.Point(154, 14);
            this.startAddress3TextBox.MaxLength = 3;
            this.startAddress3TextBox.Name = "startAddress3TextBox";
            this.startAddress3TextBox.Size = new System.Drawing.Size(24, 21);
            this.startAddress3TextBox.TabIndex = 2;
            this.startAddress3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startAddress4TextBox
            // 
            this.startAddress4TextBox.Location = new System.Drawing.Point(184, 14);
            this.startAddress4TextBox.MaxLength = 3;
            this.startAddress4TextBox.Name = "startAddress4TextBox";
            this.startAddress4TextBox.Size = new System.Drawing.Size(24, 21);
            this.startAddress4TextBox.TabIndex = 3;
            this.startAddress4TextBox.Text = "1";
            this.startAddress4TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = ".";
            // 
            // endAddressLabel
            // 
            this.endAddressLabel.Location = new System.Drawing.Point(308, 17);
            this.endAddressLabel.Name = "endAddressLabel";
            this.endAddressLabel.Size = new System.Drawing.Size(70, 23);
            this.endAddressLabel.TabIndex = 12;
            this.endAddressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 355);
            this.Controls.Add(this.endAddressLabel);
            this.Controls.Add(this.startAddress4TextBox);
            this.Controls.Add(this.startAddress3TextBox);
            this.Controls.Add(this.startAddress2TextBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endAddressTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startAddress1TextBox);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "NetPing";
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox startAddress1TextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox endAddressTextBox;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TextBox startAddress2TextBox;
		private System.Windows.Forms.TextBox startAddress3TextBox;
		private System.Windows.Forms.TextBox startAddress4TextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label endAddressLabel;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ConnectToolStripMenuItem;

	}
}

