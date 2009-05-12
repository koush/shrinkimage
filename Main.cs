// Main.cs created with MonoDevelop
// User: koush at 14:03 05/12/2009
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using System.Drawing;

namespace shrinkimage
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string input;
			string output;
			float scale;
			
			if (args.Length == 3)
			{
				input = args[1];
				output = args[2];
			}
			else if (args.Length == 2)
			{
				input = output = args[1];
			}
			else
			{
				Console.WriteLine("shrinkimage percent%|max_dimension input [output]");
				return;
			}

			Bitmap bitmap = new Bitmap(input);
			if (args[0].EndsWith("%"))
			{
				scale = float.Parse(args[0].Trim('%')) / 100;
			}
			else
			{
				int maxdim = int.Parse(args[0]);
				int bitmapMax = Math.Max(bitmap.Width, bitmap.Height);
				if (bitmapMax > maxdim)
					scale = (float)maxdim / (float)bitmapMax;
				else
					scale = 1;
			}

			Bitmap outputBitmap  = new Bitmap(bitmap.GetThumbnailImage((int)(scale * bitmap.Width), (int)(scale * bitmap.Height), null, IntPtr.Zero));
			outputBitmap.Save(output);
		}
	}
}