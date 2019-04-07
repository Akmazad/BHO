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


namespace CommonCause
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

        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            MessageBox.Show("CommonCause Plugin has been installed succesfully!");
        }
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            try
            {
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}