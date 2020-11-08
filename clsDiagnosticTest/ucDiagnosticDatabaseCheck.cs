//////////////////////////////////////////////////////////
///
/// Name: ucDiagnosticDatabaseCheck.cs
/// Author: William Kurth
/// Description: Test 
/// Class:  ucDiagnosticDatabaseCheck
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
using System.Data.SqlClient;
using NetACS; //AS.NET;


namespace clsDiagnosticTest
{
    public partial class ucDiagnosticDatabaseCheck : clsDiagnosticTest.ucDiagnosticStep
    {
        public ucDiagnosticDatabaseCheck()
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
            SqlConnection sqlConnect1;
            string strSqlConnect;
            int iNumberofSubtestLimits= 0;
            int iNumberofBomParts=0;

        //    return base.RunTest();
            try
            {
                strSqlConnect = Properties.Settings.Default.TestDatabase;

                sqlConnect1 = new SqlConnection(strSqlConnect);
                sqlConnect1.Open();
                if (sqlConnect1.State.Equals(ConnectionState.Open))
                {
                    SqlCommand cmdTestDB = sqlConnect1.CreateCommand();
                    cmdTestDB.CommandType = CommandType.StoredProcedure;
                    cmdTestDB.CommandText = "ame_TestSubtestsExist";

                    SqlDataReader sqlRead = cmdTestDB.ExecuteReader();
                    if (sqlRead.Read())
                    {

                        iNumberofSubtestLimits = Int32.Parse(sqlRead[0].ToString()) ;
                        this.setResultLabel("(" + iNumberofSubtestLimits.ToString().Trim() + ")");
                        if (iNumberofSubtestLimits < 10000)
                        {
                            ExplanationForm myForm = new ExplanationForm();

                            myForm.strLabel1 = "Unable to find subtestlimits. ["+ iNumberofSubtestLimits.ToString().Trim()+"]";
                            myForm.strLabel2 = "Contact AME";
                            myForm.ShowDialog();

                            return StepResult.stepFailed;
                        }

                    }
                    
                    string x = sqlRead[0].ToString() ;
                    sqlRead.NextResult();
                    if ( sqlRead.Read())
                    {

                        iNumberofBomParts = Int32.Parse(sqlRead[0].ToString());
                        this.setResultLabel("(" + iNumberofSubtestLimits.ToString().Trim() + ":" + iNumberofBomParts.ToString().Trim() + ")"); 
                        if (iNumberofBomParts < 10)
                        {
                            ExplanationForm myForm = new ExplanationForm();

                            myForm.strLabel1 = "Unable to find BOM parts. [" +iNumberofSubtestLimits.ToString().Trim() +":" +iNumberofBomParts.ToString().Trim()+"]";
                            myForm.strLabel2 = "Contact AME";
                            myForm.ShowDialog();

                            return StepResult.stepFailed;
                        }
                    }
                }

//                Ping ping = new Ping();
//                PingReply pingreply = ping.Send("EDB.ANON.DL.COM");
//                if ( pingreply.Status.Equals())

                return StepResult.stepPassed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +":" + ex.InnerException.Message);
                ExplanationForm myForm = new ExplanationForm();

                myForm.strLabel1 = "Unable to find subtestlimits or BOM parts";
                myForm.strLabel2 = "Contact AME";
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
            this.lblTestName.Size = new System.Drawing.Size(101, 13);
            this.lblTestName.Text = "Database Check";
            // 
            // ucDiagnosticDatabaseCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.bResultVisible = true;
            this.Name = "ucDiagnosticDatabaseCheck";
            this.Load += new System.EventHandler(this.ucDiagnosticDatabaseCheck_Load);
            this.ResumeLayout(false);

        }

        private void ucDiagnosticDatabaseCheck_Load(object sender, EventArgs e)
        {

        }

    }
}
