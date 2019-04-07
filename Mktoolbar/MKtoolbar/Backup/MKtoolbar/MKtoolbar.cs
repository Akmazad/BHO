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
using System.Text;
using Microsoft.Win32;
using Microsoft.VisualBasic;
namespace MKtoolbar
{
    [Guid("1097F0AC-9A04-46c3-9E97-2DB319F36CF1")]
    [BandObject("MKtoolbar", BandObjectStyle.TaskbarToolBar | BandObjectStyle.ExplorerToolbar | BandObjectStyle.TaskbarToolBar, HelpText = "")]

    public class MKtoolbar:BandObject
    {
        private System.Windows.Forms.Label dottedBar;

        private ToolBar myToolbar;
        private ToolBarButton myToolbarButton;
        private Label lblmainLogo;
        private Label lblMiddleDividerBar;
        private Button btnCareer;
        private Button btnGO;
        
        


        private ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CareerToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem jobBlogMittelstandToolStripMenuItem;
        private ToolStripMenuItem arbeitsmarktToolStripMenuItem;
        private ToolStripMenuItem mittelstandJobsToolStripMenuItem;
        private ComboBox comboSearchBox;
        private Panel panel1;
        private Button button1;
        private RichTextBox searchBox;
        private ToolStripMenuItem agency1ToolStripMenuItem;
        private Label label1;
        
        /*private System.Windows.Forms.ToolStripMenuItem RssfeedToolStripMenuItem;
        */
        private IContainer components;
        //private IContainer secondComponents;

