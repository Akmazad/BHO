using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Xml;
using System.Net;


namespace mktoolbarRegistryTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                XmlElement element = (XmlElement)list.Item(0);


                if (key.GetValue("mktoolbar_Version").ToString().Equals(element.InnerText))
                {
                    try
                    {
                        object oEmpty = String.Empty;

                        //Explorer.Navigate("http://www.commoncause.org/browserdonate", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
                        InternetExplorer newWindow = new InternetExplorer();
                        newWindow.Visible = true;
                        newWindow.Navigate("http://www.commoncause.org/browserdonate", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                
                timer1.Enabled = false;

            }
            catch (Exception ex)
            {
                timer1.Enabled = false;
                MessageBox.Show(ex.ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey key;
            try
            {
                Registry.LocalMachine.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects\\mktoolbar");
                
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt = 
        }
    }
}