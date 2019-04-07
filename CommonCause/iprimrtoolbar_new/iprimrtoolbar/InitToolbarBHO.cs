using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using SHDocVw;
using BandObjectLib;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Generic;

using mshtml;
//using System.web;

namespace iprimrtoolbar
{
	/// <summary>
	/// Registration:
	/// This is a browser helper object, which is registered as a COM When we register the 
	/// SearchBar.dll using the regasm command.
	/// Loading:
	/// This COM object loaded for each IE window. As a window is created, it creates its own copy of the BHO; 
	/// and, when that window is closed, it destroys its copy of the BHO
	/// Purpose of implementing this BHO:
	/// It loads the toolbar when this BHO is instantiated.
	/// Code Reference: http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=509297&SiteID=1
	/// </summary>
	[ComVisible(true)]
	[Guid("1D970ED5-3EDA-438d-BFFD-715931E2775B")]
	[ClassInterface(ClassInterfaceType.None)]
	public class InitToolbarBHO : IObjectWithSite
	{
		#region Fields
		//private InternetExplorer explorer;
		//SHDocVw.WebBrowser explorer;
        //System.Windows.Forms.WebBrowser browser;
        private InternetExplorer explorer;
        //private WebBrowser explorer;

		private const string BHOKeyName = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects";
		#endregion

		#region Com Register/UnRegister Methods
		/// <summary>
		/// Called, when IE browser starts.
		/// </summary>
		/// <param name="t"></param>
		[ComRegisterFunction]
		public static void RegisterBHO(Type t)
		{
			RegistryKey key = Registry.LocalMachine.OpenSubKey(BHOKeyName, true);
			if (key == null)
			{
				key = Registry.LocalMachine.CreateSubKey(BHOKeyName);
			}
            string guidString = t.GUID.ToString("B");
			RegistryKey bhoKey = key.OpenSubKey(guidString, true);

			if (bhoKey == null)
			{
				bhoKey = key.CreateSubKey(guidString);
			}

			// NoExplorer:dword = 1 prevents the BHO to be loaded by Explorer
			string _name = "NoExplorer";
			object _value = (object)1;
			bhoKey.SetValue(_name, _value);
			key.Close();
			bhoKey.Close();
		}

		/// <param name="t"></param>
		[ComUnregisterFunction]
		public static void UnregisterBHO(Type t)
		{
			RegistryKey key = Registry.LocalMachine.OpenSubKey(BHOKeyName, true);
			string guidString = t.GUID.ToString("B");
			if (key != null)
			{
				key.DeleteSubKey(guidString, false);
			}
		}
		#endregion

		#region IObjectWithSite Members
		/// <summary>
		/// Called, when the BHO is instantiated and when it is destroyed.
		/// </summary>
		/// <param name="site"></param>
		public void SetSite(Object site)
		{
            if (site != null)
            {
                //explorer = (InternetExplorer)site;
                //ShowBrowserBar(true);
                
                /*mind it */
                explorer = (InternetExplorer)site;
                explorer.DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(this.OnDocumentComplete);
                //explorer.DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(this.OnDocumentComplete);
                //browser.BeforeNavigate2+=new DWebBrowserEvents2_BeforeNavigate2EventHandler(this.OnBeforeNavigate2);
            }
            else
            {
                explorer.DocumentComplete -= new DWebBrowserEvents2_DocumentCompleteEventHandler(this.OnDocumentComplete);
                //explorer.DocumentComplete -= new DWebBrowserEvents2_DocumentCompleteEventHandler(this.OnDocumentComplete);
                explorer = null;
            }
		}

		public void GetSite(ref Guid guid, out Object ppvSite)
		{
			IntPtr punk = Marshal.GetIUnknownForObject(explorer);
			ppvSite = new object();
			IntPtr ppvSiteIntPtr =  Marshal.GetIUnknownForObject(ppvSite);
			int hr = Marshal.QueryInterface(punk, ref guid, out ppvSiteIntPtr);
			Marshal.Release(punk);
		}
		#endregion

		#region Helper Methods

