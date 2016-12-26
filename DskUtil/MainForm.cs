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
		SaveFileDialog SfDialog;
		FolderBrowserDialog FbDialog;
		RenameForm RenameDialog;
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
			OfDialog.DefaultExt="dsk";
			OfDialog.Filter="Disk images (*.dsk)|*.dsk|All files(*.*)|*.*";
			SfDialog=new SaveFileDialog();
			SfDialog.AddExtension=true;
			SfDialog.DefaultExt=".dsk";
			SfDialog.OverwritePrompt=true;
			SfDialog.Filter="Disk image (*.dsk)|*.dsk";
			FbDialog=new FolderBrowserDialog();
			FsForm=new FileSelectionForm();
			FsForm.FileConfirmed+=new Action<FileToCopy>(FileSelected);
			RenameDialog=new RenameForm();
			RenameDialog.NameConfirmed+=new Action<string,string>(Rename);
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
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
		
		void PopulateList()
		{
			listBox1.Items.Clear();
			if(!disk.IsOpen){return;}
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
		
		void FileSelected(FileToCopy file)
		{
			try{
				disk.CopyToDsk(file,false);
				PopulateList();
			}catch(IOException ex){
				MessageBox.Show("Copy Failed "+ex.Message,"Copy Failed");
				return;
			}
			MessageBox.Show("Copy Successful", "Copy Successful");
		}
		
		void DeleteButtonClick(object sender, EventArgs e)
		{
			if(listBox1.SelectedIndex<0)return;
			string filename=disk.Files[listBox1.SelectedIndex].Name;
			DialogResult res=MessageBox.Show("Are you sure you want to delete "+filename,"Confirm Deletion",MessageBoxButtons.YesNoCancel);
			if(res!=DialogResult.Yes)return;
			disk.DeleteFile(filename);
			PopulateList();
		}
		
		void RenameButtonClick(object sender, EventArgs e)
		{
			if(listBox1.SelectedIndex<0)return;
			string filename=disk.Files[listBox1.SelectedIndex].Name;
			RenameDialog.Show(filename);
		}
		
		void Rename(string oldName,string newName)
		{
			disk.Rename(oldName,newName);
			PopulateList();
		}
		void NewDskButtonClick(object sender, EventArgs e)
		{
			SfDialog.FileName="";
			DialogResult res=SfDialog.ShowDialog();
			if(res!=DialogResult.OK)return;
			Dsk.CreateNewImage(SfDialog.FileName);
			disk=new Dsk(SfDialog.FileName);
			textBox1.Text=SfDialog.FileName;
			PopulateList();
		}
		void CloseDskButtonClick(object sender, EventArgs e)
		{   
			if(disk==null)return;
			disk.Close();
			disk.Dispose();
			textBox1.Text="";
			PopulateList();
			
		}
		
	}
}
