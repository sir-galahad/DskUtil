/*
 * Created by SharpDevelop.
 * User: Aaron2
 * Date: 2/25/2016
 * Time: 9:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DskUtil
{
	/// <summary>
	/// a super simple class to pass data from one window to another
	/// </summary>
	public class FileToCopy
	{
		public string Path{get;private set;}
		public string Filename{get;private set;}
		public FileFormat Format{get;private set;}
		public bool Ascii{get;private set;}
		
		public FileToCopy(string path,string name,FileFormat format,bool ascii)
		{
			Path=path;
			Filename=name;
			Format=format;
			Ascii=ascii;
		}
	}
}
