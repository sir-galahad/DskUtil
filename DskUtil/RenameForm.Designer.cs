/*
 * Created by SharpDevelop.
 * User: Aaron2
 * Date: 3/10/2016
 * Time: 10:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DskUtil
{
	partial class RenameForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button HideButton;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.OkButton = new System.Windows.Forms.Button();
			this.HideButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(12, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(301, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter new name for file.";
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(12, 86);
			this.NameBox.MaxLength = 12;
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(120, 20);
			this.NameBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(13, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(300, 48);
			this.label2.TabIndex = 2;
			this.label2.Text = "Names must  contain  no more than 8 characters and extension must have no more th" +
	"an 3 names cannot contain : and may only contain . or / to seperate the name fro" +
	"m the extension.";
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkButton.Location = new System.Drawing.Point(13, 168);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(150, 23);
			this.OkButton.TabIndex = 3;
			this.OkButton.Text = "Ok";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// CancelButton
			// 
			this.HideButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.HideButton.Location = new System.Drawing.Point(178, 168);
			this.HideButton.Name = "CancelButton";
			this.HideButton.Size = new System.Drawing.Size(135, 23);
			this.HideButton.TabIndex = 4;
			this.HideButton.Text = "Cancel";
			this.HideButton.UseVisualStyleBackColor = true;
			this.HideButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// RenameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(325, 203);
			this.Controls.Add(this.HideButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.label1);
			this.Name = "RenameForm";
			this.Text = "RenameForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
