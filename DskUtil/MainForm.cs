/*
 * Created by SharpDevelop.
 * User: Aaron2
 * Date: 2/18/2016
 * Time: 4:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace DskUtil
{
	/// <summary>
	/// THE MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		OpenFileDialog OfDialog;
		FolderBrowserDialog FbDialog;
		Dsk disk;
		FileSelectionForm FsForm;
		string ImagePath=null;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			OfDialog=new OpenFileDialog();
			OfDialog.Multiselect=false;
			FbDialog=new FolderBrowserDialog();
			FsForm=new FileSelectionForm();
			FsForm.FileConfirmed+=new Action<FileToCopy>(FileSelected);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
	
		}
		
		
		void OpenButtonClick(object sender, EventArgs e)
		{
			
			DialogResult result=OfDialog.ShowDialog();
			if(result!=DialogResult.OK)return;
			if(!OfDialog.CheckFileExists)return;
			textBox1.Text=OfDialog.FileName;
			ImagePath=OfDialog.FileName;
			if(disk!=null){disk.Close();disk.Dispose();}
			disk=new Dsk(ImagePath);
			PopulateList();
		}
		void PopulateList(){
			listBox1.Items.Clear();
			foreach(FileEntry f in disk.Files)listBox1.Items.Add(f.ToString());
			listBox1.Update();
		}
		void CopyFromDskButtonClick(object sender, EventArgs e)
		{
			if(disk==null)return;
			DialogResult result=FbDialog.ShowDialog();
			if(result!=DialogResult.OK)return;
			string file=disk.Files[listBox1.SelectedIndex].Name;
			try{
				disk.CopyFileFromDsk(file,FbDialog.SelectedPath);
			}catch(IOException ex){
				MessageBox.Show("Copy failed "+ex.Message,"Copy Failed");
				return;
			}
			MessageBox.Show("Copy Successful","Copy Successful");
		}
		void CopyToDskButtonClick(object sender, EventArgs e)
		{
			FsForm.Clear();
			FsForm.Show();
		}
		void FileSelected(FileToCopy file){
			disk.CopyToDsk(file,false);
			PopulateList();
		}
		
	}
}
