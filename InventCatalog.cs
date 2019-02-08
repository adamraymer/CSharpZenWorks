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
	/// Summary description for InventCatalog.
	/// </summary>
	public class InventCatalog
	{
		public InventCatalog()
		{
			//
			// TODO: Add constructor logic here
			//
		}

			string strConn = "DSN=Zenworks Inventory";


		public void UpdateRecord(string Name, string Description, string InstallDate, string MFG, string SerialNum, string Status, string Type, string Building, string RoomNum, string Notes, string ID)
		{
			try
			{
				string UpdateInfo = "UPDATE MW_DBA.OtherInventory SET Name = '"+Name+"', Description = '"+Description+"', InstallDate = '"+InstallDate+"', MFG = '"+MFG+"', SerialNum = '"+SerialNum+"', Status = '"+Status+"', Type='"+Type+"', Building = '" +Building+ "', RoomNum = '"+RoomNum+"', Notes = '"+Notes+"' Where ID = '"+ID+"' ";
		
				//string strConn = "DSN=Sybase ODBC Driver";

				OdbcConnection myConnection = new OdbcConnection(strConn);
				myConnection.Open();
				try
				{
					OdbcCommand myCommand = new OdbcCommand(UpdateInfo, myConnection);
					myCommand.CommandType = CommandType.Text ;
				
					myCommand.ExecuteNonQuery();
				}
				catch(Exception e)
				{
					MessageBox.Show("error: "+e.ToString(),"error");
				}

				myConnection.Close();
			}
			catch(Exception Ex)
			{
				MessageBox.Show("Error Updating Inventory"+Ex.Message.ToString(),"Error");
			}
		}

		public void DeleteRecord(string ID)
		{
			string DeleteInfo = "DELETE FROM MW_DBA.OtherInventory WHERE ID = '"+ID+"' ";

			//string strConn = "DSN=Sybase ODBC Driver";

			OdbcConnection myConnection = new OdbcConnection(strConn);
			myConnection.Open();
			try
			{
				OdbcCommand myCommand = new OdbcCommand(DeleteInfo, myConnection);
				myCommand.CommandType = CommandType.Text ;
				
				myCommand.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				MessageBox.Show("Error Deleting Record: "+e.Message.ToString(),"error");
			}

			myConnection.Close();

		}

		public void AddNew(string Name, string Description, string InstallDate, string MFG, string SerialNum, string Status, string Type, string Building, string RoomNum, string Notes)
		{
			string proID;

			Random R =new Random();
			int MaxLimit = 9999;
			int MinLimit = 0001;
			int createRandom  = (R.Next (MinLimit,MaxLimit));

			proID = createRandom.ToString()+Name+SerialNum;
			
			string insertInfo = "INSERT INTO MW_DBA.OtherInventory (ID, Name, Description, InstallDate, MFG, SerialNum, Status, Type, Building, RoomNum, Notes ) Values ('"+proID+"', '"+Name+"', '"+Description+"', '"+InstallDate+"', '"+MFG+"', '"+SerialNum+"', '" + Status.ToString()+"', '"+Type+"', '"+Building+"', '"+RoomNum+"', '"+Notes+"') ";
			
			//string strConn = "DSN=Sybase ODBC Driver";

			OdbcConnection myConnection = new OdbcConnection(strConn);
			myConnection.Open();
			try
			{
				OdbcCommand myCommand = new OdbcCommand(insertInfo, myConnection);
				myCommand.CommandType = CommandType.Text ;
				
				myCommand.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				MessageBox.Show("Error Adding Inventory Record: "+e.Message.ToString(),"error");
			}
			
		}

		public DataTable OptionType()
		{
			string doQuery = "Select Type FROM MW_DBA.TypeOptions ";

			//string strConn = "DSN=Sybase ODBC Driver";
			OdbcConnection myConnection = new OdbcConnection(strConn);
			myConnection.Open();

			DataTable hold= new DataTable("tblType");
			try
			{
				OdbcCommand myCommand = new OdbcCommand(doQuery, myConnection);
				OdbcDataAdapter myAdapter = new OdbcDataAdapter(myCommand);
				myAdapter.Fill(hold);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Filling Option Type:  "+ex.Message.ToString(),"Error");
			}

			return(hold);
		}

		public void CreateCatalog()
		{
			string Create = "CREATE TABLE OtherInventory (ID char(250) NOT NULL PRIMARY KEY, Name char(500) Null, Description char(1000) Null, InstallDate char(20) Null, MFG char(500) Null, SerialNum char(100) Null, Status char(10) Not Null, Type char(50) Not Null, Building char(250) Null, RoomNum char(50) Null,Notes char(1000) Null)";

			string Create2 = "Create TABLE TypeOptions (Type char(250))";

			//string strConn = "DSN=Sybase ODBC Driver";
			Form myForm = new CreateInventMess();

			DialogResult buttonClick = myForm.ShowDialog();

			
			if(buttonClick==DialogResult.Yes )
			{
				OdbcConnection myConnection = new OdbcConnection(strConn);
				myConnection.Open();
				try
				{
					OdbcCommand myCommand = new OdbcCommand(Create, myConnection);
					myCommand.CommandType = CommandType.Text ;
				
					myCommand.ExecuteNonQuery();

					MessageBox.Show("Done creating Option Inventory Catalog","Done");
				}
				catch(Exception ex)
				{
					MessageBox.Show("Error Creating Optional Inventory Catalog: "+ex.Message.ToString(),"error");
				}

				try
				{
					OdbcCommand myCommand = new OdbcCommand(Create2, myConnection);
					myCommand.CommandType = CommandType.Text ;
				
					myCommand.ExecuteNonQuery();

					MessageBox.Show("Done creating Option Inventory Type Choices Catalog","Done");
				}
				catch(Exception ex)
				{
					MessageBox.Show("Error Creating Optional Inventory Catalog Type Choices: "+ex.Message.ToString(),"error");
				}

				myConnection.Close();
			}
			else
			{
				MessageBox.Show("Table Creation Canceled","Cancel");
			}
			myForm.Dispose();
		}

		public void DeleteTable()
		{
			string Create = "DROP TABLE OtherInventory ";

			//string strConn = "DSN=Sybase ODBC Driver";

			OdbcConnection myConnection = new OdbcConnection(strConn);
			myConnection.Open();
			try
			{
				OdbcCommand myCommand = new OdbcCommand(Create, myConnection);
				myCommand.CommandType = CommandType.Text ;
				
				myCommand.ExecuteNonQuery();
				
				try
				{
					Create = "DROP TABLE TypeOptions";

					OdbcCommand myCommand2 = new OdbcCommand(Create, myConnection);
					myCommand2.CommandType = CommandType.Text ;

					myCommand2.ExecuteNonQuery();
				}
				catch(Exception ex2)
				{
					MessageBox.Show("Error Deleting TypeOptions Table: "+ex2.Message.ToString(),"error");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Deleting Option Inventory Catalog: "+ex.Message.ToString(),"error");
			}
			myConnection.Close();
		}

		public void AddTypeOptions(string newTypeWrite)
		{
			string AddNew = "INSERT INTO MW_DBA.TypeOptions (Type) VALUES ('"+newTypeWrite+"') ";

			//string strConn = "DSN=Sybase ODBC Driver";
			OdbcConnection myConnection = new OdbcConnection(strConn);
			myConnection.Open();

			try
			{
				OdbcCommand myCommand = new OdbcCommand(AddNew, myConnection);
				myCommand.CommandType = CommandType.Text ;
				
				myCommand.ExecuteNonQuery();

			}
			catch(Exception e)
			{
				MessageBox.Show("Error writing to Catalog Type:  "+e.Message.ToString(),"Error");
			}

			myConnection.Close();
		}

		public void DeleteTypeOptions(string TypeOption)
		{
			string DeleteInfo = "DELETE FROM MW_DBA.TypeOptions WHERE Type = '"+TypeOption+"' ";

			//string strConn = "DSN=Sybase ODBC Driver";

			OdbcConnection myConnection = new OdbcConnection(strConn);
			myConnection.Open();
			try
			{
				OdbcCommand myCommand = new OdbcCommand(DeleteInfo, myConnection);
				myCommand.CommandType = CommandType.Text ;
				
				myCommand.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				MessageBox.Show("Error Deleting Record: "+e.Message.ToString(),"error");
			}

			myConnection.Close();

			
		}

	}
}
