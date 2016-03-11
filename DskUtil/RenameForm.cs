/*
 * Created by SharpDevelop.
 * User: Aaron2
 * Date: 3/10/2016
 * Time: 10:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DskUtil
{
	/// <summary>
	/// Description of RenameForm.
	/// </summary>
	public partial class RenameForm : Form
	{
		public event Action<string,string> NameConfirmed;
		string currentName;
		public RenameForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.FormClosing+=(A,O)=>{((FormClosingEventArgs)O).Cancel=true;Hide();};
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void Clear()
		{
			NameBox.Text="";
			currentName="";
		}
		public void Show(string name)
		{
			currentName=name;
			this.Show();
		}
		void CancelButtonClick(object sender, EventArgs e)
		{
			this.Hide();
		}
		void OkButtonClick(object sender, EventArgs e)
		{
			string name=NameBox.Text;
			if(name=="")
			{
				MessageBox.Show("empty names are not allowed");
				return;
			}
			if(name.Contains(":")||(name.Contains(".")&&name.Contains("/")))
			{
				MessageBox.Show("Invalid characters in name");
				return;
			}
			string[] fileAndExt=null;;
			if(name.Contains("."))
			{
				fileAndExt=name.Split('.');
				if(fileAndExt.Length>2)
				{
					MessageBox.Show("Invalid characters in name");
					return;
				}
			}else{
				fileAndExt=name.Split('/');
				if(fileAndExt.Length>2)
				{
					MessageBox.Show("Invalid characters in name");
					return;
				}
			}
			if(fileAndExt[0].Length>8)
			{
				MessageBox.Show("Too many characters in name");
				return;
			}
			if(fileAndExt[1].Length>3)
			{
				MessageBox.Show("Too many characters in extension");
				return;
			}
			NameConfirmed(currentName,name);
			this.Hide();
		}
	
	}
}
