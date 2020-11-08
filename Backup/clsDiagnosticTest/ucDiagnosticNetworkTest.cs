using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using ACSEE.NET;


namespace clsDiagnosticTest
{
    public partial class ucDiagnosticNetworkTest : clsDiagnosticTest.ucDiagnosticStep
    {
        public ucDiagnosticNetworkTest()
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
            string strFullIP ="";
            try
            {
                foreach (  string strIP in Properties.Settings.Default.NetworkAddress )
                {
                    Ping ping = new Ping() ;
                    strFullIP = strIP;
                    this.setResultLabel("(" + strIP.Trim() + ")");
                    PingReply pingReply = ping.Send(strIP) ;
                    {
                        if (!pingReply.Status.Equals(IPStatus.Success))
                        {
                            ExplanationForm myForm = new ExplanationForm();

                            myForm.strLabel1 = "Failed to PING [" + strIP +"]";
                            myForm.strLabel2 = "Contact your IT department";
                            myForm.ShowDialog();

                            return StepResult.stepFailed ;
                        }
                    }
                }
//                Ping ping = new Ping();
//                PingReply pingreply = ping.Send("ENGACSDB.ENG.PSCNET.COM");
//                if ( pingreply.Status.Equals())

                return StepResult.stepPassed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +":" + ex.InnerException.Message);

                ExplanationForm myForm = new ExplanationForm();

                myForm.strLabel1 = "Failed to PING [ " + strFullIP + "]" ;
                myForm.strLabel2 = "Contact your IT department";
                myForm.ShowDialog();
                
                return StepResult.stepFailed;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // lblTestName
            // 
            this.lblTestName.Size = new System.Drawing.Size(71, 13);
            this.lblTestName.Text = "Network Test";
            // 
            // ucDiagnosticNetworkTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ucDiagnosticNetworkTest";
            this.ResumeLayout(false);

        }

    }
}
