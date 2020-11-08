using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace clsDiagnosticTest
{
    public partial class InputDialogBox : Form
    {
        string formCaption = string.Empty;
        string formPrompt = string.Empty;
        string inputResponse = string.Empty;
        string defaultValue = string.Empty;


        public string Caption
        {
            get { return this.Text.ToString() ;}
            set { this.Text = value ;}
        }


        public string Prompt
        {
            get { return this.lblPrompt.Text.ToString(); }
            set { this.lblPrompt.Text = value; }
        }

        public string Response
        {
            get { return this.txtInput.Text.ToString() ; }
            set { this.txtInput.Text = value; }
        }

        public enum inputresponse
        {
            OK=0,
            CANCEL=1
        } ;


        private inputresponse myResponse = inputresponse.OK ;

        public inputresponse exitOK
        {
            get { return myResponse; }
            set { myResponse = value; }
        }

        public InputDialogBox()
        {
            InitializeComponent();
        }

        private void InputDialogBox_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            myResponse = inputresponse.CANCEL;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            myResponse = inputresponse.OK;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                myResponse = inputresponse.OK;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void InputDialogBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult.Equals(DialogResult.Cancel))
            {
                myResponse = inputresponse.CANCEL;
            }

        }
    }
}
