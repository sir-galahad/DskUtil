/*
 * Created by SharpDevelop.
 * User: Aaron2
 * Date: 2/25/2016
 * Time: 8:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DskUtil
{
	partial class FileSelectionForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button FileSelectButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton formatAsciiText;
		private System.Windows.Forms.RadioButton formatMachineLanguage;
		private System.Windows.Forms.RadioButton formatBasicData;
		private System.Windows.Forms.RadioButton formatBasicProgram;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton typeAscii;
		private System.Windows.Forms.RadioButton typeBinary;
		private System.Windows.Forms.Button copyButton;
		private System.Windows.Forms.Button cancelButton;
		
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
			this.FileSelectButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.formatAsciiText = new System.Windows.Forms.RadioButton();
			this.formatMachineLanguage = new System.Windows.Forms.RadioButton();
			this.formatBasicData = new System.Windows.Forms.RadioButton();
			this.formatBasicProgram = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.typeAscii = new System.Windows.Forms.RadioButton();
			this.typeBinary = new System.Windows.Forms.RadioButton();
			this.copyButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(12, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(243, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select File to Copy";
			this.label1.Click += new System.EventHandler(this.Label1Click);
			// 
			// FileSelectButton
			// 
			this.FileSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.FileSelectButton.Location = new System.Drawing.Point(259, 8);
			this.FileSelectButton.Name = "FileSelectButton";
			this.FileSelectButton.Size = new System.Drawing.Size(78, 23);
			this.FileSelectButton.TabIndex = 1;
			this.FileSelectButton.Text = "Select File...";
			this.FileSelectButton.UseVisualStyleBackColor = true;
			this.FileSelectButton.Click += new System.EventHandler(this.FileSelectButtonClick);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(12, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(243, 23);
			this.label2.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.formatAsciiText);
			this.groupBox1.Controls.Add(this.formatMachineLanguage);
			this.groupBox1.Controls.Add(this.formatBasicData);
			this.groupBox1.Controls.Add(this.formatBasicProgram);
			this.groupBox1.Location = new System.Drawing.Point(12, 66);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(133, 144);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "File Format";
			// 
			// formatAsciiText
			// 
			this.formatAsciiText.Location = new System.Drawing.Point(7, 113);
			this.formatAsciiText.Name = "formatAsciiText";
			this.formatAsciiText.Size = new System.Drawing.Size(104, 24);
			this.formatAsciiText.TabIndex = 3;
			this.formatAsciiText.TabStop = true;
			this.formatAsciiText.Text = "ASCII Text";
			this.formatAsciiText.UseVisualStyleBackColor = true;
			// 
			// formatMachineLanguage
			// 
			this.formatMachineLanguage.Location = new System.Drawing.Point(7, 82);
			this.formatMachineLanguage.Name = "formatMachineLanguage";
			this.formatMachineLanguage.Size = new System.Drawing.Size(119, 24);
			this.formatMachineLanguage.TabIndex = 2;
			this.formatMachineLanguage.TabStop = true;
			this.formatMachineLanguage.Text = "Machine Language";
			this.formatMachineLanguage.UseVisualStyleBackColor = true;
			// 
			// formatBasicData
			// 
			this.formatBasicData.Location = new System.Drawing.Point(7, 51);
			this.formatBasicData.Name = "formatBasicData";
			this.formatBasicData.Size = new System.Drawing.Size(104, 24);
			this.formatBasicData.TabIndex = 1;
			this.formatBasicData.TabStop = true;
			this.formatBasicData.Text = "BASIC Data";
			this.formatBasicData.UseVisualStyleBackColor = true;
			// 
			// formatBasicProgram
			// 
			this.formatBasicProgram.Location = new System.Drawing.Point(7, 20);
			this.formatBasicProgram.Name = "formatBasicProgram";
			this.formatBasicProgram.Size = new System.Drawing.Size(104, 24);
			this.formatBasicProgram.TabIndex = 0;
			this.formatBasicProgram.TabStop = true;
			this.formatBasicProgram.Text = "BASIC Program";
			this.formatBasicProgram.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.typeAscii);
			this.groupBox2.Controls.Add(this.typeBinary);
			this.groupBox2.Location = new System.Drawing.Point(151, 66);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(73, 89);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "File Type";
			this.groupBox2.Enter += new System.EventHandler(this.GroupBox2Enter);
			// 
			// typeAscii
			// 
			this.typeAscii.Location = new System.Drawing.Point(7, 50);
			this.typeAscii.Name = "typeAscii";
			this.typeAscii.Size = new System.Drawing.Size(60, 24);
			this.typeAscii.TabIndex = 1;
			this.typeAscii.TabStop = true;
			this.typeAscii.Text = "ASCII";
			this.typeAscii.UseVisualStyleBackColor = true;
			// 
			// typeBinary
			// 
			this.typeBinary.Location = new System.Drawing.Point(7, 19);
			this.typeBinary.Name = "typeBinary";
			this.typeBinary.Size = new System.Drawing.Size(60, 24);
			this.typeBinary.TabIndex = 0;
			this.typeBinary.TabStop = true;
			this.typeBinary.Text = "Binary";
			this.typeBinary.UseVisualStyleBackColor = true;
			// 
			// copyButton
			// 
			this.copyButton.Location = new System.Drawing.Point(70, 226);
			this.copyButton.Name = "copyButton";
			this.copyButton.Size = new System.Drawing.Size(75, 23);
			this.copyButton.TabIndex = 9;
			this.copyButton.Text = "Copy";
			this.copyButton.UseVisualStyleBackColor = true;
			this.copyButton.Click += new System.EventHandler(this.CopyButtonClick);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(219, 226);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 10;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// FileSelectionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(349, 261);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.copyButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.FileSelectButton);
			this.Controls.Add(this.label1);
			this.Name = "FileSelectionForm";
			this.Text = "File Selection";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
