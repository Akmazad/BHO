using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using BandObjectLib;
using System.Runtime.InteropServices;
using mshtml;
//using System.Web.UI.WebControls;
using System.Net;
using System.Collections.Generic;
using System.Xml;
using SHDocVw;
using System.IO;

namespace CommonCause
{
    

    [Guid("2097F0AC-9A04-46c3-9E97-2DB319F36CF1")]
    [BandObject("CommonCause_Bar2008", BandObjectStyle.TaskbarToolBar | BandObjectStyle.ExplorerToolbar | BandObjectStyle.TaskbarToolBar, HelpText = "Alerts of Common Cause")]
    //[BandObject("CommonCause_Bar", BandObjectStyle.ExplorerToolbar)]

    public class CommonCause : BandObject 
    {
        private System.Windows.Forms.Label srchLbl;
        private System.Windows.Forms.Label lblTags;

        private PictureBox pictureBox1;
        private PictureBox imgbtn;
        private System.Windows.Forms.Label lblAlert;
        private Timer timer1;

        /*testing region here*/
        private ToolBar myToolbar;
        private ToolBarButton myToolbarButton;
        private ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addUrlToolStripMenuItem;
        
        private IContainer components;
        private XmlNodeList alertlist;
        private int counter;
        public System.Windows.Forms.Label lblTagcount;
        private PictureBox pcboxDivider;
        private Timer timer2;

        private string previousURL;
        RestImpl ri;
        HttpWebRequest webRequest;
        private Label lblDivider;
        
        public XmlDocument strResponse = new XmlDocument();

