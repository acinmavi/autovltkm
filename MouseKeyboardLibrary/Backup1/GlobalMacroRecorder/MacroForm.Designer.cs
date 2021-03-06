﻿namespace GlobalMacroRecorder
{
    partial class MacroForm
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
        	this.recordStartButton = new System.Windows.Forms.Button();
        	this.recordStopButton = new System.Windows.Forms.Button();
        	this.playBackMacroButton = new System.Windows.Forms.Button();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.button1 = new System.Windows.Forms.Button();
        	this.txtLoop = new System.Windows.Forms.TextBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.button2 = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// recordStartButton
        	// 
        	this.recordStartButton.Location = new System.Drawing.Point(153, 28);
        	this.recordStartButton.Name = "recordStartButton";
        	this.recordStartButton.Size = new System.Drawing.Size(75, 23);
        	this.recordStartButton.TabIndex = 0;
        	this.recordStartButton.Text = "Start";
        	this.recordStartButton.UseVisualStyleBackColor = true;
        	this.recordStartButton.Click += new System.EventHandler(this.recordStartButton_Click);
        	// 
        	// recordStopButton
        	// 
        	this.recordStopButton.Location = new System.Drawing.Point(234, 28);
        	this.recordStopButton.Name = "recordStopButton";
        	this.recordStopButton.Size = new System.Drawing.Size(75, 23);
        	this.recordStopButton.TabIndex = 0;
        	this.recordStopButton.Text = "Stop";
        	this.recordStopButton.UseVisualStyleBackColor = true;
        	this.recordStopButton.Click += new System.EventHandler(this.recordStopButton_Click);
        	// 
        	// playBackMacroButton
        	// 
        	this.playBackMacroButton.Location = new System.Drawing.Point(153, 70);
        	this.playBackMacroButton.Name = "playBackMacroButton";
        	this.playBackMacroButton.Size = new System.Drawing.Size(156, 23);
        	this.playBackMacroButton.TabIndex = 1;
        	this.playBackMacroButton.Text = "Play Back";
        	this.playBackMacroButton.UseVisualStyleBackColor = true;
        	this.playBackMacroButton.Click += new System.EventHandler(this.playBackMacroButton_Click);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(39, 33);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(75, 13);
        	this.label1.TabIndex = 2;
        	this.label1.Text = "Record Macro";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(39, 75);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(84, 13);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "Playback Macro";
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(209, 102);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(100, 23);
        	this.button1.TabIndex = 3;
        	this.button1.Text = "Read From File";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// txtLoop
        	// 
        	this.txtLoop.Location = new System.Drawing.Point(87, 105);
        	this.txtLoop.Name = "txtLoop";
        	this.txtLoop.Size = new System.Drawing.Size(100, 20);
        	this.txtLoop.TabIndex = 4;
        	this.txtLoop.Text = "10";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(39, 108);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(31, 13);
        	this.label3.TabIndex = 5;
        	this.label3.Text = "Loop";
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(209, 135);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(100, 23);
        	this.button2.TabIndex = 6;
        	this.button2.Text = "Cancel";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.Button2Click);
        	// 
        	// MacroForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(338, 170);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.txtLoop);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.playBackMacroButton);
        	this.Controls.Add(this.recordStopButton);
        	this.Controls.Add(this.recordStartButton);
        	this.Name = "MacroForm";
        	this.Text = "Global Macro Recorder Example";
        	this.Load += new System.EventHandler(this.MacroForm_Load);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Button button2;

        #endregion

        private System.Windows.Forms.Button recordStartButton;
        private System.Windows.Forms.Button recordStopButton;
        private System.Windows.Forms.Button playBackMacroButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLoop;
        private System.Windows.Forms.Label label3;
    }
}

