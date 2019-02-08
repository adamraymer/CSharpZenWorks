using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Drawing.Printing;

namespace ZenworksQuerySystem
{
	/// <summary>
	/// Summary description for QueryZen.
	/// </summary>
	public class QueryZen
	{
		public QueryZen()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public int[] CorrectCodes = new Int32[30];
		public bool AllowAccess;
		//public string CodeHolder; //Comes from Register; 


		public void SetKeyValues()
		{
			CorrectCodes[0] = 123980;
			CorrectCodes[1] = 113908;
			CorrectCodes[2] = 144809;
			CorrectCodes[3] = 726089;
			CorrectCodes[4] = 450098;
			CorrectCodes[5] = 311098;
			CorrectCodes[6] = 213778;
			CorrectCodes[7] = 222098;
			CorrectCodes[8] = 451989;
			CorrectCodes[9] = 416299;
			CorrectCodes[10] = 526299;
			CorrectCodes[11] = 128991;
			CorrectCodes[12] = 761289;
			CorrectCodes[13] = 128912;
			CorrectCodes[14] = 828111;
			CorrectCodes[15] = 110902;
			CorrectCodes[16] = 121322;
			CorrectCodes[17] = 112940;
			CorrectCodes[18] = 181928;
			CorrectCodes[19] = 192039;
			CorrectCodes[20] = 201921;
			CorrectCodes[21] = 473829;
			CorrectCodes[22] = 100278;
			CorrectCodes[23] = 211019;
			CorrectCodes[24] = 223981;
			CorrectCodes[25] = 891729;
			CorrectCodes[26] = 008273;
			CorrectCodes[27] = 918263;
			CorrectCodes[28] = 623728;
			CorrectCodes[29] = 739238;

		}

		public void CompareKeyCode()
		{
			try
			{
				StreamReader CheckCode = new StreamReader("C:\\Program Files\\Gracon Services, Inc\\ZENWorksQuery\\KeyCode.txt");
				int Check = 0;
				string CodeCheck;
			
				CodeCheck = CheckCode.ReadLine();
				for(int i = 0; i<30; i++)
				{
					if(CodeCheck==CorrectCodes[i].ToString())
					{
						Check = 1;
					}
				}
			

				if(Check == 1)
				{
					AllowAccess=true;
				}
				else
				{
					MessageBox.Show("No Valid Key Code", "Error: Key");
					AllowAccess=false;
				}

				CheckCode.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Comparing Key Code:  "+ex.Message.ToString(),"Error");
			}
			
		}

		public void WriteKeyCode(string CodeHolder)
		{
			try
			{
				StreamWriter WriteCode = new StreamWriter("C:\\Program Files\\Gracon Services, Inc\\ZENWorksQuery\\KeyCode.txt");

				WriteCode.WriteLine(CodeHolder);

				WriteCode.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Writing Key Code: "+ex.Message.ToString(),"Error"); 
			}

		}

