using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace clsDiagnosticTest
{
    /// <summary>
    /// <Author>WDK 2/26/2010</Author>
    /// Base class for diagnostic steps
    /// </summary>
    public partial class ucDiagnosticStep : UserControl
    {
        /// <summary>
        /// x position for pass/fail circle per step in User Control
        /// </summary>
        public const int cxDotPosition = 405;

        /// <summary>
        /// y position for pass/fail circle per step in User Control
        /// </summary>
        public const int cyDotPosition = 3;

        /// <summary>
        /// delegate for step result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EventHandler(Object sender, StepEventArgs e);

        /// <summary>
        /// event for step results
        /// </summary>
        public event EventHandler HandleStepError;

        


        /// <summary>
        /// check if derived UC step checked or not
        /// </summary>
        public bool CheckRunStep
        {
            get { return this.checkBox1.Checked; }
            set { this.checkBox1.Checked = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool bResultVisible
        {
            get { return this.lblResult.Visible; }
            set { this.lblResult.Visible = value; }
        }

        public string strlblResult
        {
            get { return this.lblResult.Text.ToString(); }
            set { this.lblResult.Text = value; }
        }

        public ucDiagnosticStep()
        {
            InitializeComponent();
            stepStatus = StepStatusDisplay.notRun;

        }

        /// <summary>
        /// Possible step results
        /// </summary>
        public enum StepResult
        {
            stepPassed = 0 ,
            stepFailed = 1 ,
            stepUserCancelled = 2 ,
            stepNotSufficientInput = 3 ,
            stepWarning = 4 
        } ;


        /// <summary>
        /// possible display values for UC step
        /// </summary>
        public enum StepStatusDisplay
        {
            notRun = 0,
            passed = 1,
            failed = 2
        } ;


        public void setResultLabel(string lblText)
        {
            this.lblResult.Text = lblText;
            this.lblResult.Visible = true;
        }

        public void hideResultLabel()
        {
            this.lblResult.Visible = false;
        }

        public StepStatusDisplay stepStatus;
        public StepResult stepResult = StepResult.stepFailed;


        /// <summary>
        /// show 'Not Run' step graphics
        /// </summary>
        public virtual void ShowNotRun()
        {
            
            Graphics graphics = this.panel1.CreateGraphics();

            this.Refresh();
            this.Invalidate();
            float circlesize = 20;

            float x = cxDotPosition;
            float y = cyDotPosition;
            graphics.DrawEllipse(new Pen(Brushes.Gray, 3), x, y, circlesize, circlesize);
            lblPassFail.Visible = false;
            this.Invalidate();
            stepStatus = StepStatusDisplay.notRun;
            if (this.stepResult == StepResult.stepUserCancelled)
            {
                lblPassFail.Visible = true;

                lblPassFail.Text = "Canceled";
                this.Invalidate();
            }

            this.Refresh();

        }

        /// <summary>
        /// Show step Pass graphics
        /// </summary>
        /// <returns>true</returns>
        public virtual bool ShowPass()
        {
            Graphics graphics = this.panel1.CreateGraphics();

            this.Refresh();

            float circlesize = 20;

            float x = cxDotPosition;
            float y = cyDotPosition;

            graphics.FillEllipse(new SolidBrush(Color.Green), x, y, circlesize, circlesize);
            graphics.Dispose();

            lblPassFail.Visible = true;
            lblPassFail.Text = "Passed";
            stepStatus = StepStatusDisplay.passed;

            //           myGraphic.DrawEllipse(new Pen(Brushes.Green), cxDotPosition, cyDotPosition, 20, 20);
            return true ;
        }

        /// <summary>
        /// show UC step failure
        /// </summary>
        /// <returns>false</returns>
        public virtual bool ShowFail()
        {
            Graphics graphics = this.panel1.CreateGraphics();

            this.Refresh();

            float circlesize = 20;

            float x = cxDotPosition;
            float y = cyDotPosition;

            graphics.FillEllipse(new SolidBrush(Color.Red), x, y, circlesize, circlesize);
            graphics.Dispose();

            lblPassFail.Visible = true;
            lblPassFail.Text = "Failed";
            stepStatus = StepStatusDisplay.failed;
            OnStepError(new StepEventArgs(this.ToString())) ;
            return false;
        }

        /// <summary>
        /// Handle Step Error event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnStepError(StepEventArgs e)
        {
            if (this.HandleStepError != null)
            {
                this.HandleStepError(this, e);
            }
        }

        /// <summary>
        /// repaint main panel for this step
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = this.panel1.CreateGraphics();

//            this.Refresh();

            float circlesize = 20;

            float x = cxDotPosition;
            float y = cyDotPosition;

            if (stepStatus == StepStatusDisplay.notRun)
            {
                graphics.DrawEllipse(new Pen(Brushes.Gray, 3), x, y, circlesize, circlesize);

                if (stepResult == StepResult.stepUserCancelled)
                {
                    lblPassFail.Visible = true;
                }
                else
                {
                    lblPassFail.Visible = false;
                }
            }
            else
            {
                lblPassFail.Visible = true;

                if (stepStatus == StepStatusDisplay.failed)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Red), x, y, circlesize, circlesize);
                    lblPassFail.Text = "Failed";
                }
                else
                {
                    if (stepStatus == StepStatusDisplay.passed)
                    {
                        
                        graphics.FillEllipse(new SolidBrush(Color.Green), x, y, circlesize, circlesize);
                        lblPassFail.Text = "Passed";
                    }
                    else
                    {

                        graphics.DrawEllipse(new Pen(Brushes.Gray, 3), x, y, circlesize, circlesize);
                        if (this.stepResult == StepResult.stepUserCancelled)
                        {
                            lblPassFail.Visible = true;
                            lblPassFail.Text = "Canceled";
                        }
                        else
                        {
                            lblPassFail.Visible = true;
                            lblPassFail.Text = "Not Run";
                        }
                    }
                }
            }
            graphics.Dispose();

 //           f1_paint(sender, e);
 //             this.panel1.Paint += new PaintEventHandler(f1_paint);

        }

        public virtual StepResult RunTest()
        {
            return StepResult.stepPassed;
        }

        private void ucDiagnosticStep_Load(object sender, EventArgs e)
        {
            stepStatus = StepStatusDisplay.notRun;

//            this.panel1.Paint += new PaintEventHandler(f1_paint);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Click(object sender, EventArgs e)
        {
            MouseEventArgs clickArgs = (MouseEventArgs)e;
            Graphics graphics = panel1.CreateGraphics();

            this.Refresh();

            float circlesize = 20;

            float x = clickArgs.X - circlesize / 2;
            float y = clickArgs.Y - circlesize / 2;
           
            graphics.FillEllipse(new SolidBrush(Color.Green), x, y, circlesize, circlesize);
            graphics.Dispose();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void f1_paint(object sender, PaintEventArgs args)
        {
            Graphics graphics = this.panel1.CreateGraphics();

            this.Refresh();

            float circlesize = 20;

            float x = cxDotPosition;
            float y = cyDotPosition;

            graphics.DrawEllipse(new Pen(Brushes.Gray,3), x, y, circlesize, circlesize);
            graphics.Dispose();
            this.panel1.Paint -= f1_paint;
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }
    }
}
