using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FujiMedical.Setting.View.WinForms;

namespace HelloWorldWindows
{
    public partial class Form1 : Form
    {
		public Form1()
        {
            InitializeComponent();
		}
		private void labelTest_Click(object sender, EventArgs e)
        {
            labelTest.Text = "Hello World";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			communicationConfigControl1.Location = new Point(0, 300);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			communicationConfigControl1.Location = new Point(300, 300);
		}
    }
}