		public void WriteSybaseReg(string IP, string User, string Pass, string DatabaseName)//string IP, string User, string Pass
		{
			char quote = '"'; //since you can't have a quotation mark in a string without problems, I created
								//this character to represent it and tack it on the end
			
			string WriteCode;
	
			try
			{
				StreamWriter WriteReg = new StreamWriter("C:\\Program Files\\Gracon Services, Inc\\ZENWorksQuery\\Sybase\\SybaseODBC.reg");

				WriteCode = "REGEDIT4";
				WriteReg.WriteLine(WriteCode);
				WriteCode = " ";
				WriteReg.WriteLine(WriteCode);

				WriteCode = @"[HKEY_CURRENT_USER\Software\ODBC]";
				WriteReg.WriteLine(WriteCode);
				WriteCode = " ";
				WriteReg.WriteLine(WriteCode);

				WriteCode = @"[HKEY_CURRENT_USER\Software\ODBC\ODBC.INI]";
				WriteReg.WriteLine(WriteCode);
				WriteCode = " ";
				WriteReg.WriteLine(WriteCode);

				WriteCode = @"[HKEY_CURRENT_USER\Software\ODBC\ODBC.INI\ODBC Data Sources]";
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"Zenworks Inventory"+quote+"="+quote+"Adaptive Server Anywhere 7.0"+quote;
				WriteReg.WriteLine(WriteCode);
				WriteCode = " ";
				WriteReg.WriteLine(WriteCode);

				WriteCode = @"[HKEY_CURRENT_USER\Software\ODBC\ODBC.INI\Zenworks Inventory]";
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"AutoStop"+quote+"="+quote+"Yes"+quote;
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"DatabaseName"+quote+"="+quote+DatabaseName+quote; //database name
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"Debug"+quote+"="+quote+"NO"+quote; 
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"Description"+quote+"="+quote+"Zenworks Inventory Database"+quote; 
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"DisableMultiRowFetch"+quote+"="+quote+"NO"+quote; 
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"Driver"+quote+"="+quote+@"C:\\Program Files\\Gracon Services, Inc\\ZENWorksQuery\\Sybase\\Program Files\\sybase\\Adaptive Server Anywhere 7.0\\win32\\dbodbc7.dll"+quote; 
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"EngineName"+quote+"="+quote+IP+quote; //IP
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"Integrated"+quote+"="+quote+"No"+quote; 
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"PWD"+quote+"="+quote+Pass+quote; //password
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"UID"+quote+"="+quote+User+quote; //username
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"CommLinks"+quote+"="+quote+"TCPIP{host="+IP+"}"+quote; //IP
				WriteReg.WriteLine(WriteCode);

				/////////////////////////////////////////////////////////////////////
			
				WriteCode = " ";
				WriteReg.WriteLine(WriteCode);

				WriteCode = @"[HKEY_LOCAL_MACHINE\SOFTWARE\ODBC\ODBCINST.INI\Adaptive Server Anywhere 7.0]";
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"Driver"+quote+"="+quote+@"C:\\Program Files\\Gracon Services, Inc\\ZENWorksQuery\\Sybase\\Program Files\\sybase\\Adaptive Server Anywhere 7.0\\win32\\dbodbc7.dll"+quote; 
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"Setup"+quote+"="+quote+@"C:\\Program Files\\Gracon Services, Inc\\ZENWorksQuery\\Sybase\\Program Files\\sybase\\Adaptive Server Anywhere 7.0\\win32\\dbodbc7.dll"+quote; 
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"CPTimeout"+quote+"="+quote+"<not pooled>"+quote; 
				WriteReg.WriteLine(WriteCode);

				////////////////////////////////////////////////////////////////////////
			
				WriteCode = " ";
				WriteReg.WriteLine(WriteCode);

				WriteCode = @"[HKEY_LOCAL_MACHINE\SOFTWARE\ODBC\ODBCINST.INI\Adaptive Server Anywhere 7.0 Translator]";
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"Translator"+quote+"="+quote+@"C:\\Program Files\\Gracon Services, Inc\\ZENWorksQuery\\Sybase\\Program Files\\sybase\\Adaptive Server Anywhere 7.0\\win32\\dbodtr7.dll"+quote; 
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"Setup"+quote+"="+quote+@"C:\\Program Files\\Gracon Services, Inc\\ZENWorksQuery\\Sybase\\Program Files\\sybase\\Adaptive Server Anywhere 7.0\\win32\\dbodtr7.dll"+quote; 
				WriteReg.WriteLine(WriteCode);

				//////////////////////////////////////////////////////////////////////////  
			
				WriteCode = " ";
				WriteReg.WriteLine(WriteCode);

				WriteCode = @"[HKEY_LOCAL_MACHINE\SOFTWARE\ODBC\ODBCINST.INI\ODBC Drivers]";
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"Adaptive Server Anywhere 7.0"+quote+"="+quote+"Installed"+quote; 
				WriteReg.WriteLine(WriteCode);

				/////////////////////////////////////////////////////////////////  
			
				WriteCode = " ";
				WriteReg.WriteLine(WriteCode);

				WriteCode = @"[HKEY_LOCAL_MACHINE\SOFTWARE\ODBC\ODBCINST.INI\ODBC Translators]";
				WriteReg.WriteLine(WriteCode);

				WriteCode = quote+"Adaptive Server Anywhere 7.0 Translator"+quote+"="+quote+"Installed"+quote; 
				WriteReg.WriteLine(WriteCode);
				
				WriteReg.Close();
			}
			catch(Exception ep)
			{
				MessageBox.Show("Error Creating Reg File: "+ep.Message.ToString()+" , "+ep.Source.ToString(),"Error");
			}
			


		}

	}
}
