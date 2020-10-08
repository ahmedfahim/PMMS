using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
namespace UtilitiesLibrary
{
	/// <summary>
	/// Summary description for File.
	/// </summary>
	namespace Text
	{
		public class File
		{
			public File()
			{
				//
				// TODO: Add constructor logic here
				//
			}

			public bool IsValidEmail(string strIn)
			{
				// Return true if strIn is in valid e-mail format.
				return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
			}
			public string ReadEmail(string PathFile)
			{
				try
				{
					string temp="",StrMail="";
					StreamReader MyReader=new StreamReader(PathFile);
					while (MyReader.Peek() >= 0) 
					{
						temp=MyReader.ReadLine().Trim().ToLower();
						if(IsValidEmail(temp))
							StrMail+=temp+",";
					}
					return StrMail.TrimEnd(',');
				}
				catch
				{
					return "File Not Found...Please Sure About Path";				
				}
			}
			public string CompareEmail(string strA,string strB)
			{		
				string StrNew="";
				ArrayList ContainerOne=new ArrayList();
				ArrayList ContainerTwo=new ArrayList();
			
				for(int i=0;i<strA.Length;i++)
				{
					if(strA[i]!=44)//for character , in Ascii and 13 for Environment.NewLine
						StrNew+=strA[i].ToString();
					else 
					{
						ContainerOne.Add(StrNew);
						StrNew="";
						//i++;//for Environment.NewLine
					}
				}
				ContainerOne.Add(StrNew);
				StrNew="";
				for(int i=0;i<strB.Length;i++)
				{
					if(strB[i]!=44)
						StrNew+=strB[i].ToString();
					else
					{
						ContainerTwo.Add(StrNew);
						StrNew="";
						//i++;//for Environment.NewLine
					}
				}
				ContainerTwo.Add(StrNew);
				if(ContainerOne.Count>=ContainerTwo.Count)
					return Looping(ContainerOne,ContainerTwo);
				else
					return Looping(ContainerTwo,ContainerOne);
			}
			private string Looping(ArrayList ContainerOne,ArrayList ContainerTwo)
			{
				string StrNew="";
				for(int i=0;i<ContainerOne.Count;i++)			
					for(int j=0;j<ContainerTwo.Count;j++)
					{
						if(ContainerOne.Contains(ContainerTwo[j]))
							ContainerTwo.Remove(ContainerTwo[j]);
					}
				for(int i=0;i<ContainerTwo.Count;i++)
					ContainerOne.Add(ContainerTwo[i]);
				for(int i=0;i<ContainerOne.Count;i++)
					StrNew+=ContainerOne[i].ToString()+",";
				return StrNew.TrimEnd(',');

			}
			public string Write(string strOut,string path)
			{
				try
				{
					StreamWriter str=new StreamWriter(path);
					str.Write(strOut);
					str.Flush();
					str.Close();
					return "Successfully Write"; 
				}
				catch
				{
                    return "File Not Found...Please Sure About Path";
				}
			}

		

		}
	}
}
