//////////////////////////////////////////////////////////
///
/// Name: ucDiagnosticUserQuestions.cs
/// Author: William Kurth
/// Description: Test 
/// Class:  ucDiagnosticUserQuestions
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
using NetACS; //ASEE.NET;


namespace clsDiagnosticTest
{
    public partial class ucDiagnosticUserQuestions : clsDiagnosticTest.ucDiagnosticStep
    {
        public ucDiagnosticUserQuestions()
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
            DialogResult dResult;
        //    return base.RunTest();
            try
            {
                int iIndex = 0;
                foreach (string strQuestion in Properties.Settings.Default.UserQuestions)
                {
                    this.setResultLabel("(" + strQuestion.Trim() + ")");
                    dResult = MessageBox.Show(strQuestion, strQuestion, MessageBoxButtons.YesNo);
                    if (!(dResult == DialogResult.Yes))
                    {
                        //                Ping ping = new Ping();
                        //                PingReply pingreply = ping.Send("EDB.ANON.DL.COM");
                        //                if ( pingreply.Status.Equals())

                        string strDirection = Properties.Settings.Default.UserDirections[iIndex];
                        ExplanationForm myForm = new ExplanationForm();

                        myForm.strLabel1 = strQuestion;
                        myForm.strLabel2 = strDirection;

                        myForm.ShowDialog();

                        return StepResult.stepFailed;
                    }
                    iIndex++;
                }
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
            this.lblTestName.Size = new System.Drawing.Size(79, 13);
            this.lblTestName.Text = "User Questions";
            // 
            // ucDiagnosticUserQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ucDiagnosticUserQuestions";
            this.ResumeLayout(false);

        }

    }
}
