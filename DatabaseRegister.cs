using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ZenworksQuerySystem
{
	/// <summary>
	/// Summary description for DatabaseRegister.
	/// </summary>
	public class DatabaseRegister : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtIpAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDatabaseUID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDatabasePW;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkDefault;
		private System.Windows.Forms.TextBox txtDatabaseName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DatabaseRegister()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.txtIpAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDatabaseUID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDatabasePW = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkDefault = new System.Windows.Forms.CheckBox();
			this.txtDatabaseName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtIpAddress
			// 
			this.txtIpAddress.Location = new System.Drawing.Point(88, 72);
			this.txtIpAddress.Name = "txtIpAddress";
			this.txtIpAddress.Size = new System.Drawing.Size(216, 20);
			this.txtIpAddress.TabIndex = 0;
			this.txtIpAddress.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "IP Address:";
			// 
			// txtDatabaseUID
			// 
			this.txtDatabaseUID.Enabled = false;
			this.txtDatabaseUID.Location = new System.Drawing.Point(88, 120);
			this.txtDatabaseUID.Name = "txtDatabaseUID";
			this.txtDatabaseUID.Size = new System.Drawing.Size(216, 20);
			this.txtDatabaseUID.TabIndex = 2;
			this.txtDatabaseUID.Text = "mw_dba";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "User ID:";
			// 
			// txtDatabasePW
			// 
			this.txtDatabasePW.Enabled = false;
			this.txtDatabasePW.Location = new System.Drawing.Point(88, 168);
			this.txtDatabasePW.Name = "txtDatabasePW";
			this.txtDatabasePW.PasswordChar = '*';
			this.txtDatabasePW.Size = new System.Drawing.Size(216, 20);
			this.txtDatabasePW.TabIndex = 4;
			this.txtDatabasePW.Text = "Novell";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "PassWRD:";
			// 
			// chkDefault
			// 
			this.chkDefault.Checked = true;
			this.chkDefault.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDefault.Location = new System.Drawing.Point(328, 120);
			this.chkDefault.Name = "chkDefault";
			this.chkDefault.Size = new System.Drawing.Size(120, 40);
			this.chkDefault.TabIndex = 6;
			this.chkDefault.Text = "Use Defaults (recommended)";
			this.chkDefault.CheckedChanged += new System.EventHandler(this.chkDefault_CheckedChanged);
			// 
			// txtDatabaseName
			// 
			this.txtDatabaseName.Enabled = false;
			this.txtDatabaseName.Location = new System.Drawing.Point(88, 216);
			this.txtDatabaseName.Name = "txtDatabaseName";
			this.txtDatabaseName.Size = new System.Drawing.Size(216, 20);
			this.txtDatabaseName.TabIndex = 7;
			this.txtDatabaseName.Text = "mgmtdb";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 216);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "DB Name:";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(336, 176);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(336, 216);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// DatabaseRegister
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 266);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDatabaseName);
			this.Controls.Add(this.chkDefault);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDatabasePW);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtDatabaseUID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtIpAddress);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(512, 300);
			this.MinimumSize = new System.Drawing.Size(512, 300);
			this.Name = "DatabaseRegister";
			this.Text = "DatabaseRegister";
			this.ResumeLayout(false);

		}
		#endregion

		private void chkDefault_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkDefault.Checked==true)
			{
				this.txtDatabaseName.Enabled=false;
				this.txtDatabasePW.Enabled=false;
				this.txtDatabaseUID.Enabled=false;
			}
			else
			{
				this.txtDatabaseName.Enabled=true;
				this.txtDatabasePW.Enabled=true;
				this.txtDatabaseUID.Enabled=true;
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			string User = " ";
			string Pass = " ";
			string IP = " ";
			string Name = " ";

			User = this.txtDatabaseUID.Text;
			Pass = this.txtDatabasePW.Text;
			IP = this.txtIpAddress.Text;
			Name = this.txtDatabaseName.Text;

			QueryZen Query = new QueryZen();

			Query.WriteSybaseReg(IP,User,Pass,Name);

			System.Diagnostics.Process.Start( "C:\\Program Files\\Gracon Services, Inc\\ZENWorksQuery\\Sybase\\SybaseODBC.reg");

			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
