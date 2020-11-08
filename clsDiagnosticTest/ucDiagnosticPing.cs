//////////////////////////////////////////////////////////
///
/// Name: ucDiagnosticPing.cs
/// Author: William Kurth
/// Description: Test 
/// Class:  ucDiagnosticAccessFiles
/// Base Class: clsDiagnosticPing.ucDiagnosticStep
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
using NetACS; //ASEE.NET;
using System.Configuration;

namespace clsDiagnosticTest
{
    /// <summary>
    /// <Author>WDK 2/5/10</Author>
    /// derived UC class
    /// for Database Ping
    /// </summary>
    public partial class ucDiagnosticPing : clsDiagnosticTest.ucDiagnosticStep
    {
        public ucDiagnosticPing()
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

        /// <summary>
        /// overridden RunTest to do actual test
        /// </summary>
        /// <returns>StepResult enum - pass, fail, skip</returns>
        public override StepResult RunTest()
        {

            string strDBName = Properties.Settings.Default.DatabaseName;

                

        //    return base.RunTest();
            try
            {
                this.setResultLabel("(" + strDBName + ")");
                Ping ping = new Ping();
                PingReply pingreply = ping.Send(strDBName);
//                if ( pingreply.Status.Equals())
//                ExplanationForm myform = new ExplanationForm();
              
//                myform.ShowDialog();
                if (!(pingreply.Status == IPStatus.Success))
                {
                    ExplanationForm myForm = new ExplanationForm();

                    myForm.strLabel1 = "Failed to PING the Database Server:[" + strDBName +"]";
                    myForm.strLabel2 = "Contact your IT department";
                    myForm.ShowDialog();
                    return StepResult.stepFailed;
                }
                return StepResult.stepPassed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +":" + ex.InnerException.Message);
                ExplanationForm myForm = new ExplanationForm();

                myForm.strLabel1 = "Failed to PING the Database Server:" + strDBName;
                myForm.strLabel2 = "Contact your IT department";
                myForm.ShowDialog();
                return StepResult.stepFailed;
            }
        }

    }
}
