namespace HelloWorldWindows
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
			this.labelTest = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.communicationConfigControl1 = new FujiMedical.Setting.View.WinForms.CommunicationConfigControl();
			this.userControl11 = new HelloWorldWindows.UserControl1();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTest
			// 
			this.labelTest.AutoSize = true;
			this.labelTest.Location = new System.Drawing.Point(12, 9);
			this.labelTest.Name = "labelTest";
			this.labelTest.Size = new System.Drawing.Size(35, 13);
			this.labelTest.TabIndex = 0;
			this.labelTest.Text = "label1";
			this.labelTest.Click += new System.EventHandler(this.labelTest_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(66, 60);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(182, 157);
			this.panel1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.button2);
			this.panel2.Location = new System.Drawing.Point(60, 88);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(101, 37);
			this.panel2.TabIndex = 1;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(18, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 0;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(49, 41);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel3
			// 
			this.panel3.Location = new System.Drawing.Point(28, 185);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(18, 64);
			this.panel3.TabIndex = 2;
			// 
			// communicationConfigControl1
			// 
			this.communicationConfigControl1.Location = new System.Drawing.Point(505, 372);
			this.communicationConfigControl1.Name = "communicationConfigControl1";
			this.communicationConfigControl1.Size = new System.Drawing.Size(423, 163);
			this.communicationConfigControl1.TabIndex = 3;
			// 
			// userControl11
			// 
			this.userControl11.Location = new System.Drawing.Point(126, 38);
			this.userControl11.Name = "userControl11";
			this.userControl11.Size = new System.Drawing.Size(572, 497);
			this.userControl11.TabIndex = 4;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(953, 609);
			this.Controls.Add(this.userControl11);
			this.Controls.Add(this.communicationConfigControl1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.labelTest);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTest;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button button2;
		private FujiMedical.Setting.View.WinForms.CommunicationConfigControl communicationConfigControl1;
		private UserControl1 userControl11;
    }
}

