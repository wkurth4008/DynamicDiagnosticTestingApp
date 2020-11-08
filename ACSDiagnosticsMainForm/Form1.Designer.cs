namespace ACSDiagnosticsMainForm
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.runButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkUnCheckButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(149, 12);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(160, 25);
            this.runButton.TabIndex = 2;
            this.runButton.Text = "Run Diagnostics";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(435, 26);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(12, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 239);
            this.panel1.TabIndex = 4;
            // 
            // checkUnCheckButton
            // 
            this.checkUnCheckButton.Enabled = false;
            this.checkUnCheckButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkUnCheckButton.Location = new System.Drawing.Point(12, 53);
            this.checkUnCheckButton.Name = "checkUnCheckButton";
            this.checkUnCheckButton.Size = new System.Drawing.Size(56, 20);
            this.checkUnCheckButton.TabIndex = 5;
            this.checkUnCheckButton.Text = "UnCheck All";
            this.checkUnCheckButton.UseVisualStyleBackColor = true;
            this.checkUnCheckButton.Click += new System.EventHandler(this.checkUnCheckButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 321);
            this.Controls.Add(this.checkUnCheckButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.runButton);
            this.Name = "Form1";
            this.Text = "ACS Diagnostics";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button checkUnCheckButton;
    }
}

