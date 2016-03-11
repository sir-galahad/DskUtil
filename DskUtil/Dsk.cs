/*
 * Created by SharpDevelop.
 * User: Aaron2
 * Date: 2/18/2016
 * Time: 6:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace DskUtil
{
	/// <summary>
	/// A representation of a .dsk floppy image with DECB file system.
	/// </summary>
	public class Dsk:IDisposable
	{
		public static void CreateNewImage(string fileName){
			byte[] buffer=new byte[256];
			
			for(int x=0;x<buffer.Length;x++)buffer[x]=0xff;
			
			FileStream newImage=new FileStream(fileName,FileMode.CreateNew);
			newImage.Seek(DskFileOffset(17,2),SeekOrigin.Begin);
			newImage.Write(buffer,0,buffer.Length);
			
			//create a blank Directory there may be a better way to do this
			//but i'm going to have each entry be sixteen 0xFF values followed by sixteen 0x0 values
			//the 0x0 aren't used by DECB but were "reserved for future use" so it may be checking that these values are unused
			for(int x=16;x<256;x+=32)
			{
				for(int y=0;y<16;y++){
					buffer[x+y]=0;
				}
			}
			
			for(int x=0;x<9;x++)
			{
				newImage.Write(buffer,0,buffer.Length);
			}
			newImage.Close();
			newImage.Dispose();
		}
		public string FileName{get;private set;}
		byte[] Fat=new byte[68];
		byte[] Directory=new byte[32*72];
		public int FreeGranules{get;private set;}
		int FreeSpace=0;
		long DskFileSize=0;
		FileStream image=null;
		
		public List<FileEntry> Files=new List<FileEntry>();
		
		public Dsk(string filename)
		{
			FileName=filename;
			IOException e=null;
			try{
				image=new FileStream(FileName,FileMode.Open);
				UpdateFatData();
			}catch(IOException ex){
				e=ex;
				if(image!=null){
					image.Close();
					image.Dispose();
				}
				throw e;
			}
		}
		
		void UpdateFatData()
		{
			Files.Clear();
			FileInfo f=new FileInfo(FileName);
			DskFileSize=f.Length;
			image.Seek(DskFileOffset(17,2),SeekOrigin.Begin);
			if(image.Read(Fat,0,68)<68) throw new IOException("malformed .dsk image");
			image.Seek(DskFileOffset(17,3),SeekOrigin.Begin);
			if(image.Read(Directory,0,32*72)<256)throw new IOException("malformed dsk image");
			
			foreach(byte b in Fat)
			{
				if(b==0xFF)FreeGranules++;
			}
			
			FreeSpace=FreeGranules*2304;
			
			for(int x=0;x<32*72;x+=32)
			{
				string name=Encoding.ASCII.GetString(Directory,x,8);
				string ext=Encoding.ASCII.GetString(Directory,x+8,3);
				int nextGran=Directory[x+13];
				int firstGran=nextGran;
				int granCount=0;
				int size=0;
				int bytes;
				if(Directory[x]==255)break;
				if(Directory[x]==0)continue;
				while(nextGran<192){
					nextGran=Fat[nextGran];
					granCount++;
				}
				//if(nextGran==255)continue;
				size=(granCount-1)*9;
				size+=((nextGran&0xF)-1);
				size*=256;
				bytes=Directory[x+14];
				bytes=bytes<<8;
				bytes|=Directory[x+15];
				size+=bytes;
				Files.Add(new FileEntry(name.Trim()+"."+ext.Trim(),0,false,size,firstGran,bytes));
			}
		}
		
		public void CopyFileFromDsk(string file,string path)
		{
			string outpath=path+Path.DirectorySeparatorChar+file;
			FileStream output=null;
			IOException e=null;
			byte[] buffer=new byte[256*9];//a granule size 256 bytes per sector *9 sectors
			int x=2;
			while(File.Exists(outpath))
			{
				StringBuilder sb=new StringBuilder(path);
				sb.Append(Path.DirectorySeparatorChar);
				sb.Append(Path.GetFileNameWithoutExtension(file));
				sb.Append('(');
				sb.Append(x);
				sb.Append(')');
				sb.Append(Path.GetExtension(file));
				outpath=sb.ToString();
				x++;
			}
			try{
				output =new FileStream(outpath,FileMode.CreateNew);
				UpdateFatData();
				FileEntry entry=null;
				foreach(FileEntry ent in Files){
					if(ent.Name==file){
						entry=ent;
						break;
					}
				}
				int currentGran=entry.FirstGranule;
				int nextGran=0;
				int size=0;
				while(currentGran<192)
				{
					nextGran=Fat[currentGran];
					image.Seek(GranuleOffset(currentGran),SeekOrigin.Begin);
					if(nextGran<192){
						image.Read(buffer,0,256*9);
						output.Write(buffer,0,256*9);
					}else{
						size=nextGran&0xF;//last four bits are the number of sectors used in last granule
						size--;
						size*=256;
						size+=entry.BytesInLastSector;
						image.Read(buffer,0,size);
						output.Write(buffer,0,size);
						
					}
					currentGran=nextGran;
				}
			}catch(IOException ex){
				e=ex;
			}finally{
				if(output!=null){
					output.Close();
					output.Dispose();
				}
			}
			if(e!=null)throw e;
			UpdateFatData();
		}
		
		public void CopyToDsk(FileToCopy file,bool overwrite)
		{
			int[] granulesToUse;
			int result;
			byte[] buffer=new byte[2304];
			FileInfo fileLength=new FileInfo(file.Path);
			FileStream input;
			granulesToUse=new int[((new FileInfo(file.Path).Length)/2304)+1];
			UpdateFatData();
			
			if(fileLength.Length>FreeSpace)
			{
				image.Close();
				image.Dispose();
				throw new IOException("Not enough space on .DSK");
			}
			if(FileExists(file.Filename)){
				image.Close();
				image.Dispose();
				throw new IOException("file already exists");
			}
			
			int x=0;
			if(Fat[33]==0xff){
				granulesToUse[0]=33;
				Fat[33]=0xfe;//flagging granules to be used as 0xfe; only in memory never written to image
				x++;
			}
				
			for(;x<granulesToUse.Length;x++)
			{
				if(x==0)result=GetNearestFreeGranule(33);
				else result=GetNearestFreeGranule(granulesToUse[x-1]);
				if(result==0xff)throw new IOException("Disk image full");
				granulesToUse[x]=result;
			}
			
			input=new FileStream(file.Path,FileMode.Open);
			for(int index=0;index<granulesToUse.Length;index++){
				input.Read(buffer,0,2304);
				WriteGranule(buffer,granulesToUse[index]);
			}
			input.Close();
			input.Dispose();
			for(int index=0;index<granulesToUse.Length-1;index++){
				Fat[granulesToUse[index]]=(byte)granulesToUse[index+1];
			}
			
			int sectors=(int)(fileLength.Length%2304);
			sectors/=256;
			if(fileLength.Length%256!=0)sectors+=1;
			Fat[granulesToUse[granulesToUse.Length-1]]=(byte)(192+sectors);
			string[] fNameParts=file.Filename.Split('.');
			Encoding.ASCII.GetBytes("           ").CopyTo(buffer,0);
			buffer[11]=(byte)((file.Format)-1);
			if(file.Ascii)buffer[12]=0xff;
			else buffer[12]=0;
			buffer[13]=(byte)granulesToUse[0];
			buffer[15]=(byte)(fileLength.Length%256);
			if(fileLength.Length%256==0&&fileLength.Length>0)buffer[14]=1;
			else buffer[14]=0;
			Encoding.ASCII.GetBytes(fNameParts[0]).CopyTo(buffer,0);
			Encoding.ASCII.GetBytes(fNameParts[1]).CopyTo(buffer,8);
		
			for(int index=16;index<=31;index++){
				buffer[index]=0;
			}
			buffer[32]=0xff;
			int tocopy=33;
			for(x=0;x<68;x++){
				if(Directory[x*32]==0xff){break;}
				if(Directory[x*32]==0)
				{
					tocopy=32; 
					break;
				}
			}
			for(int index=0;index<tocopy;index++){
				Directory[x*32+index]=buffer[index];
			}
			
			WriteSector(Fat,DskFileOffset(17,2));
			WriteDirectory();
			UpdateFatData();
		}
		
		public void DeleteFile(string filename)
		{
			int FileEntryStart=-1;
			for(int x=0;x<72;x++){
				string name=Encoding.ASCII.GetString(Directory,x*32,8).Trim();
				string ext=Encoding.ASCII.GetString(Directory,x*32+8,3).Trim();
				if(filename==name+"."+ext){
					FileEntryStart=x*32;
					break;
				}
			}
			if(FileEntryStart==-1)return;
			int nextGranule=Directory[FileEntryStart+13];
			int currentGranule;
			while(nextGranule<68){
				currentGranule=nextGranule;
				nextGranule=Fat[nextGranule];
				Fat[currentGranule]=0xFF;
			}
			Directory[FileEntryStart]=0;
			
			WriteSector(Fat,DskFileOffset(17,2));
			WriteDirectory();
			UpdateFatData();
		}
		
		int GetNearestFreeGranule(int start){
			int x=1;
			while(start-x>=0||start+x<68){
				if(start+x<=67){
					if(Fat[start+x]==0xff){
						return start+x;
					}
				}
				if(start-x>=0){
					if(Fat[start-x]==0xff){
						return start-x;
					}
				}
				x++;
			}
			return 0xff;
		}
		
		public void Rename(string oldName, string newName)
		{
			int index=-1;
			string[] oldNameAndExt=oldName.Split('.');
			for(int x=0;x<32*72;x+=32)
			{
				if(Directory[x]==0xff)return;
				string tmpName=Encoding.ASCII.GetString(Directory,x,8).Trim();
				string tmpExt=Encoding.ASCII.GetString(Directory,x+8,3).Trim();
				if(oldNameAndExt[0]==tmpName && oldNameAndExt[1]==tmpExt)
				{
					index=x;
					break;
				}
				
			}
			if(index==-1)return;
			newName=newName.Replace('/','.');
			string[] newNameAndExt=newName.Split('.');
			for(int x=0;x<11;x++)
			{
				Directory[index+x]=0x20;//ASCII space
			}
			for(int x=0;x<newNameAndExt[0].Length;x++){
				Directory[index+x]=Encoding.ASCII.GetBytes(newNameAndExt[0])[x];
			}
			for(int x=0;x<newNameAndExt[1].Length;x++){
				Directory[index+8+x]=Encoding.ASCII.GetBytes(newNameAndExt[1])[x];
			}
			WriteDirectory();
			UpdateFatData();
		}
		
		void WriteDirectory()
		{
			byte[] buffer=new byte[256];
			for(int x=0;x<Directory.Length;x+=256)
			{
				for(int y=0;y<256;y++)buffer[y]=0xFF;
				for(int y=0;y<256&&(y+x)<Directory.Length;y++)
				{
					buffer[y]=Directory[x+y];	
				}
				WriteSector(buffer,DskFileOffset(17,3)+x);
			}
		}
		
		void WriteGranule(byte[] buffer,int granule)
		{	int offset=GranuleOffset(granule);
			byte[] sector=new byte[256];
			for(int x=0;x<9;x++)
			{
				for(int index=0;index<256;index++){
					sector[index]=buffer[x*256+index];
				}
				WriteSector(sector,offset+(256*x));
			}
		}
		
		void WriteSector(byte[] buffer,int offset)
		{
			byte[] output=new byte[256];
			//ugh Array.CopyTo() should have a count argument
			//but it doesn't so i'll do this manually, this is here to ensure we write a full sector, not a partial
			
			for(int x=0;x<output.Length&&x<buffer.Length;x++){
				output[x]=buffer[x];
			}
			image.Seek(offset,SeekOrigin.Begin);
			image.Write(output,0,256);
		}
		
		bool FileExists(string filename)
		{
			string dirFile;
			int index=0;
			bool match=false;
			for(index=0;index<=Directory.Length;index+=32)
			{
				if(Directory[index]==0xff){
					break;
				}
				dirFile=Encoding.ASCII.GetString(Directory,index,8);
				dirFile=dirFile.Trim();
				dirFile+=".";
				dirFile+=Encoding.ASCII.GetString(Directory,index+8,3);
				dirFile=dirFile.Trim();
				if(dirFile==filename){
					match=true;
					break;
				}
			}
			return match;
		}
		static int DskFileOffset(int track, int sector)
		{
			return track*18*256+(sector-1)*256;
		}
		
		static int GranuleOffset(int Gran)
		{
			int track=Gran/2;
			if(track>=17)track++;
			int sector=(Gran%2)*9+1;
			return DskFileOffset(track,sector);
		}
		
		public static string MakeValidFilename(string filename)
		{
			string name,ext;
			name=Path.GetFileNameWithoutExtension(filename);
			name=Regex.Replace(name,"[\0/.:]","");
			if(name.Length>8) name=name.Substring(0,8);
			name=name.ToUpper();
			ext=Path.GetExtension(filename);
			ext=Regex.Replace(ext,"[\0/.:]","");
			if(ext.Length>3) ext=ext.Substring(0,3);
			ext=ext.ToUpper();
			return name+"."+ext;
		}
		public void Close()
		{
			image.Close();
		}
		public void Dispose()
		{
			image.Dispose();
		}
	}
}
