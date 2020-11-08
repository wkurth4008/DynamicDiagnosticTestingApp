namespace clsDiagnosticTest
{
    partial class ucDiagnosticStep
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblTestName = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPassFail = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Perform Test";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestName.Location = new System.Drawing.Point(95, 7);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(80, 13);
            this.lblTestName.TabIndex = 1;
            this.lblTestName.Text = "Generic Test";
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(212, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(186, 29);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "label1";
            this.lblResult.Visible = false;
            this.lblResult.Click += new System.EventHandler(this.lblResult_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblPassFail);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.lblResult);
            this.panel1.Controls.Add(this.lblTestName);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 33);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // lblPassFail
            // 
            this.lblPassFail.AutoSize = true;
            this.lblPassFail.Location = new System.Drawing.Point(431, 10);
            this.lblPassFail.Name = "lblPassFail";
            this.lblPassFail.Size = new System.Drawing.Size(30, 13);
            this.lblPassFail.TabIndex = 4;
            this.lblPassFail.Text = "Pass";
            // 
            // ucDiagnosticStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucDiagnosticStep";
            this.Size = new System.Drawing.Size(492, 46);
            this.Load += new System.EventHandler(this.ucDiagnosticStep_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        public  System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPassFail;
    }
}
