/*
 * Created by SharpDevelop.
 * User: Aaron2
 * Date: 2/18/2016
 * Time: 8:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DskUtil
{
	/// <summary>
	/// For purposes of lookup a FileEntry stores information about a file from a .dsk directory
	/// </summary>
	public class FileEntry
	{
		public string Name{get;private set;}
		public FileFormat Type{get;private set;}
		public bool Ascii{get;private set;}
		public int Size{get;private set;}
		public int FirstGranule{get;private set;}
		public int BytesInLastSector{get;private set;}
		
		public FileEntry(string filename,FileFormat type,bool ascii,int size,int firstgran,int bytesinlast)
		{
			
			Name=filename;
			Type=type;
			Ascii=ascii;
			Size=size;
			FirstGranule=firstgran;
			BytesInLastSector=bytesinlast;
		}
		public override string ToString(){
			return Name+" ("+Size+")";
		}
	}
}

public enum FileFormat {BAS,DAT,BIN,TEXT};