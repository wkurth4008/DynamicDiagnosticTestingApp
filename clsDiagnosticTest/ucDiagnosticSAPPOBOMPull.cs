//////////////////////////////////////////////////////////
///
/// Name: ucDiagnosticSAPPOBOMPull.cs
/// Author: William Kurth
/// Description: Test 
/// Class:  ucDiagnosticSAPPOBOMPull
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
using NetACS; //AS.NET;
using System.Xml;
using ACSEE.NET;

namespace clsDiagnosticTest
{
    public partial class ucDiagnosticSAPPOBOMPull : clsDiagnosticTest.ucDiagnosticStep
    {
        public ucDiagnosticSAPPOBOMPull()
        {
            InitializeComponent();
        }

        private void ucDiagnosticSAPPOBOMPull_Load(object sender, EventArgs e)
        {

        }

        public override bool ShowFail()
        {
            MessageBox.Show("Step Failed");
            return base.ShowFail();
        }

        public override StepResult RunTest()
        {
            SAPXML mySAPXML;
            SAPPost sp;
            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList oNodes;
            XmlNode aNode;
            int qty;
            string strAddress;
            DataTable myTable;
            int iRows;



            clsDiagnosticTest.InputDialogBox ib = new InputDialogBox();

            ib.Caption = "Enter a Production Order";
            ib.Prompt = "Enter the valid Production Order number ( or a valid Production Order)";
            ib.Response = "";
            ib.ShowDialog();
            if (ib.exitOK == InputDialogBox.inputresponse.OK)
            {
                string strProdOrder = (string)ib.Response.ToString().Clone();
                string strlongProdOrder ; // = String.Format("{000000000000}", strProdOrder.Trim());
                strlongProdOrder = strProdOrder.PadLeft(12, '0');


                ib.Close();
                this.setResultLabel("(" + strlongProdOrder.Trim() + ")");
                /*            clsDiagnosticTest.InputDialogBox ib = new clsDiagnosticTest.InputDialogBox();



                ib.FormPrompt = "Enter aNode Production OrderedEnumerableRowCollection";
                ib.FormCaption = "Test Production Order";
                ib.DefaultValue = "000600001234";
                ib.ShowDialog();
                string s = ib.InputResponse;
                */

                try
                {

                    sp = new SAPPost("ZC_SEND_PODAT_AS");
                    sp.setProperty("AUFNR", strlongProdOrder);
                    //           sp.setProperty("VALID_FROM", strDateTimeholder);
                    //           sp.setProperty("VALID_TO", strDateTimeholder);


                    //                string strAddress = HomeAddress;   //+ "/sap/PRD/default.asp";
                    strAddress = "http://home/sap/PRD/default.asp";
                    mySAPXML = sp.Post(strAddress);
                    xmlDoc = mySAPXML.getXDOC();


                    myTable = mySAPXML.getDataTable("PODAT_AS");
                    iRows = myTable.Rows.Count;

                    if (iRows < 2)
                    {
                        MessageBox.Show("Error getting BOM for PO - call IT");
                        
                        ExplanationForm myForm = new ExplanationForm();

                        myForm.strLabel1 = "Failed to get BOM for Production Order =[" + strlongProdOrder +"]";
                        myForm.strLabel2 = "Contact your IT department";
                        myForm.ShowDialog();


                        return StepResult.stepFailed;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Got BOMPull exception=" + ex.Message);
                    return StepResult.stepFailed;
                }


                try
                {
                    sp = new SAPPost("ZC_SEND_POSERIALDATA_AS");
                    sp.setProperty("AUFNR", strlongProdOrder);
                    //           sp.setProperty("VALID_FROM", strDateTimeholder);
                    //           sp.setProperty("VALID_TO", strDateTimeholder);


                    //                string strAddress = HomeAddress;   //+ "/sap/PRD/default.asp";
                    //            strAddress = "http://home/sap/PRD/default.asp";
                    mySAPXML = sp.Post(strAddress);
                    xmlDoc = mySAPXML.getXDOC();


                    myTable = mySAPXML.getDataTable("ZSERIALNR_AS");
                    iRows = myTable.Rows.Count;

                    if (iRows < 2)
                    {
                        MessageBox.Show("Error getting Serials for production order.  Contact IT");
                        ExplanationForm myForm = new ExplanationForm();

                        myForm.strLabel1 = "Failed to get Serial Numbers for Production Order=[" + strlongProdOrder+"]";
                        myForm.strLabel2 = "Contact your IT department";
                        myForm.ShowDialog();

                        return StepResult.stepFailed;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Got serial number pull error=" + ex.Message);
                    return StepResult.stepFailed;
                }
            }
            else
            {
                return StepResult.stepUserCancelled;
            }
            return StepResult.stepPassed;
        }
    }
}
