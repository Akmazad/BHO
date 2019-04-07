using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Web;
using System.Net;
using System.Collections;
using System.Windows;


namespace CommonCause
{
   
    public partial class SaveBookmarkForm : Form
    {
        ArrayList arryState = new ArrayList();   
        XmlDocument strResponse = new XmlDocument();
        ArrayList tagid = new ArrayList();
        ArrayList selectedTag;
        ArrayList selectedTagName;
        XmlNodeList alertlist;
        

        public SaveBookmarkForm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            selectedTag = new ArrayList();
            selectedTagName = new ArrayList();
            
            
            foreach (Control con in this.Controls)
            {
                if (con.GetType() == typeof(System.Windows.Forms.CheckBox))
                {
                    CheckBox ch = (CheckBox)con;
                    if (ch.Checked)
                    {
                        
                        selectedTagName.Add(ch.Text);

                        //int tagIndex = Int32.Parse(ch.Name.Substring(8));
                        int ind;
                        for (ind = 0; ind < alertlist.Count; ind++)
                        {
                            if (alertlist.Item(ind).InnerText == ch.Text)
                            {
                                /*get the index value and break*/
                                break;
                            }
                        }
                        int tagIndex = Int32.Parse(tagid[ind].ToString());
                        selectedTag.Add(tagIndex);             
                    }
                }

            }
            
            RestImpl newRi = new RestImpl();
            IDictionary<String, String> newparamList = new Dictionary<String, String>();
            newparamList.Add("url", this.lblBrowserURL.Text);
            newparamList.Add("title", this.txtTitle.Text);
            newparamList.Add("notes", this.txtNotes.Text);

            string selectedState = "";
            
            if (this.comboBox1.SelectedItem != null)
            {
                selectedState = this.comboBox1.SelectedItem.ToString();
                newparamList.Add("state", this.comboBox1.SelectedItem.ToString());
            }
            else
            {
                newparamList.Add("state", "");
            }

            string tagName = HttpUtility.UrlEncode("tag_name");
            string tags = "";
            for (int i = 0; i < selectedTag.Count; i++)
            {
                tags += selectedTag[i].ToString() + ",";
            }
            if(selectedTag.Count > 0)
                tags = tags.Remove(tags.LastIndexOf(","));
            
            newparamList.Add(tagName, tags);
            tags = "";
            newparamList.Add("Submit", "Submit");

            try
            {
                string target_url = "http://sgcsoft.net/work/commoncause/admin/save-content.php";
                HttpWebRequest webRequest = newRi.CreateSubmitRequest(target_url, newparamList);
                string str = newRi.GetResponse(webRequest);
                //MessageBox.Show(str);
                string successMessage = "";
                if (str.Contains("200:OK"))
                {
                    successMessage += "!! BookMark Saved Successfully !!" + "\n";
                    successMessage += "\n" + "Saved Info: " + "\n" + "=========" + "\n";
                    successMessage += "Url: " + lblBrowserURL.Text + "\n";
                    successMessage += "Title: " + txtTitle.Text + "\n";
                    successMessage += "Notes: " + txtNotes.Text + "\n";
                    successMessage += "State: " + selectedState + "\n";
                    successMessage += "Tag(s): ";
                    for (int i = 0; i < selectedTagName.Count; i++)
                    {
                        successMessage += "\t" + selectedTagName[i] + "\n";
                    }
                    MessageBox.Show(successMessage, "Status", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    this.Dispose();

                }

                else
                    MessageBox.Show("Failure: bookmark cannot be saved", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Save Button clicked");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SaveBookmarkForm_Load(object sender, EventArgs e)
        {
            this.txtTitle.TabIndex = 0;
            RestImpl ri = new RestImpl();
            IDictionary<String, String> paramList = new Dictionary<String, String>();
            
            //MessageBox.Show(strResponse);
            try
            {
                string target_url = "http://sgcsoft.net/work/commoncause/admin/commoncause_xml.php";
                HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);
                strResponse = ri.GetXMLResponse(webRequest);
                alertlist = strResponse.GetElementsByTagName("tag");
                foreach( XmlElement element in alertlist)
                {
                    tagid.Add(element.GetAttribute("id"));
                }
                //tagid.ToArray();
                
                int i;
                int total_count = alertlist.Count;

                int LeftX = 86;
                int LeftY = 185;
                int RightX = 300;
                int RightY = 185;

                CheckBox ch = null;
                CheckBox lastCheckBox = null;

                for (i = 0; i < total_count; i++)
                {
                    if (i == 0)
                    {
                        ch = checkbox1;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 1)
                    {
                        ch = checkbox2;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 2)
                    {
                        ch = checkbox3;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 3)
                    {
                        ch = checkbox4;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 4)
                    {
                        ch = checkbox5;
                        
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 5)
                    {
                        ch = checkbox6;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 6)
                    {
                        ch = checkbox7;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 7)
                    {
                        ch = checkbox8;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 8)
                    {
                        ch = checkbox9;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 9)
                    {
                        ch = checkbox10;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 10)
                    {
                        ch = checkbox11;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 11)
                    {
                        ch = checkbox12;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 12)
                    {
                        ch = checkbox13;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 13)
                    {
                        ch = checkbox14;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 14)
                    {
                        ch = checkbox15;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 15)
                    {
                        ch = checkbox16;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 16)
                    {
                        ch = checkbox17;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 17)
                    {
                        ch = checkbox18;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 18)
                    {
                        ch = checkbox19;
                        ch.Text = alertlist.Item(i).InnerText;
                    }
                    else if (i == 19)
                    {
                        ch = checkbox20;
                        ch.Text = alertlist.Item(i).InnerText;
                    }

                    

                    if (i % 2 == 0) 
                    {
                        //LeftY += (i + 1) * 30;
                        if (i > 0)
                            LeftY += 20;

                        ch.Location = new System.Drawing.Point(LeftX, LeftY);
                    }
                    else
                    {
                        //RightY += (i + 1) * 30;
                        if (i > 1)
                            RightY += 20;
                        ch.Location = new System.Drawing.Point(RightX, RightY);
                    }

                    this.Controls.Add(ch);
                    lastCheckBox = ch;
                }

                this.BtnSave.Location = new Point(400, lastCheckBox.Location.Y + 100);
                this.BtnCancel.Location = new Point(500, lastCheckBox.Location.Y + 100);
                this.Controls.Add(BtnSave);
                this.Controls.Add(BtnCancel);

                /*load the state combo box here*/
                target_url = "http://sgcsoft.net/work/commoncause/admin/state_xml.php";
                HttpWebRequest webRequest2 = ri.CreateRequest(target_url, paramList);
                strResponse = ri.GetXMLResponse(webRequest2);
                XmlNodeList stateList = strResponse.GetElementsByTagName("state_name");

                for (int j = 0; j < stateList.Count; j++)
                {
                    this.comboBox1.Items.Add(stateList.Item(j).InnerText);    
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}