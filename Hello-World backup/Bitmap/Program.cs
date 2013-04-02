using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BitmapTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Bitmap bmp = new Bitmap(Bitmap.FromFile("C:/1.bmp"));
			Bitmap clip = Processor.Clip(bmp);
			clip.Save("C:/2.bmp");
			Bitmap threshold = Processor.Threshold(bmp);
			threshold.Save("C:/3.bmp");

			Console.ReadKey();
		}
	}
}