        public void OnDocumentComplete(object pDisp, ref object URL)
		{

            
            //HtmlDocument doc = (HtmlDocument)explorer.Document;
            ////HtmlElementCollection body_content = doc.GetElementById("body");
            //HtmlElement dd = (HtmlElement)explorer.Document;
            //HtmlElementCollection body_content = dd.GetElementsByTagName("body");
            //doc.
            
            //doc.CreateElement(

            //if(URL.ToString().IndexOf("amazon.com")!=-1)
            //{
            //    Regex rg = new Regex("/^https?:\/\/\w+\.amazon\..+\/gp\/product\/([a-zA-Z0-9]{10})\/.*/");
            //    rg.IsMatch(URL.ToString());

            //    string ss = URL.ToString();
            //    MessageBox.Show(URL.ToString());
            //    //ShowBrowserBar(true);
            //}
            //else
            //{
            //    //ShowBrowserBar(false);
            //}
            //MessageBox.Show("Event fired - " + e.Url.ToString());
            if (Regex.IsMatch(URL.ToString(), @"^https?:\/\/\w+\.amazon\..+\/gp\/product\/([a-zA-Z0-9]{10})\/.*"))
            {
                string url_string = URL.ToString();
                string ASIN_ID = new string(url_string.ToCharArray(url_string.IndexOf("product/") + 8, 10));

                string PLID = "AZ" + ASIN_ID;

                string target_url = "http://pluribo.com/xhr/id/" + PLID + "/plugin";

                //essageBox.Show(target_url);

                RestImpl ri = new RestImpl();
                IDictionary<String, String> paramList = new Dictionary<String, String>();

                HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);
                String strResponse = ri.GetResponse(webRequest);


                try
                {
                    //MessageBox.Show(strResponse);

                    //IHTMLDocument2 doc = new HTMLDocumentClass();
                    //doc = (IHTMLDocument2)AxWebBrowser1.Document;
                    
                    //foreach(IHTMLElement2 element in doc.all)
                    //{
                    //    //my processing goes here.
                       
                    //}

                    //System.Windows.Forms.WebBrowser wb = new System.Windows.Forms.WebBrowser();
                    
                    
                    //mshtml.HTMLDocumentClass doc = (mshtml.HTMLDocumentClass)explorer.Document;


                    //HtmlDocument doc = (HtmlDocument)explorer.Document;
                    //HtmlElement newdiv = doc.CreateElement("div");
                    
                    IHTMLDocument2 doc = new HTMLDocumentClass();
                    doc = (IHTMLDocument2)explorer.Document;
                    doc.body.innerHTML = strResponse + doc.body.innerHTML;
                    
                    
                    //doc = (IHTMLDocument2)explorer.Document;
                    //MessageBox.Show(doc.body.id);

                    //IHTMLElement newdiv = doc.createElement("div");
                    //newdiv.setAttribute("id", "pluribo_div", 1);
                    
                    //IHTMLElement nnnn = new HTMLElementCollectionClass();
                    //nnnn = (IHTMLElement)doc.createElement("div");
                    
                    
                    
                    //newdiv.SetAttribute("id", "pluribo_div");
                    
                    //newdiv.innerHTML = strResponse;

                    //IHTMLDocument3 doc1 = new HTMLDocumentClass();
                    //doc1 = (IHTMLDocument3)explorer.Document;
                    
                    //IHTMLElementCollection body_contents = doc1.getElementsByTagName("body");
                    //IHTMLElementCollection BODY_CONTENTS = new HTMLElementCollectionClass();
                    //BODY_CONTENTS = (IHTMLElementCollection)doc1.getElementsByTagName("body");
                    //IHTMLElement body = new HtmlElement();
                    //body = (IHTMLElement2)body_contents;

                    //IHTMLElement body = 
                    //body.AppendChild(newdiv);
                    
                    
                }
                catch (Exception et)
                {
                    MessageBox.Show(et.ToString());
                }
                finally
                {
                    //MessageBox.Show("DONE!!!!","MESSage");
                }

                
            }
            else if (Regex.IsMatch(URL.ToString(), @"^https?:\/\/\w+\.amazon\..+\/dp\/([a-zA-Z0-9]{10})\/.*"))
            {
                string url_string = URL.ToString();

                string ASIN_ID = new string(url_string.ToCharArray(url_string.IndexOf("dp/") + 3, 10));

                string PLID = "AZ" + ASIN_ID;

                string target_url = "http://pluribo.com/xhr/id/" + PLID + "/plugin";

                //MessageBox.Show(target_url);

                RestImpl ri = new RestImpl();
                IDictionary<String, String> paramList = new Dictionary<String, String>();

                HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);
                String strResponse = ri.GetResponse(webRequest);


