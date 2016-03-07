﻿/*
 * Created by SharpDevelop.
 * User: Aaron2
 * Date: 2/18/2016
 * Time: 4:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DskUtil
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button OpenButton;
		private System.Windows.Forms.Button CopyFromDskButton;
		private System.Windows.Forms.Button copyToDskButton;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.OpenButton = new System.Windows.Forms.Button();
			this.CopyFromDskButton = new System.Windows.Forms.Button();
			this.copyToDskButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(258, 20);
			this.textBox1.TabIndex = 1;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 38);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(171, 394);
			this.listBox1.TabIndex = 2;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
			// 
			// OpenButton
			// 
			this.OpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.OpenButton.Location = new System.Drawing.Point(279, 9);
			this.OpenButton.Name = "OpenButton";
			this.OpenButton.Size = new System.Drawing.Size(99, 23);
			this.OpenButton.TabIndex = 3;
			this.OpenButton.Text = "Open ...";
			this.OpenButton.UseVisualStyleBackColor = true;
			this.OpenButton.Click += new System.EventHandler(this.OpenButtonClick);
			// 
			// CopyFromDskButton
			// 
			this.CopyFromDskButton.Location = new System.Drawing.Point(235, 38);
			this.CopyFromDskButton.Name = "CopyFromDskButton";
			this.CopyFromDskButton.Size = new System.Drawing.Size(118, 23);
			this.CopyFromDskButton.TabIndex = 4;
			this.CopyFromDskButton.Text = "Copy From DSK...";
			this.CopyFromDskButton.UseVisualStyleBackColor = true;
			this.CopyFromDskButton.Click += new System.EventHandler(this.CopyFromDskButtonClick);
			// 
			// copyToDskButton
			// 
			this.copyToDskButton.Location = new System.Drawing.Point(235, 68);
			this.copyToDskButton.Name = "copyToDskButton";
			this.copyToDskButton.Size = new System.Drawing.Size(118, 23);
			this.copyToDskButton.TabIndex = 5;
			this.copyToDskButton.Text = "Copy To DSK";
			this.copyToDskButton.UseVisualStyleBackColor = true;
			this.copyToDskButton.Click += new System.EventHandler(this.CopyToDskButtonClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(381, 434);
			this.Controls.Add(this.copyToDskButton);
			this.Controls.Add(this.CopyFromDskButton);
			this.Controls.Add(this.OpenButton);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.textBox1);
			this.Name = "MainForm";
			this.Text = "DskUtil";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}