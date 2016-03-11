/*
 * Created by SharpDevelop.
 * User: Aaron2
 * Date: 2/25/2016
 * Time: 8:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace DskUtil
{
	/// <summary>
	/// used for selecting a file to copy to a .dsk image
	/// </summary>
	public partial class FileSelectionForm : Form
	{
		FileDialog FdDialog;
		RadioButton[] FormatButtons;
		FileToCopy copy=null;
		public event Action<FileToCopy> FileConfirmed;
	
		public FileSelectionForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			FdDialog=new OpenFileDialog();
			this.FormClosing+=(A,O)=>{((FormClosingEventArgs)O).Cancel=true;Hide();};
			FormatButtons=new RadioButton[4];
			FormatButtons[0]=formatBasicProgram;
			FormatButtons[1]=formatBasicData;
			FormatButtons[2]=formatMachineLanguage;
			FormatButtons[3]=formatAsciiText;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		
		void FileSelectButtonClick(object sender, EventArgs e)
		{
			DialogResult result=FdDialog.ShowDialog();
			if(result!=DialogResult.OK)return;
			string file=FdDialog.FileName;
			string dskFilename=Dsk.MakeValidFilename(Path.GetFileName(file));
			label1.Text=file;
			label2.Text=dskFilename;
		}
		
		public void Clear()
		{
			label1.Text="Select a file to copy";
			label2.Text="";
			foreach(RadioButton r in FormatButtons)r.Checked=false;
			typeBinary.Checked=false;
			typeAscii.Checked=false;
			copy=null;
		}
		
		void CancelButtonClick(object sender, EventArgs e)
		{
			this.Hide();
		}
		
		void CopyButtonClick(object sender, EventArgs e)
		{
			string sourceFile=label1.Text;
			string destFile=label2.Text;
			if(destFile=="")
			{
				MessageBox.Show("Not all options selected","Can not copy");
				return;
			}
			int fileFormat=5;
			for(int x=0;x<4;x++)
			{
				if(FormatButtons[x].Checked)
				{
					fileFormat=x+1;
					break;
				}
			}
			if(fileFormat==5||((typeAscii.Checked==false)&&(typeBinary.Checked==false)))
			{
				MessageBox.Show("Not all options selected","Can not copy");
				return;
			}
			copy=new FileToCopy(sourceFile,destFile,(FileFormat)fileFormat,typeAscii.Checked);
			this.Hide();
			if(FileConfirmed!=null)FileConfirmed(copy);
		}

	}
}