                try
                {
                    //MessageBox.Show(strResponse);

                    IHTMLDocument2 doc = new HTMLDocumentClass();
                    doc = (IHTMLDocument2)explorer.Document;
                    doc.body.innerHTML = "<div id=\"pluribo_div\">" + strResponse + "</div>" + doc.body.innerHTML;

                }
                catch (Exception et)
                {
                    MessageBox.Show(et.ToString());
                }
                finally
                {
                    //MessageBox.Show("DONE!!!!", "MESSage");
                }

            }
            else if (Regex.IsMatch(URL.ToString(), @"^https?:\/\/\w+\.amazon\..+\/exec\/obidos\/ASIN\/([a-zA-Z0-9]{10})\/.*"))
            {
                string url_string = URL.ToString();
                string ASIN_ID = new string(url_string.ToCharArray(url_string.IndexOf("ASIN/") + 5, 10));

                string PLID = "AZ" + ASIN_ID;

                string target_url = "http://pluribo.com/xhr/id/" + PLID + "/plugin";

                //MessageBox.Show(target_url);

                RestImpl ri = new RestImpl();
                IDictionary<String, String> paramList = new Dictionary<String, String>();

                try
                {

                    //WebClient eb = new WebClient();
                    //String htmlcode = eb.DownloadString(url_string);

                    //MessageBox.Show(htmlcode);

                    
                    
                    //HtmlDocument doc = (HtmlDocument)explorer.Document;

                    HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);
                    String strResponse = ri.GetResponse(webRequest);
                    //MessageBox.Show(strResponse);

                    IHTMLDocument2 doc = new HTMLDocumentClass();
                    doc = (IHTMLDocument2)explorer.Document;
                    doc.body.innerHTML = "<div id=\"pluribo_div\">" + strResponse + "</div>" + doc.body.innerHTML;

                    /*dsfasdfdsfs*/
                    
                    
                }
                catch (Exception et)
                {
                    MessageBox.Show(et.ToString());
                }
                finally
                {
                    //MessageBox.Show("DONE!!!!", "MESSage");
                }

            }
            else if (Regex.IsMatch(URL.ToString(), @"^https?:\/\/\w+\.amazon\..+\/review\/product\/([a-zA-Z0-9]{10})\/.*"))
            {
                string url_string = URL.ToString();
                string ASIN_ID = new string(url_string.ToCharArray(url_string.IndexOf("product/") + 8, 10));

                string PLID = "AZ" + ASIN_ID;

                string target_url = "http://pluribo.com/xhr/id/" + PLID + "/plugin";

                //MessageBox.Show(target_url);

                RestImpl ri = new RestImpl();
                IDictionary<String, String> paramList = new Dictionary<String, String>();


                try
                {
                    HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);
                    String strResponse = ri.GetResponse(webRequest);
                    //MessageBox.Show(strResponse);

                    IHTMLDocument2 doc = new HTMLDocumentClass();
                    doc = (IHTMLDocument2)explorer.Document;
                    doc.body.innerHTML = "<div id=\"pluribo_div\">" + strResponse + "</div>" + doc.body.innerHTML;
                }
                catch (Exception et)
                {
                    MessageBox.Show(et.ToString());
                }
                finally
                {
                    //MessageBox.Show("DONE!!!!", "MESSage");
                }

            }
		}


		public void OnBeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
		{
            //HtmlDocument doc = (HtmlDocument)explorer.Document;
            ////HtmlElementCollection body_content = doc.GetElementById("body");
            //HtmlElement dd = (HtmlElement)explorer.Document;
            //HtmlElementCollection body_content = dd.GetElementsByTagName("body");
            //doc.

            //doc.CreateElement(

            //if(URL.ToString().IndexOf("amazon.com")!=-1)
            //{
            //    Regex rg = new Regex("/^https?:\/\/\w+\.amazon\..+\/gp\/product\/([a-zA-Z0-9]{10})\/.*/");
            //    rg.IsMatch(URL.ToString());

            //    string ss = URL.ToString();
            //    MessageBox.Show(URL.ToString());
            //    //ShowBrowserBar(true);
            //}
            //else
            //{
            //    //ShowBrowserBar(false);
            //}
            if (Regex.IsMatch(URL.ToString(), @"^https?:\/\/\w+\.amazon\..+\/gp\/product\/([a-zA-Z0-9]{10})\/.*"))
            {
                string url_string = URL.ToString();
                string ASIN_ID = new string(url_string.ToCharArray(url_string.IndexOf("product/") + 8, 10));

                string PLID = "AZ" + ASIN_ID;

                string target_url = "http://pluribo.com/xhr/id/" + PLID + "/plugin";

                MessageBox.Show(target_url);

                RestImpl ri = new RestImpl();
                IDictionary<String, String> paramList = new Dictionary<String, String>();

                HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);
                String strResponse = ri.GetResponse(webRequest);

                MessageBox.Show(strResponse);

                try
                {
                    HtmlDocument doc = (HtmlDocument)explorer.Document;
                    HtmlElement newdiv = doc.CreateElement("div");
                    newdiv.SetAttribute("id", "pluribo_div");
                    newdiv.InnerHtml = strResponse;
                    HtmlElementCollection body_contents = doc.GetElementsByTagName("body");
                    HtmlElement body = body_contents[0];
                    body.AppendChild(newdiv);
                }
                catch (Exception et)
                {
                    MessageBox.Show(et.ToString());
                }
                finally
                {
                    MessageBox.Show("DONE!!!!", "MESSage");
                }


            }
            else if (Regex.IsMatch(URL.ToString(), @"^https?:\/\/\w+\.amazon\..+\/dp\/([a-zA-Z0-9]{10})\/.*"))
            {
                string url_string = URL.ToString();
                string ASIN_ID = new string(url_string.ToCharArray(url_string.IndexOf("dp/") + 3, 10));

                string PLID = "AZ" + ASIN_ID;

                string target_url = "http://pluribo.com/xhr/id/" + PLID + "/plugin";

                MessageBox.Show(target_url);

                RestImpl ri = new RestImpl();
                IDictionary<String, String> paramList = new Dictionary<String, String>();

                HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);
                String strResponse = ri.GetResponse(webRequest);

                MessageBox.Show(strResponse);

                try
                {
                    HtmlDocument doc = (HtmlDocument)explorer.Document;
                    HtmlElement newdiv = doc.CreateElement("div");
                    newdiv.SetAttribute("id", "pluribo_div");
                    newdiv.InnerHtml = strResponse;
                    HtmlElementCollection body_contents = doc.GetElementsByTagName("body");
                    HtmlElement body = body_contents[0];
                    body.AppendChild(newdiv);
                }
                catch (Exception et)
                {
                    MessageBox.Show(et.ToString());
                }
                finally
                {
                    MessageBox.Show("DONE!!!!", "MESSage");
                }

            }
            else if (Regex.IsMatch(URL.ToString(), @"^https?:\/\/\w+\.amazon\..+\/exec\/obidos\/ASIN\/([a-zA-Z0-9]{10})\/.*"))
            {
                string url_string = URL.ToString();
                string ASIN_ID = new string(url_string.ToCharArray(url_string.IndexOf("ASIN/") + 5, 10));

                string PLID = "AZ" + ASIN_ID;

                string target_url = "http://pluribo.com/xhr/id/" + PLID + "/plugin";

                MessageBox.Show(target_url);

                RestImpl ri = new RestImpl();
                IDictionary<String, String> paramList = new Dictionary<String, String>();

                try
                {
                    HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);
                    String strResponse = ri.GetResponse(webRequest);

                    MessageBox.Show(strResponse);
                    HtmlDocument doc = (HtmlDocument)explorer.Document;
                    HtmlElement newdiv = doc.CreateElement("div");
                    newdiv.SetAttribute("id", "pluribo_div");
                    newdiv.InnerHtml = strResponse;
                    HtmlElementCollection body_contents = doc.GetElementsByTagName("body");
                    HtmlElement body = body_contents[0];
                    body.AppendChild(newdiv);
                }
                catch (Exception et)
                {
                    MessageBox.Show(et.ToString());
                }
                finally
                {
                    MessageBox.Show("DONE!!!!", "MESSage");
                }

            }
            else if (Regex.IsMatch(URL.ToString(), @"^https?:\/\/\w+\.amazon\..+\/review\/product\/([a-zA-Z0-9]{10})\/.*"))
            {
                string url_string = URL.ToString();
                string ASIN_ID = new string(url_string.ToCharArray(url_string.IndexOf("product/") + 8, 10));

                string PLID = "AZ" + ASIN_ID;

                string target_url = "http://pluribo.com/xhr/id/" + PLID + "/plugin";

                MessageBox.Show(target_url);

                RestImpl ri = new RestImpl();
                IDictionary<String, String> paramList = new Dictionary<String, String>();

                HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);
                String strResponse = ri.GetResponse(webRequest);

                try
                {
                    MessageBox.Show(strResponse);
                    HtmlDocument doc = (HtmlDocument)explorer.Document;
                    HtmlElement newdiv = doc.CreateElement("div");
                    newdiv.SetAttribute("id", "pluribo_div");
                    newdiv.InnerHtml = strResponse;
                    HtmlElementCollection body_contents = doc.GetElementsByTagName("body");
                    HtmlElement body = body_contents[0];
                    body.AppendChild(newdiv);
                }
                catch (Exception et)
                {
                    MessageBox.Show(et.ToString());
                }
                finally
                {
                    MessageBox.Show("DONE!!!!", "MESSage");
                }

            }
        }

		public void ShowBrowserBar(bool bShow)
		{
			object pvaClsid = (object)(new Guid("1097F0AC-9A04-46c3-9E97-2DB319F36CF1").ToString("B"));
			object pvarShow = (object)bShow;
			object pvarSize = null;
        
			if (bShow) /* hide Browser bar before showing to prevent erroneous behavior of IE*/
			{
				object pvarShowFalse = (object)false;
				//explorer.ShowBrowserBar(ref pvaClsid, ref pvarShowFalse, ref pvarSize);
			}
			//explorer.ShowBrowserBar(ref pvaClsid, ref pvarShow, ref pvarSize);
		}
		#endregion
	}
}

