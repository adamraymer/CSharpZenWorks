using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ZenworksQuerySystem
{
	/// <summary>
	/// Summary description for DeleteTableWarn.
	/// </summary>
	public class DeleteTableWarn : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button btnNo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DeleteTableWarn()
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
			this.label1 = new System.Windows.Forms.Label();
			this.btnYes = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(384, 72);
			this.label1.TabIndex = 0;
			this.label1.Text = "You are about to delete the optional inventory catalog. All information will be l" +
				"ost! Do you wish to continue?";
			// 
			// btnYes
			// 
			this.btnYes.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnYes.Location = new System.Drawing.Point(112, 112);
			this.btnYes.Name = "btnYes";
			this.btnYes.TabIndex = 1;
			this.btnYes.Text = "Yes";
			// 
			// btnNo
			// 
			this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnNo.Location = new System.Drawing.Point(264, 112);
			this.btnNo.Name = "btnNo";
			this.btnNo.TabIndex = 2;
			this.btnNo.Text = "No";
			// 
			// DeleteTableWarn
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 150);
			this.ControlBox = false;
			this.Controls.Add(this.btnNo);
			this.Controls.Add(this.btnYes);
			this.Controls.Add(this.label1);
			this.Name = "DeleteTableWarn";
			this.Text = "WARNING!";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
