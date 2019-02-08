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
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

		//Connection string

		string strConn = "DSN=Zenworks Inventory";

		#region declared items
		public System.Data.Odbc.OdbcDataReader myReader;
		private System.Windows.Forms.DataGrid dgResults;
		public string myStringCommand;
		public string queryAddOn;
		public string IPaddress;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.SaveFileDialog SaveResults;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		
		private System.Windows.Forms.PrintDialog PrintResults;
		private System.Drawing.Printing.PrintDocument printDocument1;
		
		public int rowCount = 0;
		public DataRow printRow;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.PrintPreviewDialog PrintPreview;
		private System.Windows.Forms.MenuItem menuItemLinks;
		private System.Windows.Forms.MenuItem menuItemGracon;
		private System.Windows.Forms.MenuItem menuItemNovell;

		public string searchString = ""; //used to hold what processors are being queried
		public string searchVisMem = ""; //holds visible mem info
		public string searchDiskSize = ""; //holds disk size info
		public string searchSerial = ""; //holds serial search info
		public string searchOS = ""; //holds OS search info
		public string searchClient = ""; //holds client search info
		public string searchCompName = ""; //holds Computer Name info
		public string searchSoftware = ""; //holds software info
		public string searchSoftCompName = ""; //folds software computer name info

		public DataTable dtResults = new DataTable("tblResults");

		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabHardware;
		private System.Windows.Forms.TabPage tabSoftware;
		private System.Windows.Forms.TextBox txtSerial;
		private System.Windows.Forms.TextBox txtDiskSize;
		private System.Windows.Forms.TextBox txtVisibleMemory;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.CheckedListBox lisClient;
		private System.Windows.Forms.CheckBox chkNameWild;
		private System.Windows.Forms.CheckBox chkSerialWildCard;
		private System.Windows.Forms.GroupBox DiskBox;
		private System.Windows.Forms.RadioButton radDiskAll;
		private System.Windows.Forms.RadioButton radDiskGreat;
		private System.Windows.Forms.RadioButton radDiskLess;
		private System.Windows.Forms.GroupBox MemoryBox;
		private System.Windows.Forms.RadioButton radMemAll;
		private System.Windows.Forms.RadioButton radGreatMem;
		private System.Windows.Forms.RadioButton radMemLess;
		private System.Windows.Forms.CheckBox chkClientVer;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.CheckBox chkSerial;
		private System.Windows.Forms.CheckBox chkComputerName;
		private System.Windows.Forms.CheckBox chkOS;
		private System.Windows.Forms.CheckBox chkProcessor;
		private System.Windows.Forms.CheckedListBox lisOperatingSystems;
		private System.Windows.Forms.TextBox txtComputerName;
		private System.Windows.Forms.CheckedListBox lisProcessors;
		private System.Windows.Forms.CheckedListBox lisSoftware;
		
		private System.Windows.Forms.Button btnSoftSearch;
		private System.Windows.Forms.Button btnSoftSave;
		private System.Windows.Forms.Button btnSoftPrint;
		private System.Windows.Forms.Button btnSoftClear;
		private System.Windows.Forms.Button btnSoftExit;
		private System.Windows.Forms.CheckBox chksoftChoice;
		private System.Windows.Forms.TextBox txtSoftCompName;
		private System.Windows.Forms.CheckBox chkSoftCompName;
		private System.Windows.Forms.CheckBox chkSoftNameWild;

		public int SaveCheck = 0;
		private System.Windows.Forms.TabPage tabSorting;
		private System.Windows.Forms.GroupBox grpHardware;
		private System.Windows.Forms.RadioButton radImportASC;
		private System.Windows.Forms.RadioButton radImportDESC;
		private System.Windows.Forms.RadioButton radCompNameASC;
		private System.Windows.Forms.RadioButton radCompNameDESC;
		private System.Windows.Forms.RadioButton radDescASC;
		private System.Windows.Forms.RadioButton radDescDESC;
		private System.Windows.Forms.RadioButton radModelASC;
		private System.Windows.Forms.RadioButton radModelDESC;
		private System.Windows.Forms.RadioButton radSerialASC;
		private System.Windows.Forms.RadioButton radSerialDESC;
		private System.Windows.Forms.RadioButton radTagASC;
		private System.Windows.Forms.RadioButton radTAGDESC;
		private System.Windows.Forms.RadioButton radOSASC;
		private System.Windows.Forms.RadioButton radOSDESC;
		private System.Windows.Forms.RadioButton radOSVerASC;
		private System.Windows.Forms.RadioButton radOSVerDESC;
		private System.Windows.Forms.RadioButton radTotVisMemSizeASC;
		private System.Windows.Forms.RadioButton radTotVisMemDESC;
		private System.Windows.Forms.RadioButton radDriveNameASC;
		private System.Windows.Forms.RadioButton radDriveNameDESC;
		private System.Windows.Forms.RadioButton radFileSysSizASC;
		private System.Windows.Forms.RadioButton radFileSysSizeDESC;
		private System.Windows.Forms.RadioButton radAvSizeASC;
		private System.Windows.Forms.RadioButton radAvSizeDESC;
		private System.Windows.Forms.RadioButton radFSTASC;
		private System.Windows.Forms.RadioButton radFSTDESC;
		private System.Windows.Forms.RadioButton radProcASC;
		private System.Windows.Forms.RadioButton radProcDESC;
		private System.Windows.Forms.RadioButton radCurrClASC;
		private System.Windows.Forms.RadioButton radCurrClDESC;
		private System.Windows.Forms.RadioButton radClientASC;
		private System.Windows.Forms.RadioButton radClientDESC;
		private System.Windows.Forms.GroupBox grpSoftware;
		private System.Windows.Forms.RadioButton radSoftCompNameASC;
		private System.Windows.Forms.RadioButton radSoftCompNameDESC;
		private System.Windows.Forms.RadioButton radSoftNameASC;
		private System.Windows.Forms.RadioButton radSoftNameDESC;
		private System.Windows.Forms.RadioButton radVendorASC;
		private System.Windows.Forms.RadioButton radVendorDESC;
		private System.Windows.Forms.RadioButton radVerASC;
		private System.Windows.Forms.RadioButton radVerDESC;
		private System.Windows.Forms.Button btnNoSort;

		public string OrderItems = "";
		private System.Windows.Forms.TabPage tabImport;
		private System.Windows.Forms.DataGrid dgImport;

		public DataTable ImportTable = new DataTable();
		public DataTable NotList = new DataTable();
		float MyLines = 55;
		public int ZenType = 0;
		private System.Windows.Forms.Button btnGoogle;
		public DataTable SoftTable = new DataTable("tblSoft");
		private System.Windows.Forms.Button btnSortSearch;
		private System.Windows.Forms.MenuItem menuItem10;

		public string SelectTables =" ";
		public string FromTables= " ";
		public string WhereTables =" ";

		int ProsCheck=0;
		int OSCheck = 0;
		int ClientCheck = 0;
		int VisMem = 0;
		int DiskCheck = 0;
		private System.Windows.Forms.RadioButton radNoDisk;
		private System.Windows.Forms.RadioButton radNoMem;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem SaveTextDelimitedMenu;
		private System.Windows.Forms.MenuItem SaveWordDocument;
		private System.Windows.Forms.SaveFileDialog SaveWordDoc;
		public int CheckProgram = 0;
		public Form RegisterCode = new Register();
		private System.Windows.Forms.DataGrid dgSoftware;
		private System.Windows.Forms.TextBox txtSoftwareName;
		private System.Windows.Forms.CheckBox chkSoftwareName;
		private System.Windows.Forms.CheckBox chkWildSoftName;
		private System.Windows.Forms.RadioButton radSoft;
		private System.Windows.Forms.RadioButton radVen;
		private System.Windows.Forms.Button btnAll;
		private System.Windows.Forms.Button btnSymNum;
		private System.Windows.Forms.Button btnA;
		private System.Windows.Forms.Button btnB;
		private System.Windows.Forms.Button btnC;
		private System.Windows.Forms.Button btnD;
		private System.Windows.Forms.Button btnE;
		private System.Windows.Forms.Button btnF;
		private System.Windows.Forms.Button btnG;
		private System.Windows.Forms.Button btnH;
		private System.Windows.Forms.Button btnI;
		private System.Windows.Forms.Button btnJ;
		private System.Windows.Forms.Button btnK;
		private System.Windows.Forms.Button btnL;
		private System.Windows.Forms.Button btnM;
		private System.Windows.Forms.Button btnN;
		private System.Windows.Forms.Button btnO;
		private System.Windows.Forms.Button btnP;
		private System.Windows.Forms.Button btnQR;
		private System.Windows.Forms.Button btnS;
		private System.Windows.Forms.Button btnT;
		private System.Windows.Forms.Button btnUV;
		private System.Windows.Forms.Button btnWX;
		private System.Windows.Forms.Button btnYZ;
		int pageNum = 0;
		private System.Windows.Forms.Button btnSym;
		private System.Windows.Forms.Button btnR;
		private System.Windows.Forms.Button btnV;
		private System.Windows.Forms.Button btnX;
		private System.Windows.Forms.Button btnZ;
		private System.Windows.Forms.TabPage tabOther;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtInstalledDate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtSerialnum;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtCurrentLocation;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RadioButton radActive;
		private System.Windows.Forms.RadioButton radInactive;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.DataGrid dgInventory;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtMFG;
		private System.Windows.Forms.Button btnInventory;
		string SoftFilt = " ";
		private System.Windows.Forms.ComboBox lstType;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.ComboBox lstSortInv;
		private System.Windows.Forms.Button btnSortInv;
		private System.Windows.Forms.Button btnNoInvSort;
		private System.Windows.Forms.Button btnPrintInv;
		private System.Windows.Forms.Button btnClearInv;
		private System.Windows.Forms.Button btnSaveInv;
		DataTable Catalog = new DataTable();
		private System.Windows.Forms.Label lblImportList;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.TextBox txtRMNum;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtSortBuilding;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtSortRoom;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtSortSerial;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.CheckBox chkWildBuild;
		private System.Windows.Forms.CheckBox chkWildRoom;
		private System.Windows.Forms.CheckBox chkWildSerial;
		private System.Windows.Forms.CheckedListBox lstOSVersion;
		string InvenHold=" ";
		private System.Windows.Forms.MenuItem menuDataBaseReg;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.Button btnSelectAll;
		string OSV = " ";
