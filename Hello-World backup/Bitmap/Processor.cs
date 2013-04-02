using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace BitmapTest
{
	class Processor
	{
		public static Bitmap Clip(Bitmap original)
		{
			int width = original.Width;
			int height = original.Height;
			Bitmap bmp = new Bitmap(width/2, height/2);

			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.DrawImageUnscaledAndClipped(original, new Rectangle(0, 0, width / 2, height / 2));
			}
			return bmp;
		}

		public static Bitmap Threshold(Bitmap original)
		{
			int width = original.Width;
			int height = original.Height;
			Bitmap bmp = new Bitmap(width, height);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				ImageAttributes threshold = new ImageAttributes();
				threshold.SetThreshold(0.92f);
				//attributes.SetThreshold(0.08f);

				g.DrawImage(original, new Rectangle(0, 0, width, height),
					0, 0, width, height, GraphicsUnit.Pixel, threshold);

				ImageAttributes invert = new ImageAttributes();
				ColorMap[] map = new ColorMap[2];
				map[0] = new ColorMap();
				map[0].OldColor = Color.Black;
				map[0].NewColor = Color.White;
				map[1] = new ColorMap();
				map[1].OldColor = Color.White;
				map[1].NewColor = Color.Black;
				invert.SetRemapTable(map);

				g.DrawImage(bmp, new Rectangle(0, 0, width, height),
					0, 0, width, height, GraphicsUnit.Pixel, invert);
			}
			return bmp;
		}
	}
}
