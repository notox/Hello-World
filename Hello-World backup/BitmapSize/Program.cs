using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ImageMagickNET;

namespace BitmapSize
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				//Bitmap b = new Bitmap(10000, 10000);
				//b.Save("c:/1.png");
				//b.Dispose();
				//GC.Collect();

				//Console.ReadLine();

				//Image b2 = Bitmap.FromFile("c:/1.png");

				Image image = new Image("c:/1.png");
				Geometry g = new Geometry(100, 100, 0, 0, false, false);
				image.Resize(g);
				image.Write("c:/2.png");
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Console.ReadLine();
		}
	}
}
