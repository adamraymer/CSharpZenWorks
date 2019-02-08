using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ZenworksQuerySystem
{
	/// <summary>
	/// Summary description for SaveChoice.
	/// </summary>
	public class SaveChoice : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnText;
		private System.Windows.Forms.Button btnWord;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SaveChoice()
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
			this.btnText = new System.Windows.Forms.Button();
			this.btnWord = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnText
			// 
			this.btnText.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnText.Location = new System.Drawing.Point(16, 72);
			this.btnText.Name = "btnText";
			this.btnText.Size = new System.Drawing.Size(216, 23);
			this.btnText.TabIndex = 0;
			this.btnText.Text = "&Text Delimited";
			// 
			// btnWord
			// 
			this.btnWord.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnWord.Location = new System.Drawing.Point(16, 112);
			this.btnWord.Name = "btnWord";
			this.btnWord.Size = new System.Drawing.Size(216, 23);
			this.btnWord.TabIndex = 1;
			this.btnWord.Text = "&Word Document";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 32);
			this.label1.TabIndex = 2;
			this.label1.Text = "Save File As:";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(16, 152);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(216, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// SaveChoice
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 190);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnWord);
			this.Controls.Add(this.btnText);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(264, 224);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(264, 224);
			this.Name = "SaveChoice";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Save Choice";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