        public CommonCause()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call

		}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.myToolbar = new System.Windows.Forms.ToolBar();
            this.myToolbarButton = new System.Windows.Forms.ToolBarButton();
            this.srchLbl = new System.Windows.Forms.Label();
            this.lblAlert = new System.Windows.Forms.Label();
            this.lblTags = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTagcount = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imgbtn = new System.Windows.Forms.PictureBox();
            this.pcboxDivider = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblDivider = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcboxDivider)).BeginInit();
            this.SuspendLayout();
            // 
            // myToolbar
            // 
            this.myToolbar.DropDownArrows = true;
            this.myToolbar.Location = new System.Drawing.Point(0, 0);
            this.myToolbar.Name = "myToolbar";
            this.myToolbar.ShowToolTips = true;
            this.myToolbar.Size = new System.Drawing.Size(100, 42);
            this.myToolbar.TabIndex = 0;
            // 
            // myToolbarButton
            // 
            this.myToolbarButton.Name = "myToolbarButton";
            // 
            // srchLbl
            // 
            this.srchLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.srchLbl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srchLbl.Location = new System.Drawing.Point(161, 1);
            this.srchLbl.Name = "srchLbl";
            this.srchLbl.Size = new System.Drawing.Size(299, 23);
            this.srchLbl.TabIndex = 1;
            this.srchLbl.Text = "     Remember to Vote Today       ";
            // 
            // lblAlert
            // 
            this.lblAlert.AutoSize = true;
            this.lblAlert.ForeColor = System.Drawing.Color.Red;
            this.lblAlert.Location = new System.Drawing.Point(111, 2);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(48, 16);
            this.lblAlert.TabIndex = 8;
            this.lblAlert.Text = "Alert:";
            // 
            // lblTags
            // 
            this.lblTags.BackColor = System.Drawing.Color.Gray;
            this.lblTags.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTags.Location = new System.Drawing.Point(26, 2);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(68, 16);
            this.lblTags.TabIndex = 9;
            this.lblTags.Text = "Add";
            this.lblTags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTags.Click += new System.EventHandler(this.SaveBookMark_Promt);
            // 
            // lblTagcount
            // 
            this.lblTagcount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.lblTagcount.Enabled = false;
            this.lblTagcount.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagcount.ForeColor = System.Drawing.Color.White;
            this.lblTagcount.Location = new System.Drawing.Point(35, 26);
            this.lblTagcount.Name = "lblTagcount";
            this.lblTagcount.Size = new System.Drawing.Size(200, 20);
            this.lblTagcount.TabIndex = 9;
            this.lblTagcount.Text = "Add URL: ";
            this.lblTagcount.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.ShowItemToolTips = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // addUrlToolStripMenuItem
            // 
            this.addUrlToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.addUrlToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addUrlToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addUrlToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addUrlToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addUrlToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.addUrlToolStripMenuItem.Name = "addUrlToolStripMenuItem";
            this.addUrlToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addUrlToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CommonCause.Properties.Resources.commoncause;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 23);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.SaveBookMark_Promt);
            // 
            // imgbtn
            // 
            this.imgbtn.Image = global::CommonCause.Properties.Resources.donate_button_n;
            this.imgbtn.Location = new System.Drawing.Point(0, 0);
            this.imgbtn.Name = "imgbtn";
            this.imgbtn.Size = new System.Drawing.Size(166, 26);
            this.imgbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgbtn.TabIndex = 0;
            this.imgbtn.TabStop = false;
            this.imgbtn.MouseLeave += new System.EventHandler(this.RestoreDefaultImage);
            this.imgbtn.Click += new System.EventHandler(this.GO_Donate);
            this.imgbtn.MouseHover += new System.EventHandler(this.DonateButtonImageChange);
            // 
            // pcboxDivider
            // 
            this.pcboxDivider.Image = global::CommonCause.Properties.Resources.bar;
            this.pcboxDivider.Location = new System.Drawing.Point(0, 0);
            this.pcboxDivider.Name = "pcboxDivider";
            this.pcboxDivider.Size = new System.Drawing.Size(6, 23);
            this.pcboxDivider.TabIndex = 7;
            this.pcboxDivider.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            // 
            // lblDivider
            // 
            this.lblDivider.Image = global::CommonCause.Properties.Resources.divider;
            this.lblDivider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDivider.Location = new System.Drawing.Point(98, 1);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(10, 17);
            this.lblDivider.TabIndex = 10;
            // 
            // CommonCause
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.lblAlert);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.srchLbl);
            this.Controls.Add(this.lblTags);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1280, 26);
            this.MinSize = new System.Drawing.Size(1280, 26);
            this.Name = "CommonCause";
            this.Size = new System.Drawing.Size(1280, 26);
            this.Load += new System.EventHandler(this.CommonCause_Load);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.CommonCause_ControlAdded);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcboxDivider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        public void loadTags(object pDisp, ref object URL)
        {
            MessageBox.Show("HIT !!!!");

            ri = new RestImpl();
            string tagURL = URL.ToString();
            try
            {
                string target_url = "http://sgcsoft.net/work/commoncause/admin/tag_counter.php";
                webRequest = ri.CreateRequestForTagCount(target_url, tagURL);

                string response = ri.GetResponse(webRequest);


                this.lblTags.Text = "";
                
                if (Int32.Parse(response) > 0)
                {
                    this.lblTags.Text = "Add (" + response + ")";
                }
                else
                {
                    this.lblTags.Text = "Add (" + response + ")";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addUrlToolStripMenuItem });
            //this.contextMenuStrip1.Name = "contextMenuStrip1";

            //this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            //this.contextMenuStrip1.ResumeLayout(false);
            //this.contextMenuStrip1.Show(this.Location.X + 35, this.Location.Y + 65);
            
        }

        private void pcboxDrop_Click(object sender, MouseEventArgs e)
        {
            RestImpl ri = new RestImpl();
            
            string tagURL = Explorer.LocationURL;
            
            //if (tagURL.StartsWith("http://") )
            //{
            //    tagURL = tagURL.Substring(7, tagURL.Length - 7);
            //}
            //if (tagURL.StartsWith("https://"))
            //{
            //    tagURL = tagURL.Substring(8, tagURL.Length - 8);
            //}
            //tagURL = tagURL.Substring(0, tagURL.Length - 1);


            try
            {
                string target_url = "http://sgcsoft.net/work/commoncause/admin/tag_counter.php";
                HttpWebRequest webRequest = ri.CreateRequestForTagCount(target_url, tagURL);

                string response = ri.GetResponse(webRequest);
                

                this.addUrlToolStripMenuItem.Text = "";
                if (Int32.Parse(response) > 0)
                {
                    this.addUrlToolStripMenuItem.Text = "Add URL: " + response + " Tags";
                }
                else
                {
                    this.addUrlToolStripMenuItem.Text = "Add URL: " + response + " Tag";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.addUrlToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.Show(this.Location.X + 35, this.Location.Y + 65);
            
            
        }

        private void CommonCause_Load(object sender, EventArgs e)
        {
            previousURL = Explorer.LocationURL;
            MessageBox.Show(previousURL);
            if (previousURL != String.Empty)
            {
                try
                {
                    ri = new RestImpl();
                    string target_url = "http://sgcsoft.net/work/commoncause/admin/tag_counter.php";
                    webRequest = ri.CreateRequestForTagCount(target_url, previousURL);

                    string response = ri.GetResponse(webRequest);
                    MessageBox.Show(response);
                    this.lblTags.Text = "";

                    if (Int32.Parse(response) > 0)
                    {
                        this.lblTags.Text = "Add (" + response + ")";
                    }
                    else
                    {
                        this.lblTags.Text = "Add (" + response + ")";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            timer2.Start();
            timer2.Tick += new EventHandler(timer2_Tick);
            //MessageBox.Show("Hi ! iam changing how r u????????");
            ri = new RestImpl();
            IDictionary<String, String> paramList = new Dictionary<String, String>();

            //MessageBox.Show(strResponse);
            try
            {

                string target_url = "http://sgcsoft.net/work/commoncause/admin/commoncause_xml.php";
                webRequest = ri.CreateRequest(target_url, paramList);
                strResponse = ri.GetXMLResponse(webRequest);

                /*get the deley counter*/
                XmlNodeList list = strResponse.GetElementsByTagName("alerts");
                XmlElement element = (XmlElement)list.Item(0);
                Int32 deleyTime = Int32.Parse(element.GetAttribute("delay"));
                //MessageBox.Show("DELAY TIME IS : " + deleyTime.ToString());
                //MessageBox.Show(element.InnerText);

                /*get the alert messages*/
                alertlist = strResponse.GetElementsByTagName("alert");

                counter = 0;
                srchLbl.Text = "";
                srchLbl.Text = alertlist.Item(counter).InnerText;

                timer1.Start();
                timer1.Interval = deleyTime * 1000;
                timer1.Tick += new EventHandler(timer1_Tick);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

            
            this.imgbtn.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width-200, 0);
            this.Controls.Add(this.imgbtn);
        }

        void timer2_Tick(object sender, EventArgs e)
        {
            ri = new RestImpl();
            string tagURL = Explorer.LocationURL;

            if (tagURL != previousURL && tagURL != String.Empty)
            {
                previousURL = tagURL;
                try
                {
                    string target_url = "http://sgcsoft.net/work/commoncause/admin/tag_counter.php";
                    webRequest = ri.CreateRequestForTagCount(target_url, tagURL);

                    string response = ri.GetResponse(webRequest);
                    this.lblTags.Text = "";

                    if (Int32.Parse(response) > 0)
                    {
                        this.lblTags.Text = "Add (" + response + ")";
                    }
                    else
                    {
                        this.lblTags.Text = "Add (" + response + ")";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter == alertlist.Count)
            {
                counter = 0;
            }
            srchLbl.Text = "";
            srchLbl.Text = alertlist.Item(counter).InnerText;
            // fill the alert labels
        }
        private void SaveBookMark_Promt(object sender, EventArgs e)
        {
            SaveBookmarkForm save = new SaveBookmarkForm();
            save.lblBrowserURL.Text = Explorer.LocationURL;
            save.Show();
            
        }
        private void CommonCause_ControlAdded(object sender, ControlEventArgs e)
        {
            this.AutoSize = true;
            this.lblTagcount.Enabled = true;
            this.lblTagcount.Visible = true;
        }

        private void DonateButtonImageChange(object sender, EventArgs e)
        {
            this.imgbtn.Image = global::CommonCause.Properties.Resources.donate_button_h;
            this.imgbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            
        }

        private void RestoreDefaultImage(object sender, EventArgs e)
        {
            this.imgbtn.Image = global::CommonCause.Properties.Resources.donate_button_n;
            this.imgbtn.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void GO_Donate(object sender, EventArgs e)
        {
            object oEmpty = String.Empty;

            //Explorer.Navigate("http://www.commoncause.org/browserdonate", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            InternetExplorer newWindow = new InternetExplorer();
            newWindow.Visible = true;
            newWindow.Navigate("http://www.commoncause.org/browserdonate", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
        }

        

    }
}
