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

namespace CommonCause.BHO
{
    [ComVisible(true)]
    [Guid("FD970ED5-3EDA-438d-BFFD-715931E2775B")]
    [ClassInterface(ClassInterfaceType.None)]

    class CommonCauseBHO:IObjectWithSite
    {
        #region Fields
        //private InternetExplorer explorer;
        //SHDocVw.WebBrowser explorer;
        //System.Windows.Forms.WebBrowser browser;
        public InternetExplorer explorer;
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
                //CommonCause cs = new CommonCause();
                MessageBox.Show("sdfsdfsdfsdf");
                //explorer.DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(;
                //explorer.DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(cs.loadTags);
                //explorer.BeforeNavigate2+=new DWebBrowserEvents2_BeforeNavigate2EventHandler(this.loadTag);
            }
            else
            {
                //explorer.DocumentComplete -= new DWebBrowserEvents2_DocumentCompleteEventHandler(this.OnDocumentComplete);
                //explorer.DocumentComplete -= new DWebBrowserEvents2_DocumentCompleteEventHandler(this.OnDocumentComplete);
                explorer = null;
            }
        }
        
        public void GetSite(ref Guid guid, out Object ppvSite)
        {
            
            IntPtr punk = Marshal.GetIUnknownForObject(explorer);
            ppvSite = new object();
            IntPtr ppvSiteIntPtr = Marshal.GetIUnknownForObject(ppvSite);
            int hr = Marshal.QueryInterface(punk, ref guid, out ppvSiteIntPtr);
            Marshal.Release(punk);
        }
        #endregion

        public void ShowBrowserBar(bool bShow)
        {
            object pvaClsid = (object)(new Guid("2097F0AC-9A04-46c3-9E97-2DB319F36CF1").ToString("B"));
            object pvarShow = (object)bShow;
            object pvarSize = null;

            if (bShow) /* hide Browser bar before showing to prevent erroneous behavior of IE*/
            {
                object pvarShowFalse = (object)false;
                explorer.ShowBrowserBar(ref pvaClsid, ref pvarShowFalse, ref pvarSize);
            }
            explorer.ShowBrowserBar(ref pvaClsid, ref pvarShow, ref pvarSize);
            
        }
    }
}
