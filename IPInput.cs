using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ZenworksQuerySystem
{
	/// <summary>
	/// Summary description for IPInput.
	/// </summary>
	public class IPInput : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtIPAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOkay;
		private System.Windows.Forms.Button btnCancel;
		public string ipAddress;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IPInput()
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
			this.txtIPAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOkay = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtIPAddress
			// 
			this.txtIPAddress.Location = new System.Drawing.Point(16, 40);
			this.txtIPAddress.Name = "txtIPAddress";
			this.txtIPAddress.Size = new System.Drawing.Size(304, 20);
			this.txtIPAddress.TabIndex = 0;
			this.txtIPAddress.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Type the IP address for the Zenworks server you wish to use:";
			// 
			// btnOkay
			// 
			this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOkay.Location = new System.Drawing.Point(168, 80);
			this.btnOkay.Name = "btnOkay";
			this.btnOkay.TabIndex = 2;
			this.btnOkay.Text = "OK";
			this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(248, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			// 
			// IPInput
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 118);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOkay);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtIPAddress);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IPInput";
			this.ShowInTaskbar = false;
			this.Text = "IPInput";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOkay_Click(object sender, System.EventArgs e)
		{
			QueryZen QZ = new QueryZen();
			QZ.IpAdd = this.txtIPAddress.Text;
		}

		
	}
}
