using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using BandObjectLib;
using System.Runtime.InteropServices;
using mshtml;
namespace iprimrtoolbar
{
	[Guid("1097F0AC-9A04-46c3-9E97-2DB319F36CF1")]
	[BandObject("Azad_Primer", BandObjectStyle.TaskbarToolBar | BandObjectStyle.ExplorerToolbar | BandObjectStyle.TaskbarToolBar, HelpText = "Search for Amazon Prime eligible items")]
	
	public class iprimrtoolbar : BandObject
	{
		private System.Windows.Forms.Label srchLbl;
		private System.Windows.Forms.TextBox srchTxt;
		private System.Windows.Forms.Button srchBtn;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public iprimrtoolbar()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(iprimrtoolbar));
			this.srchLbl = new System.Windows.Forms.Label();
			this.srchTxt = new System.Windows.Forms.TextBox();
			this.srchBtn = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// srchLbl
			// 
			this.srchLbl.Location = new System.Drawing.Point(75, 3);
			this.srchLbl.Name = "srchLbl";
			this.srchLbl.Size = new System.Drawing.Size(260, 23);
			this.srchLbl.TabIndex = 1;
			this.srchLbl.Text = "     Search for Amazon Prime eligible items       ";
			// 
			// srchTxt
			// 
			this.srchTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.srchTxt.Location = new System.Drawing.Point(335, 2);
			this.srchTxt.Name = "srchTxt";
			this.srchTxt.Size = new System.Drawing.Size(280, 20);
			this.srchTxt.TabIndex = 2;
			this.srchTxt.Text = "";
			this.srchTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.srchTxt_KeyPress);
			// 
			// srchBtn
			// 
			this.srchBtn.Image = ((System.Drawing.Image)(resources.GetObject("srchBtn.Image")));
			this.srchBtn.Location = new System.Drawing.Point(616, 0);
			this.srchBtn.Name = "srchBtn";
			this.srchBtn.Size = new System.Drawing.Size(80, 23);
			this.srchBtn.TabIndex = 3;
			this.srchBtn.Click += new System.EventHandler(this.srchBtn_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(75, 23);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// iprimrtoolbar
			// 
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.srchBtn);
			this.Controls.Add(this.srchTxt);
			this.Controls.Add(this.srchLbl);
			this.MinSize = new System.Drawing.Size(695, 23);
			this.Name = "iprimrtoolbar";
			this.Size = new System.Drawing.Size(695, 23);
			this.ResumeLayout(false);

		}
		#endregion

		private void srchBtn_Click(object sender, System.EventArgs e)
		{
			this.handleSearchEvent();
		}		

		private void srchTxt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				this.handleSearchEvent();
			}
		}

		private String formatSearchString()
		{
			String srchString="";
			try
			{
				String input = this.srchTxt.Text.Trim();
				if(input.Length>0)
				{
					String[] keys=input.Split(' ');
					for(int i=0;i<keys.Length;i++)
					{
						if(keys[i].Length>0)
						{
							if(srchString.Length>0)
							{
								String key=Microsoft.JScript.GlobalObject.encodeURIComponent(keys[i]);
								srchString=srchString+"+"+key;
							}
							else
							{
								String key=Microsoft.JScript.GlobalObject.encodeURIComponent(keys[i]);
								srchString=key;
							}
						}
					}
						
				}
			}
			catch(Exception ex)
			{
			}
			return srchString;
		}

		private void handleSearchEvent()
		{
			try
			{
				String srchString=this.formatSearchString();
				if(srchString.Length>0)
				{
					String url=srchString="http://iprimr.com/search.php?keyword="+srchString+"&searchindex=All";
					this.NavigateUrl(url);
				}
			}
			catch(Exception ex)
			{
			}
		}

		private void NavigateUrl(string urlString)
		{
			HTMLDocumentClass doc = (HTMLDocumentClass)Explorer.Document;
			doc.url=urlString;		
		}
	}
}
