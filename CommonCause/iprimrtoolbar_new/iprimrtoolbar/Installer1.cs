using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;


namespace iprimrtoolbar
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver) 
        {
            base.Install(stateSaver);
            System.Windows.Forms.MessageBox.Show("We are done!!!!!!");
        }
    }
}
