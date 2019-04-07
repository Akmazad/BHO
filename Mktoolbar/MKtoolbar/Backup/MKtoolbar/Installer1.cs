using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Deployment.Internal;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MKtoolbar
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            
            versionAction();
            base.Install(stateSaver);
            try
            {
                RegistrationServices regasm = new RegistrationServices();
                //bool bResult = regAsm.RegisterAssembly(this.GetType().Assembly,AssemblyRegistrationFlags.SetCodeBase);
                bool bresult = regasm.RegisterAssembly(this.GetType().Assembly, AssemblyRegistrationFlags.SetCodeBase);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void versionAction()
        {
            /*read registry values to check for update*/
            writeVersionNumber("0.2");
            /*if new version then request to url to get updated version number*/
            /*or browse to another new page*/
            /* write/update new version number to registry*/
        }

        private void writeVersionNumber(string _versionNo)
        {
            RegistryKey key;
            string mainKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects\\mktoolbar";
            key = Registry.LocalMachine.OpenSubKey(mainKey);

            if (key == null)
            {
                key = Registry.LocalMachine.CreateSubKey(mainKey);
            }
            key.SetValue("InstallationDate", DateTime.Now);
            key.SetValue("mktoolbar_Version", _versionNo);
            key.Close();
        }

        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            MessageBox.Show("MKtool Plugin has been installed succesfully!");
        }
        public override void Uninstall(IDictionary savedState)
        {
            /*delete version number from registry*/
            try
            {
                Registry.LocalMachine.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects\\mktoolbar");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            base.Uninstall(savedState);
            try
            {
                RegistrationServices regasm = new RegistrationServices();
                //bool bResult = regAsm.RegisterAssembly(this.GetType().Assembly,AssemblyRegistrationFlags.SetCodeBase);
                bool bresult = regasm.UnregisterAssembly(this.GetType().Assembly);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}