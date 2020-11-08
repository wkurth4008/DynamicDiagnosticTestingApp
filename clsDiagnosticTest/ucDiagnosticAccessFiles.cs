//////////////////////////////////////////////////////////
///
/// Name: ucDiagnosticAccessFiles.cs
/// Author: William Kurth
/// Description: Test 
/// Class:  ucDiagnosticAccessFiles
/// Base Class: clsDiagnosticTest.ucDiagnosticStep
/// Notes:
/// 


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using NetACS; //AS.NET;


namespace clsDiagnosticTest
{
    public partial class ucDiagnosticAccessFiles : clsDiagnosticTest.ucDiagnosticStep
    {
        public ucDiagnosticAccessFiles()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public override bool ShowFail()
        {
            MessageBox.Show("Step Failed");
            return base.ShowFail();
        }


        public override StepResult RunTest()
        {
        //    return base.RunTest();
            try
            {
                Ping ping = new Ping();
                PingReply pingreply = ping.Send("EDB.ANON.DL.COM");
//                if ( pingreply.Status.Equals())

                return StepResult.stepPassed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +":" + ex.InnerException.Message);
                return StepResult.stepFailed;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // lblTestName
            // 
            this.lblTestName.Size = new System.Drawing.Size(66, 13);
            this.lblTestName.Text = "Access files ";
            // 
            // ucDiagnosticAccessFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ucDiagnosticAccessFiles";
            this.ResumeLayout(false);

        }

    }
}