        public MKtoolbar()
        {
            InitializeComponent();
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CareerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.jobBlogMittelstandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arbeitsmarktToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mittelstandJobsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboSearchBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchBox = new System.Windows.Forms.RichTextBox();
            this.btnCareer = new System.Windows.Forms.Button();
            this.lblMiddleDividerBar = new System.Windows.Forms.Label();
            this.lblmainLogo = new System.Windows.Forms.Label();
            this.dottedBar = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.agency1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agency1ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.ShowItemToolTips = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 48);
            // 
            // CareerToolStripMenuItem
            // 
            this.CareerToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.CareerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CareerToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CareerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.CareerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CareerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.CareerToolStripMenuItem.Name = "CareerToolStripMenuItem";
            this.CareerToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CareerToolStripMenuItem.Text = "This is a test";
            this.CareerToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jobBlogMittelstandToolStripMenuItem,
            this.arbeitsmarktToolStripMenuItem,
            this.mittelstandJobsToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip2.ShowImageMargin = false;
            this.contextMenuStrip2.Size = new System.Drawing.Size(154, 70);
            // 
            // jobBlogMittelstandToolStripMenuItem
            // 
            this.jobBlogMittelstandToolStripMenuItem.Name = "jobBlogMittelstandToolStripMenuItem";
            this.jobBlogMittelstandToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.jobBlogMittelstandToolStripMenuItem.Text = "JobBlog Mittelstand";
            this.jobBlogMittelstandToolStripMenuItem.Click += new System.EventHandler(this.jobBlogMittelstandToolStripMenuItem_Click);
            // 
            // arbeitsmarktToolStripMenuItem
            // 
            this.arbeitsmarktToolStripMenuItem.Name = "arbeitsmarktToolStripMenuItem";
            this.arbeitsmarktToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.arbeitsmarktToolStripMenuItem.Text = "Arbeitsmarkt";
            this.arbeitsmarktToolStripMenuItem.Click += new System.EventHandler(this.arbeitsmarktToolStripMenuItem_Click);
            // 
            // mittelstandJobsToolStripMenuItem
            // 
            this.mittelstandJobsToolStripMenuItem.Name = "mittelstandJobsToolStripMenuItem";
            this.mittelstandJobsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.mittelstandJobsToolStripMenuItem.Text = "Mittelstand & Jobs";
            this.mittelstandJobsToolStripMenuItem.Click += new System.EventHandler(this.mittelstandJobsToolStripMenuItem_Click);
            // 
            // comboSearchBox
            // 
            this.comboSearchBox.AllowDrop = true;
            this.comboSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSearchBox.CausesValidation = false;
            this.comboSearchBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboSearchBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSearchBox.FormattingEnabled = true;
            this.comboSearchBox.Location = new System.Drawing.Point(877, 2);
            this.comboSearchBox.Name = "comboSearchBox";
            this.comboSearchBox.Size = new System.Drawing.Size(121, 150);
            this.comboSearchBox.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.searchBox);
            this.panel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(724, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 20);
            this.panel1.TabIndex = 13;
            // 
            // searchBox
            // 
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.searchBox.Location = new System.Drawing.Point(37, 2);
            this.searchBox.Multiline = false;
            this.searchBox.Name = "searchBox";
            this.searchBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.searchBox.Size = new System.Drawing.Size(158, 16);
            this.searchBox.TabIndex = 14;
            this.searchBox.Text = "Google Suche";
            this.searchBox.WordWrap = false;
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            this.searchBox.Click += new System.EventHandler(this.richTextBox1_Click);
            // 
            // btnCareer
            // 
            this.btnCareer.BackgroundImage = global::MKtoolbar.Properties.Resources.careerImage;
            this.btnCareer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCareer.FlatAppearance.BorderSize = 0;
            this.btnCareer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCareer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCareer.Location = new System.Drawing.Point(590, 3);
            this.btnCareer.Name = "btnCareer";
            this.btnCareer.Size = new System.Drawing.Size(108, 19);
            this.btnCareer.TabIndex = 11;
            this.btnCareer.UseVisualStyleBackColor = true;
            this.btnCareer.MouseLeave += new System.EventHandler(this.btnCareer_MouseLeave);
            this.btnCareer.Click += new System.EventHandler(this.btnCareer_Click);
            this.btnCareer.MouseHover += new System.EventHandler(this.btnCareer_MouseHover);
            // 
            // lblMiddleDividerBar
            // 
            this.lblMiddleDividerBar.Image = global::MKtoolbar.Properties.Resources.middle_bar1;
            this.lblMiddleDividerBar.Location = new System.Drawing.Point(174, 2);
            this.lblMiddleDividerBar.Name = "lblMiddleDividerBar";
            this.lblMiddleDividerBar.Size = new System.Drawing.Size(5, 17);
            this.lblMiddleDividerBar.TabIndex = 10;
            // 
            // lblmainLogo
            // 
            this.lblmainLogo.Image = global::MKtoolbar.Properties.Resources.sampleLogo1;
            this.lblmainLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblmainLogo.Location = new System.Drawing.Point(6, -1);
            this.lblmainLogo.Name = "lblmainLogo";
            this.lblmainLogo.Size = new System.Drawing.Size(162, 21);
            this.lblmainLogo.TabIndex = 9;
            this.lblmainLogo.Click += new System.EventHandler(this.lblmainLogo_Click);
            // 
            // dottedBar
            // 
            this.dottedBar.ForeColor = System.Drawing.Color.Red;
            this.dottedBar.Image = global::MKtoolbar.Properties.Resources.left_dot_bar;
            this.dottedBar.Location = new System.Drawing.Point(-1, 0);
            this.dottedBar.Name = "dottedBar";
            this.dottedBar.Size = new System.Drawing.Size(8, 19);
            this.dottedBar.TabIndex = 8;
            this.dottedBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::MKtoolbar.Properties.Resources.searchLogo;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 17);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnGO
            // 
            this.btnGO.FlatAppearance.BorderSize = 0;
            this.btnGO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGO.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGO.Image = global::MKtoolbar.Properties.Resources.go_arrow;
            this.btnGO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGO.Location = new System.Drawing.Point(933, 0);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(80, 23);
            this.btnGO.TabIndex = 14;
            this.btnGO.Text = "Search";
            this.btnGO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // label1
            // 
            this.label1.Image = global::MKtoolbar.Properties.Resources.middle_bar1;
            this.label1.Location = new System.Drawing.Point(704, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(5, 17);
            this.label1.TabIndex = 15;
            // 
            // agency1ToolStripMenuItem
            // 
            this.agency1ToolStripMenuItem.Name = "agency1ToolStripMenuItem";
            this.agency1ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.agency1ToolStripMenuItem.Text = "Agency 1";
            // 
            // MKtoolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(222)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMiddleDividerBar);
            this.Controls.Add(this.lblmainLogo);
            this.Controls.Add(this.dottedBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCareer);
            this.Controls.Add(this.btnGO);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 21);
            this.MinSize = new System.Drawing.Size(1024, 21);
            this.Name = "MKtoolbar";
            this.Size = new System.Drawing.Size(1024, 27);
            this.Load += new System.EventHandler(this.MKtoolbar_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void btnCareer_Click(object sender, EventArgs e)
        {
            //this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.CareerToolStripMenuItem });
            this.contextMenuStrip1.Name = "contextMenuStrip1";

            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 28);
            this.contextMenuStrip1.ResumeLayout(false);
            
            RegistryKey ieVersion = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Internet Explorer");
            if (ieVersion.GetValue("Version").ToString().StartsWith("6"))
            {
                this.contextMenuStrip1.Show(this.Location.X + 165, this.Location.Y + 47);
            }
            else if (ieVersion.GetValue("Version").ToString().StartsWith("7"))
            {
                this.contextMenuStrip1.Show(this.Location.X + 165, this.Location.Y + 80);
            }
        }

        private void btnRssFeed_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip2.Name = "contextMenuStrip2";

            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 48);
            this.contextMenuStrip2.ResumeLayout(false);
            
            RegistryKey ieVersion = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Internet Explorer");
            if (ieVersion.GetValue("Version").ToString().StartsWith("6"))
            {
                this.contextMenuStrip2.Show(this.Location.X + 277, this.Location.Y + 47);
            }
            else if (ieVersion.GetValue("Version").ToString().StartsWith("7"))
            {
                this.contextMenuStrip2.Show(this.Location.X + 277, this.Location.Y + 80);
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            goSearchActions();
        }

        private void goSearchActions()
        {
            if (this.searchBox.Text != "")
            {
                try
                {
                    object oEmpty = String.Empty;
                    Explorer.Navigate("http://www.google.com.bd/search?q=" + this.searchBox.Text, ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            }
        }

        private void jobGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object oEmpty = String.Empty;

                Explorer.Navigate("http://jobguide.de/", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void berufszentrumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object oEmpty = String.Empty;

                Explorer.Navigate("http://www.berufszentrum.de/", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void karrieredeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object oEmpty = String.Empty;

                Explorer.Navigate("http://www.karriere.de/", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void berufeNetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object oEmpty = String.Empty;

                Explorer.Navigate("http://www.berufenet.de/", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void gehaltsCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object oEmpty = String.Empty;

                Explorer.Navigate("http://www.nettolohn.de/", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void jobBlogMittelstandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object oEmpty = String.Empty;

                Explorer.Navigate("http://www.mittelstandskarriere.de/job-blog/feed/", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void arbeitsmarktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object oEmpty = String.Empty;

                Explorer.Navigate("http://news.google.de/news?svnum=10&as_scoring=r&hl=de&tab=wn&ned=de&as_drrb=q&as_qdr=&as_mind=14&as_minm=1&as_maxd=13&as_maxm=2&aq=f&q=arbeitsmarkt&ie=UTF-8&nolr=1&output=rss", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void mittelstandJobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object oEmpty = String.Empty;

                Explorer.Navigate("http://news.google.de/news?hl=de&tab=wn&ned=de&q=Jobs+KMU+OR+Mittelstand+OR+Mittelst%C3%A4ndler&ie=UTF-8&nolr=1&output=rss", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void MKtoolbar_Load(object sender, EventArgs e)
        {
            
            
            
            /*check for IE version*/
            
                //this.comboSearchBox.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - 190, 0);
                //this.btnGO.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - 70, 0);


                //MessageBox.Show(Explorer.Width.ToString() + " dfgd");
            //this.Controls.Add(this.comboSearchBox);
            
            

            /*enable the timer for version checking*/
            //timer1.Enabled = true;

            /*check date time on every load*/
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects\\mktoolbar");

                DateTime dt = DateTime.Parse(key.GetValue("InstallationDate").ToString());

                DateTime now = DateTime.Now;
                TimeSpan ts = now - dt;
                if (ts.Days >= 120)
                {
                    checkForUpdate();
                }
            }
            catch (Exception ex)
            { 
                
            }


        }

        private void btnCareer_MouseHover(object sender, EventArgs e)
        {
            this.btnCareer.Cursor = Cursors.Hand;
        }
        //public void InsertImage(string pic)
        //{
            
        //    //string lstrFile = fileDialog.FileName;
        //    string lstrFile = pic;
        //    Bitmap myBitmap = new Bitmap(lstrFile);
        //    MessageBox.Show("hi " + pic);
        //    // Copy the bitmap to the clipboard.
        //    Clipboard.SetDataObject(myBitmap);
        //    // Get the format for the object type.
        //    DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
        //    // After verifying that the data can be pasted, paste
        //    if (richTextBox1.CanPaste(myFormat))
        //    {
        //        richTextBox1.Paste(myFormat);
        //    }
        //    else
        //    {
        //        MessageBox.Show("The data format that you attempted site" + " is not supportedby this control.");
        //    }

        //}
        private void btnCareer_MouseLeave(object sender, EventArgs e)
        {
            this.btnCareer.Cursor = Cursors.Default;
        }

        private void btnRssFeed_MouseHover(object sender, EventArgs e)
        {
            //this.btnRssFeed.Cursor = Cursors.Hand;
        }

        private void btnRssFeed_MouseLeave(object sender, EventArgs e)
        {
            //this.btnRssFeed.Cursor = Cursors.Default;
        }

        private void checkForUpdate()
        {
            RegistryKey key;
            RestImpl ri;
            try
            {
                /*get the version from registry*/
                key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects\\mktoolbar");


                /*check for update*/
                ri = new RestImpl();
                string target_url = "http://www.mittelstandskarriere.de/jobs-toolbar/mk-toolbar-var.php";


                HttpWebRequest webRequest;
                XmlDocument strResponse = new XmlDocument();
                IDictionary<String, String> paramList = new Dictionary<String, String>();
                paramList.Add("opr", "get");
                webRequest = ri.CreateRequest(target_url, paramList);

                strResponse = ri.GetXMLResponse(webRequest);

                ///*get the version number from xml file*/
                XmlNodeList list = strResponse.GetElementsByTagName("version");
                XmlNodeList dulist = strResponse.GetElementsByTagName("download-url");
                XmlElement element = (XmlElement)list.Item(0);
                XmlElement downloadUrl = (XmlElement)dulist.Item(0);
                
                
                if (!key.GetValue("mktoolbar_Version").ToString().Equals(element.InnerText))
                {
                    //MessageBox.Show("[demo] : Your MKtoolbar version is outdated!!!!!");
                    try
                    {
                        object oEmpty = String.Empty;

                        //Explorer.Navigate("http://www.commoncause.org/browserdonate", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
                        InternetExplorer newWindow = new InternetExplorer();
                        newWindow.Visible = true;
                        newWindow.Navigate(downloadUrl.InnerText, ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                //timer1.Enabled = false;

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());

            }
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            if ((searchBox.Text == "Google Suche") && (this.searchBox.ForeColor == System.Drawing.SystemColors.ScrollBar))
            {
                this.searchBox.Text = "";
                this.searchBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void lblmainLogo_Click(object sender, EventArgs e)
        {
            try
            {
                object oEmpty = String.Empty;

                Explorer.Navigate("http://www.mittelstandskarriere.de", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
                //InternetExplorer newWindow = new InternetExplorer();
                //newWindow.Visible = true;
                //newWindow.Navigate(downloadUrl.InnerText, ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                goSearchActions();
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                
            }
        }

        private void versicherungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object oEmpty = String.Empty;

                Explorer.Navigate("http://www.mittelstandskarriere.de/mehrwerte/versicherung/", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}
