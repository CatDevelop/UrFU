using System.Drawing;
using System;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		const double Angle45 = Math.PI * 45 / 180;
		const double Angle135 = Math.PI * 135 / 180;

		private static Tuple<double, double> ChangeCoordinates(double curX, double curY, double angle, int offset)
		{
			var newX = (curX * Math.Cos(angle) - curY * Math.Sin(angle)) / Math.Sqrt(2) + offset;
			var newY = (curX * Math.Sin(angle) + curY * Math.Cos(angle)) / Math.Sqrt(2);
			return Tuple.Create(newX, newY); 
		}
		
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
			var curX = 1.0;
			var curY = 0.0;

			var random = new Random(seed);

			for (var i = 0; i < iterationsCount; i++)
			{
				// Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз)
				// Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу)
				if (random.Next(2) == 0)
					(curX, curY) = ChangeCoordinates(curX, curY, Angle45, 0);
				else
					(curX, curY) = ChangeCoordinates(curX, curY, Angle135, 1);
				
				pixels.SetPixel(curX, curY);
			}
		}
	}
}