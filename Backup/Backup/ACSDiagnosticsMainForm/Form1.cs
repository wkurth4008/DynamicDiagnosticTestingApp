using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using clsDiagnosticTest;
using System.Reflection;


namespace ACSDiagnosticsMainForm
{
    /// <summary>
    /// <Author>WDK 2/4/10</Author>
    /// Main form containing User Control Diagnostics
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// List of steps (UC's)
        /// </summary>
        public List<diagnosticStepInfo> mySteps;


        ucDiagnosticStep StepPing;
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Main Form load
        /// get list of steps from app.config and display on main panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            int i;
            Type ucType;
            Assembly CurrentAssembly = Assembly.LoadFrom("clsDiagnosticTest.dll");

            ucDiagnosticStep StepTest = new ucDiagnosticStep();
            mySteps =  new List<diagnosticStepInfo>() ;
            diagnosticStepInfo myStep;
            i = 0;

            /// <c>
            /// loop through al configured steps and 
            /// add to panel and list of steps
            /// </c>
            foreach ( string s in Properties.Settings.Default.debugsteps)
            {
                i++;
                myStep = new diagnosticStepInfo();
                string myString = s;
                ucType = CurrentAssembly.GetType(s);

                StepPing = (ucDiagnosticStep)(Activator.CreateInstance(ucType));
                myStep.objMyStep = StepPing;
                myStep.strStepName = myString;
                myStep.order = i;
                StepPing.HandleStepError += new ucDiagnosticStep.EventHandler(this.HandleStepError);
                StepPing.Left = 2;
                StepPing.Top = StepPing.Height * (i - 1) + 5;
                StepPing.CheckRunStep = true;
                this.panel1.Controls.Add(StepPing);
                mySteps.Add(myStep);
//                StepTest = new ucDiagnosticStep
            }

            button3.Enabled = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// event handler for step errors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleStepError(object sender, StepEventArgs e)
        {
            MessageBox.Show("Error in Step:" + e.strStepName);
        }

        /// <summary>
        /// Loop through all tests(steps) and execute   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
//            StepPing.ShowPass();
            ucDiagnosticStep.StepResult myResult = ucDiagnosticStep.StepResult.stepFailed;


            /// <summary> 
            /// loop through diagnostic steps
            /// </summary>
            foreach (diagnosticStepInfo aStep in mySteps)
            {
                aStep.objMyStep.ShowNotRun();
            }

            foreach ( diagnosticStepInfo aStep in mySteps )
            {
                if (aStep.objMyStep.CheckRunStep == true)
                {
                    myResult = aStep.objMyStep.RunTest() ;
                    aStep.objMyStep.stepResult = myResult;
                    if (myResult == ucDiagnosticStep.StepResult.stepPassed)
                    {
                        aStep.objMyStep.ShowPass();
                    }
                    else
                    {
                        if (myResult == ucDiagnosticStep.StepResult.stepFailed)
                        {
                            aStep.objMyStep.ShowFail();
                            break;
                        }
                        else
                        {
                            if (myResult == ucDiagnosticStep.StepResult.stepUserCancelled)
                            {
                                aStep.objMyStep.ShowNotRun();

                            }
                        }
                    }
                }
            }
            if (myResult != ucDiagnosticStep.StepResult.stepFailed)
            {
                ExplanationForm myform = new ExplanationForm();
                myform.strLabel1 = "No Problems Found through this diagnostic tool!";
                myform.strLabel2 = "Contact IT or AME for further investigation if problem still persists.";
                myform.ShowDialog();
            }
        }


        /// <summary>
        /// check or uncheck all steps check boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;

            if (button3.Text.Equals("Check All"))
            {
                foreach (diagnosticStepInfo aStep in mySteps)
                {
                    aStep.objMyStep.CheckRunStep = true;
                }
                button3.Text = "UnCheck All";
            }
            else
            {
                foreach (diagnosticStepInfo aStep in mySteps)
                {
                    aStep.objMyStep.CheckRunStep =false;
                }
                button3.Text = "Check All";
            }

            button3.Enabled = true;
        }
    }

    public class testclass
    {
        public void test()
        {
        }
    }
}