#endregion
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			try
			{
				InitializeComponent();

				QueryZen Compare = new QueryZen();
			
				Compare.SetKeyValues();
			
			//try was here
				Compare.CompareKeyCode();

				if(Compare.AllowAccess==false)
				{
					DialogResult buttonClicked = this.RegisterCode.ShowDialog();
					
					if(buttonClicked.Equals(DialogResult.OK))
					{
						Compare.CompareKeyCode();
						
						if(Compare.AllowAccess == true)//if the compare fails the first time, it means that there is no code or it is false
						{
							CheckProgram = 2;	
						}
						else
						{
							CheckProgram = 0;
						}
					}
					else
					{
						MessageBox.Show("Operation Cancelled; No Key Code Given","No Key Code");
					}
				}
				else //this means that the code checks correctly and loading can continue
				{
					try//newer try
					{
						Compare.CompareKeyCode();  //double checks to make sure
						if(Compare.AllowAccess==true)
						{
							CheckProgram = 1;
							ResetDatabase();
						}
						else
						{
							CheckProgram = 0;
						}
					}
					catch(Exception ex)
					{
						MessageBox.Show("Error Checking Key Code:  "+ex.Message.ToString(),"Key Code Check Error");
					}
				}

				
			}
			catch(Exception ex) //Problem opening KeyCode.txt, possibly its not there
			{
				MessageBox.Show("Error Checking For Key Code. Check Status of KeyCode.txt " + ex.Message.ToString(),"Key Code Error");
			}
			
			//ResetDatabase();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private void ResetDatabase()
		{
			
				Form myForm = new LoadingProgram();
				Form loadOS	= new LoadingOSInformation();
				Form loadClient = new LoadingClientInformation();
				Form loadSoft = new LoadingSoftwareInformation();

			//try was here
			try
			{
				loadClient.Show();
				this.Cursor = Cursors.WaitCursor;
				Application.DoEvents();
				this.FillClientList();

				loadClient.Close();
				loadClient.Dispose();

				myForm.Show();
				Application.DoEvents();

				this.FillProcessorList();
				myForm.Close();
				myForm.Dispose();

				loadOS.Show();

				Application.DoEvents();

				this.FillOSList();

				loadOS.Close();
				loadOS.Dispose();

				loadSoft.Show();

				Application.DoEvents();
				//this.FillSoftwareList();
				this.FillImportList();

				//if available; checks in this method
				this.FillTypeSearch();
				
				loadSoft.Close();
				loadSoft.Dispose();

				this.Cursor = Cursors.Default;
				Application.DoEvents();
			}
			catch(Exception ex)
			{
				try
				{
					MessageBox.Show("There is an error connecting to the database; Check database connection  "+ex.Message.ToString(),"Error Connecting");
					//run ODBC configure program from Windows
					myForm.Close();
					loadOS.Close();
					loadClient.Close();
					loadSoft.Close();
					myForm.Dispose();
					loadOS.Dispose();
					loadClient.Dispose();
					loadSoft.Dispose();
					this.Cursor = Cursors.Default;
					System.Diagnostics.Process.Start("odbcad32.exe");
					
				}
				catch(Exception ex2)
				{
					MessageBox.Show("There was an error openning 'odbcad32.exe'.  "+ex.Message.ToString()+ " "+ex2.Message.ToString(),"odbcad32.exe/ Starting Error");
					myForm.Close();
					loadOS.Close();
					loadClient.Close();
					loadSoft.Close();
					myForm.Dispose();
					loadOS.Dispose();
					loadClient.Dispose();
					loadSoft.Dispose();
					this.Cursor = Cursors.Default;
				}
			}
			

		}

		

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.dgResults = new System.Windows.Forms.DataGrid();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuDataBaseReg = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.SaveTextDelimitedMenu = new System.Windows.Forms.MenuItem();
			this.SaveWordDocument = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItemLinks = new System.Windows.Forms.MenuItem();
			this.menuItemGracon = new System.Windows.Forms.MenuItem();
			this.menuItemNovell = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.SaveResults = new System.Windows.Forms.SaveFileDialog();
			this.PrintResults = new System.Windows.Forms.PrintDialog();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.PrintPreview = new System.Windows.Forms.PrintPreviewDialog();
			this.lblCount = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabHardware = new System.Windows.Forms.TabPage();
			this.lstOSVersion = new System.Windows.Forms.CheckedListBox();
			this.txtSerial = new System.Windows.Forms.TextBox();
			this.txtDiskSize = new System.Windows.Forms.TextBox();
			this.txtVisibleMemory = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.lisClient = new System.Windows.Forms.CheckedListBox();
			this.chkNameWild = new System.Windows.Forms.CheckBox();
			this.chkSerialWildCard = new System.Windows.Forms.CheckBox();
			this.DiskBox = new System.Windows.Forms.GroupBox();
			this.radDiskAll = new System.Windows.Forms.RadioButton();
			this.radDiskGreat = new System.Windows.Forms.RadioButton();
			this.radDiskLess = new System.Windows.Forms.RadioButton();
			this.radNoDisk = new System.Windows.Forms.RadioButton();
			this.MemoryBox = new System.Windows.Forms.GroupBox();
			this.radMemAll = new System.Windows.Forms.RadioButton();
			this.radGreatMem = new System.Windows.Forms.RadioButton();
			this.radMemLess = new System.Windows.Forms.RadioButton();
			this.radNoMem = new System.Windows.Forms.RadioButton();
			this.chkClientVer = new System.Windows.Forms.CheckBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.chkSerial = new System.Windows.Forms.CheckBox();
			this.chkComputerName = new System.Windows.Forms.CheckBox();
			this.chkOS = new System.Windows.Forms.CheckBox();
			this.chkProcessor = new System.Windows.Forms.CheckBox();
			this.lisOperatingSystems = new System.Windows.Forms.CheckedListBox();
			this.txtComputerName = new System.Windows.Forms.TextBox();
			this.lisProcessors = new System.Windows.Forms.CheckedListBox();
			this.tabSoftware = new System.Windows.Forms.TabPage();
			this.btnSelectAll = new System.Windows.Forms.Button();
			this.btnZ = new System.Windows.Forms.Button();
			this.btnX = new System.Windows.Forms.Button();
			this.btnV = new System.Windows.Forms.Button();
			this.btnR = new System.Windows.Forms.Button();
			this.btnSym = new System.Windows.Forms.Button();
			this.btnYZ = new System.Windows.Forms.Button();
			this.btnWX = new System.Windows.Forms.Button();
			this.btnUV = new System.Windows.Forms.Button();
			this.btnT = new System.Windows.Forms.Button();
			this.btnS = new System.Windows.Forms.Button();
			this.btnQR = new System.Windows.Forms.Button();
			this.btnP = new System.Windows.Forms.Button();
			this.btnO = new System.Windows.Forms.Button();
			this.btnN = new System.Windows.Forms.Button();
			this.btnM = new System.Windows.Forms.Button();
			this.btnL = new System.Windows.Forms.Button();
			this.btnK = new System.Windows.Forms.Button();
			this.btnJ = new System.Windows.Forms.Button();
			this.btnI = new System.Windows.Forms.Button();
			this.btnH = new System.Windows.Forms.Button();
			this.btnG = new System.Windows.Forms.Button();
			this.btnF = new System.Windows.Forms.Button();
			this.btnE = new System.Windows.Forms.Button();
			this.btnD = new System.Windows.Forms.Button();
			this.btnC = new System.Windows.Forms.Button();
			this.btnB = new System.Windows.Forms.Button();
			this.btnA = new System.Windows.Forms.Button();
			this.btnSymNum = new System.Windows.Forms.Button();
			this.btnAll = new System.Windows.Forms.Button();
			this.radVen = new System.Windows.Forms.RadioButton();
			this.radSoft = new System.Windows.Forms.RadioButton();
			this.chkWildSoftName = new System.Windows.Forms.CheckBox();
			this.chkSoftwareName = new System.Windows.Forms.CheckBox();
			this.txtSoftwareName = new System.Windows.Forms.TextBox();
			this.btnGoogle = new System.Windows.Forms.Button();
			this.chkSoftNameWild = new System.Windows.Forms.CheckBox();
			this.chkSoftCompName = new System.Windows.Forms.CheckBox();
			this.txtSoftCompName = new System.Windows.Forms.TextBox();
			this.chksoftChoice = new System.Windows.Forms.CheckBox();
			this.btnSoftExit = new System.Windows.Forms.Button();
			this.btnSoftClear = new System.Windows.Forms.Button();
			this.btnSoftPrint = new System.Windows.Forms.Button();
			this.btnSoftSave = new System.Windows.Forms.Button();
			this.btnSoftSearch = new System.Windows.Forms.Button();
			this.lisSoftware = new System.Windows.Forms.CheckedListBox();
			this.tabSorting = new System.Windows.Forms.TabPage();
			this.btnSortSearch = new System.Windows.Forms.Button();
			this.grpSoftware = new System.Windows.Forms.GroupBox();
			this.radVerDESC = new System.Windows.Forms.RadioButton();
			this.radVerASC = new System.Windows.Forms.RadioButton();
			this.radVendorDESC = new System.Windows.Forms.RadioButton();
			this.radVendorASC = new System.Windows.Forms.RadioButton();
			this.radSoftNameDESC = new System.Windows.Forms.RadioButton();
			this.radSoftNameASC = new System.Windows.Forms.RadioButton();
			this.radSoftCompNameDESC = new System.Windows.Forms.RadioButton();
			this.radSoftCompNameASC = new System.Windows.Forms.RadioButton();
			this.grpHardware = new System.Windows.Forms.GroupBox();
			this.radClientDESC = new System.Windows.Forms.RadioButton();
			this.radClientASC = new System.Windows.Forms.RadioButton();
			this.radCurrClDESC = new System.Windows.Forms.RadioButton();
			this.radCurrClASC = new System.Windows.Forms.RadioButton();
			this.radProcDESC = new System.Windows.Forms.RadioButton();
			this.radProcASC = new System.Windows.Forms.RadioButton();
			this.radFSTDESC = new System.Windows.Forms.RadioButton();
			this.radFSTASC = new System.Windows.Forms.RadioButton();
			this.radAvSizeDESC = new System.Windows.Forms.RadioButton();
			this.radAvSizeASC = new System.Windows.Forms.RadioButton();
			this.radFileSysSizeDESC = new System.Windows.Forms.RadioButton();
			this.radFileSysSizASC = new System.Windows.Forms.RadioButton();
			this.radDriveNameDESC = new System.Windows.Forms.RadioButton();
			this.radDriveNameASC = new System.Windows.Forms.RadioButton();
			this.radTotVisMemDESC = new System.Windows.Forms.RadioButton();
			this.radTotVisMemSizeASC = new System.Windows.Forms.RadioButton();
			this.radOSVerDESC = new System.Windows.Forms.RadioButton();
			this.radOSVerASC = new System.Windows.Forms.RadioButton();
			this.radOSDESC = new System.Windows.Forms.RadioButton();
			this.radOSASC = new System.Windows.Forms.RadioButton();
			this.radTAGDESC = new System.Windows.Forms.RadioButton();
			this.radTagASC = new System.Windows.Forms.RadioButton();
			this.radSerialDESC = new System.Windows.Forms.RadioButton();
			this.radSerialASC = new System.Windows.Forms.RadioButton();
			this.radModelDESC = new System.Windows.Forms.RadioButton();
			this.radModelASC = new System.Windows.Forms.RadioButton();
			this.radDescDESC = new System.Windows.Forms.RadioButton();
			this.radDescASC = new System.Windows.Forms.RadioButton();
			this.radCompNameDESC = new System.Windows.Forms.RadioButton();
			this.radCompNameASC = new System.Windows.Forms.RadioButton();
			this.radImportDESC = new System.Windows.Forms.RadioButton();
			this.radImportASC = new System.Windows.Forms.RadioButton();
			this.btnNoSort = new System.Windows.Forms.Button();
			this.tabImport = new System.Windows.Forms.TabPage();
			this.lblImportList = new System.Windows.Forms.Label();
			this.dgImport = new System.Windows.Forms.DataGrid();
			this.tabOther = new System.Windows.Forms.TabPage();
			this.label13 = new System.Windows.Forms.Label();
			this.txtRMNum = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkWildSerial = new System.Windows.Forms.CheckBox();
			this.chkWildRoom = new System.Windows.Forms.CheckBox();
			this.chkWildBuild = new System.Windows.Forms.CheckBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtSortSerial = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtSortRoom = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtSortBuilding = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.btnInventory = new System.Windows.Forms.Button();
			this.lstSortInv = new System.Windows.Forms.ComboBox();
			this.btnSortInv = new System.Windows.Forms.Button();
			this.btnNoInvSort = new System.Windows.Forms.Button();
			this.btnSaveInv = new System.Windows.Forms.Button();
			this.btnClearInv = new System.Windows.Forms.Button();
			this.btnPrintInv = new System.Windows.Forms.Button();
			this.lstType = new System.Windows.Forms.ComboBox();
			this.txtMFG = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.radInactive = new System.Windows.Forms.RadioButton();
			this.radActive = new System.Windows.Forms.RadioButton();
			this.label8 = new System.Windows.Forms.Label();
			this.txtCurrentLocation = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtSerialnum = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtInstalledDate = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.dgInventory = new System.Windows.Forms.DataGrid();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.dgSoftware = new System.Windows.Forms.DataGrid();
			this.SaveWordDoc = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabHardware.SuspendLayout();
			this.DiskBox.SuspendLayout();
			this.MemoryBox.SuspendLayout();
			this.tabSoftware.SuspendLayout();
			this.tabSorting.SuspendLayout();
			this.grpSoftware.SuspendLayout();
			this.grpHardware.SuspendLayout();
			this.tabImport.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgImport)).BeginInit();
			this.tabOther.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgInventory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSoftware)).BeginInit();
			this.SuspendLayout();
			// 
			// dgResults
			// 
			this.dgResults.AllowSorting = false;
			this.dgResults.CaptionText = "Hardware Search Results";
			this.dgResults.DataMember = "";
			this.dgResults.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgResults.Location = new System.Drawing.Point(14, 424);
			this.dgResults.Name = "dgResults";
			this.dgResults.PreferredColumnWidth = 140;
			this.dgResults.ReadOnly = true;
			this.dgResults.Size = new System.Drawing.Size(680, 168);
			this.dgResults.TabIndex = 20;
			this.dgResults.TabStop = false;
			this.toolTip1.SetToolTip(this.dgResults, "Hardware results");
			this.dgResults.Visible = false;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem8,
																					  this.menuItem9,
																					  this.menuItemLinks,
																					  this.menuItem11});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem10,
																					  this.menuDataBaseReg,
																					  this.menuItem4,
																					  this.menuItem14,
																					  this.menuItem5,
																					  this.menuItem12,
																					  this.menuItem7,
																					  this.menuItem2,
																					  this.menuItem6,
																					  this.menuItem13,
																					  this.menuItem20,
																					  this.menuItem24,
																					  this.menuItem3});
			this.menuItem1.Text = "&File";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 0;
			this.menuItem10.Text = "&Reset Connections";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuDataBaseReg
			// 
			this.menuDataBaseReg.Index = 1;
			this.menuDataBaseReg.Text = "&New Database Registration";
			this.menuDataBaseReg.Click += new System.EventHandler(this.menuDataBaseReg_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "C&onfigure ODBC";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 3;
			this.menuItem14.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 4;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.SaveTextDelimitedMenu,
																					  this.SaveWordDocument});
			this.menuItem5.Text = "&Save";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// SaveTextDelimitedMenu
			// 
			this.SaveTextDelimitedMenu.Index = 0;
			this.SaveTextDelimitedMenu.Text = "Text Delimited";
			this.SaveTextDelimitedMenu.Click += new System.EventHandler(this.SaveTextDelimitedMenu_Click);
			// 
			// SaveWordDocument
			// 
			this.SaveWordDocument.Index = 1;
			this.SaveWordDocument.Text = "Word Document";
			this.SaveWordDocument.Click += new System.EventHandler(this.SaveWordDocument_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 5;
			this.menuItem12.Text = "-";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 6;
			this.menuItem7.Text = "P&rint Preview";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 7;
			this.menuItem2.Text = "&Print";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 8;
			this.menuItem6.Text = "P&age Setup";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 9;
			this.menuItem13.Text = "-";
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 10;
			this.menuItem20.Text = "&Hide";
			this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 11;
			this.menuItem24.Text = "-";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 12;
			this.menuItem3.Text = "&Close";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 1;
			this.menuItem8.Text = "&Help";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 2;
			this.menuItem9.Text = "&About";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItemLinks
			// 
			this.menuItemLinks.Index = 3;
			this.menuItemLinks.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.menuItemGracon,
																						  this.menuItemNovell});
			this.menuItemLinks.Text = "&Links";
			// 
			// menuItemGracon
			// 
			this.menuItemGracon.Index = 0;
			this.menuItemGracon.Text = "&Gracon Services, Inc";
			this.menuItemGracon.Click += new System.EventHandler(this.menuItemGracon_Click);
			// 
			// menuItemNovell
			// 
			this.menuItemNovell.Index = 1;
			this.menuItemNovell.Text = "&Novell";
			this.menuItemNovell.Click += new System.EventHandler(this.menuItemNovell_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 4;
			this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem15,
																					   this.menuItem16,
																					   this.menuItem17,
																					   this.menuItem18});
			this.menuItem11.Text = "&Optional";
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 0;
			this.menuItem15.Text = "&Create Optional Inventory Catalog";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 1;
			this.menuItem16.Text = "&Delete Optional Inventory Catalog";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 2;
			this.menuItem17.Text = "-";
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 3;
			this.menuItem18.Text = "&Add New Type";
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// SaveResults
			// 
			this.SaveResults.DefaultExt = "txt";
			this.SaveResults.InitialDirectory = "C:\\Program Files\\Gracon Services, Inc\\ZENWorks Query\\Saved Searches";
			this.SaveResults.Title = "Save Results";
			// 
			// printDocument1
			// 
			this.printDocument1.OriginAtMargins = true;
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// PrintPreview
			// 
			this.PrintPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.PrintPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.PrintPreview.ClientSize = new System.Drawing.Size(400, 300);
			this.PrintPreview.Enabled = true;
			this.PrintPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("PrintPreview.Icon")));
			this.PrintPreview.Location = new System.Drawing.Point(27, 30);
			this.PrintPreview.MinimumSize = new System.Drawing.Size(375, 250);
			this.PrintPreview.Name = "PrintPreview";
			this.PrintPreview.TransparencyKey = System.Drawing.Color.Empty;
			this.PrintPreview.Visible = false;
			// 
			// lblCount
			// 
			this.lblCount.Location = new System.Drawing.Point(16, 608);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(344, 23);
			this.lblCount.TabIndex = 37;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabHardware);
			this.tabControl1.Controls.Add(this.tabSoftware);
			this.tabControl1.Controls.Add(this.tabSorting);
			this.tabControl1.Controls.Add(this.tabImport);
			this.tabControl1.Controls.Add(this.tabOther);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(792, 416);
			this.tabControl1.TabIndex = 0;
			this.toolTip1.SetToolTip(this.tabControl1, "Choose how you would like searches to be sorted");
			this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabHardware
			// 
			this.tabHardware.Controls.Add(this.lstOSVersion);
			this.tabHardware.Controls.Add(this.txtSerial);
			this.tabHardware.Controls.Add(this.txtDiskSize);
			this.tabHardware.Controls.Add(this.txtVisibleMemory);
			this.tabHardware.Controls.Add(this.label2);
			this.tabHardware.Controls.Add(this.label1);
			this.tabHardware.Controls.Add(this.btnExit);
			this.tabHardware.Controls.Add(this.btnClear);
			this.tabHardware.Controls.Add(this.btnPrint);
			this.tabHardware.Controls.Add(this.btnSave);
			this.tabHardware.Controls.Add(this.lisClient);
			this.tabHardware.Controls.Add(this.chkNameWild);
			this.tabHardware.Controls.Add(this.chkSerialWildCard);
			this.tabHardware.Controls.Add(this.DiskBox);
			this.tabHardware.Controls.Add(this.MemoryBox);
			this.tabHardware.Controls.Add(this.chkClientVer);
			this.tabHardware.Controls.Add(this.btnSearch);
			this.tabHardware.Controls.Add(this.chkSerial);
			this.tabHardware.Controls.Add(this.chkComputerName);
			this.tabHardware.Controls.Add(this.chkOS);
			this.tabHardware.Controls.Add(this.chkProcessor);
			this.tabHardware.Controls.Add(this.lisOperatingSystems);
			this.tabHardware.Controls.Add(this.txtComputerName);
			this.tabHardware.Controls.Add(this.lisProcessors);
			this.tabHardware.Location = new System.Drawing.Point(4, 22);
			this.tabHardware.Name = "tabHardware";
			this.tabHardware.Size = new System.Drawing.Size(784, 390);
			this.tabHardware.TabIndex = 0;
			this.tabHardware.Text = "Hardware";
			this.tabHardware.Click += new System.EventHandler(this.tabHardware_Click);
			this.tabHardware.Enter += new System.EventHandler(this.tabHardware_Click);
			// 
			// lstOSVersion
			// 
			this.lstOSVersion.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lstOSVersion.CheckOnClick = true;
			this.lstOSVersion.Location = new System.Drawing.Point(432, 40);
			this.lstOSVersion.Name = "lstOSVersion";
			this.lstOSVersion.Size = new System.Drawing.Size(144, 154);
			this.lstOSVersion.TabIndex = 20;
			this.toolTip1.SetToolTip(this.lstOSVersion, "Select an OS Version or Service Pack");
			this.lstOSVersion.SelectedIndexChanged += new System.EventHandler(this.lstOSVersion_SelectedIndexChanged);
			// 
			// txtSerial
			// 
			this.txtSerial.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtSerial.Location = new System.Drawing.Point(8, 80);
			this.txtSerial.Name = "txtSerial";
			this.txtSerial.Size = new System.Drawing.Size(112, 20);
			this.txtSerial.TabIndex = 4;
			this.txtSerial.Text = "";
			this.toolTip1.SetToolTip(this.txtSerial, "Type Serial Number here");
			this.txtSerial.TextChanged += new System.EventHandler(this.txtSerial_TextChanged);
			// 
			// txtDiskSize
			// 
			this.txtDiskSize.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtDiskSize.Enabled = false;
			this.txtDiskSize.Location = new System.Drawing.Point(8, 360);
			this.txtDiskSize.Name = "txtDiskSize";
			this.txtDiskSize.Size = new System.Drawing.Size(112, 20);
			this.txtDiskSize.TabIndex = 17;
			this.txtDiskSize.Text = "0";
			this.toolTip1.SetToolTip(this.txtDiskSize, "Type Hard Disk storage size values in gigabites");
			// 
			// txtVisibleMemory
			// 
			this.txtVisibleMemory.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtVisibleMemory.Enabled = false;
			this.txtVisibleMemory.Location = new System.Drawing.Point(8, 224);
			this.txtVisibleMemory.Name = "txtVisibleMemory";
			this.txtVisibleMemory.Size = new System.Drawing.Size(112, 20);
			this.txtVisibleMemory.TabIndex = 11;
			this.txtVisibleMemory.Text = "0";
			this.toolTip1.SetToolTip(this.txtVisibleMemory, "Type memory values here");
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.Location = new System.Drawing.Point(128, 368);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 60;
			this.label2.Text = "in GB";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.Location = new System.Drawing.Point(128, 232);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 59;
			this.label1.Text = "in MB";
			// 
			// btnExit
			// 
			this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnExit.Location = new System.Drawing.Point(592, 344);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(136, 23);
			this.btnExit.TabIndex = 29;
			this.btnExit.Text = "&Exit";
			this.toolTip1.SetToolTip(this.btnExit, "Close program");
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnClear.Location = new System.Drawing.Point(592, 312);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(136, 23);
			this.btnClear.TabIndex = 28;
			this.btnClear.Text = "C&lear";
			this.toolTip1.SetToolTip(this.btnClear, "Clear selections");
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnPrint.Location = new System.Drawing.Point(592, 280);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(136, 23);
			this.btnPrint.TabIndex = 27;
			this.btnPrint.Text = "&Print";
			this.toolTip1.SetToolTip(this.btnPrint, "Print Hardware info");
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSave.Location = new System.Drawing.Point(592, 248);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(136, 23);
			this.btnSave.TabIndex = 26;
			this.btnSave.Text = "&Save";
			this.toolTip1.SetToolTip(this.btnSave, "Save Hardware info to a text delimited file");
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// lisClient
			// 
			this.lisClient.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lisClient.CheckOnClick = true;
			this.lisClient.HorizontalScrollbar = true;
			this.lisClient.Location = new System.Drawing.Point(584, 40);
			this.lisClient.Name = "lisClient";
			this.lisClient.Size = new System.Drawing.Size(192, 154);
			this.lisClient.Sorted = true;
			this.lisClient.TabIndex = 24;
			this.toolTip1.SetToolTip(this.lisClient, "Check which versions of Novell Client to search for");
			this.lisClient.SelectedIndexChanged += new System.EventHandler(this.lisClient_SelectedIndexChanged);
			// 
			// chkNameWild
			// 
			this.chkNameWild.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkNameWild.Location = new System.Drawing.Point(128, 32);
			this.chkNameWild.Name = "chkNameWild";
			this.chkNameWild.Size = new System.Drawing.Size(136, 24);
			this.chkNameWild.TabIndex = 2;
			this.chkNameWild.Text = "Use Wildcard (ex. *)";
			this.toolTip1.SetToolTip(this.chkNameWild, "Use * as a wild card before or after a value: example Comp% will find all values " +
				"where \'Comp\' is the first four letters");
			// 
			// chkSerialWildCard
			// 
			this.chkSerialWildCard.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkSerialWildCard.Location = new System.Drawing.Point(128, 80);
			this.chkSerialWildCard.Name = "chkSerialWildCard";
			this.chkSerialWildCard.Size = new System.Drawing.Size(144, 24);
			this.chkSerialWildCard.TabIndex = 5;
			this.chkSerialWildCard.Text = "Use Wildcard (ex. *)";
			this.toolTip1.SetToolTip(this.chkSerialWildCard, "Use * as a wild card before or after a value: example 1234% will find all values " +
				"where \'1234\' is the first four numbers");
			// 
			// DiskBox
			// 
			this.DiskBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.DiskBox.Controls.Add(this.radDiskAll);
			this.DiskBox.Controls.Add(this.radDiskGreat);
			this.DiskBox.Controls.Add(this.radDiskLess);
			this.DiskBox.Controls.Add(this.radNoDisk);
			this.DiskBox.Location = new System.Drawing.Point(8, 256);
			this.DiskBox.Name = "DiskBox";
			this.DiskBox.Size = new System.Drawing.Size(264, 96);
			this.DiskBox.TabIndex = 12;
			this.DiskBox.TabStop = false;
			// 
			// radDiskAll
			// 
			this.radDiskAll.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radDiskAll.Location = new System.Drawing.Point(8, 64);
			this.radDiskAll.Name = "radDiskAll";
			this.radDiskAll.Size = new System.Drawing.Size(120, 24);
			this.radDiskAll.TabIndex = 15;
			this.radDiskAll.Text = "Disk Size (All)";
			this.toolTip1.SetToolTip(this.radDiskAll, "Returns all Hard Disk sizes");
			this.radDiskAll.Click += new System.EventHandler(this.radDiskAll_Click);
			// 
			// radDiskGreat
			// 
			this.radDiskGreat.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radDiskGreat.Location = new System.Drawing.Point(8, 40);
			this.radDiskGreat.Name = "radDiskGreat";
			this.radDiskGreat.Size = new System.Drawing.Size(240, 24);
			this.radDiskGreat.TabIndex = 14;
			this.radDiskGreat.Text = "Disk Size (Greater than or equal to)";
			this.toolTip1.SetToolTip(this.radDiskGreat, "Searches Hard Disk sizes greater than the text box value");
			this.radDiskGreat.Click += new System.EventHandler(this.radDiskGreat_Click);
			// 
			// radDiskLess
			// 
			this.radDiskLess.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radDiskLess.Location = new System.Drawing.Point(8, 16);
			this.radDiskLess.Name = "radDiskLess";
			this.radDiskLess.Size = new System.Drawing.Size(240, 24);
			this.radDiskLess.TabIndex = 13;
			this.radDiskLess.Text = "Disk Size (Less than or equal to)";
			this.toolTip1.SetToolTip(this.radDiskLess, "Searches Hard Disk sizes less than value in text box");
			this.radDiskLess.Click += new System.EventHandler(this.radDiskLess_Click);
			// 
			// radNoDisk
			// 
			this.radNoDisk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radNoDisk.Checked = true;
			this.radNoDisk.Location = new System.Drawing.Point(136, 64);
			this.radNoDisk.Name = "radNoDisk";
			this.radNoDisk.Size = new System.Drawing.Size(120, 24);
			this.radNoDisk.TabIndex = 16;
			this.radNoDisk.TabStop = true;
			this.radNoDisk.Text = "No Disk Search";
			this.toolTip1.SetToolTip(this.radNoDisk, "Disables Hard Disk search");
			this.radNoDisk.CheckedChanged += new System.EventHandler(this.radNoDisk_CheckedChanged);
			// 
			// MemoryBox
			// 
			this.MemoryBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.MemoryBox.Controls.Add(this.radMemAll);
			this.MemoryBox.Controls.Add(this.radGreatMem);
			this.MemoryBox.Controls.Add(this.radMemLess);
			this.MemoryBox.Controls.Add(this.radNoMem);
			this.MemoryBox.Location = new System.Drawing.Point(8, 120);
			this.MemoryBox.Name = "MemoryBox";
			this.MemoryBox.Size = new System.Drawing.Size(264, 96);
			this.MemoryBox.TabIndex = 6;
			this.MemoryBox.TabStop = false;
			// 
			// radMemAll
			// 
			this.radMemAll.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radMemAll.Location = new System.Drawing.Point(8, 64);
			this.radMemAll.Name = "radMemAll";
			this.radMemAll.Size = new System.Drawing.Size(128, 24);
			this.radMemAll.TabIndex = 9;
			this.radMemAll.Text = "Visible Memory (All)";
			this.toolTip1.SetToolTip(this.radMemAll, "Searches all memory values");
			this.radMemAll.Click += new System.EventHandler(this.radMemAll_Click);
			// 
			// radGreatMem
			// 
			this.radGreatMem.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radGreatMem.Location = new System.Drawing.Point(8, 40);
			this.radGreatMem.Name = "radGreatMem";
			this.radGreatMem.Size = new System.Drawing.Size(232, 24);
			this.radGreatMem.TabIndex = 8;
			this.radGreatMem.Text = "Visible Memory (Greater than or equal to)";
			this.toolTip1.SetToolTip(this.radGreatMem, "Searches values greater than in the text box");
			this.radGreatMem.Click += new System.EventHandler(this.radGreatMem_Click);
			// 
			// radMemLess
			// 
			this.radMemLess.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radMemLess.Location = new System.Drawing.Point(8, 16);
			this.radMemLess.Name = "radMemLess";
			this.radMemLess.Size = new System.Drawing.Size(224, 24);
			this.radMemLess.TabIndex = 7;
			this.radMemLess.Text = "Visble Memory (Less than or equal to)";
			this.toolTip1.SetToolTip(this.radMemLess, "Searches for values less than value in the text box");
			this.radMemLess.Click += new System.EventHandler(this.radMemLess_Click);
			// 
			// radNoMem
			// 
			this.radNoMem.Checked = true;
			this.radNoMem.Location = new System.Drawing.Point(136, 64);
			this.radNoMem.Name = "radNoMem";
			this.radNoMem.Size = new System.Drawing.Size(120, 24);
			this.radNoMem.TabIndex = 10;
			this.radNoMem.TabStop = true;
			this.radNoMem.Text = "No Memory Search";
			this.toolTip1.SetToolTip(this.radNoMem, "Disables memory search");
			this.radNoMem.CheckedChanged += new System.EventHandler(this.radNoMem_CheckedChanged);
			// 
			// chkClientVer
			// 
			this.chkClientVer.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkClientVer.Location = new System.Drawing.Point(584, 8);
			this.chkClientVer.Name = "chkClientVer";
			this.chkClientVer.Size = new System.Drawing.Size(128, 24);
			this.chkClientVer.TabIndex = 23;
			this.chkClientVer.Text = "Novell Client Version";
			this.toolTip1.SetToolTip(this.chkClientVer, "Search Novell Client Version");
			this.chkClientVer.CheckedChanged += new System.EventHandler(this.chkClientVer_CheckedChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSearch.Location = new System.Drawing.Point(592, 216);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(136, 23);
			this.btnSearch.TabIndex = 25;
			this.btnSearch.Text = "Se&arch";
			this.toolTip1.SetToolTip(this.btnSearch, "Search Hardware info");
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// chkSerial
			// 
			this.chkSerial.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkSerial.Location = new System.Drawing.Point(8, 56);
			this.chkSerial.Name = "chkSerial";
			this.chkSerial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSerial.Size = new System.Drawing.Size(112, 24);
			this.chkSerial.TabIndex = 3;
			this.chkSerial.Text = "Serial Number*";
			this.toolTip1.SetToolTip(this.chkSerial, "Serial Number values will always display in searches. Type specific Serial Number" +
				"s in the text box");
			this.chkSerial.CheckedChanged += new System.EventHandler(this.chkSerial_CheckedChanged);
			// 
			// chkComputerName
			// 
			this.chkComputerName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkComputerName.Location = new System.Drawing.Point(8, 8);
			this.chkComputerName.Name = "chkComputerName";
			this.chkComputerName.Size = new System.Drawing.Size(120, 24);
			this.chkComputerName.TabIndex = 0;
			this.chkComputerName.Text = "Computer Name*";
			this.toolTip1.SetToolTip(this.chkComputerName, "This field will always show information under default conditions");
			this.chkComputerName.CheckedChanged += new System.EventHandler(this.chkComputerName_CheckedChanged);
			// 
			// chkOS
			// 
			this.chkOS.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkOS.Location = new System.Drawing.Point(280, 8);
			this.chkOS.Name = "chkOS";
			this.chkOS.Size = new System.Drawing.Size(136, 24);
			this.chkOS.TabIndex = 18;
			this.chkOS.Text = "Operating System";
			this.toolTip1.SetToolTip(this.chkOS, "Search Operating Systems");
			this.chkOS.CheckedChanged += new System.EventHandler(this.chkOS_CheckedChanged);
			// 
			// chkProcessor
			// 
			this.chkProcessor.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkProcessor.Location = new System.Drawing.Point(280, 208);
			this.chkProcessor.Name = "chkProcessor";
			this.chkProcessor.Size = new System.Drawing.Size(136, 24);
			this.chkProcessor.TabIndex = 21;
			this.chkProcessor.Text = "Processor Type";
			this.toolTip1.SetToolTip(this.chkProcessor, "Search Processors");
			this.chkProcessor.CheckedChanged += new System.EventHandler(this.chkProcessor_CheckedChanged);
			// 
			// lisOperatingSystems
			// 
			this.lisOperatingSystems.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lisOperatingSystems.CheckOnClick = true;
			this.lisOperatingSystems.HorizontalScrollbar = true;
			this.lisOperatingSystems.Location = new System.Drawing.Point(280, 40);
			this.lisOperatingSystems.Name = "lisOperatingSystems";
			this.lisOperatingSystems.Size = new System.Drawing.Size(152, 154);
			this.lisOperatingSystems.Sorted = true;
			this.lisOperatingSystems.TabIndex = 19;
			this.toolTip1.SetToolTip(this.lisOperatingSystems, "Check which Operating Systems to search for");
			this.lisOperatingSystems.SelectedIndexChanged += new System.EventHandler(this.lisOperatingSystems_SelectedIndexChanged);
			// 
			// txtComputerName
			// 
			this.txtComputerName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtComputerName.Location = new System.Drawing.Point(8, 32);
			this.txtComputerName.Name = "txtComputerName";
			this.txtComputerName.Size = new System.Drawing.Size(112, 20);
			this.txtComputerName.TabIndex = 1;
			this.txtComputerName.Text = "";
			this.toolTip1.SetToolTip(this.txtComputerName, "Type Computer Name values here (use % as a wild card character)");
			this.txtComputerName.TextChanged += new System.EventHandler(this.txtComputerName_TextChanged);
			// 
			// lisProcessors
			// 
			this.lisProcessors.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lisProcessors.CheckOnClick = true;
			this.lisProcessors.HorizontalScrollbar = true;
			this.lisProcessors.Location = new System.Drawing.Point(280, 240);
			this.lisProcessors.Name = "lisProcessors";
			this.lisProcessors.Size = new System.Drawing.Size(256, 139);
			this.lisProcessors.Sorted = true;
			this.lisProcessors.TabIndex = 22;
			this.toolTip1.SetToolTip(this.lisProcessors, "Check which Processors to look for");
			this.lisProcessors.SelectedIndexChanged += new System.EventHandler(this.lisProcessors_SelectedIndexChanged);
			// 
			// tabSoftware
			// 
			this.tabSoftware.Controls.Add(this.btnSelectAll);
			this.tabSoftware.Controls.Add(this.btnZ);
			this.tabSoftware.Controls.Add(this.btnX);
			this.tabSoftware.Controls.Add(this.btnV);
			this.tabSoftware.Controls.Add(this.btnR);
			this.tabSoftware.Controls.Add(this.btnSym);
			this.tabSoftware.Controls.Add(this.btnYZ);
			this.tabSoftware.Controls.Add(this.btnWX);
			this.tabSoftware.Controls.Add(this.btnUV);
			this.tabSoftware.Controls.Add(this.btnT);
			this.tabSoftware.Controls.Add(this.btnS);
			this.tabSoftware.Controls.Add(this.btnQR);
			this.tabSoftware.Controls.Add(this.btnP);
			this.tabSoftware.Controls.Add(this.btnO);
			this.tabSoftware.Controls.Add(this.btnN);
			this.tabSoftware.Controls.Add(this.btnM);
			this.tabSoftware.Controls.Add(this.btnL);
			this.tabSoftware.Controls.Add(this.btnK);
			this.tabSoftware.Controls.Add(this.btnJ);
			this.tabSoftware.Controls.Add(this.btnI);
			this.tabSoftware.Controls.Add(this.btnH);
			this.tabSoftware.Controls.Add(this.btnG);
			this.tabSoftware.Controls.Add(this.btnF);
			this.tabSoftware.Controls.Add(this.btnE);
			this.tabSoftware.Controls.Add(this.btnD);
			this.tabSoftware.Controls.Add(this.btnC);
			this.tabSoftware.Controls.Add(this.btnB);
			this.tabSoftware.Controls.Add(this.btnA);
			this.tabSoftware.Controls.Add(this.btnSymNum);
			this.tabSoftware.Controls.Add(this.btnAll);
			this.tabSoftware.Controls.Add(this.radVen);
			this.tabSoftware.Controls.Add(this.radSoft);
			this.tabSoftware.Controls.Add(this.chkWildSoftName);
			this.tabSoftware.Controls.Add(this.chkSoftwareName);
			this.tabSoftware.Controls.Add(this.txtSoftwareName);
			this.tabSoftware.Controls.Add(this.btnGoogle);
			this.tabSoftware.Controls.Add(this.chkSoftNameWild);
			this.tabSoftware.Controls.Add(this.chkSoftCompName);
			this.tabSoftware.Controls.Add(this.txtSoftCompName);
			this.tabSoftware.Controls.Add(this.chksoftChoice);
			this.tabSoftware.Controls.Add(this.btnSoftExit);
			this.tabSoftware.Controls.Add(this.btnSoftClear);
			this.tabSoftware.Controls.Add(this.btnSoftPrint);
			this.tabSoftware.Controls.Add(this.btnSoftSave);
			this.tabSoftware.Controls.Add(this.btnSoftSearch);
			this.tabSoftware.Controls.Add(this.lisSoftware);
			this.tabSoftware.Location = new System.Drawing.Point(4, 22);
			this.tabSoftware.Name = "tabSoftware";
			this.tabSoftware.Size = new System.Drawing.Size(784, 390);
			this.tabSoftware.TabIndex = 1;
			this.tabSoftware.Text = "Software";
			this.tabSoftware.Click += new System.EventHandler(this.tabSoftware_Click);
			this.tabSoftware.Enter += new System.EventHandler(this.tabSoftware_Click);
			// 
			// btnSelectAll
			// 
			this.btnSelectAll.Location = new System.Drawing.Point(184, 64);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.TabIndex = 46;
			this.btnSelectAll.Text = "Select &All";
			this.btnSelectAll.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnZ
			// 
			this.btnZ.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnZ.Location = new System.Drawing.Point(584, 360);
			this.btnZ.Name = "btnZ";
			this.btnZ.Size = new System.Drawing.Size(16, 23);
			this.btnZ.TabIndex = 45;
			this.btnZ.Text = "Z";
			this.toolTip1.SetToolTip(this.btnZ, "Select which software choices to display");
			this.btnZ.Click += new System.EventHandler(this.btnZ_Click);
			// 
			// btnX
			// 
			this.btnX.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnX.Location = new System.Drawing.Point(552, 360);
			this.btnX.Name = "btnX";
			this.btnX.Size = new System.Drawing.Size(16, 23);
			this.btnX.TabIndex = 43;
			this.btnX.Text = "X";
			this.toolTip1.SetToolTip(this.btnX, "Select which software choices to display");
			this.btnX.Click += new System.EventHandler(this.btnX_Click);
			// 
			// btnV
			// 
			this.btnV.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnV.Location = new System.Drawing.Point(512, 360);
			this.btnV.Name = "btnV";
			this.btnV.Size = new System.Drawing.Size(16, 23);
			this.btnV.TabIndex = 41;
			this.btnV.Text = "V";
			this.toolTip1.SetToolTip(this.btnV, "Select which software choices to display");
			this.btnV.Click += new System.EventHandler(this.btnV_Click);
			// 
			// btnR
			// 
			this.btnR.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnR.Location = new System.Drawing.Point(448, 360);
			this.btnR.Name = "btnR";
			this.btnR.Size = new System.Drawing.Size(16, 23);
			this.btnR.TabIndex = 37;
			this.btnR.Text = "R";
			this.toolTip1.SetToolTip(this.btnR, "Select which software choices to display");
			this.btnR.Click += new System.EventHandler(this.btnR_Click);
			// 
			// btnSym
			// 
			this.btnSym.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSym.Location = new System.Drawing.Point(128, 360);
			this.btnSym.Name = "btnSym";
			this.btnSym.Size = new System.Drawing.Size(48, 23);
			this.btnSym.TabIndex = 18;
			this.btnSym.Text = "Sym";
			this.toolTip1.SetToolTip(this.btnSym, "Select which software choices to display");
			this.btnSym.Click += new System.EventHandler(this.btnSym_Click);
			// 
			// btnYZ
			// 
			this.btnYZ.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnYZ.Location = new System.Drawing.Point(568, 360);
			this.btnYZ.Name = "btnYZ";
			this.btnYZ.Size = new System.Drawing.Size(16, 23);
			this.btnYZ.TabIndex = 44;
			this.btnYZ.Text = "Y";
			this.toolTip1.SetToolTip(this.btnYZ, "Select which software choices to display");
			this.btnYZ.Click += new System.EventHandler(this.btnYZ_Click);
			// 
			// btnWX
			// 
			this.btnWX.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnWX.Location = new System.Drawing.Point(528, 360);
			this.btnWX.Name = "btnWX";
			this.btnWX.Size = new System.Drawing.Size(24, 23);
			this.btnWX.TabIndex = 42;
			this.btnWX.Text = "W";
			this.toolTip1.SetToolTip(this.btnWX, "Select which software choices to display");
			this.btnWX.Click += new System.EventHandler(this.btnWX_Click);
			// 
			// btnUV
			// 
			this.btnUV.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnUV.Location = new System.Drawing.Point(496, 360);
			this.btnUV.Name = "btnUV";
			this.btnUV.Size = new System.Drawing.Size(16, 23);
			this.btnUV.TabIndex = 40;
			this.btnUV.Text = "U";
			this.toolTip1.SetToolTip(this.btnUV, "Select which software choices to display");
			this.btnUV.Click += new System.EventHandler(this.btnUV_Click);
			// 
			// btnT
			// 
			this.btnT.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnT.Location = new System.Drawing.Point(480, 360);
			this.btnT.Name = "btnT";
			this.btnT.Size = new System.Drawing.Size(16, 23);
			this.btnT.TabIndex = 39;
			this.btnT.Text = "T";
			this.toolTip1.SetToolTip(this.btnT, "Select which software choices to display");
			this.btnT.Click += new System.EventHandler(this.btnT_Click);
			// 
			// btnS
			// 
			this.btnS.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnS.Location = new System.Drawing.Point(464, 360);
			this.btnS.Name = "btnS";
			this.btnS.Size = new System.Drawing.Size(16, 23);
			this.btnS.TabIndex = 38;
			this.btnS.Text = "S";
			this.toolTip1.SetToolTip(this.btnS, "Select which software choices to display");
			this.btnS.Click += new System.EventHandler(this.btnS_Click);
			// 
			// btnQR
			// 
			this.btnQR.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnQR.Location = new System.Drawing.Point(432, 360);
			this.btnQR.Name = "btnQR";
			this.btnQR.Size = new System.Drawing.Size(16, 23);
			this.btnQR.TabIndex = 36;
			this.btnQR.Text = "Q";
			this.toolTip1.SetToolTip(this.btnQR, "Select which software choices to display");
			this.btnQR.Click += new System.EventHandler(this.btnQR_Click);
			// 
			// btnP
			// 
			this.btnP.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnP.Location = new System.Drawing.Point(416, 360);
			this.btnP.Name = "btnP";
			this.btnP.Size = new System.Drawing.Size(16, 23);
			this.btnP.TabIndex = 35;
			this.btnP.Text = "P";
			this.toolTip1.SetToolTip(this.btnP, "Select which software choices to display");
			this.btnP.Click += new System.EventHandler(this.btnP_Click);
			// 
			// btnO
			// 
			this.btnO.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnO.Location = new System.Drawing.Point(400, 360);
			this.btnO.Name = "btnO";
			this.btnO.Size = new System.Drawing.Size(16, 23);
			this.btnO.TabIndex = 34;
			this.btnO.Text = "O";
			this.toolTip1.SetToolTip(this.btnO, "Select which software choices to display");
			this.btnO.Click += new System.EventHandler(this.btnO_Click);
			// 
			// btnN
			// 
			this.btnN.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnN.Location = new System.Drawing.Point(384, 360);
			this.btnN.Name = "btnN";
			this.btnN.Size = new System.Drawing.Size(16, 23);
			this.btnN.TabIndex = 33;
			this.btnN.Text = "N";
			this.toolTip1.SetToolTip(this.btnN, "Select which software choices to display");
			this.btnN.Click += new System.EventHandler(this.btnN_Click);
			// 
			// btnM
			// 
			this.btnM.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnM.Location = new System.Drawing.Point(368, 360);
			this.btnM.Name = "btnM";
			this.btnM.Size = new System.Drawing.Size(16, 23);
			this.btnM.TabIndex = 32;
			this.btnM.Text = "M";
			this.toolTip1.SetToolTip(this.btnM, "Select which software choices to display");
			this.btnM.Click += new System.EventHandler(this.btnM_Click);
			// 
			// btnL
			// 
			this.btnL.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnL.Location = new System.Drawing.Point(352, 360);
			this.btnL.Name = "btnL";
			this.btnL.Size = new System.Drawing.Size(16, 23);
			this.btnL.TabIndex = 31;
			this.btnL.Text = "L";
			this.toolTip1.SetToolTip(this.btnL, "Select which software choices to display");
			this.btnL.Click += new System.EventHandler(this.btnL_Click);
			// 
			// btnK
			// 
			this.btnK.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnK.Location = new System.Drawing.Point(336, 360);
			this.btnK.Name = "btnK";
			this.btnK.Size = new System.Drawing.Size(16, 23);
			this.btnK.TabIndex = 30;
			this.btnK.Text = "K";
			this.toolTip1.SetToolTip(this.btnK, "Select which software choices to display");
			this.btnK.Click += new System.EventHandler(this.btnK_Click);
			// 
			// btnJ
			// 
			this.btnJ.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnJ.Location = new System.Drawing.Point(320, 360);
			this.btnJ.Name = "btnJ";
			this.btnJ.Size = new System.Drawing.Size(16, 23);
			this.btnJ.TabIndex = 29;
			this.btnJ.Text = "J";
			this.toolTip1.SetToolTip(this.btnJ, "Select which software choices to display");
			this.btnJ.Click += new System.EventHandler(this.btnJ_Click);
			// 
			// btnI
			// 
			this.btnI.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnI.Location = new System.Drawing.Point(304, 360);
			this.btnI.Name = "btnI";
			this.btnI.Size = new System.Drawing.Size(16, 23);
			this.btnI.TabIndex = 28;
			this.btnI.Text = "I";
			this.toolTip1.SetToolTip(this.btnI, "Select which software choices to display");
			this.btnI.Click += new System.EventHandler(this.btnI_Click);
			// 
			// btnH
			// 
			this.btnH.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnH.Location = new System.Drawing.Point(288, 360);
			this.btnH.Name = "btnH";
			this.btnH.Size = new System.Drawing.Size(16, 23);
			this.btnH.TabIndex = 27;
			this.btnH.Text = "H";
			this.toolTip1.SetToolTip(this.btnH, "Select which software choices to display");
			this.btnH.Click += new System.EventHandler(this.btnH_Click);
			// 
			// btnG
			// 
			this.btnG.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnG.Location = new System.Drawing.Point(272, 360);
			this.btnG.Name = "btnG";
			this.btnG.Size = new System.Drawing.Size(16, 23);
			this.btnG.TabIndex = 25;
			this.btnG.Text = "G";
			this.toolTip1.SetToolTip(this.btnG, "Select which software choices to display");
			this.btnG.Click += new System.EventHandler(this.btnG_Click);
			// 
			// btnF
			// 
			this.btnF.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnF.Location = new System.Drawing.Point(256, 360);
			this.btnF.Name = "btnF";
			this.btnF.Size = new System.Drawing.Size(16, 23);
			this.btnF.TabIndex = 24;
			this.btnF.Text = "F";
			this.toolTip1.SetToolTip(this.btnF, "Select which software choices to display");
			this.btnF.Click += new System.EventHandler(this.btnF_Click);
			// 
			// btnE
			// 
			this.btnE.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnE.Location = new System.Drawing.Point(240, 360);
			this.btnE.Name = "btnE";
			this.btnE.Size = new System.Drawing.Size(16, 23);
			this.btnE.TabIndex = 23;
			this.btnE.Text = "E";
			this.toolTip1.SetToolTip(this.btnE, "Select which software choices to display");
			this.btnE.Click += new System.EventHandler(this.btnE_Click);
			// 
			// btnD
			// 
			this.btnD.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnD.Location = new System.Drawing.Point(224, 360);
			this.btnD.Name = "btnD";
			this.btnD.Size = new System.Drawing.Size(16, 23);
			this.btnD.TabIndex = 22;
			this.btnD.Text = "D";
			this.toolTip1.SetToolTip(this.btnD, "Select which software choices to display");
			this.btnD.Click += new System.EventHandler(this.btnD_Click);
			// 
			// btnC
			// 
			this.btnC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnC.Location = new System.Drawing.Point(208, 360);
			this.btnC.Name = "btnC";
			this.btnC.Size = new System.Drawing.Size(16, 23);
			this.btnC.TabIndex = 21;
			this.btnC.Text = "C";
			this.toolTip1.SetToolTip(this.btnC, "Select which software choices to display");
			this.btnC.Click += new System.EventHandler(this.btnC_Click);
			// 
			// btnB
			// 
			this.btnB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnB.Location = new System.Drawing.Point(192, 360);
			this.btnB.Name = "btnB";
			this.btnB.Size = new System.Drawing.Size(16, 23);
			this.btnB.TabIndex = 20;
			this.btnB.Text = "B";
			this.toolTip1.SetToolTip(this.btnB, "Select which software choices to display");
			this.btnB.Click += new System.EventHandler(this.btnB_Click);
			// 
			// btnA
			// 
			this.btnA.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnA.Location = new System.Drawing.Point(176, 360);
			this.btnA.Name = "btnA";
			this.btnA.Size = new System.Drawing.Size(16, 23);
			this.btnA.TabIndex = 19;
			this.btnA.Text = "A";
			this.toolTip1.SetToolTip(this.btnA, "Select which software choices to display");
			this.btnA.Click += new System.EventHandler(this.btnA_Click);
			// 
			// btnSymNum
			// 
			this.btnSymNum.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSymNum.Location = new System.Drawing.Point(96, 360);
			this.btnSymNum.Name = "btnSymNum";
			this.btnSymNum.Size = new System.Drawing.Size(32, 23);
			this.btnSymNum.TabIndex = 17;
			this.btnSymNum.Text = "0-9";
			this.toolTip1.SetToolTip(this.btnSymNum, "Select which software choices to display");
			this.btnSymNum.Click += new System.EventHandler(this.btnSymNum_Click);
			// 
			// btnAll
			// 
			this.btnAll.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnAll.Location = new System.Drawing.Point(64, 360);
			this.btnAll.Name = "btnAll";
			this.btnAll.Size = new System.Drawing.Size(32, 23);
			this.btnAll.TabIndex = 16;
			this.btnAll.Text = "All";
			this.toolTip1.SetToolTip(this.btnAll, "Select which software choices to display");
			this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
			// 
			// radVen
			// 
			this.radVen.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radVen.Location = new System.Drawing.Point(176, 336);
			this.radVen.Name = "radVen";
			this.radVen.TabIndex = 15;
			this.radVen.Text = "Vendor Name";
			this.toolTip1.SetToolTip(this.radVen, "Display Software Choices by Vendor");
			// 
			// radSoft
			// 
			this.radSoft.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radSoft.Checked = true;
			this.radSoft.Location = new System.Drawing.Point(64, 336);
			this.radSoft.Name = "radSoft";
			this.radSoft.TabIndex = 14;
			this.radSoft.TabStop = true;
			this.radSoft.Text = "Software Name";
			this.toolTip1.SetToolTip(this.radSoft, "Display Software Choices by Name");
			// 
			// chkWildSoftName
			// 
			this.chkWildSoftName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkWildSoftName.Location = new System.Drawing.Point(424, 32);
			this.chkWildSoftName.Name = "chkWildSoftName";
			this.chkWildSoftName.Size = new System.Drawing.Size(128, 24);
			this.chkWildSoftName.TabIndex = 5;
			this.chkWildSoftName.Text = "Use Wildcard (ex.*)";
			this.toolTip1.SetToolTip(this.chkWildSoftName, "Use Wildcard for Software Name (*)");
			// 
			// chkSoftwareName
			// 
			this.chkSoftwareName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkSoftwareName.Location = new System.Drawing.Point(312, 8);
			this.chkSoftwareName.Name = "chkSoftwareName";
			this.chkSoftwareName.TabIndex = 3;
			this.chkSoftwareName.Text = "Software Name";
			this.toolTip1.SetToolTip(this.chkSoftwareName, "Check here to search by Software Name");
			this.chkSoftwareName.CheckedChanged += new System.EventHandler(this.chkSoftwareName_CheckedChanged);
			// 
			// txtSoftwareName
			// 
			this.txtSoftwareName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtSoftwareName.Location = new System.Drawing.Point(312, 32);
			this.txtSoftwareName.Name = "txtSoftwareName";
			this.txtSoftwareName.TabIndex = 4;
			this.txtSoftwareName.Text = "";
			this.toolTip1.SetToolTip(this.txtSoftwareName, "Search by Software Name");
			this.txtSoftwareName.TextChanged += new System.EventHandler(this.txtSoftwareName_TextChanged);
			// 
			// btnGoogle
			// 
			this.btnGoogle.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnGoogle.Location = new System.Drawing.Point(584, 16);
			this.btnGoogle.Name = "btnGoogle";
			this.btnGoogle.Size = new System.Drawing.Size(136, 23);
			this.btnGoogle.TabIndex = 8;
			this.btnGoogle.Text = "Search &Google";
			this.toolTip1.SetToolTip(this.btnGoogle, "Opens http://www.google.com in Internet Explorer");
			this.btnGoogle.Visible = false;
			this.btnGoogle.Click += new System.EventHandler(this.btnGoogle_Click);
			// 
			// chkSoftNameWild
			// 
			this.chkSoftNameWild.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkSoftNameWild.Location = new System.Drawing.Point(168, 32);
			this.chkSoftNameWild.Name = "chkSoftNameWild";
			this.chkSoftNameWild.Size = new System.Drawing.Size(136, 24);
			this.chkSoftNameWild.TabIndex = 2;
			this.chkSoftNameWild.Text = "Use Wildcard (ex. *)";
			this.toolTip1.SetToolTip(this.chkSoftNameWild, "Use * as a wild card before or after a value: example Comp% will find all values " +
				"where \'Comp\' is the first four letters");
			// 
			// chkSoftCompName
			// 
			this.chkSoftCompName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkSoftCompName.Location = new System.Drawing.Point(64, 8);
			this.chkSoftCompName.Name = "chkSoftCompName";
			this.chkSoftCompName.Size = new System.Drawing.Size(112, 24);
			this.chkSoftCompName.TabIndex = 0;
			this.chkSoftCompName.Text = "Computer Name";
			this.toolTip1.SetToolTip(this.chkSoftCompName, "Check here to search for a Computer Name");
			this.chkSoftCompName.CheckedChanged += new System.EventHandler(this.chkSoftCompName_CheckedChanged);
			// 
			// txtSoftCompName
			// 
			this.txtSoftCompName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtSoftCompName.Location = new System.Drawing.Point(64, 32);
			this.txtSoftCompName.Name = "txtSoftCompName";
			this.txtSoftCompName.Size = new System.Drawing.Size(96, 20);
			this.txtSoftCompName.TabIndex = 1;
			this.txtSoftCompName.Text = "";
			this.toolTip1.SetToolTip(this.txtSoftCompName, "Type in a Computer Name or use wildcards");
			this.txtSoftCompName.TextChanged += new System.EventHandler(this.txtSoftCompName_TextChanged);
			// 
			// chksoftChoice
			// 
			this.chksoftChoice.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chksoftChoice.Location = new System.Drawing.Point(64, 64);
			this.chksoftChoice.Name = "chksoftChoice";
			this.chksoftChoice.Size = new System.Drawing.Size(120, 24);
			this.chksoftChoice.TabIndex = 6;
			this.chksoftChoice.Text = "Software Choice";
			this.toolTip1.SetToolTip(this.chksoftChoice, "Search for a specific program");
			this.chksoftChoice.CheckedChanged += new System.EventHandler(this.chksoftChoice_CheckedChanged);
			// 
			// btnSoftExit
			// 
			this.btnSoftExit.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSoftExit.Location = new System.Drawing.Point(584, 304);
			this.btnSoftExit.Name = "btnSoftExit";
			this.btnSoftExit.Size = new System.Drawing.Size(136, 23);
			this.btnSoftExit.TabIndex = 13;
			this.btnSoftExit.Text = "&Exit";
			this.toolTip1.SetToolTip(this.btnSoftExit, "Close program");
			this.btnSoftExit.Click += new System.EventHandler(this.btnSoftExit_Click);
			// 
			// btnSoftClear
			// 
			this.btnSoftClear.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSoftClear.Location = new System.Drawing.Point(584, 272);
			this.btnSoftClear.Name = "btnSoftClear";
			this.btnSoftClear.Size = new System.Drawing.Size(136, 23);
			this.btnSoftClear.TabIndex = 12;
			this.btnSoftClear.Text = "&Clear";
			this.toolTip1.SetToolTip(this.btnSoftClear, "Clear Software Information selections");
			this.btnSoftClear.Click += new System.EventHandler(this.btnSoftClear_Click);
			// 
			// btnSoftPrint
			// 
			this.btnSoftPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSoftPrint.Location = new System.Drawing.Point(584, 240);
			this.btnSoftPrint.Name = "btnSoftPrint";
			this.btnSoftPrint.Size = new System.Drawing.Size(136, 23);
			this.btnSoftPrint.TabIndex = 11;
			this.btnSoftPrint.Text = "&Print";
			this.toolTip1.SetToolTip(this.btnSoftPrint, "Print Software Information");
			this.btnSoftPrint.Click += new System.EventHandler(this.btnSoftPrint_Click);
			// 
			// btnSoftSave
			// 
			this.btnSoftSave.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSoftSave.Location = new System.Drawing.Point(584, 208);
			this.btnSoftSave.Name = "btnSoftSave";
			this.btnSoftSave.Size = new System.Drawing.Size(136, 23);
			this.btnSoftSave.TabIndex = 10;
			this.btnSoftSave.Text = "&Save";
			this.toolTip1.SetToolTip(this.btnSoftSave, "Save Software Information in a text delimited file");
			this.btnSoftSave.Click += new System.EventHandler(this.btnSoftSave_Click);
			// 
			// btnSoftSearch
			// 
			this.btnSoftSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSoftSearch.Location = new System.Drawing.Point(584, 176);
			this.btnSoftSearch.Name = "btnSoftSearch";
			this.btnSoftSearch.Size = new System.Drawing.Size(136, 23);
			this.btnSoftSearch.TabIndex = 9;
			this.btnSoftSearch.Text = "Se&arch";
			this.toolTip1.SetToolTip(this.btnSoftSearch, "Search for Software Information");
			this.btnSoftSearch.Click += new System.EventHandler(this.btnSoftSearch_Click);
			// 
			// lisSoftware
			// 
			this.lisSoftware.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lisSoftware.CheckOnClick = true;
			this.lisSoftware.HorizontalScrollbar = true;
			this.lisSoftware.Location = new System.Drawing.Point(64, 88);
			this.lisSoftware.Name = "lisSoftware";
			this.lisSoftware.ScrollAlwaysVisible = true;
			this.lisSoftware.Size = new System.Drawing.Size(504, 244);
			this.lisSoftware.TabIndex = 7;
			this.toolTip1.SetToolTip(this.lisSoftware, "Check here for specific progams to search for");
			this.lisSoftware.SelectedIndexChanged += new System.EventHandler(this.lisSoftware_SelectedIndexChanged);
			// 
			// tabSorting
			// 
			this.tabSorting.Controls.Add(this.btnSortSearch);
			this.tabSorting.Controls.Add(this.grpSoftware);
			this.tabSorting.Controls.Add(this.grpHardware);
			this.tabSorting.Controls.Add(this.btnNoSort);
			this.tabSorting.Location = new System.Drawing.Point(4, 22);
			this.tabSorting.Name = "tabSorting";
			this.tabSorting.Size = new System.Drawing.Size(784, 390);
			this.tabSorting.TabIndex = 2;
			this.tabSorting.Text = "Sorting";
			// 
			// btnSortSearch
			// 
			this.btnSortSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSortSearch.Location = new System.Drawing.Point(368, 344);
			this.btnSortSearch.Name = "btnSortSearch";
			this.btnSortSearch.Size = new System.Drawing.Size(128, 23);
			this.btnSortSearch.TabIndex = 33;
			this.btnSortSearch.Text = "&Sort Search";
			this.toolTip1.SetToolTip(this.btnSortSearch, "Runs a search ordered by what sorting choice was selected and information from So" +
				"ftware or Hardware tabs");
			this.btnSortSearch.Click += new System.EventHandler(this.btnSortSearch_Click);
			// 
			// grpSoftware
			// 
			this.grpSoftware.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.grpSoftware.Controls.Add(this.radVerDESC);
			this.grpSoftware.Controls.Add(this.radVerASC);
			this.grpSoftware.Controls.Add(this.radVendorDESC);
			this.grpSoftware.Controls.Add(this.radVendorASC);
			this.grpSoftware.Controls.Add(this.radSoftNameDESC);
			this.grpSoftware.Controls.Add(this.radSoftNameASC);
			this.grpSoftware.Controls.Add(this.radSoftCompNameDESC);
			this.grpSoftware.Controls.Add(this.radSoftCompNameASC);
			this.grpSoftware.Location = new System.Drawing.Point(56, 248);
			this.grpSoftware.Name = "grpSoftware";
			this.grpSoftware.Size = new System.Drawing.Size(680, 80);
			this.grpSoftware.TabIndex = 1;
			this.grpSoftware.TabStop = false;
			this.grpSoftware.Text = "Computer Software";
			this.grpSoftware.Enter += new System.EventHandler(this.tabSoftware_Click);
			// 
			// radVerDESC
			// 
			this.radVerDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radVerDESC.Location = new System.Drawing.Point(504, 40);
			this.radVerDESC.Name = "radVerDESC";
			this.radVerDESC.TabIndex = 7;
			this.radVerDESC.Text = "Version DESC";
			this.toolTip1.SetToolTip(this.radVerDESC, "Choose how to sort Software results");
			this.radVerDESC.Click += new System.EventHandler(this.Software_Click);
			// 
			// radVerASC
			// 
			this.radVerASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radVerASC.Location = new System.Drawing.Point(504, 16);
			this.radVerASC.Name = "radVerASC";
			this.radVerASC.TabIndex = 6;
			this.radVerASC.Text = "Version ASC";
			this.toolTip1.SetToolTip(this.radVerASC, "Choose how to sort Software results");
			this.radVerASC.Click += new System.EventHandler(this.Software_Click);
			// 
			// radVendorDESC
			// 
			this.radVendorDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radVendorDESC.Location = new System.Drawing.Point(332, 40);
			this.radVendorDESC.Name = "radVendorDESC";
			this.radVendorDESC.TabIndex = 5;
			this.radVendorDESC.Text = "Vendor DESC";
			this.toolTip1.SetToolTip(this.radVendorDESC, "Choose how to sort Software results");
			this.radVendorDESC.Click += new System.EventHandler(this.Software_Click);
			// 
			// radVendorASC
			// 
			this.radVendorASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radVendorASC.Location = new System.Drawing.Point(332, 16);
			this.radVendorASC.Name = "radVendorASC";
			this.radVendorASC.TabIndex = 4;
			this.radVendorASC.Text = "Vendor ASC";
			this.toolTip1.SetToolTip(this.radVendorASC, "Choose how to sort Software results");
			this.radVendorASC.Click += new System.EventHandler(this.Software_Click);
			// 
			// radSoftNameDESC
			// 
			this.radSoftNameDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radSoftNameDESC.Location = new System.Drawing.Point(196, 40);
			this.radSoftNameDESC.Name = "radSoftNameDESC";
			this.radSoftNameDESC.Size = new System.Drawing.Size(136, 24);
			this.radSoftNameDESC.TabIndex = 3;
			this.radSoftNameDESC.Text = "SoftwareName DESC";
			this.toolTip1.SetToolTip(this.radSoftNameDESC, "Choose how to sort Software results");
			this.radSoftNameDESC.Click += new System.EventHandler(this.Software_Click);
			// 
			// radSoftNameASC
			// 
			this.radSoftNameASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radSoftNameASC.Location = new System.Drawing.Point(196, 16);
			this.radSoftNameASC.Name = "radSoftNameASC";
			this.radSoftNameASC.Size = new System.Drawing.Size(128, 24);
			this.radSoftNameASC.TabIndex = 2;
			this.radSoftNameASC.Text = "SoftwareName ASC";
			this.toolTip1.SetToolTip(this.radSoftNameASC, "Choose how to sort Software results");
			this.radSoftNameASC.Click += new System.EventHandler(this.Software_Click);
			// 
			// radSoftCompNameDESC
			// 
			this.radSoftCompNameDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radSoftCompNameDESC.Location = new System.Drawing.Point(52, 40);
			this.radSoftCompNameDESC.Name = "radSoftCompNameDESC";
			this.radSoftCompNameDESC.Size = new System.Drawing.Size(144, 24);
			this.radSoftCompNameDESC.TabIndex = 1;
			this.radSoftCompNameDESC.Text = "ComputerName DESC";
			this.toolTip1.SetToolTip(this.radSoftCompNameDESC, "Choose how to sort Software results");
			this.radSoftCompNameDESC.Click += new System.EventHandler(this.Software_Click);
			// 
			// radSoftCompNameASC
			// 
			this.radSoftCompNameASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radSoftCompNameASC.Location = new System.Drawing.Point(52, 16);
			this.radSoftCompNameASC.Name = "radSoftCompNameASC";
			this.radSoftCompNameASC.Size = new System.Drawing.Size(128, 24);
			this.radSoftCompNameASC.TabIndex = 0;
			this.radSoftCompNameASC.Text = "ComputerName ASC";
			this.toolTip1.SetToolTip(this.radSoftCompNameASC, "Choose how to sort Software results");
			this.radSoftCompNameASC.Click += new System.EventHandler(this.Software_Click);
			// 
			// grpHardware
			// 
			this.grpHardware.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.grpHardware.Controls.Add(this.radClientDESC);
			this.grpHardware.Controls.Add(this.radClientASC);
			this.grpHardware.Controls.Add(this.radCurrClDESC);
			this.grpHardware.Controls.Add(this.radCurrClASC);
			this.grpHardware.Controls.Add(this.radProcDESC);
			this.grpHardware.Controls.Add(this.radProcASC);
			this.grpHardware.Controls.Add(this.radFSTDESC);
			this.grpHardware.Controls.Add(this.radFSTASC);
			this.grpHardware.Controls.Add(this.radAvSizeDESC);
			this.grpHardware.Controls.Add(this.radAvSizeASC);
			this.grpHardware.Controls.Add(this.radFileSysSizeDESC);
			this.grpHardware.Controls.Add(this.radFileSysSizASC);
			this.grpHardware.Controls.Add(this.radDriveNameDESC);
			this.grpHardware.Controls.Add(this.radDriveNameASC);
			this.grpHardware.Controls.Add(this.radTotVisMemDESC);
			this.grpHardware.Controls.Add(this.radTotVisMemSizeASC);
			this.grpHardware.Controls.Add(this.radOSVerDESC);
			this.grpHardware.Controls.Add(this.radOSVerASC);
			this.grpHardware.Controls.Add(this.radOSDESC);
			this.grpHardware.Controls.Add(this.radOSASC);
			this.grpHardware.Controls.Add(this.radTAGDESC);
			this.grpHardware.Controls.Add(this.radTagASC);
			this.grpHardware.Controls.Add(this.radSerialDESC);
			this.grpHardware.Controls.Add(this.radSerialASC);
			this.grpHardware.Controls.Add(this.radModelDESC);
			this.grpHardware.Controls.Add(this.radModelASC);
			this.grpHardware.Controls.Add(this.radDescDESC);
			this.grpHardware.Controls.Add(this.radDescASC);
			this.grpHardware.Controls.Add(this.radCompNameDESC);
			this.grpHardware.Controls.Add(this.radCompNameASC);
			this.grpHardware.Controls.Add(this.radImportDESC);
			this.grpHardware.Controls.Add(this.radImportASC);
			this.grpHardware.Location = new System.Drawing.Point(56, 0);
			this.grpHardware.Name = "grpHardware";
			this.grpHardware.Size = new System.Drawing.Size(680, 248);
			this.grpHardware.TabIndex = 0;
			this.grpHardware.TabStop = false;
			this.grpHardware.Text = "Computer Hardware";
			this.grpHardware.Enter += new System.EventHandler(this.tabHardware_Click);
			// 
			// radClientDESC
			// 
			this.radClientDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radClientDESC.Location = new System.Drawing.Point(504, 208);
			this.radClientDESC.Name = "radClientDESC";
			this.radClientDESC.Size = new System.Drawing.Size(128, 24);
			this.radClientDESC.TabIndex = 31;
			this.radClientDESC.Text = "ClientVersion DESC";
			this.toolTip1.SetToolTip(this.radClientDESC, "Choose how to sort Hardware results");
			this.radClientDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radClientASC
			// 
			this.radClientASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radClientASC.Location = new System.Drawing.Point(504, 184);
			this.radClientASC.Name = "radClientASC";
			this.radClientASC.Size = new System.Drawing.Size(120, 24);
			this.radClientASC.TabIndex = 30;
			this.radClientASC.Text = "ClientVersion ASC";
			this.toolTip1.SetToolTip(this.radClientASC, "Choose how to sort Hardware results");
			this.radClientASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radCurrClDESC
			// 
			this.radCurrClDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radCurrClDESC.Location = new System.Drawing.Point(504, 152);
			this.radCurrClDESC.Name = "radCurrClDESC";
			this.radCurrClDESC.Size = new System.Drawing.Size(160, 24);
			this.radCurrClDESC.TabIndex = 29;
			this.radCurrClDESC.Text = "CurrentClockSpeed DESC";
			this.toolTip1.SetToolTip(this.radCurrClDESC, "Choose how to sort Hardware results");
			this.radCurrClDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radCurrClASC
			// 
			this.radCurrClASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radCurrClASC.Location = new System.Drawing.Point(504, 128);
			this.radCurrClASC.Name = "radCurrClASC";
			this.radCurrClASC.Size = new System.Drawing.Size(152, 24);
			this.radCurrClASC.TabIndex = 28;
			this.radCurrClASC.Text = "CurrentClockSpeed ASC";
			this.toolTip1.SetToolTip(this.radCurrClASC, "Choose how to sort Hardware results");
			this.radCurrClASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radProcDESC
			// 
			this.radProcDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radProcDESC.Location = new System.Drawing.Point(504, 40);
			this.radProcDESC.Name = "radProcDESC";
			this.radProcDESC.Size = new System.Drawing.Size(112, 24);
			this.radProcDESC.TabIndex = 25;
			this.radProcDESC.Text = "Processor DESC";
			this.toolTip1.SetToolTip(this.radProcDESC, "Choose how to sort Hardware results");
			this.radProcDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radProcASC
			// 
			this.radProcASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radProcASC.Location = new System.Drawing.Point(504, 16);
			this.radProcASC.Name = "radProcASC";
			this.radProcASC.TabIndex = 24;
			this.radProcASC.Text = "Processor ASC";
			this.toolTip1.SetToolTip(this.radProcASC, "Choose how to sort Hardware results");
			this.radProcASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radFSTDESC
			// 
			this.radFSTDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radFSTDESC.Location = new System.Drawing.Point(504, 96);
			this.radFSTDESC.Name = "radFSTDESC";
			this.radFSTDESC.Size = new System.Drawing.Size(144, 24);
			this.radFSTDESC.TabIndex = 27;
			this.radFSTDESC.Text = "FileSystemType DESC";
			this.toolTip1.SetToolTip(this.radFSTDESC, "Choose how to sort Hardware results");
			this.radFSTDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radFSTASC
			// 
			this.radFSTASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radFSTASC.Location = new System.Drawing.Point(504, 72);
			this.radFSTASC.Name = "radFSTASC";
			this.radFSTASC.Size = new System.Drawing.Size(136, 24);
			this.radFSTASC.TabIndex = 26;
			this.radFSTASC.Text = "FileSystemType ASC";
			this.toolTip1.SetToolTip(this.radFSTASC, "Choose how to sort Hardware results");
			this.radFSTASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radAvSizeDESC
			// 
			this.radAvSizeDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radAvSizeDESC.Location = new System.Drawing.Point(332, 208);
			this.radAvSizeDESC.Name = "radAvSizeDESC";
			this.radAvSizeDESC.Size = new System.Drawing.Size(136, 24);
			this.radAvSizeDESC.TabIndex = 23;
			this.radAvSizeDESC.Text = "AvailableSpace DESC";
			this.toolTip1.SetToolTip(this.radAvSizeDESC, "Choose how to sort Hardware results");
			this.radAvSizeDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radAvSizeASC
			// 
			this.radAvSizeASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radAvSizeASC.Location = new System.Drawing.Point(332, 184);
			this.radAvSizeASC.Name = "radAvSizeASC";
			this.radAvSizeASC.Size = new System.Drawing.Size(128, 24);
			this.radAvSizeASC.TabIndex = 22;
			this.radAvSizeASC.Text = "AvailableSpace ASC";
			this.toolTip1.SetToolTip(this.radAvSizeASC, "Choose how to sort Hardware results");
			this.radAvSizeASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radFileSysSizeDESC
			// 
			this.radFileSysSizeDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radFileSysSizeDESC.Location = new System.Drawing.Point(332, 152);
			this.radFileSysSizeDESC.Name = "radFileSysSizeDESC";
			this.radFileSysSizeDESC.Size = new System.Drawing.Size(136, 24);
			this.radFileSysSizeDESC.TabIndex = 21;
			this.radFileSysSizeDESC.Text = "FileSystemSize DESC";
			this.toolTip1.SetToolTip(this.radFileSysSizeDESC, "Choose how to sort Hardware results");
			this.radFileSysSizeDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radFileSysSizASC
			// 
			this.radFileSysSizASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radFileSysSizASC.Location = new System.Drawing.Point(332, 128);
			this.radFileSysSizASC.Name = "radFileSysSizASC";
			this.radFileSysSizASC.Size = new System.Drawing.Size(144, 24);
			this.radFileSysSizASC.TabIndex = 20;
			this.radFileSysSizASC.Text = "FileSystemSize ASC";
			this.toolTip1.SetToolTip(this.radFileSysSizASC, "Choose how to sort Hardware results");
			this.radFileSysSizASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radDriveNameDESC
			// 
			this.radDriveNameDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radDriveNameDESC.Location = new System.Drawing.Point(332, 96);
			this.radDriveNameDESC.Name = "radDriveNameDESC";
			this.radDriveNameDESC.Size = new System.Drawing.Size(128, 24);
			this.radDriveNameDESC.TabIndex = 19;
			this.radDriveNameDESC.Text = "DriveLetter DESC";
			this.toolTip1.SetToolTip(this.radDriveNameDESC, "Choose how to sort Hardware results");
			this.radDriveNameDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radDriveNameASC
			// 
			this.radDriveNameASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radDriveNameASC.Location = new System.Drawing.Point(332, 72);
			this.radDriveNameASC.Name = "radDriveNameASC";
			this.radDriveNameASC.Size = new System.Drawing.Size(120, 24);
			this.radDriveNameASC.TabIndex = 18;
			this.radDriveNameASC.Text = "DriveLetter ASC";
			this.toolTip1.SetToolTip(this.radDriveNameASC, "Choose how to sort Hardware results");
			this.radDriveNameASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radTotVisMemDESC
			// 
			this.radTotVisMemDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radTotVisMemDESC.Location = new System.Drawing.Point(332, 40);
			this.radTotVisMemDESC.Name = "radTotVisMemDESC";
			this.radTotVisMemDESC.Size = new System.Drawing.Size(184, 24);
			this.radTotVisMemDESC.TabIndex = 17;
			this.radTotVisMemDESC.Text = "TotalVisibleMemorySize DESC";
			this.toolTip1.SetToolTip(this.radTotVisMemDESC, "Choose how to sort Hardware results");
			this.radTotVisMemDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radTotVisMemSizeASC
			// 
			this.radTotVisMemSizeASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radTotVisMemSizeASC.Location = new System.Drawing.Point(332, 16);
			this.radTotVisMemSizeASC.Name = "radTotVisMemSizeASC";
			this.radTotVisMemSizeASC.Size = new System.Drawing.Size(176, 24);
			this.radTotVisMemSizeASC.TabIndex = 16;
			this.radTotVisMemSizeASC.Text = "TotalVisibleMemorySize ASC";
			this.toolTip1.SetToolTip(this.radTotVisMemSizeASC, "Choose how to sort Hardware results");
			this.radTotVisMemSizeASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radOSVerDESC
			// 
			this.radOSVerDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radOSVerDESC.Location = new System.Drawing.Point(196, 208);
			this.radOSVerDESC.Name = "radOSVerDESC";
			this.radOSVerDESC.Size = new System.Drawing.Size(112, 24);
			this.radOSVerDESC.TabIndex = 15;
			this.radOSVerDESC.Text = "OSVersion DESC";
			this.toolTip1.SetToolTip(this.radOSVerDESC, "Choose how to sort Hardware results");
			this.radOSVerDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radOSVerASC
			// 
			this.radOSVerASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radOSVerASC.Location = new System.Drawing.Point(196, 184);
			this.radOSVerASC.Name = "radOSVerASC";
			this.radOSVerASC.TabIndex = 14;
			this.radOSVerASC.Text = "OSVersion ASC";
			this.toolTip1.SetToolTip(this.radOSVerASC, "Choose how to sort Hardware results");
			this.radOSVerASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radOSDESC
			// 
			this.radOSDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radOSDESC.Location = new System.Drawing.Point(196, 152);
			this.radOSDESC.Name = "radOSDESC";
			this.radOSDESC.TabIndex = 13;
			this.radOSDESC.Text = "OS DESC";
			this.toolTip1.SetToolTip(this.radOSDESC, "Choose how to sort Hardware results");
			this.radOSDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radOSASC
			// 
			this.radOSASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radOSASC.Location = new System.Drawing.Point(196, 128);
			this.radOSASC.Name = "radOSASC";
			this.radOSASC.TabIndex = 12;
			this.radOSASC.Text = "OS ASC";
			this.toolTip1.SetToolTip(this.radOSASC, "Choose how to sort Hardware results");
			this.radOSASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radTAGDESC
			// 
			this.radTAGDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radTAGDESC.Location = new System.Drawing.Point(196, 96);
			this.radTAGDESC.Name = "radTAGDESC";
			this.radTAGDESC.TabIndex = 11;
			this.radTAGDESC.Text = "Tag DESC";
			this.toolTip1.SetToolTip(this.radTAGDESC, "Choose how to sort Hardware results");
			this.radTAGDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radTagASC
			// 
			this.radTagASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radTagASC.Location = new System.Drawing.Point(196, 72);
			this.radTagASC.Name = "radTagASC";
			this.radTagASC.TabIndex = 10;
			this.radTagASC.Text = "Tag ASC";
			this.toolTip1.SetToolTip(this.radTagASC, "Choose how to sort Hardware results");
			this.radTagASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radSerialDESC
			// 
			this.radSerialDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radSerialDESC.Location = new System.Drawing.Point(196, 40);
			this.radSerialDESC.Name = "radSerialDESC";
			this.radSerialDESC.Size = new System.Drawing.Size(128, 24);
			this.radSerialDESC.TabIndex = 9;
			this.radSerialDESC.Text = "SerialNumber DESC";
			this.toolTip1.SetToolTip(this.radSerialDESC, "Choose how to sort Hardware results");
			this.radSerialDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radSerialASC
			// 
			this.radSerialASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radSerialASC.Location = new System.Drawing.Point(196, 16);
			this.radSerialASC.Name = "radSerialASC";
			this.radSerialASC.Size = new System.Drawing.Size(120, 24);
			this.radSerialASC.TabIndex = 8;
			this.radSerialASC.Text = "SerialNumber ASC";
			this.toolTip1.SetToolTip(this.radSerialASC, "Choose how to sort Hardware results");
			this.radSerialASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radModelDESC
			// 
			this.radModelDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radModelDESC.Location = new System.Drawing.Point(52, 208);
			this.radModelDESC.Name = "radModelDESC";
			this.radModelDESC.TabIndex = 7;
			this.radModelDESC.Text = "Model DESC";
			this.toolTip1.SetToolTip(this.radModelDESC, "Choose how to sort Hardware results");
			this.radModelDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radModelASC
			// 
			this.radModelASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radModelASC.Location = new System.Drawing.Point(52, 184);
			this.radModelASC.Name = "radModelASC";
			this.radModelASC.TabIndex = 6;
			this.radModelASC.Text = "Model ASC";
			this.toolTip1.SetToolTip(this.radModelASC, "Choose how to sort Hardware results");
			this.radModelASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radDescDESC
			// 
			this.radDescDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radDescDESC.Location = new System.Drawing.Point(52, 152);
			this.radDescDESC.Name = "radDescDESC";
			this.radDescDESC.Size = new System.Drawing.Size(120, 24);
			this.radDescDESC.TabIndex = 5;
			this.radDescDESC.Text = "Description DESC";
			this.toolTip1.SetToolTip(this.radDescDESC, "Choose how to sort Hardware results");
			this.radDescDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radDescASC
			// 
			this.radDescASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radDescASC.Location = new System.Drawing.Point(52, 128);
			this.radDescASC.Name = "radDescASC";
			this.radDescASC.Size = new System.Drawing.Size(112, 24);
			this.radDescASC.TabIndex = 4;
			this.radDescASC.Text = "Description ASC";
			this.toolTip1.SetToolTip(this.radDescASC, "Choose how to sort Hardware results");
			this.radDescASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radCompNameDESC
			// 
			this.radCompNameDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radCompNameDESC.Location = new System.Drawing.Point(52, 96);
			this.radCompNameDESC.Name = "radCompNameDESC";
			this.radCompNameDESC.Size = new System.Drawing.Size(152, 24);
			this.radCompNameDESC.TabIndex = 3;
			this.radCompNameDESC.Text = "ComputerName DESC";
			this.toolTip1.SetToolTip(this.radCompNameDESC, "Choose how to sort Hardware results");
			this.radCompNameDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radCompNameASC
			// 
			this.radCompNameASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radCompNameASC.Location = new System.Drawing.Point(52, 72);
			this.radCompNameASC.Name = "radCompNameASC";
			this.radCompNameASC.Size = new System.Drawing.Size(128, 24);
			this.radCompNameASC.TabIndex = 2;
			this.radCompNameASC.Text = "ComputerName ASC";
			this.toolTip1.SetToolTip(this.radCompNameASC, "Choose how to sort Hardware results");
			this.radCompNameASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radImportDESC
			// 
			this.radImportDESC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radImportDESC.Location = new System.Drawing.Point(52, 40);
			this.radImportDESC.Name = "radImportDESC";
			this.radImportDESC.Size = new System.Drawing.Size(120, 24);
			this.radImportDESC.TabIndex = 1;
			this.radImportDESC.Text = "ImportedAs DESC";
			this.toolTip1.SetToolTip(this.radImportDESC, "Choose how to sort Hardware results");
			this.radImportDESC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// radImportASC
			// 
			this.radImportASC.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radImportASC.Location = new System.Drawing.Point(52, 16);
			this.radImportASC.Name = "radImportASC";
			this.radImportASC.Size = new System.Drawing.Size(109, 24);
			this.radImportASC.TabIndex = 0;
			this.radImportASC.Text = "ImportedAs ASC";
			this.toolTip1.SetToolTip(this.radImportASC, "Choose how to sort Hardware results");
			this.radImportASC.Click += new System.EventHandler(this.Hardware_Click);
			// 
			// btnNoSort
			// 
			this.btnNoSort.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnNoSort.Location = new System.Drawing.Point(512, 344);
			this.btnNoSort.Name = "btnNoSort";
			this.btnNoSort.Size = new System.Drawing.Size(120, 23);
			this.btnNoSort.TabIndex = 34;
			this.btnNoSort.Text = "&No Sorting";
			this.toolTip1.SetToolTip(this.btnNoSort, "Disables sorting");
			this.btnNoSort.Click += new System.EventHandler(this.btnNoSort_Click);
			// 
			// tabImport
			// 
			this.tabImport.Controls.Add(this.lblImportList);
			this.tabImport.Controls.Add(this.dgImport);
			this.tabImport.Location = new System.Drawing.Point(4, 22);
			this.tabImport.Name = "tabImport";
			this.tabImport.Size = new System.Drawing.Size(784, 390);
			this.tabImport.TabIndex = 3;
			this.tabImport.Text = "Import List";
			// 
			// lblImportList
			// 
			this.lblImportList.Location = new System.Drawing.Point(56, 360);
			this.lblImportList.Name = "lblImportList";
			this.lblImportList.Size = new System.Drawing.Size(440, 23);
			this.lblImportList.TabIndex = 1;
			// 
			// dgImport
			// 
			this.dgImport.AllowSorting = false;
			this.dgImport.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dgImport.CaptionText = "Imported Computers";
			this.dgImport.DataMember = "";
			this.dgImport.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgImport.Location = new System.Drawing.Point(96, 16);
			this.dgImport.Name = "dgImport";
			this.dgImport.PreferredColumnWidth = 590;
			this.dgImport.ReadOnly = true;
			this.dgImport.Size = new System.Drawing.Size(592, 336);
			this.dgImport.TabIndex = 0;
			this.dgImport.TabStop = false;
			this.toolTip1.SetToolTip(this.dgImport, "Listed known imported computers");
			// 
			// tabOther
			// 
			this.tabOther.Controls.Add(this.label13);
			this.tabOther.Controls.Add(this.txtRMNum);
			this.tabOther.Controls.Add(this.groupBox1);
			this.tabOther.Controls.Add(this.btnSaveInv);
			this.tabOther.Controls.Add(this.btnClearInv);
			this.tabOther.Controls.Add(this.btnPrintInv);
			this.tabOther.Controls.Add(this.lstType);
			this.tabOther.Controls.Add(this.txtMFG);
			this.tabOther.Controls.Add(this.label11);
			this.tabOther.Controls.Add(this.btnDelete);
			this.tabOther.Controls.Add(this.btnUpdate);
			this.tabOther.Controls.Add(this.btnAdd);
			this.tabOther.Controls.Add(this.txtNotes);
			this.tabOther.Controls.Add(this.label10);
			this.tabOther.Controls.Add(this.label9);
			this.tabOther.Controls.Add(this.radInactive);
			this.tabOther.Controls.Add(this.radActive);
			this.tabOther.Controls.Add(this.label8);
			this.tabOther.Controls.Add(this.txtCurrentLocation);
			this.tabOther.Controls.Add(this.label7);
			this.tabOther.Controls.Add(this.txtSerialnum);
			this.tabOther.Controls.Add(this.label6);
			this.tabOther.Controls.Add(this.txtInstalledDate);
			this.tabOther.Controls.Add(this.label5);
			this.tabOther.Controls.Add(this.label4);
			this.tabOther.Controls.Add(this.label3);
			this.tabOther.Controls.Add(this.txtName);
			this.tabOther.Controls.Add(this.txtDescription);
			this.tabOther.Location = new System.Drawing.Point(4, 22);
			this.tabOther.Name = "tabOther";
			this.tabOther.Size = new System.Drawing.Size(784, 390);
			this.tabOther.TabIndex = 4;
			this.tabOther.Text = "Other Inventory";
			this.tabOther.Click += new System.EventHandler(this.tabOther_Click);
			// 
			// label13
			// 
			this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label13.Location = new System.Drawing.Point(224, 352);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(32, 23);
			this.label13.TabIndex = 70;
			this.label13.Text = "Rm #";
			// 
			// txtRMNum
			// 
			this.txtRMNum.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtRMNum.Location = new System.Drawing.Point(264, 352);
			this.txtRMNum.Name = "txtRMNum";
			this.txtRMNum.Size = new System.Drawing.Size(40, 20);
			this.txtRMNum.TabIndex = 7;
			this.txtRMNum.Text = "";
			this.toolTip1.SetToolTip(this.txtRMNum, "Current location: Room");
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox1.Controls.Add(this.chkWildSerial);
			this.groupBox1.Controls.Add(this.chkWildRoom);
			this.groupBox1.Controls.Add(this.chkWildBuild);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.txtSortSerial);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.txtSortRoom);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.txtSortBuilding);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.btnInventory);
			this.groupBox1.Controls.Add(this.lstSortInv);
			this.groupBox1.Controls.Add(this.btnSortInv);
			this.groupBox1.Controls.Add(this.btnNoInvSort);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(696, 136);
			this.groupBox1.TabIndex = 68;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Optional Inventory ";
			// 
			// chkWildSerial
			// 
			this.chkWildSerial.Location = new System.Drawing.Point(344, 64);
			this.chkWildSerial.Name = "chkWildSerial";
			this.chkWildSerial.TabIndex = 22;
			this.chkWildSerial.Text = "Use Wildcard";
			this.toolTip1.SetToolTip(this.chkWildSerial, "Use Wildcard (%)");
			// 
			// chkWildRoom
			// 
			this.chkWildRoom.Location = new System.Drawing.Point(424, 24);
			this.chkWildRoom.Name = "chkWildRoom";
			this.chkWildRoom.TabIndex = 20;
			this.chkWildRoom.Text = "Use Wildcard";
			this.toolTip1.SetToolTip(this.chkWildRoom, "Sort by Wildcard(%)");
			// 
			// chkWildBuild
			// 
			this.chkWildBuild.Location = new System.Drawing.Point(216, 24);
			this.chkWildBuild.Name = "chkWildBuild";
			this.chkWildBuild.TabIndex = 18;
			this.chkWildBuild.Text = "Use Wildcard";
			this.toolTip1.SetToolTip(this.chkWildBuild, "Use Wildcard (%)");
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 64);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(80, 23);
			this.label17.TabIndex = 69;
			this.label17.Text = "Serial Number:";
			// 
			// txtSortSerial
			// 
			this.txtSortSerial.Location = new System.Drawing.Point(88, 64);
			this.txtSortSerial.Name = "txtSortSerial";
			this.txtSortSerial.Size = new System.Drawing.Size(248, 20);
			this.txtSortSerial.TabIndex = 21;
			this.txtSortSerial.Text = "";
			this.toolTip1.SetToolTip(this.txtSortSerial, "Sort by Serial Number");
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(328, 24);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(40, 23);
			this.label16.TabIndex = 67;
			this.label16.Text = "Room:";
			// 
			// txtSortRoom
			// 
			this.txtSortRoom.Location = new System.Drawing.Point(368, 24);
			this.txtSortRoom.Name = "txtSortRoom";
			this.txtSortRoom.Size = new System.Drawing.Size(48, 20);
			this.txtSortRoom.TabIndex = 19;
			this.txtSortRoom.Text = "";
			this.toolTip1.SetToolTip(this.txtSortRoom, "Sort by Room");
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 24);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(48, 23);
			this.label15.TabIndex = 65;
			this.label15.Text = "Building:";
			// 
			// txtSortBuilding
			// 
			this.txtSortBuilding.Location = new System.Drawing.Point(56, 24);
			this.txtSortBuilding.Name = "txtSortBuilding";
			this.txtSortBuilding.Size = new System.Drawing.Size(152, 20);
			this.txtSortBuilding.TabIndex = 17;
			this.txtSortBuilding.Text = "";
			this.toolTip1.SetToolTip(this.txtSortBuilding, "Sort by Building");
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 96);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(40, 23);
			this.label14.TabIndex = 63;
			this.label14.Text = "Type:";
			// 
			// btnInventory
			// 
			this.btnInventory.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnInventory.Location = new System.Drawing.Point(364, 96);
			this.btnInventory.Name = "btnInventory";
			this.btnInventory.Size = new System.Drawing.Size(316, 23);
			this.btnInventory.TabIndex = 26;
			this.btnInventory.Text = "&View Inventory";
			this.toolTip1.SetToolTip(this.btnInventory, "View entire Inventory Database");
			this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
			// 
			// lstSortInv
			// 
			this.lstSortInv.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lstSortInv.Items.AddRange(new object[] {
															""});
			this.lstSortInv.Location = new System.Drawing.Point(52, 96);
			this.lstSortInv.Name = "lstSortInv";
			this.lstSortInv.Size = new System.Drawing.Size(248, 20);
			this.lstSortInv.TabIndex = 23;
			this.toolTip1.SetToolTip(this.lstSortInv, "Sort by Type");
			// 
			// btnSortInv
			// 
			this.btnSortInv.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSortInv.Location = new System.Drawing.Point(528, 24);
			this.btnSortInv.Name = "btnSortInv";
			this.btnSortInv.TabIndex = 24;
			this.btnSortInv.Text = "S&ort";
			this.toolTip1.SetToolTip(this.btnSortInv, "Sort Search");
			this.btnSortInv.Click += new System.EventHandler(this.btnSortInv_Click);
			// 
			// btnNoInvSort
			// 
			this.btnNoInvSort.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnNoInvSort.Location = new System.Drawing.Point(608, 24);
			this.btnNoInvSort.Name = "btnNoInvSort";
			this.btnNoInvSort.TabIndex = 25;
			this.btnNoInvSort.Text = "&No Sort";
			this.toolTip1.SetToolTip(this.btnNoInvSort, "No Sort Search");
			this.btnNoInvSort.Click += new System.EventHandler(this.btnNoInvSort_Click);
			// 
			// btnSaveInv
			// 
			this.btnSaveInv.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSaveInv.Location = new System.Drawing.Point(344, 160);
			this.btnSaveInv.Name = "btnSaveInv";
			this.btnSaveInv.Size = new System.Drawing.Size(80, 23);
			this.btnSaveInv.TabIndex = 14;
			this.btnSaveInv.Text = "&Save";
			this.toolTip1.SetToolTip(this.btnSaveInv, "Save results");
			this.btnSaveInv.Click += new System.EventHandler(this.btnSaveInv_Click);
			// 
			// btnClearInv
			// 
			this.btnClearInv.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnClearInv.Location = new System.Drawing.Point(552, 160);
			this.btnClearInv.Name = "btnClearInv";
			this.btnClearInv.Size = new System.Drawing.Size(80, 23);
			this.btnClearInv.TabIndex = 16;
			this.btnClearInv.Text = "&Clear";
			this.toolTip1.SetToolTip(this.btnClearInv, "Clear fields");
			this.btnClearInv.Click += new System.EventHandler(this.btnClearInv_Click);
			// 
			// btnPrintInv
			// 
			this.btnPrintInv.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnPrintInv.Location = new System.Drawing.Point(448, 160);
			this.btnPrintInv.Name = "btnPrintInv";
			this.btnPrintInv.Size = new System.Drawing.Size(80, 23);
			this.btnPrintInv.TabIndex = 15;
			this.btnPrintInv.Text = "&Print";
			this.toolTip1.SetToolTip(this.btnPrintInv, "Print results");
			this.btnPrintInv.Click += new System.EventHandler(this.btnPrintInv_Click);
			// 
			// lstType
			// 
			this.lstType.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lstType.Location = new System.Drawing.Point(352, 208);
			this.lstType.Name = "lstType";
			this.lstType.Size = new System.Drawing.Size(328, 20);
			this.lstType.TabIndex = 8;
			this.toolTip1.SetToolTip(this.lstType, "Item Type");
			// 
			// txtMFG
			// 
			this.txtMFG.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtMFG.Location = new System.Drawing.Point(88, 256);
			this.txtMFG.Name = "txtMFG";
			this.txtMFG.Size = new System.Drawing.Size(216, 20);
			this.txtMFG.TabIndex = 3;
			this.txtMFG.Text = "";
			this.toolTip1.SetToolTip(this.txtMFG, "Item manufacturer");
			// 
			// label11
			// 
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label11.Location = new System.Drawing.Point(8, 256);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 23);
			this.label11.TabIndex = 58;
			this.label11.Text = "Manufacturer:";
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(240, 160);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(80, 23);
			this.btnDelete.TabIndex = 13;
			this.btnDelete.Text = "&Delete";
			this.toolTip1.SetToolTip(this.btnDelete, "Delete existing record");
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnUpdate.Enabled = false;
			this.btnUpdate.Location = new System.Drawing.Point(136, 160);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(80, 23);
			this.btnUpdate.TabIndex = 12;
			this.btnUpdate.Text = "&Update";
			this.toolTip1.SetToolTip(this.btnUpdate, "Update existing record");
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnAdd.Location = new System.Drawing.Point(32, 160);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(80, 23);
			this.btnAdd.TabIndex = 11;
			this.btnAdd.Text = "&Add";
			this.toolTip1.SetToolTip(this.btnAdd, "Add new record");
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtNotes
			// 
			this.txtNotes.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtNotes.Location = new System.Drawing.Point(352, 288);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtNotes.Size = new System.Drawing.Size(328, 88);
			this.txtNotes.TabIndex = 10;
			this.txtNotes.Text = "";
			this.toolTip1.SetToolTip(this.txtNotes, "Item Notes");
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label10.Location = new System.Drawing.Point(312, 288);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 23);
			this.label10.TabIndex = 52;
			this.label10.Text = "Notes:";
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label9.Location = new System.Drawing.Point(312, 208);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 23);
			this.label9.TabIndex = 50;
			this.label9.Text = "Type:";
			// 
			// radInactive
			// 
			this.radInactive.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radInactive.Location = new System.Drawing.Point(112, 232);
			this.radInactive.Name = "radInactive";
			this.radInactive.Size = new System.Drawing.Size(64, 24);
			this.radInactive.TabIndex = 2;
			this.radInactive.Text = "Inactive";
			this.toolTip1.SetToolTip(this.radInactive, "Item Status");
			// 
			// radActive
			// 
			this.radActive.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radActive.Checked = true;
			this.radActive.Location = new System.Drawing.Point(56, 232);
			this.radActive.Name = "radActive";
			this.radActive.Size = new System.Drawing.Size(56, 24);
			this.radActive.TabIndex = 1;
			this.radActive.TabStop = true;
			this.radActive.Text = "Active";
			this.toolTip1.SetToolTip(this.radActive, "Item Status");
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label8.Location = new System.Drawing.Point(8, 232);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 23);
			this.label8.TabIndex = 47;
			this.label8.Text = "Status:";
			// 
			// txtCurrentLocation
			// 
			this.txtCurrentLocation.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtCurrentLocation.Location = new System.Drawing.Point(64, 352);
			this.txtCurrentLocation.Name = "txtCurrentLocation";
			this.txtCurrentLocation.Size = new System.Drawing.Size(152, 20);
			this.txtCurrentLocation.TabIndex = 6;
			this.txtCurrentLocation.Text = "";
			this.toolTip1.SetToolTip(this.txtCurrentLocation, "Current location: Building");
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label7.Location = new System.Drawing.Point(8, 352);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 23);
			this.label7.TabIndex = 45;
			this.label7.Text = "Building:";
			// 
			// txtSerialnum
			// 
			this.txtSerialnum.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtSerialnum.Location = new System.Drawing.Point(88, 288);
			this.txtSerialnum.Name = "txtSerialnum";
			this.txtSerialnum.Size = new System.Drawing.Size(216, 20);
			this.txtSerialnum.TabIndex = 4;
			this.txtSerialnum.Text = "";
			this.toolTip1.SetToolTip(this.txtSerialnum, "Item Serial Number");
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label6.Location = new System.Drawing.Point(8, 288);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 43;
			this.label6.Text = "Serial Number:";
			// 
			// txtInstalledDate
			// 
			this.txtInstalledDate.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtInstalledDate.Location = new System.Drawing.Point(64, 320);
			this.txtInstalledDate.Name = "txtInstalledDate";
			this.txtInstalledDate.Size = new System.Drawing.Size(240, 20);
			this.txtInstalledDate.TabIndex = 5;
			this.txtInstalledDate.Text = "";
			this.toolTip1.SetToolTip(this.txtInstalledDate, "Date Installed");
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label5.Location = new System.Drawing.Point(8, 320);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 23);
			this.label5.TabIndex = 41;
			this.label5.Text = "Installed:";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label4.Location = new System.Drawing.Point(312, 240);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 40;
			this.label4.Text = "Description: ";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.Location = new System.Drawing.Point(8, 208);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "Name:";
			// 
			// txtName
			// 
			this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtName.Location = new System.Drawing.Point(48, 208);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(256, 20);
			this.txtName.TabIndex = 0;
			this.txtName.Text = "";
			this.toolTip1.SetToolTip(this.txtName, "Item name");
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtDescription.Location = new System.Drawing.Point(376, 240);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescription.Size = new System.Drawing.Size(304, 40);
			this.txtDescription.TabIndex = 9;
			this.txtDescription.Text = "";
			this.toolTip1.SetToolTip(this.txtDescription, "Item Description");
			// 
			// dgInventory
			// 
			this.dgInventory.AllowNavigation = false;
			this.dgInventory.AllowSorting = false;
			this.dgInventory.CaptionText = "Inventory";
			this.dgInventory.DataMember = "";
			this.dgInventory.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgInventory.Location = new System.Drawing.Point(14, 424);
			this.dgInventory.Name = "dgInventory";
			this.dgInventory.ReadOnly = true;
			this.dgInventory.Size = new System.Drawing.Size(680, 168);
			this.dgInventory.TabIndex = 57;
			this.toolTip1.SetToolTip(this.dgInventory, "Inventory results");
			this.dgInventory.Visible = false;
			this.dgInventory.DoubleClick += new System.EventHandler(this.dgInventory_Click);
			// 
			// dgSoftware
			// 
			this.dgSoftware.CaptionText = "Software Search Results";
			this.dgSoftware.DataMember = "";
			this.dgSoftware.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgSoftware.Location = new System.Drawing.Point(14, 424);
			this.dgSoftware.Name = "dgSoftware";
			this.dgSoftware.PreferredColumnWidth = 145;
			this.dgSoftware.ReadOnly = true;
			this.dgSoftware.Size = new System.Drawing.Size(680, 168);
			this.dgSoftware.TabIndex = 38;
			this.toolTip1.SetToolTip(this.dgSoftware, "Software results");
			this.dgSoftware.Visible = false;
			// 
			// SaveWordDoc
			// 
			this.SaveWordDoc.DefaultExt = "doc";
			this.SaveWordDoc.InitialDirectory = "C:\\Program Files\\Gracon Services, Inc\\ZENWorks Query\\Saved Searches";
			this.SaveWordDoc.Title = "Save Results as Word Document";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(808, 651);
			this.Controls.Add(this.dgSoftware);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.lblCount);
			this.Controls.Add(this.dgResults);
			this.Controls.Add(this.dgInventory);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.MinimumSize = new System.Drawing.Size(816, 685);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ZENWorks Query";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabHardware.ResumeLayout(false);
			this.DiskBox.ResumeLayout(false);
			this.MemoryBox.ResumeLayout(false);
			this.tabSoftware.ResumeLayout(false);
			this.tabSorting.ResumeLayout(false);
			this.grpSoftware.ResumeLayout(false);
			this.grpHardware.ResumeLayout(false);
			this.tabImport.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgImport)).EndInit();
			this.tabOther.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgInventory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSoftware)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void ReadOS()
		{
			try//newer try
			{
				string HoldOther;
				if(this.lisOperatingSystems.CheckedItems.Count != 0)
				{
			
					if((this.lisOperatingSystems.CheckedItems[0].ToString() == "WIN98") ||(this.lisOperatingSystems.CheckedItems[0].ToString()=="Microsoft Windows 98")||(this.lisOperatingSystems.CheckedItems[0].ToString()=="Windows 98"))
					{
						this.queryAddOn = this.queryAddOn + " AND (CIM.OperatingSystem.Caption LIKE '%98' OR CIM.OperatingSystem.Description LIKE '%98'"; 
					}
					else
					{
						if((this.lisOperatingSystems.CheckedItems[0].ToString() == "WIN95")||(this.lisOperatingSystems.CheckedItems[0].ToString() == "Microsoft Windows 95")||(this.lisOperatingSystems.CheckedItems[0].ToString() == "Windows 95"))
						{
							this.queryAddOn = this.queryAddOn + " AND (CIM.OperatingSystem.Caption LIKE '%95' OR CIM.OperatingSystem.Description LIKE '%95'"; 
						}
						else
						{
							if((this.lisOperatingSystems.CheckedItems[0].ToString() == "Windows 2000")||(this.lisOperatingSystems.CheckedItems[0].ToString() == "Microsoft Windows 2000"))
							{
								this.queryAddOn = this.queryAddOn + " AND (CIM.OperatingSystem.Caption LIKE '%2000' OR CIM.OperatingSystem.Description LIKE '%2000'"; 
							}
							else
							{
								if((this.lisOperatingSystems.CheckedItems[0].ToString() == "Windows XP")||(this.lisOperatingSystems.CheckedItems[0].ToString() == "Microsoft Windows XP"))
								{
									this.queryAddOn = this.queryAddOn + " AND (CIM.OperatingSystem.Caption LIKE '%XP' OR CIM.OperatingSystem.Description LIKE '%XP'"; 
								}
								else
								{
									HoldOther=this.lisOperatingSystems.CheckedItems[0].ToString();
									this.queryAddOn = this.queryAddOn + " AND (CIM.OperatingSystem.Caption = '" + HoldOther + "' OR CIM.OperatingSystem.Description = '" + HoldOther + "' ";
								}
							}
						}
					}
				
					HoldOther="";
					for(int i = 1; i<=this.lisOperatingSystems.CheckedItems.Count - 1; i++)
					{
					
						if((this.lisOperatingSystems.CheckedItems[i].ToString() == "WIN98")||(this.lisOperatingSystems.CheckedItems[i].ToString() == "Windows 98")||(this.lisOperatingSystems.CheckedItems[i].ToString() == "Microsoft Windows 98"))
						{
							this.queryAddOn = this.queryAddOn + " OR CIM.OperatingSystem.Caption LIKE '%98' OR CIM.OperatingSystem.Description LIKE '%98' "; 
						}
						else
						{
							if((this.lisOperatingSystems.CheckedItems[i].ToString() == "WIN95")||(this.lisOperatingSystems.CheckedItems[i].ToString() == "Windows 95")||(this.lisOperatingSystems.CheckedItems[i].ToString() == "Microsoft Windows 95"))
							{
								this.queryAddOn = this.queryAddOn + " OR CIM.OperatingSystem.Caption LIKE '%95' OR CIM.OperatingSystem.Description LIKE '%95' "; 
							}
							else
							{
								if((this.lisOperatingSystems.CheckedItems[i].ToString() == "Windows 2000")||(this.lisOperatingSystems.CheckedItems[i].ToString() == "Microsoft Windows 2000"))
								{
									this.queryAddOn = this.queryAddOn + " OR CIM.OperatingSystem.Caption LIKE '%2000' OR CIM.OperatingSystem.Description LIKE '%2000'"; 
								}
								else
								{
									if((this.lisOperatingSystems.CheckedItems[i].ToString() == "Windows XP")||(this.lisOperatingSystems.CheckedItems[i].ToString() == "Microsoft Windows XP"))
									{
										this.queryAddOn = this.queryAddOn + " OR CIM.OperatingSystem.Caption LIKE '%XP' OR CIM.OperatingSystem.Description LIKE '%XP'"; 
									}
									else
									{
										HoldOther = this.lisOperatingSystems.CheckedItems[i].ToString();
										this.queryAddOn = this.queryAddOn + " OR CIM.OperatingSystem.Caption = '" + HoldOther + "' OR CIM.OperatingSystem.Description = '"+ HoldOther +"' ";
									}
								}
							}
						}	
					}

					this.queryAddOn = this.queryAddOn + ") ";
			
				}
			

				this.SelectTables = this.SelectTables + ", CIM.OperatingSystem.Caption AS OS, CIM.OperatingSystem.Description AS OSDescription, CIM.OperatingSystem.Version AS OSVersion ";
				this.FromTables= this.FromTables + ", CIM.OperatingSystem, CIM.InstalledOS";
				this.WhereTables= this.WhereTables+" AND CIM.OperatingSystem.id$ = CIM.InstalledOS.PartComponent AND CIM.InstalledOS.GroupComponent = CIM.UnitaryComputerSystem.id$";
				this.OSCheck=1;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error in Reading OS Information: "+ex.Message.ToString(),"OS Reading Error");

			}
		}

		private void ReadProcessor()
		{
			try
			{
				if(this.lisProcessors.CheckedItems.Count != 0)
				{
					this.queryAddOn = this.queryAddOn + " AND ( CIM.Processor.Name= '" + this.lisProcessors.CheckedItems[0].ToString() + "' OR CIM.Processor.OtherFamilyDescription = '"+this.lisProcessors.CheckedItems[0].ToString()+"' "; 

					for(int i = 1; i<=this.lisProcessors.CheckedItems.Count - 1; i++)
					{
						this.queryAddOn = this.queryAddOn + " OR CIM.Processor.Name = '" + this.lisProcessors.CheckedItems[i].ToString() + "'  OR CIM.Processor.OtherFamilyDescription = '"+this.lisProcessors.CheckedItems[i].ToString()+"' ";
					}

					this.queryAddOn = this.queryAddOn + ") ";
				}
			
				this.SelectTables = this.SelectTables + ", CIM.Processor.Name AS ProcessorName,  CIM.Processor.OtherFamilyDescription AS ProcessorDescription, CIM.Processor.CurrentClockSpeed";
				this.FromTables = this.FromTables + ", CIM.Processor, CIM.ComputerSystemProcessor";
				this.WhereTables = this.WhereTables + " AND CIM.Processor.id$ = CIM.ComputerSystemProcessor.PartComponent AND CIM.ComputerSystemProcessor.GroupComponent = CIM.UnitaryComputerSystem.id$ AND CIM.Processor.DeviceID = 'CPU0'"; 

				this.ProsCheck=1;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Reading Processor Information  " + ex.Message.ToString(),"Processor Reading Error");
			}
		}

		private void ReadClient()
		{
			try
			{
				if(this.lisClient.CheckedItems.Count != 0)
				{
					try
					{
					
						this.queryAddOn = this.queryAddOn + " AND (ZENWorks.NetwareClient.Version = '"+this.lisClient.CheckedItems[0].ToString()+"' ";
						

						for(int i = 1; i<=this.lisClient.CheckedItems.Count - 1; i++)
						{
							
							this.queryAddOn = this.queryAddOn + " OR ZENWorks.NetwareClient.Version = '"+this.lisClient.CheckedItems[i].ToString()+"' ";
							
						}

						this.queryAddOn = this.queryAddOn + ") ";
					
					}
					catch(Exception ex)
					{
						MessageBox.Show("Error creating query for Client Version " +ex.Message.ToString(),"Error 0001");
					}
				
				}
			
			
				this.SelectTables = this.SelectTables + ", ZENWorks.NetwareClient.Version AS ClientVersion";
				this.ClientCheck=1;
			}
			catch(Exception ex2)
			{
				MessageBox.Show("Error Getting/Reading Client Information  "+ex2.Message.ToString(),"Client Reading Error");
			}
		}

		private void ReadSerial()
		{
			string holder;

			holder = this.txtSerial.Text.Replace("'","''"); //check for an invalid SQL char

			string compName;
			compName = holder.Replace("*","%");

			try
			{
				if(this.chkSerialWildCard.Checked == true)
				{
					this.queryAddOn = this.queryAddOn + " AND (ZENworks.SystemInfo.Tag LIKE '" + compName + "' OR ZENWorks.SystemInfo.SerialNumber LIKE '"+compName+"') ";
				}
				else
				{
					this.queryAddOn = this.queryAddOn + " AND (ZENworks.SystemInfo.Tag = '" + compName + "' OR ZENWorks.SystemInfo.SerialNumber = '"+compName+"')";
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Reading Hardware: Serial Number  "+ex.Message.ToString(),"Hardware: Serial Number Error");
			}

		}

		private void ReadComputerName()
		{
			string holder;

			holder = this.txtComputerName.Text.Replace("'","''");

			string compName;
			compName = holder.Replace("*","%");

			try
			{
				if(this.chkNameWild.Checked==true)
				{
					this.queryAddOn = queryAddOn + " AND ZENworks.SystemInfo.Caption LIKE '" + compName + "' ";
				}
				else
				{
					this.queryAddOn = queryAddOn + " AND ZENworks.SystemInfo.Caption = '" + compName + "' ";
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error reading Hardware: Computer Name  "+ex.Message.ToString(),"Hardware: Computer Name Error");
			}
			
		}

		private void ReadDiskSize()
		{	
			try
			{
				this.queryAddOn = this.queryAddOn + " AND CIM.FileSystem.FileSystemSize <= " + Convert.ToString(((Convert.ToInt32(this.txtDiskSize.Text)) * 1024));

				this.SelectTables = this.SelectTables + ", CIM.FileSystem.Name AS DriveLetter, CIM.FileSystem.FileSystemSize, CIM.FileSystem.AvailableSpace, CIM.FileSystem.FileSystemType";
				this.FromTables = this.FromTables + ", CIM.FileSystem, CIM.HostedFileSystem";
				this.WhereTables = this.WhereTables + " AND CIM.FileSystem.id$ = CIM.HostedFileSystem.PartComponent AND CIM.HostedFileSystem.GroupComponent = CIM.UnitaryComputerSystem.id$ AND CIM.FileSystem.Name LIKE 'C%'";
				this.DiskCheck =1;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Reading Less Than Disk Size  "+ ex.Message.ToString(),"Disk Size Less Than Error");
			}
		}

		private void ReadGreaterDiskSize()
		{
			try
			{
				this.queryAddOn = this.queryAddOn + " AND CIM.FileSystem.FileSystemSize >= " + Convert.ToString(((Convert.ToInt32(this.txtDiskSize.Text)) * 1024));

				this.SelectTables = this.SelectTables + ", CIM.FileSystem.Name AS DriveLetter, CIM.FileSystem.FileSystemSize, CIM.FileSystem.AvailableSpace, CIM.FileSystem.FileSystemType";
				this.FromTables = this.FromTables + ", CIM.FileSystem, CIM.HostedFileSystem";
				this.WhereTables = this.WhereTables + " AND CIM.FileSystem.id$ = CIM.HostedFileSystem.PartComponent AND CIM.HostedFileSystem.GroupComponent = CIM.UnitaryComputerSystem.id$ AND CIM.FileSystem.Name LIKE 'C%'";
				this.DiskCheck=1;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Reading Greater Than Disk Size  "+ex.Message.ToString(), "Disk Size Greater Than Error");
			}
		}

		private void ReadMemory()
		{
			try
			{
				this.queryAddOn = this.queryAddOn + " AND CIM.OperatingSystem.TotalVisibleMemorySize <= " + this.txtVisibleMemory.Text;

				if(this.chkOS.Checked == false)
				{
					this.SelectTables = this.SelectTables + ", CIM.OperatingSystem.TotalVisibleMemorySize ";
					this.FromTables= this.FromTables + ", CIM.OperatingSystem, CIM.InstalledOS";
					this.WhereTables= this.WhereTables+" AND CIM.OperatingSystem.id$ = CIM.InstalledOS.PartComponent AND CIM.InstalledOS.GroupComponent = CIM.UnitaryComputerSystem.id$";
				}
				else
				{
					this.SelectTables = this.SelectTables + ", CIM.OperatingSystem.TotalVisibleMemorySize ";
				}
				this.VisMem=1;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Reading Less Than Memory  "+ex.Message.ToString(),"Error Reading Less Than Memory");
			}
		}

		private void ReadGreaterMemory()
		{
			try
			{
				this.queryAddOn = this.queryAddOn + " AND CIM.OperatingSystem.TotalVisibleMemorySize >= " + this.txtVisibleMemory.Text;

				if(this.chkOS.Checked == false)
				{
					this.SelectTables = this.SelectTables + ", CIM.OperatingSystem.TotalVisibleMemorySize ";
					this.FromTables= this.FromTables + ", CIM.OperatingSystem, CIM.InstalledOS";
					this.WhereTables= this.WhereTables+" AND CIM.OperatingSystem.id$ = CIM.InstalledOS.PartComponent AND CIM.InstalledOS.GroupComponent = CIM.UnitaryComputerSystem.id$";
				}
				else
				{
					this.SelectTables = this.SelectTables + ", CIM.OperatingSystem.TotalVisibleMemorySize ";
				}
				this.VisMem=1;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Reading Greater Memory  "+ex.Message.ToString(),"Error Reading Greater Memory");
			}
		}

		private void HardwareSearchCheck()
		{
			//this is where all the checks are located for the Hardware Search Button

			Form CheckHardware = new HardwareSearchWarn();
			try
			{
				if((this.chkClientVer.Checked==false)&&(this.chkComputerName.Checked==false)&&(this.chkOS.Checked==false)&&(this.chkSerial.Checked==false)&&(this.chkProcessor.Checked==false)&&(this.radDiskGreat.Checked==false)&&(this.radDiskLess.Checked==false)&&(this.radGreatMem.Checked==false)&&(this.radMemLess.Checked==false)&&(this.radNoDisk.Checked==false)&&(this.radNoMem.Checked==false))
				{
					//checks if everything is not checked; brings up a warning to continue or not
					DialogResult buttonClick = CheckHardware.ShowDialog();
					if(buttonClick.Equals(DialogResult.OK))
					{
						this.lblCount.Text = "Loading Results...";
						this.SaveCheck = 0;
						this.RunSearch();
					}
					else
					{
						MessageBox.Show("Hardware Search Aborted","No Search");
					}
				}
				else
				{
					if(((this.radDiskAll.Checked==true)||(this.radMemAll.Checked==true)||(this.radNoDisk.Checked==true)||(this.radNoMem.Checked==true))&&((this.chkClientVer.Checked==false)&&(this.chkComputerName.Checked==false)&&(this.chkOS.Checked==false)&&(this.chkSerial.Checked==false)&&(this.chkProcessor.Checked==false)&&(this.radDiskGreat.Checked==false)&&(this.radDiskLess.Checked==false)&&(this.radGreatMem.Checked==false)&&(this.radMemLess.Checked==false)))
					{
						//this is the same as above, only with the All or None for Mem and disk checked, with all others unchecked
						DialogResult buttonClick = CheckHardware.ShowDialog();
						if(buttonClick.Equals(DialogResult.OK))
						{
							this.lblCount.Text = "Loading Results...";
							this.SaveCheck = 0;
							this.RunSearch();
						}
						else
						{
							MessageBox.Show("Hardware Search Aborted","No Search");
						}
					}
					else
					{
						if(((this.radDiskAll.Checked==true)||(this.radMemAll.Checked==true)||(this.radNoDisk.Checked==true)||(this.radNoMem.Checked==true)||(this.radMemAll.Checked==false)||(this.radNoDisk.Checked==false)||(this.radNoMem.Checked==false)||(this.radDiskAll.Checked==false))&&((this.chkComputerName.Checked==false)&&(this.chkSerial.Checked==false)&&(this.radDiskGreat.Checked==false)&&(this.radDiskLess.Checked==false)&&(this.radGreatMem.Checked==false)&&(this.radMemLess.Checked==false)&&(this.radNoDisk.Checked==false)&&(this.radNoMem.Checked==false))&&((this.chkClientVer.Checked == true)||(this.chkProcessor.Checked==true)||(this.chkOS.Checked==true)))
						{
							if((this.chkClientVer.Checked == true)&&(this.lisClient.CheckedItems.Count==0)&&((this.chkProcessor.Checked==false)||((this.chkProcessor.Checked==true)&&(this.lisProcessors.CheckedItems.Count==0)))&&((this.chkOS.Checked==false)||((this.chkOS.Checked==true)&&(this.lisOperatingSystems.CheckedItems.Count==0))))
							{	//true if client checked with no choices AND either processors not checked or checked with no choices AND OS either not checked or checked with no choices
								DialogResult buttonClick = CheckHardware.ShowDialog();
								if(buttonClick.Equals(DialogResult.OK))
								{
									this.lblCount.Text = "Loading Results...";
									this.SaveCheck = 0;
									this.RunSearch();
								}
								else
								{
									MessageBox.Show("Hardware Search Aborted","No Search");
								}
							}
							else
							{
								if((this.chkOS.Checked==true)&&(this.lisOperatingSystems.CheckedItems.Count == 0)&&((this.chkProcessor.Checked==false)||((this.chkProcessor.Checked==true)&&(this.lisProcessors.CheckedItems.Count==0)))&&((this.chkClientVer.Checked==false)||((this.chkClientVer.Checked==true)&&(this.lisClient.CheckedItems.Count==0))))
								{
									DialogResult buttonClick = CheckHardware.ShowDialog();
									if(buttonClick.Equals(DialogResult.OK))
									{
										this.lblCount.Text = "Loading Results...";
										this.SaveCheck = 0;
										this.RunSearch();
									}
									else
									{
										MessageBox.Show("Hardware Search Aborted","No Search");
									}
								}
								else
								{
									if((this.chkProcessor.Checked == true)&&(this.lisProcessors.CheckedItems.Count == 0)&&((this.chkOS.Checked==false)||((this.chkOS.Checked==true)&&(this.lisOperatingSystems.CheckedItems.Count==0)))&&((this.chkClientVer.Checked==false)||((this.chkClientVer.Checked==true)&&(this.lisClient.CheckedItems.Count==0))))
									{
										DialogResult buttonClick = CheckHardware.ShowDialog();
										if(buttonClick.Equals(DialogResult.OK))
										{
											this.lblCount.Text = "Loading Results...";
											this.SaveCheck = 0;
											this.RunSearch();
										}
										else
										{
											MessageBox.Show("Hardware Search Aborted","No Search");
										}
									}
									else
									{
										this.lblCount.Text = "Loading Results...";
										this.SaveCheck = 0;
										this.RunSearch();

									}
								}
							}
						
						}
						else
						{

							if(((this.radDiskAll.Checked==true)||(this.radMemAll.Checked==true)||(this.radNoDisk.Checked==true)||(this.radNoMem.Checked==true)||(this.radMemAll.Checked==false)||(this.radNoDisk.Checked==false)||(this.radNoMem.Checked==false)||(this.radDiskAll.Checked==false))&&((this.chkComputerName.Checked==false)&&(this.chkSerial.Checked==false)&&(this.radDiskGreat.Checked==false)&&(this.radDiskLess.Checked==false)&&(this.radGreatMem.Checked==false)&&(this.radMemLess.Checked==false))&&((this.chkClientVer.Checked == true)||(this.chkProcessor.Checked==true)||(this.chkOS.Checked==true)))
							{
								if((this.chkClientVer.Checked == true)&&(this.lisClient.CheckedItems.Count==0)&&((this.chkProcessor.Checked==false)||((this.chkProcessor.Checked==true)&&(this.lisProcessors.CheckedItems.Count==0)))&&((this.chkOS.Checked==false)||((this.chkOS.Checked==true)&&(this.lisOperatingSystems.CheckedItems.Count==0))))
								{	//true if client checked with no choices AND either processors not checked or checked with no choices AND OS either not checked or checked with no choices
									DialogResult buttonClick = CheckHardware.ShowDialog();
									if(buttonClick.Equals(DialogResult.OK))
									{
										this.lblCount.Text = "Loading Results...";
										this.SaveCheck = 0;
										this.RunSearch();
									}
									else
									{
										MessageBox.Show("Hardware Search Aborted","No Search");
									}
								}
								else
								{
									if((this.chkOS.Checked==true)&&(this.lisOperatingSystems.CheckedItems.Count == 0)&&((this.chkProcessor.Checked==false)||((this.chkProcessor.Checked==true)&&(this.lisProcessors.CheckedItems.Count==0)))&&((this.chkClientVer.Checked==false)||((this.chkClientVer.Checked==true)&&(this.lisClient.CheckedItems.Count==0))))
									{
										DialogResult buttonClick = CheckHardware.ShowDialog();
										if(buttonClick.Equals(DialogResult.OK))
										{
											this.lblCount.Text = "Loading Results...";
											this.SaveCheck = 0;
											this.RunSearch();
										}
										else
										{
											MessageBox.Show("Hardware Search Aborted","No Search");
										}
									}
									else
									{
										if((this.chkProcessor.Checked == true)&&(this.lisProcessors.CheckedItems.Count == 0)&&((this.chkOS.Checked==false)||((this.chkOS.Checked==true)&&(this.lisOperatingSystems.CheckedItems.Count==0)))&&((this.chkClientVer.Checked==false)||((this.chkClientVer.Checked==true)&&(this.lisClient.CheckedItems.Count==0))))
										{
											DialogResult buttonClick = CheckHardware.ShowDialog();
											if(buttonClick.Equals(DialogResult.OK))
											{
												this.lblCount.Text = "Loading Results...";
												this.SaveCheck = 0;
												this.RunSearch();
											}
											else
											{
												MessageBox.Show("Hardware Search Aborted","No Search");
											}
										}
										else
										{
											this.lblCount.Text = "Loading Results...";
											this.SaveCheck = 0;
											this.RunSearch();

										}
									}
								}
							}
							else
							{
					
								this.lblCount.Text = "Loading Results...";
								this.SaveCheck = 0;
								this.RunSearch();
							}

						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Hardware Check Error:  "+ex.Message.ToString(),"Hardware Check Error");
			}

		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			this.HardwareSearchCheck();
		}

		private void RunSearch()
		{
			//reset query string

			this.queryAddOn = " ";

			DataTable SearchResults = new DataTable();

			Form myForm = new WaitResults();

			myForm.Show();

			this.Cursor = Cursors.WaitCursor;
 
			Application.DoEvents();
			
			//"UID=mw_dba;PWD=novell;DSN=Sybase ODBC Driver";
			try
			{

				//string strConn = "DSN=Zenworks Inventory";

				OdbcConnection myConnection = new OdbcConnection(strConn);

				this.searchClient = "";
				this.searchCompName = "";
				this.searchDiskSize = "";
				this.searchOS = "";
				this.searchSerial = "";
				this.searchString = "";
				this.searchVisMem = "";
				this.searchString = "";
				this.searchSoftware ="";
				this.searchSoftCompName = "";

				this.ProsCheck=0;
				this.VisMem=0;
				this.OSCheck =0;
				this.DiskCheck=0;
				this.ClientCheck=0;


				if(this.chkComputerName.Checked==true)
				{
					if(this.txtComputerName.Text=="")
					{
						MessageBox.Show("Computer Name is Blank; Cannot Continue Search","Search Error");
						goto LeaveSearch;
					}
					else
					{
						this.ReadComputerName();
					}
				}
			
				if(this.chkClientVer.Checked == true)
				{
					this.ReadClient();
				}

				if(this.radDiskLess.Checked==true)
				{
					this.ReadDiskSize();
				}
				else
				{
					if(this.radDiskGreat.Checked == true)
					{
						this.ReadGreaterDiskSize();
					}
				}

				if(this.chkProcessor.Checked==true)
				{
					this.ReadProcessor();
				}

				if(this.chkOS.Checked==true)
				{
					this.ReadOS();
				}

				if(this.chkSerial.Checked==true)
				{
					if(this.txtSerial.Text == "")
					{
						MessageBox.Show("Serial Number is Blank; Cannot Continue Search","Search Error");
						goto LeaveSearch;
					}
					else
					{
						this.ReadSerial();
					}
				}

				if(this.radMemLess.Checked==true)
				{
					this.ReadMemory();
				}
				else
				{
					if(this.radGreatMem.Checked == true)
					{
						this.ReadGreaterMemory();
					}
				}

				if(this.radDiskAll.Checked ==true)
				{
					
					this.SelectTables = this.SelectTables + ", CIM.FileSystem.Name AS DriveLetter, CIM.FileSystem.FileSystemSize, CIM.FileSystem.AvailableSpace, CIM.FileSystem.FileSystemType";
					this.FromTables = this.FromTables + ", CIM.FileSystem, CIM.HostedFileSystem";
					this.WhereTables = this.WhereTables + " AND CIM.FileSystem.id$ = CIM.HostedFileSystem.PartComponent AND CIM.HostedFileSystem.GroupComponent = CIM.UnitaryComputerSystem.id$ AND CIM.FileSystem.Name LIKE 'C%'";
					this.DiskCheck=1;
				}

				if(this.radMemAll.Checked == true)
				{
					this.searchVisMem = "Visible Memory = All";

					if(this.chkOS.Checked == false)
					{
						this.SelectTables = this.SelectTables + ", CIM.OperatingSystem.TotalVisibleMemorySize ";
						this.FromTables= this.FromTables + ", CIM.OperatingSystem, CIM.InstalledOS";
						this.WhereTables= this.WhereTables+" AND CIM.OperatingSystem.id$ = CIM.InstalledOS.PartComponent AND CIM.InstalledOS.GroupComponent = CIM.UnitaryComputerSystem.id$";
					}
					else
					{
						this.SelectTables = this.SelectTables + ", CIM.OperatingSystem.TotalVisibleMemorySize ";
					}
					this.VisMem = 1;

				}
			
				//Open connection
				myConnection.Open();

				//CIM.Processor.DeviceID,       
				this.myStringCommand="SELECT CIM.UnitaryComputerSystem.Name AS ImportedAs, ZENworks.SystemInfo.Caption AS ComputerName, ZENworks.SystemInfo.Description, ZENworks.SystemInfo.Model, ZENworks.SystemInfo.SerialNumber, ZENworks.SystemInfo.Tag" + this.SelectTables + " FROM ZENWorks.NetwareClient, CIM.InstalledSoftwareElement, ZENworks.SystemInfo, CIM.ComputerSystemPackage, CIM.UnitaryComputerSystem "+this.FromTables+ " WHERE ZENworks.SystemInfo.id$ = CIM.ComputerSystemPackage.Antecedent AND CIM.ComputerSystemPackage.Dependent = CIM.UnitaryComputerSystem.id$ AND  ZENWorks.NetwareClient.id$ = CIM.InstalledSoftwareElement.Software AND CIM.InstalledSoftwareElement.System = CIM.UnitaryComputerSystem.id$ "+this.WhereTables + OSV+ queryAddOn +" " +this.OrderItems;

				OdbcCommand myCommand = new OdbcCommand(myStringCommand, myConnection);//this.ZENWorksConnection);

				OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);
				
				myAdapter.Fill(SearchResults);

				dtResults.Clear();

				this.SoftTable.Dispose(); //dispose of other table

				dtResults = SearchResults.Copy();

				this.dgResults.DataSource = dtResults;
			
				this.dgResults.Visible = true;
			
				myConnection.Close();
				//myAdapter.Dispose();		
				

			LeaveSearch:
				this.Cursor = Cursors.Default;
				myForm.Close();
				myForm.Dispose();
				this.lblCount.Text = dtResults.Rows.Count + " Records Found";
				this.SelectTables = " ";
				this.FromTables = " ";
				this.WhereTables = " ";
				

			}
			catch(Exception ex)
			{
				if((this.radAvSizeASC.Checked==true)||(this.radAvSizeDESC.Checked==true)||(this.radClientASC.Checked==true)||(this.radClientDESC.Checked==true)||(this.radCompNameASC.Checked==true)||(this.radCompNameDESC.Checked==true)||(this.radCurrClASC.Checked==true)||(this.radCurrClDESC.Checked==true)||(this.radDescASC.Checked==true)||(this.radDescDESC.Checked==true)||(this.radDriveNameASC.Checked==true)||(this.radDriveNameDESC.Checked==true)||(this.radFileSysSizASC.Checked==true)||(this.radFileSysSizeDESC.Checked==true)||(this.radFSTASC.Checked==true)||(this.radFSTDESC.Checked==true)||(this.radImportASC.Checked==true)||(this.radImportDESC.Checked==true)||(this.radModelASC.Checked==true)||(this.radModelDESC.Checked==true)||(this.radOSASC.Checked==true)||(this.radOSDESC.Checked==true)||(this.radOSVerASC.Checked==true)||(this.radOSVerDESC.Checked==true)||(this.radProcASC.Checked==true)||(this.radProcDESC.Checked==true)||(this.radSerialASC.Checked==true)||(this.radSerialDESC.Checked==true)||(this.radTagASC.Checked==true)||(this.radTAGDESC.Checked==true)||(this.radTotVisMemDESC.Checked==true)||(this.radTotVisMemSizeASC.Checked==true))
				{
					MessageBox.Show("Error Sorting; Is the search choice selected for this sort?  "+ex.Message.ToString(),"Error Sort");
				}
				else
				{
					MessageBox.Show("Error running search; "+ex.Message.ToString(),"Error" );
					
				}
				this.Cursor = Cursors.Default;
				myForm.Close();
				this.lblCount.Text = "  ";
				
			}
			finally
			{
				
			}
		}

		#region ReadSoftware
		private void ReadSoftCompName()
		{
			string holder;

			holder = this.txtSoftCompName.Text.Replace("'","''");

			string compName;

			compName = holder.Replace("*","%");

			try
			{
				if(this.chkSoftNameWild.Checked==true)
				{
					this.queryAddOn = queryAddOn + " AND ZENworks.SystemInfo.Caption LIKE '" + compName + "' ";
				}
				else
				{
					this.queryAddOn = queryAddOn + " AND ZENworks.SystemInfo.Caption = '" + compName + "' ";
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Reading Software: Computer Name  "+ex.Message.ToString(),"Error Reading Software: Computer Name");
			}
			
		}

		private void ReadSoftName()
		{
			string holder;

			holder = this.txtSoftwareName.Text.Replace("'","''");

			string softName; 

			softName = holder.Replace("*","%");
			try
			{
				if(this.chkWildSoftName.Checked==true)
				{
					this.queryAddOn = queryAddOn + " AND CIM.Product.Name LIKE '" + softName + "' ";
				}
				else
				{
					this.queryAddOn = queryAddOn + " AND CIM.Product.Name = '" + softName + "' ";
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Reading Software Name  "+ex.Message.ToString(),"Error Reading Software Name");
			}
		}

		private void ReadSoftwareList()
		{
			string holder;
			string holder2;
			
			try
			{
				if(this.lisSoftware.CheckedItems.Count != 0)
				{
					holder = this.lisSoftware.CheckedItems[0].ToString();
					holder2=holder.Replace("'","''");
					
					this.queryAddOn = this.queryAddOn + " AND (CIM.Product.Name = '"+ holder2 + "' "; 

					for(int i = 1; i<=this.lisSoftware.CheckedItems.Count - 1; i++)
					{
						holder = this.lisSoftware.CheckedItems[i].ToString();
						holder2 = holder.Replace("'","''");
						this.queryAddOn = this.queryAddOn + " OR CIM.Product.Name = '"+ holder2 +"' ";
					}

					this.queryAddOn = this.queryAddOn + ") ";
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Reading Software List  "+ex.Message.ToString(),"Software List Error");
			}
		}
		#endregion
		#region RunSoftSearch()
		private void RunSoftSearch()
		{
			//reset query string

			this.queryAddOn = " ";
			
			Form myForm = new WaitResults();

			SoftTable.Clear();

			myForm.Show();

			this.Cursor = Cursors.WaitCursor;
 
			Application.DoEvents();
			
			try
			{
				//string strConn = "DSN=Zenworks Inventory";

				OdbcConnection myConnection = new OdbcConnection(strConn);

				this.searchClient = "";
				this.searchCompName = "";
				this.searchDiskSize = "";
				this.searchOS = "";
				this.searchSerial = "";
				this.searchString = "";
				this.searchVisMem = "";
				this.searchString = "";
				this.searchSoftware ="";
				this.searchSoftCompName = "";

				if(this.chkSoftCompName.Checked==true)
				{
					if(this.txtSoftCompName.Text=="")
					{
						MessageBox.Show("Computer Name is Blank; Cannot Continue Search","Search Error");
						goto LeaveSearch;
					}
					else
					{
						this.ReadSoftCompName();
					}
				}

				if(this.chkSoftwareName.Checked==true)
				{
					if(this.txtSoftwareName.Text=="")
					{
						MessageBox.Show("Software Name is Blank; Cannot Continue Search","Search Error");
						goto LeaveSearch;
					}
					else
					{
						this.ReadSoftName();
					}
				}
			
				if(this.chksoftChoice.Checked == true)
				{
					this.ReadSoftwareList();
				}
				
				//Open connection
				myConnection.Open();

				//CIM.Processor.DeviceID,
				this.myStringCommand="SELECT CIM.UnitaryComputerSystem.Name AS ImportedAs,ZENWorks.SystemInfo.Caption AS ComputerName, CIM.Product.Name AS SoftwareName, CIM.Product.Vendor, CIM.Product.Version FROM ZENWorks.SystemInfo, CIM.Product, CIM.UnitaryComputerSystem, ZENWorks.InstalledProduct, CIM.ComputerSystemPackage WHERE ZENworks.SystemInfo.id$ = CIM.ComputerSystemPackage.Antecedent AND CIM.ComputerSystemPackage.Dependent = CIM.UnitaryComputerSystem.id$ AND CIM.Product.id$=Zenworks.InstalledProduct.Product AND ZENWorks.InstalledProduct.ComputerSystem = CIM.UnitaryComputerSystem.id$ "+ queryAddOn + " " +this.OrderItems;

				OdbcCommand myCommand = new OdbcCommand(myStringCommand, myConnection);//this.ZENWorksConnection);

				OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);
				
				myAdapter.Fill(SoftTable);

				int i = 0;
				int CountHolder = 0;
				DataRow RowOne ;
				DataRow RowTwo ;
				

				if(this.chkSoftCompName.Checked==false)
				{
					//this is mainly used for checking specific software
					CountHolder = SoftTable.Rows.Count;
				
					while(i<CountHolder-1)//first pass for checking
					{
						RowOne = SoftTable.Rows[i];
						RowTwo = SoftTable.Rows[i+1];
						RowOne.ClearErrors();
						RowTwo.ClearErrors();
						if((RowOne["ImportedAs"].ToString().Equals(RowTwo["ImportedAs"].ToString())==true)&&(RowOne["ComputerName"].ToString().Equals(RowTwo["ComputerName"].ToString())==true)&&(RowOne["SoftwareName"].ToString().Equals(RowTwo["SoftwareName"].ToString())==true)&&(RowOne["Vendor"].ToString().Equals(RowTwo["Vendor"].ToString())==true)&&(RowOne["Version"].ToString().Equals(RowTwo["Version"].ToString())==true))
						{
						
							SoftTable.Rows[i+1].Delete();
							CountHolder--;
							SoftTable.AcceptChanges();
					
						}
						i++;
					
					
					}
				
					i=0;
					CountHolder = SoftTable.Rows.Count;

					while(i<CountHolder-1) //pass to end all passes; searches and compares a record to each other record
					{
						RowOne = SoftTable.Rows[i];
					
						for(int j = 0; j<CountHolder; j++)
						{
							if(j!=i)//this means if i=j, they are refering to the same record
							{
								RowTwo = SoftTable.Rows[j];
								RowOne.ClearErrors();
								try
								{
									if((RowOne["ImportedAs"].ToString().Equals(RowTwo["ImportedAs"].ToString())==true)&&(RowOne["ComputerName"].ToString().Equals(RowTwo["ComputerName"].ToString())==true)&&(RowOne["SoftwareName"].ToString().Equals(RowTwo["SoftwareName"].ToString())==true)&&(RowOne["Vendor"].ToString().Equals(RowTwo["Vendor"].ToString())==true)&&(RowOne["Version"].ToString().Equals(RowTwo["Version"].ToString())==true))
									{
										SoftTable.Rows[j].Delete();//delte duplicate
										CountHolder--;
									}
								}
								catch
								{
									j=j; //this is here for debugging purposes
								}
							}

						}
						SoftTable.AcceptChanges();
						i++;
					}

					i=0;
					CountHolder = SoftTable.Rows.Count;

					while(i<CountHolder-1) //pass to end all passes; searches and compares a record to each other record
					{
						RowOne = SoftTable.Rows[i];
					
						for(int j = 0; j<CountHolder; j++)
						{
							if(j!=i)//this means if i=j, they are refering to the same record
							{
								RowTwo = SoftTable.Rows[j];
								RowOne.ClearErrors();
								try
								{
									if((RowOne["ImportedAs"].ToString().Equals(RowTwo["ImportedAs"].ToString())==true)&&(RowOne["ComputerName"].ToString().Equals(RowTwo["ComputerName"].ToString())==true)&&(RowOne["SoftwareName"].ToString().Equals(RowTwo["SoftwareName"].ToString())==true)&&(RowOne["Vendor"].ToString().Equals(RowTwo["Vendor"].ToString())==true)&&(RowOne["Version"].ToString().Equals(RowTwo["Version"].ToString())==true))
									{
										SoftTable.Rows[j].Delete();//delte duplicate
										CountHolder--;
									}
								}
								catch
								{
									j=j; //this is here for debugging purposes
								}
							}

						}
						SoftTable.AcceptChanges();
						i++;
					}
				}
				else //this section is for checking by computer
				{
					i=0;
					CountHolder = SoftTable.Rows.Count;
					/////////////// Three passes, first, compares one record to next record		
					while(i<CountHolder-1)//first pass for checking
					{
						RowOne = SoftTable.Rows[i];
						RowTwo = SoftTable.Rows[i+1];
						RowOne.ClearErrors();
						RowTwo.ClearErrors();
						if((RowOne["ImportedAs"].ToString().Equals(RowTwo["ImportedAs"].ToString())==true)&&(RowOne["ComputerName"].ToString().Equals(RowTwo["ComputerName"].ToString())==true)&&(RowOne["SoftwareName"].ToString().Equals(RowTwo["SoftwareName"].ToString())==true)&&(RowOne["Vendor"].ToString().Equals(RowTwo["Vendor"].ToString())==true)&&(RowOne["Version"].ToString().Equals(RowTwo["Version"].ToString())==true))
						{
						
							SoftTable.Rows[i+1].Delete();
							CountHolder--;
							SoftTable.AcceptChanges();
					
						}
						i++;
					
					
					}
					
					i=0;
					CountHolder = SoftTable.Rows.Count;
					///////////////////////////////////////////////////////////////////////////////////////
					
					while(i<CountHolder-1) //pass to end all passes; searches and compares a record to each other record
					{
						RowOne = SoftTable.Rows[i];

						
						for(int j = 0; j<CountHolder; j++)
						{
							if(j!=i)//this means if i=j, they are refering to the same record
							{
								RowTwo = SoftTable.Rows[j];
								RowOne.ClearErrors();
								try
								{
									if((RowOne["SoftwareName"].ToString().Equals(RowTwo["SoftwareName"].ToString())==true)&&(RowOne["Vendor"].ToString().Equals(RowTwo["Vendor"].ToString())==true)&&(RowOne["Version"].ToString().Equals(RowTwo["Version"].ToString())==true))
									{
										SoftTable.Rows[j].Delete();//delte duplicate
										CountHolder--;
											
									}
								}
								catch
								{
									j=j;//just to get it to stop here for debugging purposes
								}
							}
						}
						
						SoftTable.AcceptChanges();
						i++;
					}
					i=0;
					CountHolder = SoftTable.Rows.Count;
					while(i<CountHolder-1) //pass to end all passes; searches and compares a record to each other record
					{
						RowOne = SoftTable.Rows[i];

						
						for(int j = 0; j<CountHolder; j++)
						{
							if(j!=i)//this means if i=j, they are refering to the same record
							{
								RowTwo = SoftTable.Rows[j];
								RowOne.ClearErrors();
								try
								{
									if((RowOne["SoftwareName"].ToString().Equals(RowTwo["SoftwareName"].ToString())==true)&&(RowOne["Vendor"].ToString().Equals(RowTwo["Vendor"].ToString())==true)&&(RowOne["Version"].ToString().Equals(RowTwo["Version"].ToString())==true))
									{
										SoftTable.Rows[j].Delete();//delte duplicate
										CountHolder--;
											
									}
								}
								catch
								{
									j=j;//just to get it to stop here for debugging purposes
								}
							}
						}
						
						SoftTable.AcceptChanges();
						i++;
					}
				
				}

				this.dgSoftware.DataSource = SoftTable;

				//this.dtResults.Dispose();
			
				this.dgSoftware.Visible = true;
			
				myConnection.Close();

				

			LeaveSearch:
				this.lblCount.Text = SoftTable.Rows.Count + " Records Found";
				this.Cursor = Cursors.Default;
				myForm.Close();
				myForm.Dispose();
			}
			catch(Exception EX)
			{
				MessageBox.Show("Error running search; Possible causes: Does a choice have an ( ' ) in the title?  "+EX.Message.ToString(),"Error");
				//MessageBox.Show("String = "+this.myStringCommand, "String Check");
				this.Cursor = Cursors.Default;
				this.lblCount.Text = " ";
				myForm.Close();
				myForm.Dispose();
			}

		}

		#endregion
		#region FillListBoxes
		private void FillProcessorList()
		{
			string Command;
			//string strConn = "DSN=Sybase ODBC Driver";

			try
			{
				OdbcConnection myConnection = new OdbcConnection(strConn);

				myConnection.Open();

				//Command = "SELECT EnumString FROM CIM.Family_en_US";
				Command="SELECT Name, OtherFamilyDescription FROM CIM.Processor";

				OdbcCommand myCommand = new OdbcCommand(Command, myConnection);

				OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);

				DataTable ProResults = new DataTable("tblProcessors");

				myAdapter.Fill(ProResults);

				DataRow myRow; 
 
				DataRow CompRow;

				for(int i = 0; i<ProResults.Rows.Count;i++)
				{
					
					myRow = ProResults.Rows[i]; 
					
					for(int j = 0; j<this.lisProcessors.Items.Count; j++)
					{
						CompRow = ProResults.Rows[j];
						if(myRow["Name"].ToString().Equals(this.lisProcessors.Items[j].ToString())==true)
						{
							this.lisProcessors.Items.Remove(myRow["Name"].ToString());
						}
					}
					this.lisProcessors.Items.Add(myRow["Name"].ToString());
					
				}
				myRow=null;
				CompRow=null;
				for(int i = 0; i<ProResults.Rows.Count;i++)
				{
					
					myRow = ProResults.Rows[i]; 
					
					for(int j = 0; j<this.lisProcessors.Items.Count; j++)
					{
						CompRow = ProResults.Rows[j];
						if(myRow["OtherFamilyDescription"].ToString().Equals(this.lisProcessors.Items[j].ToString())==true)
						{
							this.lisProcessors.Items.Remove(myRow["OtherFamilyDescription"].ToString());
						}
					}
					this.lisProcessors.Items.Add(myRow["OtherFamilyDescription"].ToString());
					
				}

				this.lisProcessors.Sorted = true;

				myConnection.Close();
			
			}
			catch(Exception Ex)
			{
				MessageBox.Show("Could not retrieve Processor information  "+Ex.Message.ToString(), "Error");
			}

			
		}


		private void FillClientList()
		{
			string Command;
			//string strConn = "DSN=Zenworks Inventory";
			
			try
			{
				this.lisClient.Items.Clear();
			
				OdbcConnection myConnection = new OdbcConnection(strConn);

				myConnection.Open();

				Command = "SELECT Version FROM ZENworks.NetwareClient";

				OdbcCommand myCommand = new OdbcCommand(Command, myConnection);

				OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);

				DataTable ClientResults = new DataTable("tblClient");

				myAdapter.Fill(ClientResults);

				DataRow myRow;  

				for(int i = 0; i<ClientResults.Rows.Count;i++)
				{
					myRow = ClientResults.Rows[i]; 
					this.lisClient.Items.Add(myRow["Version"].ToString());
				}

				myConnection.Close();

				this.lisClient.Sorted=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Filling Client List  "+ex.Message.ToString(),"Error");
			}
		

		}


		public void FillSoftwareList()
		{
			string Command;
			//string strConn = "DSN=Sybase ODBC Driver";

			try
			{
				this.lisSoftware.Items.Clear();
			
				OdbcConnection myConnection = new OdbcConnection(strConn);

				myConnection.Open();

				Command = "SELECT Name FROM CIM.Product " + this.SoftFilt;

				OdbcCommand myCommand = new OdbcCommand(Command, myConnection);

				OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);

				DataTable SoftwareResults = new DataTable("tblSoftware");

				myAdapter.Fill(SoftwareResults);

				DataRow myRow; 
 
				DataRow CompRow;

				for(int i = 0; i<SoftwareResults.Rows.Count;i++)
				{
					
					myRow = SoftwareResults.Rows[i]; 
					
					for(int j = 0; j<this.lisSoftware.Items.Count; j++)
					{
						CompRow = SoftwareResults.Rows[j];
						if(myRow["Name"].ToString().Equals(this.lisSoftware.Items[j].ToString())==true)
						{
							this.lisSoftware.Items.Remove(myRow["Name"].ToString());
						}
					}
					this.lisSoftware.Items.Add(myRow["Name"].ToString());
					
				}

				this.lisSoftware.Sorted = true;

				myConnection.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Filling Software List  "+ex.Message.ToString(),"Error");
			}

			
		}

		private void FillOSList()
		{
			string Command;
			//string strConn = "DSN=Zenworks Inventory";

			try
			{
				OdbcConnection myConnection = new OdbcConnection(strConn);

				myConnection.Open();

				Command = "SELECT Caption, Description FROM CIM.OperatingSystem";
				
				OdbcCommand myCommand = new OdbcCommand(Command, myConnection);

				OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);

				DataTable ProResults = new DataTable("tblOS");

				myAdapter.Fill(ProResults);


				DataRow myRow; 
 
				DataRow CompRow;

				for(int i = 0; i<ProResults.Rows.Count;i++)
				{
					
					myRow = ProResults.Rows[i]; 
					
					for(int j = 0; j<this.lisOperatingSystems.Items.Count; j++)
					{
						CompRow = ProResults.Rows[j];
						if(myRow["Caption"].ToString().Equals(this.lisOperatingSystems.Items[j].ToString())==true)
						{
							this.lisOperatingSystems.Items.Remove(myRow["Caption"].ToString());
						}
					}
					this.lisOperatingSystems.Items.Add(myRow["Caption"].ToString());
					
				}
				myRow=null;
				CompRow=null;
				for(int i = 0; i<ProResults.Rows.Count;i++)
				{
					
					myRow = ProResults.Rows[i]; 
					
					for(int j = 0; j<this.lisOperatingSystems.Items.Count; j++)
					{
						CompRow = ProResults.Rows[j];
						if(myRow["Description"].ToString().Equals(this.lisOperatingSystems.Items[j].ToString())==true)
						{
							this.lisOperatingSystems.Items.Remove(myRow["Description"].ToString());
						}
					}
					this.lisOperatingSystems.Items.Add(myRow["Description"].ToString());
					
				}

				this.lisOperatingSystems.Sorted = true;

				myConnection.Close();

			}
			catch(Exception ex)
			{
				MessageBox.Show("Could not retrieve Operating System information  "+ex.Message.ToString(), "Error");
			}
			
			
		}
		#endregion
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Close();
		}


		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.PrintTheResults();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			try
			{
				//run ODBC configure program from Windows
				System.Diagnostics.Process.Start("odbcad32.exe");
			}
			catch(Exception ex)
			{
				MessageBox.Show("There was an error openning 'odbcad32.exe'.  "+ex.Message.ToString(),"Error");
			}
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			
		}
		#region Save
		private void SaveSoftwareResults()
		{
			int i = 0;
			string hold;
			DataRow myRow;			
		
			try
			{
				if(this.SoftTable.Rows.Count == 0)
				{
					MessageBox.Show("No search was made, or no results returned", "Error");
				}
				else
				{
					DialogResult buttonClicked = this.SaveResults.ShowDialog();
					if(buttonClicked.Equals(DialogResult.OK))
					{
						Stream saveStream2 = this.SaveResults.OpenFile();
						StreamWriter saveWriter2 = new StreamWriter(saveStream2);
					
						saveWriter2.WriteLine("ImportedAs; ComputerName; SoftwareName; Vendor; Version  ");
						
						while(i<this.SoftTable.Rows.Count)
						{
							
							myRow = this.SoftTable.Rows[i];
							
							hold = myRow["ImportedAs"].ToString() + "; "+myRow["ComputerName"].ToString()+"; "+myRow["SoftwareName"].ToString()+"; "+myRow["Vendor"].ToString()+"; "+ myRow["Version"].ToString();

							saveWriter2.WriteLine(hold);

							saveWriter2.WriteLine("  ");

							i++;
						}
						saveWriter2.Close();
					}
				}
			}
			catch(Exception ex)
			{
				if(this.SoftTable.Rows.Count == 0)
				{
					MessageBox.Show("There was an error creating the saved results file; No search was made"+ex.Message.ToString(),"Error ");
				}
				else
				{
					MessageBox.Show("There was an error creating the saved results file"+ex.Message.ToString(),"Error ");
				}
			}
			
			hold = "";
		}

		private void SaveSoftwareWord()
		{
			int i = 0;
			string hold;
			DataRow myRow;	
			
			int recnum = 0;
		
			try
			{
				if(this.SoftTable.Rows.Count == 0)
				{
					MessageBox.Show("No search was made, or no results returned", "Error");
				}
				else
				{
					
					DialogResult buttonClicked = this.SaveWordDoc.ShowDialog();
					if(buttonClicked.Equals(DialogResult.OK))
					{
						Stream saveStream2 = this.SaveWordDoc.OpenFile();
						StreamWriter saveWriter2 = new StreamWriter(saveStream2);
						
						hold= "Saved Results From Query:         " + DateTime.Now;

						saveWriter2.WriteLine(hold);

						hold = "";

						hold = "Number of Records: " + this.SoftTable.Rows.Count;
						saveWriter2.WriteLine(hold);
						saveWriter2.WriteLine("  ");
						saveWriter2.WriteLine("  ");

						if(this.chksoftChoice.Checked==true)
						{
							if(this.lisSoftware.CheckedItems.Count != 0)
							{
								this.searchSoftware = "Software = " + this.lisSoftware.CheckedItems[0].ToString();
								for(int e = 1; e<=this.lisSoftware.CheckedItems.Count - 1; e++)
								{
									this.searchSoftware = this.searchSoftware + ", " + this.lisSoftware.CheckedItems[e].ToString();
								}
							}
							else
							{
								this.searchSoftware = this.searchSoftware + "Software = All";
							}
							if(this.searchSoftware != "")
							{
								saveWriter2.WriteLine(this.searchSoftware);
							}
						}
						else
						{
							if(this.chkSoftwareName.Checked==true)
							{
								this.searchSoftware = "Software = " + this.txtSoftwareName.Text ;
								
								if(this.searchSoftware != "")
								{
									saveWriter2.WriteLine(this.searchSoftware);
								}
							}
							
							
						}

						if(this.txtSoftCompName.Text != "")
						{
							this.searchSoftCompName = "Computer Name = " + this.txtSoftCompName.Text;
							if(this.searchSoftCompName != "")
							{
								saveWriter2.WriteLine(this.searchSoftCompName);
							}
						}

						saveWriter2.WriteLine("  ");
						saveWriter2.WriteLine("  ");
						saveWriter2.WriteLine("  ");
						
						while(i<this.SoftTable.Rows.Count)
						{
							
							myRow = this.SoftTable.Rows[i];

							recnum = i+1;

							hold="///////////////     Record Number: "+recnum.ToString()+"     ///////////////";
							saveWriter2.WriteLine(hold);

							hold="Information found for:    "+myRow["ImportedAs"].ToString();
							saveWriter2.WriteLine(hold);

							hold="Computer Name:            "+myRow["ComputerName"].ToString();
							saveWriter2.WriteLine(hold);

							hold="Software Information:     "+"SoftwareName: "+myRow["SoftwareName"].ToString();
							saveWriter2.WriteLine(hold);

							hold="                          Vendor: "+myRow["Vendor"].ToString();
							saveWriter2.WriteLine(hold);

							hold="                          Version: "+ myRow["Version"].ToString();

							saveWriter2.WriteLine(hold);

							saveWriter2.WriteLine("  ");

							i++;
						}
						saveWriter2.Close();
					}
				}
			}
			catch(Exception ex)
			{
				if(this.SoftTable.Rows.Count == 0)
				{
					MessageBox.Show("There was an error creating the saved results file; No search was made  "+ex.Message.ToString(),"Error");
				}
				else
				{
					MessageBox.Show("There was an error creating the saved results file"+ex.Message.ToString(),"Error");
				}
			}
			
			hold = "";
		}

		private void SaveInvDel()
		{//delimited file

			int i = 0;
			string hold;
			DataRow myRow;			
		
			try
			{
				if(this.Catalog.Rows.Count == 0)
				{
					MessageBox.Show("No search was made, or no results returned", "Error");
				}
				else
				{
					DialogResult buttonClicked = this.SaveResults.ShowDialog();
					if(buttonClicked.Equals(DialogResult.OK))
					{
						Stream saveStream2 = this.SaveResults.OpenFile();
						StreamWriter saveWriter2 = new StreamWriter(saveStream2);
					
						saveWriter2.WriteLine("Type; Name; Serial#; Install Date; Status; MFG; Building; Room  ");
						
						while(i<this.Catalog.Rows.Count)
						{
							
							myRow = this.Catalog.Rows[i];
							
							hold = myRow["Type"].ToString() + "; "+myRow["Name"].ToString()+"; "+myRow["SerialNum"].ToString()+"; "+myRow["InstallDate"].ToString()+"; "+ myRow["Status"].ToString()+"; "+myRow["MFG"].ToString()+"; "+ myRow["Building"].ToString()+"; "+myRow["RoomNum"].ToString();

							saveWriter2.WriteLine(hold);

							saveWriter2.WriteLine("  ");

							i++;
						}
						saveWriter2.Close();
					}
				}
			}
			catch(Exception ex)
			{
				if(this.Catalog.Rows.Count == 0)
				{
					MessageBox.Show("There was an error creating the saved results file; No search was made  "+ex.Message.ToString(),"Error ");
				}
				else
				{
					MessageBox.Show("There was an error creating the saved results file"+ex.Message.ToString(),"Error");
				}
			}
			
			hold = "";
		}

		private void SaveInvWord()
		{
			int i = 0;
			string hold;
			DataRow myRow;	
			
			int recnum = 0;
		
			try
			{
				if(this.Catalog.Rows.Count == 0)
				{
					MessageBox.Show("No search was made, or no results returned", "Error");
				}
				else
				{
					
					DialogResult buttonClicked = this.SaveWordDoc.ShowDialog();
					if(buttonClicked.Equals(DialogResult.OK))
					{
						Stream saveStream2 = this.SaveWordDoc.OpenFile();
						StreamWriter saveWriter2 = new StreamWriter(saveStream2);
						
						hold= "Saved Results From Query:         " + DateTime.Now;

						saveWriter2.WriteLine(hold);

						hold = "";

						hold = "Number of Records: " + this.Catalog.Rows.Count;
						saveWriter2.WriteLine(hold);
						saveWriter2.WriteLine("  ");
						saveWriter2.WriteLine("  ");

					
						if((this.lstSortInv.Text=="")||(this.lstSortInv.Text==" "))
						{
							hold="Type: Entire Inventory";
						}
						else
						{
							hold="Type: " + this.InvenHold;
						}

						saveWriter2.WriteLine(hold);

						saveWriter2.WriteLine("  ");
						saveWriter2.WriteLine("  ");
						saveWriter2.WriteLine("  ");
						
						while(i<this.Catalog.Rows.Count)
						{
							
							myRow = this.Catalog.Rows[i];

							recnum = i+1;

							hold="///////////////     Record Number: "+recnum.ToString()+"     ///////////////";
							saveWriter2.WriteLine(hold);

							hold="Type:             "+myRow["Type"].ToString();
							saveWriter2.WriteLine(hold);

							hold="Name:             "+myRow["Name"].ToString();
							saveWriter2.WriteLine(hold);

							hold="Serial #:         "+myRow["SerialNum"].ToString();
							saveWriter2.WriteLine(hold);

							hold="Install Date:     "+myRow["InstallDate"].ToString();
							saveWriter2.WriteLine(hold);

							hold="Status:           "+ myRow["Status"].ToString();
							saveWriter2.WriteLine(hold);

							hold="MFG:              "+ myRow["MFG"].ToString();
							saveWriter2.WriteLine(hold);

							hold="Building:         "+ myRow["Building"].ToString();
							saveWriter2.WriteLine(hold);

							hold="Rm:               "+myRow["RoomNum"].ToString();
							saveWriter2.WriteLine(hold);

							saveWriter2.WriteLine("  ");

							i++;
						}
						saveWriter2.Close();
					}
				}
			}
			catch(Exception ex)
			{
				if(this.Catalog.Rows.Count == 0)
				{
					MessageBox.Show("There was an error creating the saved results file; No search was made"+ex.Message.ToString(),"Error");
				}
				else
				{
					MessageBox.Show("There was an error creating the saved results file"+ex.Message.ToString(),"Error");
				}
			}
			
			hold = "";
		}

		private void SaveFileResults()
		{
			int i = 0;
			string hold;
			DataRow myRow;	
		
			try
			{
				if(this.dtResults.Rows.Count == 0)
				{
					MessageBox.Show("No search was made, or no results returned", "Error");
				}
				else
				{
					DialogResult buttonClicked = this.SaveResults.ShowDialog();
					if(buttonClicked.Equals(DialogResult.OK))
					{
						Stream saveStream = this.SaveResults.OpenFile();
						StreamWriter saveWriter = new StreamWriter(saveStream);
						
						saveWriter.WriteLine("Imported As; Computer Name; Description; Model; Serial Number; Tag; OS; OS Description; OS Version; Total Visible Memory Size; Drive Letter; File System Size; Available Space; File System Type; Processor; Processor Description; Current Clock Speed; Client Version  ");
						
						while(i<this.dtResults.Rows.Count)
						{
							myRow = this.dtResults.Rows[i];

							hold = myRow["ImportedAs"].ToString()+ "; "+myRow["ComputerName"].ToString() + "; "+myRow["Description"].ToString() + "; " +myRow["Model"].ToString() + "; " + myRow["SerialNumber"].ToString()+"; "+myRow["Tag"].ToString() + "; ";
							if(this.OSCheck==1)
							{
								hold = hold + myRow["OS"].ToString() + "; " + myRow["OSDescription"]+"; "+myRow["OSVersion"].ToString()+ "; ";
							}
							else
							{
								hold = hold +" ; ; ;";
							}
							if(this.VisMem==1)
							{
								hold=hold+myRow["TotalVisibleMemorySize"].ToString() + "; ";
							}
							else
							{
								hold = hold+" ; ";
							}
							if(this.DiskCheck==1)
							{
								hold=hold+ myRow["DriveLetter"].ToString() + "; " + myRow["FileSystemSize"].ToString() + "; " + myRow["AvailableSpace"].ToString() + "; " + myRow["FileSystemType"].ToString()+"; ";
							}
							else
							{
								hold=hold+" ; ; ; ; ";
							}
							if(this.ProsCheck==1)
							{
								hold=hold+myRow["ProcessorName"].ToString() + "; " + myRow["ProcessorDescription"].ToString()+"; "+myRow["CurrentClockSpeed"].ToString() + "; "; 
							}
							else
							{
								hold=hold+" ; ; ; ";
							}
							if(this.ClientCheck==1)
							{
								hold=hold+ myRow["ClientVersion"].ToString();
							}

							saveWriter.WriteLine(hold);
							saveWriter.WriteLine("  ");

							i++;
						}
						saveWriter.Close();
						
					}
				
				}
			}
			catch(Exception Ex)
			{
				if(this.dtResults.Rows.Count == 0)
				{
					MessageBox.Show("There was an error creating the saved results file; No search was made  "+Ex.Message.ToString(),"Error");
				}
				else
				{
					MessageBox.Show("There was an error creating the saved results file"+Ex.Message.ToString(),"Error");
				}
			}
			
			hold = "";
		}

		private void SaveHardwareWord()
		{
			int i = 0;
			string hold;
			DataRow myRow;	
		
			try
			{
				if(this.dtResults.Rows.Count == 0)
				{
					MessageBox.Show("No search was made, or no results returned", "Error");
				}
				else
				{
					DialogResult buttonClicked = this.SaveWordDoc.ShowDialog();
					if(buttonClicked.Equals(DialogResult.OK))
					{
						Stream saveStream = this.SaveWordDoc.OpenFile();
						StreamWriter saveWriter = new StreamWriter(saveStream);

						Font myFont = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);
						Font myFont2 = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);

						hold= "Saved Results From Query:         " + DateTime.Now;

						saveWriter.WriteLine(hold,myFont2);

						hold = "";

						hold = "Number of Records: " + this.dtResults.Rows.Count;
						saveWriter.WriteLine(hold);

						saveWriter.WriteLine("  ");

						saveWriter.WriteLine("  ");
						/////////////////   Client    ///////////////////
						if(this.chkClientVer.Checked==true)
						{
							if(this.lisClient.CheckedItems.Count != 0)
							{
								this.searchClient = "Client = ";
								for(int e = 0; e<this.lisClient.CheckedItems.Count; e++)
								{
									this.searchClient = this.searchClient + this.lisClient.CheckedItems[e].ToString()+" ";
								}
							}
							else
							{
								this.searchClient = "Client = All Known On Network";
							}
							if(this.searchClient != "")
							{
								saveWriter.WriteLine(this.searchClient);
							}
						}

						////////////   Computer Name    /////////
						if(this.txtComputerName.Text != "")
						{
							this.searchCompName = "Computer Name = " + this.txtComputerName.Text;
							if(this.searchCompName != "")
							{
								saveWriter.WriteLine(this.searchCompName);
							}
						}

						////////////   Disk Size     ////////////
						if((this.radDiskAll.Checked==true)||(this.radDiskGreat.Checked==true)||(this.radDiskLess.Checked==true))
						{
							if(this.radDiskAll.Checked == true)
							{
								this.searchDiskSize = "Disk Size = All Sizes";
							}

							if(this.radDiskGreat.Checked == true)
							{
								this.searchDiskSize = "Disk Size >= "+this.txtDiskSize.Text +" GB";
							}

							if(this.radDiskLess.Checked == true)
							{
								this.searchDiskSize = "Disk Size <= "+this.txtDiskSize.Text+" GB";
							}
							if(this.searchDiskSize != "")
							{
								saveWriter.WriteLine(this.searchDiskSize);
							}
						}

						//////////     OS     /////////
						if(this.chkOS.Checked==true)
						{
							if(this.lisOperatingSystems.CheckedItems.Count != 0)
							{
								this.searchOS = "Operating System = "+ this.lisOperatingSystems.CheckedItems[0].ToString();
								for(int e = 1; e<this.lisOperatingSystems.CheckedItems.Count; e++)
								{
									this.searchOS = this.searchOS  + ", "+this.lisOperatingSystems.CheckedItems[e].ToString();
								}
							}
							else
							{
								this.searchOS = "Operating System = All Known On Network";
							}
						
							if(this.searchOS != "")
							{
								saveWriter.WriteLine(this.searchOS);
							}
						}

						////////   Serial    //////
						if(this.txtSerial.Text != "")
						{
							this.searchSerial = "Serial # = " + this.txtSerial.Text;

							if(this.searchSerial != "")
							{
								saveWriter.WriteLine(this.searchSerial);
							}
						}
				
						/////////    processor       /////////
						if(this.chkProcessor.Checked==true)
						{
							if(this.lisProcessors.CheckedItems.Count != 0)
							{
								this.searchString = "Processor = "+ this.lisProcessors.CheckedItems[0].ToString();;// + this.lisProcessors.CheckedItems[0].ToString();
								for(int e = 1; e<this.lisProcessors.CheckedItems.Count; e++)
								{
									this.searchString = this.searchString +", " + this.lisProcessors.CheckedItems[e].ToString();
								}
							}
							else
							{
								this.searchString = "Processor = All Known On Network";
							}
							if(this.searchString != "")
							{
								saveWriter.WriteLine(this.searchString);
							}
						}

						/////////   Visible Memory    ///////
						if((this.radMemAll.Checked == true)||(this.radMemLess.Checked == true)||(this.radGreatMem.Checked==true))
						{
							if(this.radMemAll.Checked == true)
							{
								this.searchVisMem = "Visible Memory = All Sizes";
							}
							if(this.radMemLess.Checked == true)
							{
								this.searchVisMem = "Visible Memory <= "+this.txtVisibleMemory.Text;
							}
							if(this.radGreatMem.Checked == true)
							{
								this.searchVisMem = "Visible Memory >= "+this.txtVisibleMemory.Text;
							}
							if(this.searchVisMem != "")
							{
								saveWriter.WriteLine(this.searchVisMem);
							}
						}
						
						int recnum = 0;
						saveWriter.WriteLine("  ");
						saveWriter.WriteLine("  ");
						saveWriter.WriteLine("  ");
						while(i<this.dtResults.Rows.Count)
						{
							myRow = this.dtResults.Rows[i];
							
							saveWriter.WriteLine("  ");

							recnum = i+1;

							hold = "///////////////     Record Number: " + recnum.ToString()+"     ///////////////";
							saveWriter.WriteLine(hold);
							hold ="Imported As:               "+ myRow["ImportedAs"].ToString();
							saveWriter.WriteLine(hold);
							hold= "Computer Information:      Computer Name: "+myRow["ComputerName"].ToString() + "    Description: "+myRow["Description"].ToString(); 
							saveWriter.WriteLine(hold);
							hold= "                           Model:" +myRow["Model"].ToString()+"   Serial Number: " + myRow["SerialNumber"].ToString()+"   Tag: "+myRow["Tag"].ToString();
							saveWriter.WriteLine(hold);

							if(this.OSCheck==1)
							{
								
								hold="Operating System Info:     OS: "+myRow["OS"].ToString() + "    OS Description: " + myRow["OSDescription"].ToString();
								saveWriter.WriteLine(hold);
								hold="                           OS Version: "+myRow["OSVersion"].ToString();
								saveWriter.WriteLine(hold);
							}
							
							if(this.VisMem==1)
							{
								hold="Total Visible MemorySize:  "+myRow["TotalVisibleMemorySize"].ToString()+" MB";
								saveWriter.WriteLine(hold);
							}
							
							if(this.DiskCheck==1)
							{
								hold="Drive Information:         Drive Letter: "+myRow["DriveLetter"].ToString() + "    File System Size: " + myRow["FileSystemSize"].ToString()+" MB"; 
								saveWriter.WriteLine(hold);
								hold="                           Available Space: " + myRow["AvailableSpace"].ToString() + " MB    File System Type: " + myRow["FileSystemType"].ToString();
								saveWriter.WriteLine(hold);
							}
						
							if(this.ProsCheck==1)
							{
								hold="Processor Information:     Processor Name: "+myRow["ProcessorName"].ToString(); 
								saveWriter.WriteLine(hold);
								hold="                           Processor Description: " + myRow["ProcessorDescription"].ToString();
								saveWriter.WriteLine(hold);
								hold="                           Current Clock Speed: "+myRow["CurrentClockSpeed"].ToString()+" MHz"; 
								saveWriter.WriteLine(hold);
							}
							
							if(this.ClientCheck==1)
							{
								hold="Client Version:            "+myRow["ClientVersion"].ToString();
								saveWriter.WriteLine(hold);
							}

							saveWriter.WriteLine("  ");

							i++;
						}
						saveWriter.Close();
						
					}
				
				}
			}
			catch(Exception ex)
			{
				if(this.dtResults.Rows.Count == 0)
				{
					MessageBox.Show("There was an error creating the saved results file; No search was made  "+ex.Message.ToString(),"Error");
				}
				else
				{
					MessageBox.Show("There was an error creating the saved results file  "+ex.Message.ToString(),"Error");
				}
			}
			
			hold = "";
		}
		#endregion
		#region PrintPage
		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Font myFont = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);
			Font myFont2 = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);
			Font myFont3 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);

			float LeftMargin = e.MarginBounds.Left;
			float TopMargin = e.MarginBounds.Top;
			float BottomMargin = e.MarginBounds.Bottom;
			float Yposition = 0;
			float XPosition = 0;
			int Counter = 0;

			int recnum = 0;
			int NumberOfRecords=0;
			string[] HoldString;
			char[] delimiter;
			string delstr = ",";
			int t = 0;

			delimiter=delstr.ToCharArray();
			
			string CurrentLine;

			try
			{
				pageNum++;
				CurrentLine= "Current Results From Query:" + "    " + "Run: "+DateTime.Now+ "           Page Number: " + pageNum.ToString();
				
				e.Graphics.DrawString(CurrentLine, myFont2,Brushes.Black,0,Yposition, new StringFormat());
				if(this.SaveCheck == 0)
				{
					NumberOfRecords = dtResults.Rows.Count;
					CurrentLine="Number of Records: " + NumberOfRecords.ToString();
					Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
					e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
				}
				else
				{
					if(this.SaveCheck==2)//Inventory
					{
						NumberOfRecords = this.Catalog.Rows.Count;
						CurrentLine="Number of Records: " + NumberOfRecords.ToString();
						Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
						e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
					}
					else
					{
						NumberOfRecords = this.SoftTable.Rows.Count;
						CurrentLine="Number of Records: " + NumberOfRecords.ToString();
						Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
						e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
					}
				}

				Counter++;

				if(this.SaveCheck == 1) 
				{
					//header information for software
					if(this.chksoftChoice.Checked==true)
					{
						if(this.lisSoftware.CheckedItems.Count != 0)
						{
							this.searchSoftware = "Software = " + this.lisSoftware.CheckedItems[0].ToString();
							for(int i = 1; i<=this.lisSoftware.CheckedItems.Count - 1; i++)
							{
								this.searchSoftware = this.searchSoftware + ", " + this.lisSoftware.CheckedItems[i].ToString();
							}
						}
						else
						{
							this.searchSoftware = this.searchSoftware + "Software = All";
						}

						if(this.searchSoftware.Length>100)//if the string is too long, break it up
						{
						
							HoldString=this.searchSoftware.Split(delimiter);
							t=0;
							XPosition=0;
							while(t<HoldString.Length)
							{
								//try and put three items on a line, as long as its not at the end of the list
							
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								
								CurrentLine = HoldString[t].ToString();
								t++;
								if(t<HoldString.Length)
								{
									CurrentLine = CurrentLine+", "+HoldString[t].ToString();
									t++;
								}
								if(t<HoldString.Length)
								{
									CurrentLine = CurrentLine+", "+HoldString[t].ToString()+", ";
									t++;
								}
								
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,XPosition,Yposition, new StringFormat());
								
								Counter++;
								XPosition=25;
							}
						}
						else
						{
							Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
							CurrentLine = this.searchSoftware;
							e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
							Counter++;
						}
					}
					else
					{
						if(this.chkSoftwareName.Checked == true)
						{
							this.searchSoftware = "Software = " + this.txtSoftwareName.Text;
							Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
							CurrentLine = this.searchSoftware;
							e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
							Counter++;
						}
					}
				
					if(this.txtSoftCompName.Text != "")
					{
						this.searchSoftCompName = "Computer Name = " + this.txtSoftCompName.Text;
						if(this.searchSoftCompName != "")
						{
							Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
							CurrentLine = this.searchSoftCompName;
							e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
							Counter++;
						}
					}
				}
				else
				{
					if(this.SaveCheck == 0) //header information for hardware
					{
						//////////////////   Client   /////////////////
						if(this.chkClientVer.Checked==true)
						{
							if(this.lisClient.CheckedItems.Count != 0)
							{
								for(int i = 0; i<this.lisClient.CheckedItems.Count; i++)
								{
									this.searchClient = this.searchClient + this.lisClient.CheckedItems[i].ToString()+" ";
								}
							}
							else
							{
								this.searchClient = "Client = All Known On Network";
							}
							if(this.searchClient != "")
							{
								if(this.searchClient.Length>100)
								{
									//HoldString="";
									HoldString = this.searchClient.Split(delimiter);
									t=0;
									XPosition=0;
									while(t<HoldString.Length)
									{
										Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
										CurrentLine = HoldString[t];
										t++;

										if(t<HoldString.Length)
										{
											CurrentLine = CurrentLine+", "+HoldString[t];
											t++;
										}

										if(t<HoldString.Length)
										{
											CurrentLine = CurrentLine+", "+HoldString[t];
											t++;
										}
										e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,XPosition,Yposition, new StringFormat());
										Counter++;
										XPosition = 25;
									}
								}
								else
								{
									Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
									CurrentLine = this.searchClient;
									e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
									Counter++;
								}

							}
						}

						/////////////////   Computer Name     /////////////////
						if(this.txtComputerName.Text != "")
						{
							this.searchCompName = "Computer Name = " + this.txtComputerName.Text;
							if(this.searchCompName != "")
							{
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								CurrentLine = this.searchCompName;
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
								Counter++;

							}
						}
						//////////////////////   Disk Size   ////////////////////
						if((this.radDiskAll.Checked==true)||(this.radDiskGreat.Checked==true)||(this.radDiskLess.Checked==true))
						{
							if(this.radDiskAll.Checked == true)
							{
								this.searchDiskSize = "Disk Size = All Sizes";
							}

							if(this.radDiskGreat.Checked == true)
							{
								this.searchDiskSize = "Disk Size >= "+this.txtDiskSize.Text +" GB";
							}

							if(this.radDiskLess.Checked == true)
							{
								this.searchDiskSize = "Disk Size <= "+this.txtDiskSize.Text+" GB";
							}

							if(this.searchDiskSize != "")
							{
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								CurrentLine =  this.searchDiskSize;
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
								Counter++;

							}
						}

						///////////////////////////////  OS   ////////////////
						if(this.chkOS.Checked==true)
						{
							if(this.lisOperatingSystems.CheckedItems.Count != 0)
							{
								this.searchOS = "Operating System = "+ this.lisOperatingSystems.CheckedItems[0].ToString();
								for(int i = 1; i<this.lisOperatingSystems.CheckedItems.Count; i++)
								{
									this.searchOS = this.searchOS  + ", "+this.lisOperatingSystems.CheckedItems[i].ToString();
								}
							}
							else
							{
								this.searchOS = "Operating System = All Known On Network";
							}
						}

						if(this.searchOS != "")
						{
							if(this.searchOS.Length>100)
							{
								HoldString=this.searchOS.Split(delimiter);
								t=0;
								XPosition=0;
								while(t<HoldString.Length)
								{
									Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
									CurrentLine =  HoldString[t];
									t++;

									if(t<HoldString.Length)
									{
										CurrentLine =  CurrentLine+", "+HoldString[t];
										t++;
									}

									if(t<HoldString.Length)
									{
										CurrentLine =  CurrentLine+", "+HoldString[t];
										t++;
									}
							
									if(t<HoldString.Length)
									{
										CurrentLine =  CurrentLine+", "+HoldString[t];
										t++;
									}
									e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,XPosition,Yposition, new StringFormat());
									Counter++;
									XPosition = 25;

								}
							}
							else
							{
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								CurrentLine =  this.searchOS;
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
								Counter++;
							}
						}
						////////////////////////    Serial     //////////////////////

						if(this.txtSerial.Text != "")
						{
							this.searchSerial = "Serial # = " + this.txtSerial.Text;
							if(this.searchSerial != "")
							{
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								CurrentLine =  this.searchSerial;
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
								Counter++;
							}
						}

						/////////////////  Processor    //////////////////
						if(this.chkProcessor.Checked==true)
						{
							if(this.lisProcessors.CheckedItems.Count != 0)
							{
								this.searchString = "Processor = "+ this.lisProcessors.CheckedItems[0].ToString();;// + this.lisProcessors.CheckedItems[0].ToString();
								for(int i = 1; i<this.lisProcessors.CheckedItems.Count; i++)
								{
									this.searchString = this.searchString +", " + this.lisProcessors.CheckedItems[i].ToString();
								}
							}
							else
							{
								this.searchString = "Processor = All Known On Network";
							}
							if(this.searchString != "")
							{
								if(this.searchString.Length>100)
								{
									HoldString=this.searchString.Split(delimiter);
									t=0;
									XPosition=0;
									while(t<HoldString.Length)
									{
										Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
										CurrentLine =  HoldString[t];
										t++;

										if(t<HoldString.Length)
										{
											CurrentLine =  CurrentLine+", "+HoldString[t];
											t++;
										}

										if(t<HoldString.Length)
										{
											CurrentLine =  CurrentLine+", "+HoldString[t];
											t++;
										}
										if(t<HoldString.Length)
										{
											CurrentLine =  CurrentLine+", "+HoldString[t];
											t++;
										}
										e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,XPosition,Yposition, new StringFormat());
										Counter++;
										XPosition=25;
									}
								}
								else
								{
									Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
									CurrentLine =  this.searchString;
									e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
									Counter++;
								}
							}
						}

						///////////      Visible Memory    ///////////////
						if((this.radMemAll.Checked == true)||(this.radMemLess.Checked == true)||(this.radGreatMem.Checked==true))
						{
							if(this.radMemAll.Checked == true)
							{
								this.searchVisMem = "Visible Memory = All Sizes";
							}
							if(this.radMemLess.Checked == true)
							{
								this.searchVisMem = "Visible Memory <= "+this.txtVisibleMemory.Text;
							}
							if(this.radGreatMem.Checked == true)
							{
								this.searchVisMem = "Visible Memory >= "+this.txtVisibleMemory.Text;
							}

							if(this.searchVisMem != "")
							{
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								CurrentLine =  this.searchVisMem;
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
								Counter++;
							}
						}
					}
					else
					{
						if(this.SaveCheck==2)//Inventory
						{
							if((this.lstSortInv.Text==" ")||(this.lstSortInv.Text==""))
							{
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								CurrentLine =  "Type: Entire Inventory";
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
								Counter++;
							}
							else
							{
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								CurrentLine =  "Type: "+this.lstSortInv.Text;
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
								Counter++;
							}
						}
					}
				}

				Counter++;

				if(this.SaveCheck == 0)
				{

					while(Counter < MyLines && this.rowCount < this.dtResults.Rows.Count)
					{
					
						try
						{
							this.printRow = this.dtResults.Rows[rowCount];

							recnum = rowCount + 1;
							CurrentLine="///////////////     Record Number: "+recnum.ToString()+"     ///////////////";
							Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
							e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
							Counter++;

							CurrentLine = "Information found for: ";
							Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
							e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
							
							CurrentLine = printRow["ImportedAS"].ToString(); 
							Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
							e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
							Counter++;
							CurrentLine="";

							CurrentLine = "Computer Information:";
							Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
							e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
							
							CurrentLine = "Computer Name: "+printRow["ComputerName"].ToString() + "     "+"Description: "+printRow["Description"].ToString() + "     "; 
							Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
							e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
							Counter++;
							CurrentLine = "Model: " + printRow["Model"].ToString() + "     " + "Serial#: "+printRow["SerialNumber"].ToString()+"     "+"Tag#: "+printRow["Tag"].ToString() + " ";
							Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
							e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
							Counter++;

							if(this.OSCheck == 1)
							{
								
								CurrentLine="Operating System Information: ";
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
								CurrentLine="Operating System: " + printRow["OS"].ToString() + "    Operating System Description: " +printRow["OSDescription"].ToString(); //five spaces between right now
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
								CurrentLine = "Version: "+printRow["OSVersion"].ToString();
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
							}
							
							CurrentLine="";
						
						
							if(this.VisMem==1)
							{
								CurrentLine="Total Visible Memory: ";
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
								CurrentLine = printRow["TotalVisibleMemorySize"].ToString() + " MB";
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
								CurrentLine="";
							}
							if(this.DiskCheck==1)
							{
								CurrentLine="Disk Drive Information: ";
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
								CurrentLine = "Drive Letter: " + printRow["DriveLetter"].ToString() + "     " +"File System Size: "+ printRow["FileSystemSize"].ToString(); 
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
								CurrentLine="Available Space: "+printRow["AvailableSpace"].ToString() + " MB     " + "File System Type: "+printRow["FileSystemType"].ToString();
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
							}
							

							if(this.ProsCheck ==1)
							{
								CurrentLine = "Processor Information: "; 
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
								
								CurrentLine = "Processor Name: " + this.printRow["ProcessorName"].ToString()+"     "+"Processor Description: "+this.printRow["ProcessorDescription"].ToString();
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
								CurrentLine = "Current Clock Speed: "+this.printRow["CurrentClockSpeed"].ToString()+ " MHz";
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
							}
							if(this.ClientCheck==1)
							{
							
								CurrentLine = "Novel Client Information: ";
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
									
								CurrentLine = "ClientVersion: "+printRow["ClientVersion"].ToString();
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
							}
						
							CurrentLine="";
							Counter++; //add space between records
							rowCount++;
						
						}
						catch
						{
							Counter++; //add space between records
							rowCount++;
						}
					}
					if(!(rowCount == this.dtResults.Rows.Count))
					{
						e.HasMorePages = true;
					}
					else
					{
						e.HasMorePages=false;
						rowCount = 0;
						pageNum = 0;
					}
				}
				else
				{
					if(this.SaveCheck==2)//Inventory
					{
						while(Counter < MyLines && this.rowCount < this.Catalog.Rows.Count)
						{
					
							try
							{
								this.printRow = this.Catalog.Rows[rowCount];
								
								int MoveIt = 200;

								recnum = rowCount + 1;
								CurrentLine="///////////////     Record Number: "+recnum.ToString()+"     ///////////////";
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
								Counter++;

								CurrentLine = "Type: "+printRow["Type"].ToString(); 
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
								Counter++;
								CurrentLine="";

								CurrentLine = "Name: "+printRow["Name"].ToString(); 
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
								CurrentLine = "Serial #: "+printRow["SerialNum"].ToString(); 

								if(printRow["Name"].ToString().Length> 195)
								{
									MoveIt=printRow["Name"].ToString().Length +20;
								}
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,MoveIt,Yposition, new StringFormat());
								Counter++;
								CurrentLine="";

								CurrentLine = "Install Date: "+printRow["InstallDate"].ToString(); 
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
								CurrentLine = "Status: "+printRow["Status"].ToString(); 
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
								CurrentLine="";
								
								CurrentLine = "MFG: "+printRow["MFG"].ToString(); 
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,0,Yposition, new StringFormat());
								CurrentLine = "Building: "+printRow["Building"].ToString()+ " Rm: "+ printRow["RoomNum"].ToString(); 
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
								CurrentLine="";

								Counter++; //add space between records
								rowCount++;
							}
							catch
							{
								Counter++; //add space between records
								rowCount++;
							}

						}
						if(!(rowCount == this.Catalog.Rows.Count))
						{
							e.HasMorePages = true;
						}
						else
						{
							e.HasMorePages=false;
							rowCount = 0;
							pageNum = 0;
						}
					}
					else
					{
						try
						{
							while(Counter < MyLines && this.rowCount < this.SoftTable.Rows.Count)
							{
								this.printRow = this.SoftTable.Rows[rowCount];
							
								recnum = rowCount + 1;

								CurrentLine = "///////////////     Record Number: "+recnum.ToString()+"     ///////////////";
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());
								Counter++;

								CurrentLine = "Information found for: ";
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());

								CurrentLine = printRow["ImportedAS"].ToString(); 
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;

								CurrentLine = "Computer Name: ";
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());

								CurrentLine = printRow["ComputerName"].ToString();
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;

								CurrentLine = "Software Information: ";
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont3,Brushes.Black,0,Yposition, new StringFormat());

								CurrentLine = "Software Name: "+printRow["SoftwareName"].ToString();
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
								CurrentLine = "Vendor: "+printRow["Vendor"].ToString() + "    " + "Version: " + printRow["Version"].ToString();
								Yposition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
								e.Graphics.DrawString(CurrentLine, myFont,Brushes.Black,200,Yposition, new StringFormat());
								Counter++;
								Counter++; //add space between records
								rowCount++;
							}
							if(!(rowCount == this.SoftTable.Rows.Count))
							{
								e.HasMorePages = true;
							}
							else
							{
								e.HasMorePages=false;
								rowCount = 0;
								pageNum = 0;
							}
						}
						catch(Exception ex)
						{
							MessageBox.Show("Error printing information  "+ex.Message.ToString(),"Error");
						}
					}
				}
			}
			catch
			{
				Counter++; //add space between records
				rowCount++;
			}	
		}
		#endregion
		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			//page setup dialog box
			PageSetupDialog myDialog = new PageSetupDialog();
			myDialog.Document = this.printDocument1;

			myDialog.ShowDialog();
			rowCount = 0; //reset print line counter back to 0
		
		}

		private void PrintTheResults()
		{

			PrintResults.Document = this.printDocument1;

			DialogResult buttonClicked = this.PrintResults.ShowDialog();

			if(printDocument1.DefaultPageSettings.Landscape == true)
			{
				this.MyLines = 35;
			}
			else
			{
				this.MyLines = 55;
			}

			if(buttonClicked.Equals(DialogResult.OK))
			{
				this.printDocument1.Print();
			}

			rowCount = 0; //reset row counter back to 0
		}

		#region button and menu code
		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			//print preview dialog box

			PrintPreview.Document = this.printDocument1;

			if(printDocument1.DefaultPageSettings.Landscape == true)
			{
				this.MyLines = 35;
			}
			else
			{
				this.MyLines = 55;
			}

			this.PrintPreview.ShowDialog();

			rowCount = 0; //set print counter back to 0
			

		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			//to open a new form, you first need to create a new instance
			Form myForm= new About();

			myForm.ShowDialog();  //then open it.
			myForm.Dispose();

		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			this.SaveChoiceBox();
		}

		private void SaveChoiceBox()
		{
			if(this.SaveCheck == 1)
			{
				Form SaveChoice = new SaveChoice();
				DialogResult buttonClick = SaveChoice.ShowDialog();
				if(buttonClick.Equals(DialogResult.Yes))
				{
					this.SaveSoftwareResults();
				}
				else
				{
					if(buttonClick.Equals(DialogResult.OK))
					{
						this.SaveSoftwareWord();
					}
				}
				SaveChoice.Dispose();
			}
			else
			{
				if(SaveCheck==2)
				{
					Form SaveChoice = new SaveChoice();
					DialogResult buttonClick = SaveChoice.ShowDialog();
					if(buttonClick.Equals(DialogResult.Yes))
					{
						//save as delimited file (inventory)
						this.SaveInvDel();
					}
					else
					{
						if(buttonClick.Equals(DialogResult.OK))
						{
							//save as word file (inventory)
							this.SaveInvWord();
						}
					}
					SaveChoice.Dispose();

				}
				else
				{
					Form SaveChoice = new SaveChoice();
					DialogResult buttonClick = SaveChoice.ShowDialog();
					if(buttonClick.Equals(DialogResult.Yes))
					{
						this.SaveFileResults();
					}
					else
					{
						if(buttonClick.Equals(DialogResult.OK))
						{
							this.SaveHardwareWord();
						}
					}
					SaveChoice.Dispose();
				}
			}
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			this.PrintTheResults();
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			this.txtComputerName.Text = "";
			this.txtDiskSize.Text  = "";
			this.txtDiskSize.Enabled=false;
			this.txtSerial.Text = "";
			this.txtVisibleMemory.Text = "";
			this.txtVisibleMemory.Enabled=false;
			this.chkClientVer.Checked = false;
			this.chkComputerName.Checked = false;
			this.chkNameWild.Checked=false;
			this.chkOS.Checked = false;
			this.chkProcessor.Checked = false;
			this.chkSerial.Checked = false;
			this.chkSerialWildCard.Checked = false;
			this.radDiskAll.Checked=false;
			this.radNoDisk.Checked=false;
			this.radDiskGreat.Checked=false;
			this.radDiskLess.Checked=false;
			this.radMemAll.Checked=false;
			this.radMemLess.Checked=false;
			this.radGreatMem.Checked=false;
			this.radNoMem.Checked=false;

			this.lstOSVersion.Items.Clear();

			try
			{
				if(this.lisClient.CheckedItems.Count!=0)
				{
				
					for(int i=0;i<this.lisClient.Items.Count;i++)
					{
						this.lisClient.SetItemChecked(i,false);
					}

				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Error");
			}

			try
			{
				if(this.lisProcessors.CheckedItems.Count!=0)
				{
					for(int i=0;i<this.lisProcessors.Items.Count;i++)
					{
						this.lisProcessors.SetItemChecked(i,false);
					}

				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Error");
			}

			try
			{
				if(this.lisOperatingSystems.CheckedItems.Count!=0)
				{
					for(int i=0;i<this.lisOperatingSystems.Items.Count;i++)
					{
						this.lisOperatingSystems.SetItemChecked(i,false);
					}

				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Error");
			}
			
		}

		private void radDiskGreat_Click(object sender, EventArgs e)
		{
			this.EnableDisk();
			this.radDiskGreat.Checked=true;
		}

		private void radMemLess_Click(object sender, EventArgs e)
		{
			this.EnableMemory();
			this.radMemLess.Checked=true;
		}

		private void EnableMemory()
		{
			this.txtVisibleMemory.Enabled = true;
			//this.txtVisibleMemory.Focus();
		}

		private void EnableDisk()
		{
			this.txtDiskSize.Enabled = true;
			//this.txtDiskSize.Focus();
		}

		private void radDiskLess_Click(object sender, EventArgs e)
		{
			this.EnableDisk();
			this.radDiskLess.Checked=true;
		}

		private void radGreatMem_Click(object sender, EventArgs e)
		{
			this.EnableMemory();
			this.radGreatMem.Checked=true;
		}

		private void radDiskAll_Click(object sender, EventArgs e)
		{
			this.radDiskAll.Checked=true;
			this.txtDiskSize.Enabled = false;
			this.txtDiskSize.Text = "";
			this.searchDiskSize = "Disk Size = All";
		}

		private void radMemAll_Click(object sender, EventArgs e)
		{
			this.radMemAll.Checked=true;
			this.txtVisibleMemory.Enabled = false;
			this.txtVisibleMemory.Text = "";
			this.searchVisMem = "Visible Memory = All";
		}

		private void menuItem8_Click(object sender, EventArgs e)
		{
			//Help Page
			try
			{
				//System.Diagnostics.Process.Start( "HelpPage.htm");
			}
			catch(Exception ex)
			{
				MessageBox.Show("Cannot Open Internet Browser  "+ex.Message.ToString(),"Browser Error");
			}
			
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			this.dgResults.Width = int.Parse(this.Width.ToString()) - 40;
			this.dgInventory.Width = int.Parse(this.Width.ToString()) - 40;
			this.dgSoftware.Width = int.Parse(this.Width.ToString()) - 40;
			this.tabControl1.Width = int.Parse(this.Width.ToString());
		}

		private void btnSoftSave_Click(object sender, System.EventArgs e)
		{
			this.SaveChoiceBox();
		}

		private void btnSoftPrint_Click(object sender, System.EventArgs e)
		{
			this.PrintTheResults();
		}

		private void btnSoftExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		#endregion

		private void btnSoftSearch_Click(object sender, System.EventArgs e)
		{	
			try
			{
				if((this.chkSoftwareName.Checked == false)&&(this.chkSoftCompName.Checked == false)&&(this.chksoftChoice.Checked==false))
				{
					Form SearchCheck = new SoftSearchCheck();
					DialogResult buttonClick = SearchCheck.ShowDialog();
					if(buttonClick.Equals(DialogResult.OK))
					{
						this.SaveCheck = 1;
						this.lblCount.Text = "Loading Results...";
						this.RunSoftSearch();
					}
					else
					{
						MessageBox.Show("Search Aborted","No Search");
					}
			
				}
				else
				{
					if((this.lisSoftware.CheckedItems.Count==0)&&(this.chkSoftCompName.Checked==false)&&(this.chkSoftwareName.Checked == false))
					{
						Form SearchCheck = new SoftSearchCheck();
						DialogResult buttonClick = SearchCheck.ShowDialog();
						if(buttonClick.Equals(DialogResult.OK))
						{
							this.SaveCheck = 1;
							this.lblCount.Text = "Loading Results...";
							this.RunSoftSearch();
						}
						else
						{
							MessageBox.Show("Search Aborted","No Search");
						}
					}
					else
					{
						this.SaveCheck = 1;
						this.lblCount.Text = "Loading Results...";
						this.RunSoftSearch();
					}
				
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Error");
			}
		}

		private void btnSoftClear_Click(object sender, System.EventArgs e)
		{
			this.chksoftChoice.Checked = false;
			this.chkSoftCompName.Checked = false;
			this.chkSoftNameWild.Checked = false;
			this.chkSoftwareName.Checked=false;
			this.chkWildSoftName.Checked=false;
			this.txtSoftwareName.Text = "";
			this.lisSoftware.Items.Clear();
			//try
			//{
				//if(this.lisSoftware.CheckedItems.Count!=0)
				//{

					//this.lisSoftware.Items.Clear();
					//for(int i=0;i<this.lisSoftware.Items.Count;i++)
					//{
					//	this.lisSoftware.SetItemChecked(i,false);
					//}

				//}
			//}
			//catch(Exception ex)
			//{
			//	MessageBox.Show(ex.Message.ToString(),"Error");
			//}
		}

		private void btnNoSort_Click(object sender, System.EventArgs e)
		{
			this.radAvSizeASC.Checked = false;
			this.radAvSizeDESC.Checked = false;
			this.radClientASC.Checked = false;
			this.radClientDESC.Checked = false;
			this.radCompNameASC.Checked = false;
			this.radCompNameDESC.Checked = false;
			this.radCurrClASC.Checked = false;
			this.radCurrClDESC.Checked = false;
			this.radDescASC.Checked = false;
			this.radDescDESC.Checked = false;
			this.radDriveNameASC.Checked = false;
			this.radDriveNameDESC.Checked = false;
			this.radFileSysSizASC.Checked = false;
			this.radFileSysSizeDESC.Checked = false;
			this.radFSTASC.Checked = false;
			this.radFSTDESC.Checked = false;
			this.radImportASC.Checked = false;
			this.radImportDESC.Checked = false;
			this.radModelASC.Checked = false;
			this.radModelDESC.Checked = false;
			this.radOSASC.Checked = false;
			this.radOSVerASC.Checked = false;
			this.radOSDESC.Checked = false;
			this.radOSVerDESC.Checked = false;
			this.radProcASC.Checked = false;
			this.radProcDESC.Checked = false;
			this.radSerialASC.Checked = false;
			this.radSerialDESC.Checked = false;
			this.radSoftCompNameASC.Checked = false;
			this.radSoftCompNameDESC.Checked = false;
			this.radSoftNameASC.Checked = false;
			this.radSoftNameDESC.Checked = false;
			this.radTagASC.Checked = false;
			this.radTAGDESC.Checked = false;
			this.radTotVisMemDESC.Checked = false;
			this.radTotVisMemSizeASC.Checked = false;
			this.radVendorASC.Checked = false;
			this.radVendorDESC.Checked = false;
			this.radVerASC.Checked = false;
			this.radVerDESC.Checked = false;

			this.OrderItems = "";
		}

		private void OrderHardItemsSort()
		{

			try
			{
				this.radVendorASC.Checked = false;
				this.radVendorDESC.Checked = false;
				this.radVerASC.Checked = false;
				this.radVerDESC.Checked = false;
				this.radSoftCompNameASC.Checked = false;
				this.radSoftCompNameDESC.Checked = false;
				this.radSoftNameASC.Checked = false;
				this.radSoftNameDESC.Checked = false;

				this.OrderItems = "";
				this.OrderItems = "ORDER BY ";
				////// Client ///////
			
				if(this.radClientASC.Checked == true)
				{
					if(this.chkClientVer.Checked==true)
					{
						this.OrderItems = this.OrderItems + "ClientVersion ASC";
					}
					else
					{
						MessageBox.Show("Cannot sort; Client Version was not chosen to search","Sort Error");
						this.OrderItems = "";
						this.radClientASC.Checked=false;
					}
				}

				if(this.radClientDESC.Checked == true)
				{
					if(this.chkClientVer.Checked == true)
					{
						this.OrderItems = this.OrderItems + "ClientVersion DESC";
					}
					else
					{
						MessageBox.Show("Cannot sort; Client Version was not chosen to search","Sort Error");
						this.OrderItems = "";
						this.radClientDESC.Checked = false;
					}
				}
			

				///////   Basic //////////////
				if(this.radCompNameASC.Checked == true)
				{
					this.OrderItems = this.OrderItems + "ComputerName ASC";
				}

				if(this.radCompNameDESC.Checked == true)
				{
					this.OrderItems = this.OrderItems + "ComputerName DESC";
				}

				if(this.radDescASC.Checked == true)
				{
					this.OrderItems = this.OrderItems + "ZENWorks.SystemInfo.Description ASC";
				}

				if(this.radDescDESC.Checked == true)
				{
					this.OrderItems = this.OrderItems + "ZENWorks.SystemInfo.Description DESC";
				}

				/////    Hard Drive ///////
				if(this.radDriveNameASC.Checked == true)
				{
					if((this.radDiskAll.Checked==true)||(this.radDiskGreat.Checked==true)||(this.radDiskLess.Checked==true))
					{
						this.OrderItems = OrderItems + "DriveLetter ASC";
					}
					else
					{
						MessageBox.Show("Cannot sort; Drive Information was not chosen to search","Sort Error");
						this.OrderItems = "";
						this.radDriveNameASC.Checked=false;
					}
				}

				if(this.radDriveNameDESC.Checked == true)
				{
					if((this.radDiskAll.Checked==true)||(this.radDiskGreat.Checked==true)||(this.radDiskLess.Checked==true))
					{
						this.OrderItems = this.OrderItems + "DriveLetter DESC";
					}
					else
					{
						MessageBox.Show("Cannot sort; Drive Information was not chosen to search","Sort Error");
						this.OrderItems="";
						this.radDriveNameDESC.Checked=false;
					}
				}

				if(this.radFileSysSizASC.Checked == true)
				{
					if((this.radDiskAll.Checked==true)||(this.radDiskGreat.Checked==true)||(this.radDiskLess.Checked==true))
					{
						this.OrderItems = this.OrderItems + "FileSystemSize ASC";
					}
					else
					{
						MessageBox.Show("Cannot sort; Drive Information was not chosen to search","Sort Error");
						this.OrderItems="";
						this.radFileSysSizASC.Checked=false;
					}
				}

				if(this.radFileSysSizeDESC.Checked == true)
				{
					if((this.radDiskAll.Checked==true)||(this.radDiskGreat.Checked==true)||(this.radDiskLess.Checked==true))
					{
						this.OrderItems = this.OrderItems + "FileSystemSize DESC";
					}
					else
					{
						MessageBox.Show("Cannot sort; Drive Information was not chosen to search","Sort Error");
						this.OrderItems="";
						this.radFileSysSizeDESC.Checked=false;
					}
				}

				if(this.radFSTASC.Checked == true)
				{
					if((this.radDiskAll.Checked==true)||(this.radDiskGreat.Checked==true)||(this.radDiskLess.Checked==true))
					{
						this.OrderItems = this.OrderItems + "FileSystemType ASC";
					}
					else
					{
						MessageBox.Show("Cannot sort; Drive Information was not chosen to search","Sort Error");
						this.OrderItems="";
						this.radFSTASC.Checked=false;
					}
				}

				if(this.radFSTDESC.Checked == true)
				{
					if((this.radDiskAll.Checked==true)||(this.radDiskGreat.Checked==true)||(this.radDiskLess.Checked==true))
					{
						this.OrderItems = this.OrderItems + "FileSystemType DESC";
					}
					else
					{
						MessageBox.Show("Cannot sort; Drive Information was not chosen to search","Sort Error");
						this.OrderItems="";
						this.radFSTDESC.Checked=false;
					}
				}

				if(this.radAvSizeASC.Checked == true)
				{
					if((this.radDiskAll.Checked==true)||(this.radDiskGreat.Checked==true)||(this.radDiskLess.Checked==true))
					{
						this.OrderItems = this.OrderItems + "AvailableSpace ASC";
					}
					else
					{
						MessageBox.Show("Cannot sort; Drive Information was not chosen to search","Sort Error");
						this.OrderItems="";
						this.radAvSizeASC.Checked=false;
					}
				}

				if(this.radAvSizeDESC.Checked == true)
				{
					if((this.radDiskAll.Checked==true)||(this.radDiskGreat.Checked==true)||(this.radDiskLess.Checked==true))
					{
						this.OrderItems = this.OrderItems + "AvailableSpace DESC";
					}
					else
					{
						MessageBox.Show("Cannot sort; Drive Information was not chosen to search","Sort Error");
						this.OrderItems="";
						this.radAvSizeDESC.Checked=false;
					}
				}
				///////  Basic ////////
				if(this.radImportASC.Checked ==true)
				{
					this.OrderItems= this.OrderItems + "ImportedAs ASC";
				}

				if(this.radImportDESC.Checked ==true)
				{
					this.OrderItems = this.OrderItems + "ImportedAs DESC";
				}

				if(this.radModelASC.Checked == true)
				{
					this.OrderItems = this.OrderItems + "Model ASC";
				}

				if(this.radModelDESC.Checked ==true)
				{
					this.OrderItems = this.OrderItems + "Model DESC";
				}
				///////// Operating Systems ///////////
				if(this.radOSASC.Checked == true)
				{
					if(this.chkOS.Checked==true)
					{
						this.OrderItems = this.OrderItems + "OS ASC, OSDescription ASC";
					}
					else
					{
						MessageBox.Show("Cannot Sort; Operating System Information not chosen to search","Sort Error");
						this.OrderItems="";
						this.radOSASC.Checked=false;
					}
				}
			
				if(this.radOSDESC.Checked == true)
				{
					if(this.chkOS.Checked==true)
					{
						this.OrderItems = this.OrderItems + "OS DESC, OSDescription DESC";
					}
					else
					{
						MessageBox.Show("Cannot Sort; Operating System Information not chosen to search","Sort Error");
						this.OrderItems="";
						this.radOSDESC.Checked=false;
					}
				}

				if(this.radOSVerASC.Checked == true)
				{
					if(this.chkOS.Checked==true)
					{
						this.OrderItems = this.OrderItems + "OSVersion ASC";
					}
					else
					{
						MessageBox.Show("Cannot Sort; Operating System Information not chosen to search","Sort Error");
						this.OrderItems="";
						this.radOSVerASC.Checked = false;
					}
				}

				if(this.radOSVerDESC.Checked == true)
				{ 
					if(this.chkOS.Checked==true)
					{
						this.OrderItems = this.OrderItems + "OSVersion DESC";
					}
					else
					{
						MessageBox.Show("Cannot Sort; Operating System Information not chosen to search","Sort Error");
						this.OrderItems="";
						this.radOSVerDESC.Checked = false;
					}
				}
				/////////  Processor /////////
				if(this.radProcASC.Checked == true)
				{
					if(this.chkProcessor.Checked==true)
					{
						this.OrderItems = this.OrderItems + "ProcessorName ASC, ProcessorDescription ASC";
					}
					else
					{
						MessageBox.Show("Cannot Sort; Processor Information was not chosen to search","Sort Error");
						this.OrderItems="";
						this.radProcASC.Checked=false;

					}
				}

				if(this.radProcDESC.Checked == true)
				{
					if(this.chkProcessor.Checked==true)
					{
						this.OrderItems = this.OrderItems + "ProcessorName DESC, ProcessorDescription DESC";
					}
					else
					{
						MessageBox.Show("Cannot Sort; Processor Information was not chosen to search","Sort Error");
						this.OrderItems="";
						this.radProcDESC.Checked=false;
					}
				}

				if(this.radCurrClASC.Checked == true)
				{
					if(this.chkProcessor.Checked==true)
					{
						this.OrderItems = this.OrderItems + "CurrentClockSpeed ASC";
					}
					else
					{
						MessageBox.Show("Cannot Sort; Processor Information was not chosen to search","Sort Error");
						this.radCurrClASC.Checked=false;
						this.OrderItems="";
					}
				}

				if(this.radCurrClDESC.Checked == true)
				{
					if(this.chkProcessor.Checked==true)
					{
						this.OrderItems = this.OrderItems + "CurrentClockSpeed DESC";
					}
					else
					{
						MessageBox.Show("Cannot Sort; Processor Information was not chosen to search","Sort Error");
						this.radCurrClDESC.Checked=false;
						this.OrderItems="";
					}
				}
				///////    Basic  ///////////
				if(this.radSerialASC.Checked == true)
				{
					this.OrderItems = this.OrderItems + "ZENWorks.SystemInfo.SerialNumber ASC";
				}

				if(this.radSerialDESC.Checked == true)
				{
					this.OrderItems = this.OrderItems + "ZENWorks.SystemInfo.SerialNumber DESC";
				}

				if(this.radTagASC.Checked == true)
				{
					this.OrderItems = this.OrderItems + "Tag ASC";
				}

				if(this.radTAGDESC.Checked == true)
				{
					this.OrderItems = this.OrderItems + "Tag DESC";
				}
				//////      Memeory checked    /////////////
				if(this.radTotVisMemDESC.Checked == true)
				{
					if((this.radGreatMem.Checked==true)||(this.radMemAll.Checked==true)||(this.radMemLess.Checked==true))
					{
						this.OrderItems = this.OrderItems + "TotalVisibleMemorySize DESC";
					}
					else
					{
						MessageBox.Show("Cannot Sort; Memory Information not chosen to search","Sort Error");
						this.OrderItems="";
						this.radTotVisMemDESC.Checked=false;
					}
				}

				if(this.radTotVisMemSizeASC.Checked == true)
				{
					if((this.radGreatMem.Checked==true)||(this.radMemAll.Checked==true)||(this.radMemLess.Checked==true))
					{
						this.OrderItems = this.OrderItems + "TotalVisibleMemorySize ASC";
					}
					else
					{
						MessageBox.Show("Cannot Sort; Memory Information not chosen to search","Sort Error");
						this.OrderItems="";
						this.radTotVisMemSizeASC.Checked = false;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Error");
			}
		}

		private void Hardware_Click(object sender, EventArgs e)
		{
			this.OrderHardItemsSort();
		}

		private void OrderSoftItemsSort()
		{
			try
			{
				this.radAvSizeASC.Checked = false;
				this.radAvSizeDESC.Checked = false;
				this.radClientASC.Checked = false;
				this.radClientDESC.Checked = false;
				this.radCompNameASC.Checked = false;
				this.radCompNameDESC.Checked = false;
				this.radCurrClASC.Checked = false;
				this.radCurrClDESC.Checked = false;
				this.radDescASC.Checked = false;
				this.radDescDESC.Checked = false;
				this.radDriveNameASC.Checked = false;
				this.radDriveNameDESC.Checked = false;
				this.radFileSysSizASC.Checked = false;
				this.radFileSysSizeDESC.Checked = false;
				this.radFSTASC.Checked = false;
				this.radFSTDESC.Checked = false;
				this.radImportASC.Checked = false;
				this.radImportDESC.Checked = false;
				this.radModelASC.Checked = false;
				this.radModelDESC.Checked = false;
				this.radOSASC.Checked = false;
				this.radOSVerASC.Checked = false;
				this.radOSDESC.Checked = false;
				this.radOSVerDESC.Checked = false;
				this.radProcASC.Checked = false;
				this.radProcDESC.Checked = false;
				this.radSerialASC.Checked = false;
				this.radSerialDESC.Checked = false;
				this.radTagASC.Checked = false;
				this.radTAGDESC.Checked = false;
				this.radTotVisMemDESC.Checked = false;
				this.radTotVisMemSizeASC.Checked = false;

				this.OrderItems = "";
				this.OrderItems = "ORDER BY ";

				if((this.chksoftChoice.Checked==false)&&(this.chkSoftCompName.Checked==false))
				{

					MessageBox.Show("Neither Computer Name or Software Choice are checked. This could return ALL results","Search Warning");
					//////// Software computer name  /////////////
	
				
					if(this.radSoftCompNameASC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "ZENWorks.SystemInfo.Caption ASC";//"ComputerName ASC";
					
					}	

					if(this.radSoftCompNameDESC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "ZENWorks.SystemInfo.Caption DESC";//"ComputerName DESC";
					
					}

					//// software search ///////
					if(this.radSoftNameASC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "SoftwareName ASC";
					
					}

					if(this.radSoftNameDESC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "SoftwareName DESC";
					
					}

					if(this.radVendorASC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "Vendor ASC";
					
					}

					if(this.radVendorDESC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "Vendor DESC";
					
					}

					if(this.radVerASC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "CIM.Product.Version ASC";
					
					}

					if(this.radVerDESC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "CIM.Product.Version DESC";
					
					}


				}
				else
				{
					//////// Software computer name  /////////////
	
				
					if(this.radSoftCompNameASC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "ZENWorks.SystemInfo.Caption ASC";//"ComputerName ASC";
					
					}	

					if(this.radSoftCompNameDESC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "ZENWorks.SystemInfo.Caption DESC";//"ComputerName DESC";
					
					}

					//// software search ///////
					if(this.radSoftNameASC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "SoftwareName ASC";
					
					}

					if(this.radSoftNameDESC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "SoftwareName DESC";
					
					}

					if(this.radVendorASC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "Vendor ASC";
					
					}

					if(this.radVendorDESC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "Vendor DESC";
					
					}

					if(this.radVerASC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "CIM.Product.Version ASC";
					
					}

					if(this.radVerDESC.Checked == true)
					{
					
						this.OrderItems = this.OrderItems + "CIM.Product.Version DESC";
					
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Error");
			}

		}

		private void Software_Click(object sender, EventArgs e)
		{
			this.OrderSoftItemsSort();
		}

		private void FillImportList()
		{
			try
			{
				//string strConn = "DSN=Zenworks Inventory";

				OdbcConnection myConnection = new OdbcConnection(strConn);
			
				this.ImportTable.Clear();
				
				//Open connection
				myConnection.Open();

				//CIM.Processor.DeviceID,
				this.myStringCommand="SELECT CIM.UnitaryComputerSystem.Name AS Import FROM CIM.UnitaryComputerSystem ORDER BY Name";

				OdbcCommand myCommand = new OdbcCommand(myStringCommand, myConnection);//this.ZENWorksConnection);

				OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);
				
				myAdapter.Fill(ImportTable);

				this.dgImport.DataSource = ImportTable;
			
				this.dgImport.Visible = true;

				this.lblImportList.Text= ImportTable.Rows.Count.ToString()+" Imported Workstations Found";
			
				myConnection.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Filling Import List  "+ex.Message.ToString(),"Error");
			}

		}
	
		private void btnGoogle_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start("http://www.google.com");
			}
			catch(Exception ex)
			{
				MessageBox.Show("Cannot Open Internet Browser"+ex.Message.ToString(),"Browser Error");
			}
		}

		private void btnSortSearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				if((this.radSoftCompNameASC.Checked == true) || (this.radSoftCompNameDESC.Checked ==true) || (this.radSoftNameASC.Checked ==true) ||(this.radSoftNameDESC.Checked ==true) || (this.radVendorASC.Checked ==true) || (this.radVendorDESC.Checked ==true) || (this.radVerASC.Checked ==true)|| (this.radVerDESC.Checked ==true))
				{
					if((this.lisSoftware.CheckedItems.Count==0)&&(this.chkSoftCompName.Checked==false)&&(this.chkSoftwareName.Checked==false))
					{
						Form myForm = new SoftSearchCheck();
						DialogResult buttonClick = myForm.ShowDialog();

						if(buttonClick.Equals(DialogResult.OK))
						{	
							this.RunSoftSearch();
						}
						else
						{
							MessageBox.Show("Software Sort Aborted","Search Error");
						}

						myForm.Dispose();
					}
					else
					{					
						this.OrderSoftItemsSort();
						this.RunSoftSearch();
					}
				
				}
				else
				{//First check to see if any specific search for things that have to be typed in
					//Check for anything else that can be open ended	
					//check list boxes
					this.OrderHardItemsSort();
					this.HardwareSearchCheck();
				
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Sorting  "+ex.Message.ToString(),"Error");
			}
			this.OrderItems="";
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			this.ResetDatabase();
		}

		private void radNoDisk_CheckedChanged(object sender, System.EventArgs e)
		{
			this.radDiskAll.Checked=false;
			this.radDiskGreat.Checked = false;
			this.radDiskLess.Checked = false;
			this.txtDiskSize.Enabled = false;
			this.txtDiskSize.Text = "0";
			this.DiskCheck = 0;
			this.searchDiskSize = "";
		}

		private void radNoMem_CheckedChanged(object sender, System.EventArgs e)
		{
			this.radMemAll.Checked = false;
			this.radMemLess.Checked = false;
			this.radGreatMem.Checked = false;
			this.txtVisibleMemory.Enabled = false;
			this.txtVisibleMemory.Text = "0";
			this.VisMem = 0;
			this.searchVisMem = "";
			
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(CheckProgram==2)
				{
					MessageBox.Show("Please Set Database Information","Check");
					Form myForm = new DatabaseRegister();
					myForm.ShowDialog();
					//System.Diagnostics.Process.Start("C:\\Program Files\\Gracon Services, Inc\\ZENWorksQuery\\Sybase\\SybaseODBC.reg");
					MessageBox.Show("Be sure to Reset Connections when finished","Reset Connections");//ResetDatabase(); //runs connections to list boxes. This is an indicator that everything is running as expected.
				}
				if(CheckProgram==0)
				{
					Application.Exit();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Starting Program  "+ex.Message.ToString(),"Error");
				Application.Exit();

			}
		}

		private void SaveTextDelimitedMenu_Click(object sender, System.EventArgs e)
		{
			if(this.SaveCheck==0)
			{
				this.SaveFileResults();
			}
			else
			{
				if(SaveCheck==2)
				{
					this.SaveInvDel();
				}
				else
				{
					this.SaveSoftwareResults();
				}
			}
		}

		private void SaveWordDocument_Click(object sender, System.EventArgs e)
		{
			if(this.SaveCheck==0)
			{
				this.SaveHardwareWord();
			}
			else
			{
				if(this.SaveCheck==2)
				{
					this.SaveInvWord();
				}
				else
				{
					this.SaveSoftwareWord();
				}
			}
		}

		private void menuItemGracon_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start( "https://www.gracon.com");
			}
			catch(Exception ex)
			{
				MessageBox.Show("Cannot Open Internet Browser  "+ex.Message.ToString(),"Browser Error");
			}
		}

		private void menuItemNovell_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start("http://www.Novell.com");
			}
			catch(Exception ex)
			{
				MessageBox.Show("Cannot Open Internet Browser  "+ex.Message.ToString(),"Browser Error");
			}
		}
		#region Control Events
		private void lisSoftware_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.lisSoftware.CheckedItems.Count==0)
			{
				this.chksoftChoice.Checked=false;
			}
			else
			{
				this.chksoftChoice.Checked=true;
			}
		}

		private void lisProcessors_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.lisProcessors.CheckedItems.Count==0)
			{
				this.chkProcessor.Checked=false;
			}
			else
			{
				this.chkProcessor.Checked=true;
			}
		}

		private void lstOSVersion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.lstOSVersion.CheckedItems.Count!=0)
			{
				this.OSV = " AND (CIM.OperatingSystem.Version = '"+this.lstOSVersion.CheckedItems[0].ToString()+"' ";
				for(int i =1; i<this.lstOSVersion.CheckedItems.Count;i++)
				{
					this.OSV = this.OSV + " OR CIM.OperatingSystem.Version = '" + this.lstOSVersion.CheckedItems[i].ToString()+"' ";
				}
				this.OSV = this.OSV + ") ";
			}
		}

		private void lisOperatingSystems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.lisOperatingSystems.CheckedItems.Count==0)
			{
				this.chkOS.Checked=false;
			}
			else
			{
				this.chkOS.Checked=true;
			}
			DataTable OSVersion = new DataTable("tblOSVersion");
			try
			{
				if(this.lisOperatingSystems.CheckedItems.Count!=0)
				{
					this.lstOSVersion.Items.Clear();

					string WhereClause = " ";

					WhereClause = "AND (CIM.OperatingSystem.Caption = '"+this.lisOperatingSystems.CheckedItems[0].ToString()+"' ";
					for(int i = 1; i<this.lisOperatingSystems.CheckedItems.Count; i++)
					{
						WhereClause = WhereClause + " OR CIM.OperatingSystem.Caption = '"+this.lisOperatingSystems.CheckedItems[i].ToString()+"' ";
					}
					WhereClause=WhereClause+")";
					//string strConn = "DSN=Sybase ODBC Driver";

					OdbcConnection myConnection = new OdbcConnection(strConn);

					myConnection.Open();

					//CIM.Processor.DeviceID,       
					this.myStringCommand="SELECT CIM.OperatingSystem.Version AS OSVersion FROM CIM.OperatingSystem, CIM.InstalledOS, CIM.UnitaryComputerSystem WHERE CIM.OperatingSystem.id$ = CIM.InstalledOS.PartComponent AND CIM.InstalledOS.GroupComponent = CIM.UnitaryComputerSystem.id$ "+WhereClause;

					OdbcCommand myCommand = new OdbcCommand(myStringCommand, myConnection);//this.ZENWorksConnection);

					OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);
				
					myAdapter.Fill(OSVersion);

					DataRow myRow; 
 
					DataRow CompRow;

					for(int i = 0; i<OSVersion.Rows.Count;i++)
					{
					
						myRow = OSVersion.Rows[i]; 
					
						for(int j = 0; j<this.lstOSVersion.Items.Count; j++)
						{
							CompRow = OSVersion.Rows[j];
							if(myRow["OSVersion"].ToString().Equals(this.lstOSVersion.Items[j].ToString())==true)
							{
								this.lstOSVersion.Items.Remove(myRow["OSVersion"].ToString());
							}
						}
						this.lstOSVersion.Items.Add(myRow["OSVersion"].ToString());
					
					}

					myConnection.Close();

					
				}
				else
				{
					this.lstOSVersion.Items.Clear();
				}
			}
			catch(Exception exq)
			{
				MessageBox.Show(exq.Message,"error");
			}
		}

		private void lisClient_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.lisClient.CheckedItems.Count==0)
			{
				this.chkClientVer.Checked=false;
			}
			else
			{
				this.chkClientVer.Checked=true;
			}
		}

		private void tabHardware_Click(object sender, System.EventArgs e)
		{
			this.HardwareTab();
		}

		private void HardwareTab()
		{
			this.dgSoftware.Visible=false;
			this.dgInventory.Visible=false;
			this.dgResults.Visible=true;
			this.lblCount.Text = dtResults.Rows.Count + " Records Found";
			SaveCheck=0;
		}

		private void tabSoftware_Click(object sender, System.EventArgs e)
		{
			this.SoftwareTab();
		}

		private void SoftwareTab()
		{
			this.dgInventory.Visible=false;
			this.dgResults.Visible = false;
			this.dgSoftware.Visible = true;
			this.lblCount.Text = SoftTable.Rows.Count + " Records Found";
			SaveCheck=1;
		}

		private void txtComputerName_TextChanged(object sender, System.EventArgs e)
		{
			if(this.txtComputerName.Text=="")
			{
				this.chkComputerName.Checked = false;
				this.chkNameWild.Checked = false;
			}
			else
			{
				this.chkComputerName.Checked=true;
			}
		}

		private void txtSerial_TextChanged(object sender, System.EventArgs e)
		{
			if(this.txtSerial.Text == "")
			{
				this.chkSerial.Checked = false;
				this.chkSerialWildCard.Checked = false;
			}
			else
			{
				this.chkSerial.Checked=true;
			}
		}

		private void txtSoftCompName_TextChanged(object sender, System.EventArgs e)
		{
			if(this.txtSoftCompName.Text == "")
			{
				this.chkSoftCompName.Checked = false;
				this.chkSoftNameWild.Checked = false;
			}
			else
			{
				this.chkSoftCompName.Checked=true;
			}
		}

		private void chkComputerName_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkComputerName.Checked==false)
			{
				this.txtComputerName.Text ="";
				this.chkComputerName.Checked=false;
				this.chkNameWild.Checked = false;
			}
		}

		private void chkSerial_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkSerial.Checked==false)
			{
				this.txtSerial.Text="";
				this.chkSerial.Checked=false;
				this.chkSerialWildCard.Checked = false;
			}
		}

		private void chkSoftCompName_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkSoftCompName.Checked==false)
			{
				this.txtSoftCompName.Text="";
				this.chkSoftCompName.Checked=false;
				this.chkSoftNameWild.Checked = false;
			}
		}

		private void chksoftChoice_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(chksoftChoice.Checked==false)
				{
					if(this.lisSoftware.CheckedItems.Count!=0)
					{
						for(int i=0;i<this.lisSoftware.Items.Count;i++)
						{
							this.lisSoftware.SetItemChecked(i,false);
						}

					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Error");
			}
		}

		private void tabControl1_Click(object sender, System.EventArgs e)
		{
			if(this.tabHardware.ContainsFocus==true)
			{
				this.dgSoftware.Visible=false;
				this.dgResults.Visible=true;
				SaveCheck=0;
			}
			else
			{
				if(this.tabSoftware.ContainsFocus==true)
				{
					this.dgResults.Visible = false;
					this.dgSoftware.Visible = true;
					SaveCheck=1;
				}
			}
		}
		#endregion

		private void chkOS_CheckedChanged(object sender, System.EventArgs e) 
		{
			try
			{
				if(chkOS.Checked==false)
				{
					if(this.lisOperatingSystems.CheckedItems.Count!=0)
					{
						for(int i=0;i<this.lisOperatingSystems.Items.Count;i++)
						{
							this.lisOperatingSystems.SetItemChecked(i,false);
						}
						this.lstOSVersion.Items.Clear();
					}
					else
					{
						this.lstOSVersion.Items.Clear();
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Error");
			}
		}

		private void chkClientVer_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(chkClientVer.Checked==false)
				{
					if(this.lisClient.CheckedItems.Count!=0)
					{
						for(int i=0;i<this.lisClient.Items.Count;i++)
						{
							this.lisClient.SetItemChecked(i,false);
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Error");
			}
		}

		private void chkProcessor_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(chkProcessor.Checked==false)
				{
					if(this.lisProcessors.CheckedItems.Count!=0)
					{
						for(int i=0;i<this.lisProcessors.Items.Count;i++)
						{
							this.lisProcessors.SetItemChecked(i,false);
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Error");
			}
		}

		private void txtSoftwareName_TextChanged(object sender, System.EventArgs e)
		{
			if(txtSoftwareName.Text == "")
			{
				this.chkSoftwareName.Checked=false;
				this.chkWildSoftName.Checked = false;
			}
			else
			{
				this.chkSoftwareName.Checked=true;
			}
		}

		private void chkSoftwareName_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkSoftwareName.Checked==false)
			{
				this.txtSoftwareName.Text="";
				this.chkSoftwareName.Checked=false;
				this.chkWildSoftName.Checked = false;
			}
		}


		#region SoftwareListSort
		private void btnAll_Click(object sender, System.EventArgs e)
		{
			Form loadSoft = new LoadingSoftwareInformation();
			loadSoft.Show();

			Application.DoEvents();

			this.FillSoftwareList();

			loadSoft.Close();
			loadSoft.Dispose();

			SoftFilt= " ";
		}

		private void btnSymNum_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE '0%' Or CIM.Product.Name LIKE '1%' Or CIM.Product.Name LIKE '2%' Or CIM.Product.Name LIKE '3%' Or CIM.Product.Name LIKE '4%' Or CIM.Product.Name LIKE '5%' Or CIM.Product.Name LIKE '6%' Or CIM.Product.Name LIKE '7%' Or CIM.Product.Name LIKE '8%' Or CIM.Product.Name LIKE '9%' Or CIM.Product.Name LIKE '0%' ";
				this.FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE '0%' Or CIM.Product.Vendor LIKE '1%' Or CIM.Product.Vendor LIKE '2%' Or CIM.Product.Vendor LIKE '3%' Or CIM.Product.Vendor LIKE '4%' Or CIM.Product.Vendor LIKE '5%' Or CIM.Product.Vendor LIKE '6%' Or CIM.Product.Vendor LIKE '7%' Or CIM.Product.Vendor LIKE '8%' Or CIM.Product.Vendor LIKE '9%' Or CIM.Product.Vendor LIKE '0%' ";
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnA_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'A%' Or CIM.Product.Name LIKE 'a%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'A%' Or CIM.Product.Vendor LIKE 'a%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnB_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'B%' Or CIM.Product.Name LIKE 'b%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'B%' Or CIM.Product.Vendor LIKE 'b%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnC_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'C%' Or CIM.Product.Name LIKE 'c%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'C%' Or CIM.Product.Vendor LIKE 'c%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnD_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'D%' Or CIM.Product.Name LIKE 'd%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'D%' Or CIM.Product.Vendor LIKE 'd%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnE_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'E%' Or CIM.Product.Name LIKE 'e%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'E%' Or CIM.Product.Vendor LIKE 'e%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnF_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'F%' Or CIM.Product.Name LIKE 'f%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'F%' Or CIM.Product.Vendor LIKE 'f%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnG_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'G%' Or CIM.Product.Name LIKE 'g%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'G%' Or CIM.Product.Vendor LIKE 'g%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnH_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'H%' Or CIM.Product.Name LIKE 'h%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'H%' Or CIM.Product.Vendor LIKE 'h%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnI_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'I%' Or CIM.Product.Name LIKE 'i%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'I%' Or CIM.Product.Vendor LIKE 'i%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnJ_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'J%' Or CIM.Product.Name LIKE 'j%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'J%' Or CIM.Product.Vendor LIKE 'j%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnK_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'K%' Or CIM.Product.Name LIKE 'k%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'K%' Or CIM.Product.Vendor LIKE 'k%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnL_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'L%' Or CIM.Product.Name LIKE 'l%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'L%' Or CIM.Product.Vendor LIKE 'l%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnM_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'M%' Or CIM.Product.Name LIKE 'm%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'M%' Or CIM.Product.Vendor LIKE 'm%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnN_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'N%' Or CIM.Product.Name LIKE 'n%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'N%' Or CIM.Product.Vendor LIKE 'n%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnO_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'O%' Or CIM.Product.Name LIKE 'o%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'O%' Or CIM.Product.Vendor LIKE 'o%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnP_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'P%' Or CIM.Product.Name LIKE 'p%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'P%' Or CIM.Product.Vendor LIKE 'p%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnQR_Click(object sender, System.EventArgs e) //this is just Q now
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'Q%' Or CIM.Product.Name LIKE 'q%' ";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'Q%' Or CIM.Product.Vendor LIKE 'q%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnS_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'S%' Or CIM.Product.Name LIKE 's%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'S%' Or CIM.Product.Vendor LIKE 's%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnT_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'T%' Or CIM.Product.Name LIKE 't%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'T%' Or CIM.Product.Vendor LIKE 't%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnUV_Click(object sender, System.EventArgs e) //Now just U
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'U%' Or CIM.Product.Name LIKE 'u%' ";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'U%' Or CIM.Product.Vendor LIKE 'u%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

	

			private void btnWX_Click(object sender, System.EventArgs e)
			{
				if(this.radSoft.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Name LIKE 'W%' Or CIM.Product.Name LIKE 'w%' ";
					FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
				else
				{
					if(this.radVen.Checked==true)
					{
						Form loadSoft = new LoadingSoftwareInformation();
						loadSoft.Show();

						Application.DoEvents();
						this.SoftFilt = "Where CIM.Product.Vendor LIKE 'W%' Or CIM.Product.Vendor LIKE 'w%' ";
					
						this.FillSoftwareList();

						loadSoft.Close();
						loadSoft.Dispose();
					}
				}

				SoftFilt = " ";
			}
		


		private void btnYZ_Click(object sender, System.EventArgs e) //now just y
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'Y%' Or CIM.Product.Name LIKE 'y%' ";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'Y%' Or CIM.Product.Vendor LIKE 'y%' ";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}
		

		private void btnSym_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();//Where CIM.Product.Name LIKE '?%' Or CIM.Product.Name LIKE '-%' Or CIM.Product.Name LIKE '@%' Or CIM.Product.Name LIKE '!%' Or CIM.Product.Name LIKE '#%' Or CIM.Product.Name LIKE '$%' Or CIM.Product.Name LIKE '^%' Or CIM.Product.Name LIKE '&%' Or CIM.Product.Name LIKE '*%' Or CIM.Product.Name LIKE '(%' Or CIM.Product.Name LIKE ')%'
				this.SoftFilt = "Where (CIM.Product.Name NOT LIKE 'A%') AND (CIM.Product.Name NOT LIKE 'B%') AND (CIM.Product.Name NOT LIKE 'C%') AND (CIM.Product.Name NOT LIKE 'D%') AND (CIM.Product.Name NOT LIKE 'E%') AND (CIM.Product.Name NOT LIKE 'F%') AND (CIM.Product.Name NOT LIKE 'G%') AND (CIM.Product.Name NOT LIKE 'H%') AND (CIM.Product.Name NOT LIKE 'I%') AND (CIM.Product.Name NOT LIKE 'J%') AND (CIM.Product.Name NOT LIKE 'K%') AND (CIM.Product.Name NOT LIKE 'L%') AND (CIM.Product.Name NOT LIKE 'M%') AND (CIM.Product.Name NOT LIKE 'N%') AND (CIM.Product.Name NOT LIKE 'O%') AND (CIM.Product.Name NOT LIKE 'P%') AND (CIM.Product.Name NOT LIKE 'Q%') AND (CIM.Product.Name NOT LIKE 'R%') AND (CIM.Product.Name NOT LIKE 'S%') AND (CIM.Product.Name NOT LIKE 'T%') AND (CIM.Product.Name NOT LIKE 'U%') AND (CIM.Product.Name NOT LIKE 'V%') AND (CIM.Product.Name NOT LIKE 'W%') AND (CIM.Product.Name NOT LIKE 'X%') AND (CIM.Product.Name NOT LIKE 'Y%') AND (CIM.Product.Name NOT LIKE 'Z%') AND (CIM.Product.Name NOT LIKE '1%') AND (CIM.Product.Name NOT LIKE '2%') AND (CIM.Product.Name NOT LIKE '3%') AND (CIM.Product.Name NOT LIKE '4%') AND (CIM.Product.Name NOT LIKE '5%') AND (CIM.Product.Name NOT LIKE '6%') AND (CIM.Product.Name NOT LIKE '7%') AND (CIM.Product.Name NOT LIKE '8%') AND (CIM.Product.Name NOT LIKE '9%') AND (CIM.Product.Name NOT LIKE '0%')";
				this.FillSoftwareList();//(CIM.Product.Name NOT LIKE 'A%') Or (CIM.Product.Name NOT LIKE 'a%') Or (CIM.Product.Name NOT LIKE 'B%') Or (CIM.Product.Name NOT LIKE 'b%') Or  Or (CIM.Product.Name NOT LIKE 'c%') Or  Or (CIM.Product.Name NOT LIKE 'd%') Or  Or (CIM.Product.Name NOT LIKE 'e%') Or  Or (CIM.Product.Name NOT LIKE 'f%')

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where (CIM.Product.Vendor NOT LIKE 'A%') AND (CIM.Product.Vendor NOT LIKE 'B%') AND (CIM.Product.Vendor NOT LIKE 'C%') AND (CIM.Product.Vendor NOT LIKE 'D%') AND (CIM.Product.Vendor NOT LIKE 'E%') AND (CIM.Product.Vendor NOT LIKE 'F%') AND (CIM.Product.Vendor NOT LIKE 'G%') AND (CIM.Product.Vendor NOT LIKE 'H%') AND (CIM.Product.Vendor NOT LIKE 'I%') AND (CIM.Product.Vendor NOT LIKE 'J%') AND (CIM.Product.Vendor NOT LIKE 'K%') AND (CIM.Product.Vendor NOT LIKE 'L%') AND (CIM.Product.Vendor NOT LIKE 'M%') AND (CIM.Product.Vendor NOT LIKE 'N%') AND (CIM.Product.Vendor NOT LIKE 'O%') AND (CIM.Product.Vendor NOT LIKE 'P%') AND (CIM.Product.Vendor NOT LIKE 'Q%') AND (CIM.Product.Vendor NOT LIKE 'R%') AND (CIM.Product.Vendor NOT LIKE 'S%') AND (CIM.Product.Vendor NOT LIKE 'T%') AND (CIM.Product.Vendor NOT LIKE 'U%') AND (CIM.Product.Vendor NOT LIKE 'V%') AND (CIM.Product.Vendor NOT LIKE 'W%') AND (CIM.Product.Vendor NOT LIKE 'X%') AND (CIM.Product.Vendor NOT LIKE 'Y%') AND (CIM.Product.Vendor NOT LIKE 'Z%') AND (CIM.Product.Vendor NOT LIKE '1%') AND (CIM.Product.Vendor NOT LIKE '2%') AND (CIM.Product.Vendor NOT LIKE '3%') AND (CIM.Product.Vendor NOT LIKE '4%') AND (CIM.Product.Vendor NOT LIKE '5%') AND (CIM.Product.Vendor NOT LIKE '6%') AND (CIM.Product.Vendor NOT LIKE '7%') AND (CIM.Product.Vendor NOT LIKE '8%') AND (CIM.Product.Vendor NOT LIKE '9%') AND (CIM.Product.Vendor NOT LIKE '0%')";
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnR_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'R%' Or CIM.Product.Name LIKE 'r%' ";
				this.FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "CIM.Product.Vendor LIKE 'R%' Or CIM.Product.Vendor LIKE 'R%' ";
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnV_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'V%' Or CIM.Product.Name LIKE 'v%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'V%' Or CIM.Product.Vendor LIKE 'v%'";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnX_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'X%' Or CIM.Product.Name LIKE 'x%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'X%' Or CIM.Product.Vendor LIKE 'x%'";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}

		private void btnZ_Click(object sender, System.EventArgs e)
		{
			if(this.radSoft.Checked==true)
			{
				Form loadSoft = new LoadingSoftwareInformation();
				loadSoft.Show();

				Application.DoEvents();
				this.SoftFilt = "Where CIM.Product.Name LIKE 'Z%' Or CIM.Product.Name LIKE 'z%'";
				FillSoftwareList();

				loadSoft.Close();
				loadSoft.Dispose();
			}
			else
			{
				if(this.radVen.Checked==true)
				{
					Form loadSoft = new LoadingSoftwareInformation();
					loadSoft.Show();

					Application.DoEvents();
					this.SoftFilt = "Where CIM.Product.Vendor LIKE 'Z%' Or CIM.Product.Vendor LIKE 'z%'";
					
					this.FillSoftwareList();

					loadSoft.Close();
					loadSoft.Dispose();
				}
			}

			SoftFilt = " ";
		}
#endregion 

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			InventCatalog Invent = new InventCatalog();

			string ItemStatus = " ";
			string Type = " ";

			Type = this.lstType.Text;

			if(this.radActive.Checked == true)
			{
				ItemStatus = "Active";
			}
			else
			{
				if(this.radInactive.Checked == true)
				{
					ItemStatus = "Inactive";
				}
			}

			Invent.AddNew(this.txtName.Text , this.txtDescription.Text, this.txtInstalledDate.Text, this.txtMFG.Text, this.txtSerialnum.Text, ItemStatus, Type, this.txtCurrentLocation.Text,this.txtRMNum.Text, this.txtNotes.Text);
			
			if((this.lstSortInv.Text==" ")||(this.lstSortInv.Text==""))
			{
				this.ViewInventoryRecords();
			}
			else
			{
				this.ViewSortedInvRecords();
			}

			this.txtName.Text=""; //clear the fields
			this.txtDescription.Text="";
			this.txtInstalledDate.Text="";
			this.txtMFG.Text="";
			this.txtNotes.Text="";
			this.txtSerialnum.Text="";
			this.txtCurrentLocation.Text = "";//now building
			this.txtRMNum.Text="";
			this.radActive.Checked =false;
			this.radInactive.Checked=false;
			this.lstType.Text = "";

			this.dgInventory.Visible=true;
			this.dgResults.Visible=false;
			this.dgSoftware.Visible=false;
			this.SaveCheck = 2;
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			InventCatalog Invent = new InventCatalog();

			string ItemStatus = " ";
			string Type = " ";
			string ID= " ";


			DataRow currentRow;

			currentRow = Catalog.Rows[this.dgInventory.CurrentRowIndex];
		
			ID = currentRow["ID"].ToString();

			Type = this.lstType.Text;

			if(this.radActive.Checked == true)
			{
				ItemStatus = "Active";
			}
			else
			{
				if(this.radInactive.Checked == true)
				{
					ItemStatus = "Inactive";
				}
			}

			Invent.UpdateRecord(this.txtName.Text , this.txtDescription.Text, this.txtInstalledDate.Text, this.txtMFG.Text, this.txtSerialnum.Text, ItemStatus, Type, this.txtCurrentLocation.Text, this.txtRMNum.Text, this.txtName.Text, ID);
			
			if((this.lstSortInv.Text==" ")||(this.lstSortInv.Text==""))
			{
				this.ViewInventoryRecords();
			}
			else
			{
				this.ViewSortedInvRecords();
			}

			this.txtName.Text=""; //clear the fields
			this.txtDescription.Text="";
			this.txtInstalledDate.Text="";
			this.txtMFG.Text="";
			this.txtNotes.Text="";
			this.txtSerialnum.Text="";
			this.txtCurrentLocation.Text = "";
			this.radActive.Checked =false;
			this.radInactive.Checked=false;
			this.lstType.Text = "";
			this.txtRMNum.Text="";

			this.dgInventory.Visible=true;
			this.dgResults.Visible=false;
			this.dgSoftware.Visible=false;
			this.SaveCheck = 2;

			this.btnUpdate.Enabled=false;
			this.btnDelete.Enabled=false;
			this.btnAdd.Enabled=true;
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{			

			InventCatalog Invent = new InventCatalog();

			DataRow currentRow;

			string ID = " ";

			currentRow = Catalog.Rows[this.dgInventory.CurrentRowIndex];

			ID = currentRow["ID"].ToString();

			Invent.DeleteRecord(ID);

			if((this.lstSortInv.Text==" ")||(this.lstSortInv.Text==""))
			{
				this.ViewInventoryRecords();
			}
			else
			{
				this.ViewSortedInvRecords();
			}

			this.txtName.Text=""; //clear the fields
			this.txtDescription.Text="";
			this.txtInstalledDate.Text="";
			this.txtMFG.Text="";
			this.txtNotes.Text="";
			this.txtSerialnum.Text="";
			this.txtCurrentLocation.Text = "";
			this.radActive.Checked =false;
			this.radInactive.Checked=false;
			this.lstType.Text = "";

			this.dgInventory.Visible=true;
			this.dgResults.Visible=false;
			this.dgSoftware.Visible=false;
			this.SaveCheck = 2;

			this.btnUpdate.Enabled=false;
			this.btnDelete.Enabled=false;
			this.btnAdd.Enabled=true;
		}

		private void ViewInventoryRecords()
		{
			//string strConn = "DSN=Sybase ODBC Driver";

			try
			{
				OdbcConnection myConnection = new OdbcConnection(strConn);
			
				Catalog.Clear();

				this.InvenHold="Entire Inventory";
				
				//Open connection
				myConnection.Open();

				//CIM.Processor.DeviceID,
				this.myStringCommand="SELECT * FROM MW_DBA.OtherInventory ORDER BY Type";

				OdbcCommand myCommand = new OdbcCommand(myStringCommand, myConnection);//this.ZENWorksConnection);

				OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);
				
				myAdapter.Fill(Catalog);

				this.dgInventory.DataSource = Catalog;
			
				this.dgInventory.Visible = true;
			
				myConnection.Close();

				this.lblCount.Text = Catalog.Rows.Count.ToString()+ " Records Found";
			}
			catch(Exception Ex)
			{
				MessageBox.Show("Error viewing inventory  "+Ex.Message.ToString(),"Error");
			}
		}

		private void ViewSortedInvRecords()
		{
			//string strConn = "DSN=Sybase ODBC Driver";
			string Type;
			string Building;
			string Room;
			string SerialNumber;

			Building = " ";
			Room = " ";
			SerialNumber=" ";
			Type =" ";
			try
			{
				string WhereClause = " ";

				//check for info

				if((this.txtSortBuilding.Text != "")&&(this.txtSortBuilding.Text != " "))
				{
					if(this.chkWildBuild.Checked==true)
					{
						Building = " AND Building LIKE '"+txtSortBuilding.Text+"' ";
					}
					else
					{
						Building = " AND Building = '"+txtSortBuilding.Text+"' ";
					}
				}

				if((this.txtSortRoom.Text!="")&&(this.txtSortRoom.Text!=" "))
				{
					if(this.chkWildRoom.Checked==true)
					{
						Room = " AND RoomNum LIKE '"+this.txtSortRoom.Text+"' "; 
					}
					else
					{
						Room = " AND RoomNum = '"+this.txtSortRoom.Text+"' ";
					}
				}

				if((this.txtSortSerial.Text!="")&&(this.txtSortSerial.Text!=" "))
				{
					if(this.chkWildSerial.Checked==true)
					{
						SerialNumber = " AND SerialNum LIKE '"+this.txtSortSerial.Text+"' ";
					}
					else
					{
						SerialNumber = " AND SerialNum = '"+this.txtSortSerial.Text+"' ";
					}
				}

				if((this.lstSortInv.Text!="")&&(this.lstSortInv.Text!=" "))
				{
					Type = " AND Type = '"+this.lstSortInv.Text+"' ";
				}

				WhereClause = "1=1 " + Building + Room + SerialNumber+Type;//AND Type = '"+this.lstSortInv.Text+"' ";

				OdbcConnection myConnection = new OdbcConnection(strConn);
			
				Catalog.Clear();
				
				this.InvenHold=this.lstSortInv.Text;
				//Open connection
				myConnection.Open();

				//CIM.Processor.DeviceID,
				this.myStringCommand="SELECT * FROM MW_DBA.OtherInventory WHERE "+WhereClause ;

				OdbcCommand myCommand = new OdbcCommand(myStringCommand, myConnection);//this.ZENWorksConnection);

				OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);
				
				myAdapter.Fill(Catalog);

				this.dgInventory.DataSource = Catalog;
			
				this.dgInventory.Visible = true;
			
				myConnection.Close();

				this.lblCount.Text = Catalog.Rows.Count.ToString()+ " Records Found";
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Displaying Sorted Inventory  "+ex.Message.ToString(),"Error");
			}
		}

		private void btnInventory_Click(object sender, System.EventArgs e)
		{
			Form myForm = new WaitResults();

			myForm.Show();
			this.Cursor=Cursors.WaitCursor;
			Application.DoEvents();

			ViewInventoryRecords();
			this.dgInventory.Visible=true;
			this.dgResults.Visible=false;
			this.dgSoftware.Visible=false;
			this.SaveCheck = 2;

			myForm.Close();
			this.Cursor=Cursors.Default;
			myForm.Dispose();

			this.txtSortBuilding.Text="";
			this.txtSortRoom.Text="";
			this.txtSortSerial.Text="";
			this.lstSortInv.Text="";
			this.chkWildBuild.Checked=false;
			this.chkWildRoom.Checked=false;
			this.chkWildSerial.Checked=false;
			
		}

		private void dgInventory_Click(object sender, System.EventArgs e)
		{
			DataRow currentRow;

			currentRow = Catalog.Rows[this.dgInventory.CurrentRowIndex];

			this.txtName.Text = currentRow["Name"].ToString();
			this.txtDescription.Text=currentRow["Description"].ToString();
			this.txtInstalledDate.Text = currentRow["InstallDate"].ToString();
			this.txtSerialnum.Text=currentRow["SerialNum"].ToString();
			this.txtNotes.Text=currentRow["Notes"].ToString();
			this.txtCurrentLocation.Text=currentRow["Building"].ToString();
			this.txtMFG.Text=currentRow["MFG"].ToString();
			this.txtRMNum.Text = currentRow["RoomNum"].ToString();
			if(currentRow["Status"].ToString()=="Active")
			{
				this.radActive.Checked=true;
			}
			if(currentRow["Status"].ToString()=="Inactive")
			{
				this.radInactive.Checked=true;
			}
			this.lstType.Text=currentRow["Type"].ToString();

			this.SaveCheck = 2;
			this.btnUpdate.Enabled=true;
			this.btnDelete.Enabled=true;
			this.btnAdd.Enabled=false;
		}

		private void tabOther_Click(object sender, System.EventArgs e)
		{
			this.OtherTab();
		}

		private void OtherTab()
		{
			this.dgInventory.Visible=true;
			this.dgResults.Visible=false;
			this.dgSoftware.Visible=false;
			this.SaveCheck = 2;
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			InventCatalog Invent = new InventCatalog();

			Invent.CreateCatalog();
		}

		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			InventCatalog Invent = new InventCatalog();

			Form myForm = new DeleteTableWarn();
			DialogResult buttonClick = myForm.ShowDialog();

			if(buttonClick.Equals(DialogResult.OK))//OK to delete the table
			{
				Invent.DeleteTable();
			}
			myForm.Dispose();
		}

		private void btnSortInv_Click(object sender, System.EventArgs e)
		{
			Form myForm = new WaitResults();

			myForm.Show();
			this.Cursor=Cursors.WaitCursor;
			Application.DoEvents();

			this.ViewSortedInvRecords();

			myForm.Close();
			this.Cursor=Cursors.Default;
			myForm.Dispose();

			this.dgInventory.Visible=true;
			this.dgResults.Visible=false;
			this.dgSoftware.Visible=false;
			this.SaveCheck = 2;
		}

		private void btnNoInvSort_Click(object sender, System.EventArgs e)
		{
			this.lstSortInv.Text=" ";

			Form myForm = new WaitResults();

			myForm.Show();
			this.Cursor=Cursors.WaitCursor;
			Application.DoEvents();

			this.ViewInventoryRecords();

			myForm.Close();
			this.Cursor=Cursors.Default;
			myForm.Dispose();

			this.dgInventory.Visible=true;
			this.dgResults.Visible=false;
			this.dgSoftware.Visible=false;
			this.SaveCheck = 2;
		}

		private void btnPrintInv_Click(object sender, System.EventArgs e)
		{
			this.PrintTheResults();
		}

		private void btnClearInv_Click(object sender, System.EventArgs e)
		{
			this.txtName.Text="";
			this.txtDescription.Text = "";
			this.txtInstalledDate.Text ="";
			this.txtMFG.Text="";
			this.txtNotes.Text="";
			this.txtSerialnum.Text="";
			this.lstSortInv.Text="";
			this.lstType.Text="";
			this.radActive.Checked=false;
			this.radInactive.Checked=false;
			this.txtCurrentLocation.Text="";
			this.txtRMNum.Text="";

			this.btnAdd.Enabled=true;
			this.btnUpdate.Enabled=false;
			this.btnDelete.Enabled=false;
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(tabControl1.SelectedIndex==0)
			{
				this.HardwareTab();
			}
			if(tabControl1.SelectedIndex==1)
			{
				this.SoftwareTab();
			}
			if(tabControl1.SelectedIndex==2)
			{
				//for Sorting tab if needed
			}
			if(tabControl1.SelectedIndex==3)
			{
				//for Imported if needed
			}
			if(tabControl1.SelectedIndex==4)
			{
				this.OtherTab();
			}
		}

		private void btnSaveInv_Click(object sender, System.EventArgs e)
		{
			this.SaveChoiceBox();
		}

		public void FillTypeSearch()
		{
			this.lstSortInv.Items.Clear();
			this.lstType.Items.Clear();

			string doQuery = "Select Type FROM MW_DBA.TypeOptions ";

			//string strConn = "DSN=Sybase ODBC Driver";
			OdbcConnection myConnection = new OdbcConnection(strConn);
			myConnection.Open();

			DataRow myRow;
			DataTable hold= new DataTable("tblType");
			try
			{
				OdbcCommand myCommand = new OdbcCommand(doQuery, myConnection);
				OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);
				myAdapter.Fill(hold);
				for(int i = 0; i<hold.Rows.Count; i++)
				{
					myRow = hold.Rows[i];
					
					if(myRow["Type"].ToString()!=null)
					{
						this.lstSortInv.Items.Add(myRow["Type"].ToString());
						this.lstType.Items.Add(myRow["Type"].ToString());
					}
				}

			}
			catch(Exception e)
			{
				//MessageBox.Show("Error Populating Type Lists:  "+e.ToString(),"Error");
			}

			myConnection.Close();

		}

		private void menuItem18_Click(object sender, System.EventArgs e)
		{
			Form myForm = new Add();

			myForm.ShowDialog();	

			this.FillTypeSearch();
			
		}

		private void menuDataBaseReg_Click(object sender, System.EventArgs e)
		{
			Form myForm = new DatabaseRegister();

			myForm.ShowDialog();
		}

		//part of context menu
		private void menuItem23_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void menuItem19_Click(object sender, System.EventArgs e)
		{
			//context menu restore
			try
			{
				this.Show();
			}
			catch(Exception ec)
			{
				MessageBox.Show("Error Showing Form: "+ec.Message.ToString(),"Error");
			}
		}

		private void menuItem21_Click(object sender, System.EventArgs e)
		{
			//Context menu Hide
			try
			{
				this.Hide();
			}
			catch(Exception ed)
			{
				MessageBox.Show("Error Hiding Form: "+ed.Message.ToString(),"Error");
			}

		}

		private void menuItem20_Click(object sender, System.EventArgs e)
		{
			//from regular program menu
			try
			{
				this.Hide();
			}
			catch(Exception ed2)
			{
				MessageBox.Show("Error Hiding Form: "+ed2.Message.ToString(),"Error");
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(this.chksoftChoice.Checked==true)
			{
				for(int i = 0; i<this.lisSoftware.Items.Count; i++)
				{
					this.lisSoftware.SetItemChecked(i,true);
				}
			}
		}

		
		
	}
}
