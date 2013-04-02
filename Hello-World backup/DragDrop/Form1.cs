using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DragDrop
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void label1_MouseDown(object sender, MouseEventArgs e)
		{
			this.DoDragDrop(label1.Text, DragDropEffects.Move);
		}



		private void textBox1_DragDrop(object sender, DragEventArgs e)
		{
			string test = e.Data.GetData(DataFormats.Text) as string;
			textBox1.Text = test;
		}

		private void textBox1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.Move;
			}
		}
	}
}
