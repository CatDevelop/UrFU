using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		/// <param name="r1">Первый прямоугольник</param>
		/// <param name="r2">Второй прямоугольник</param>
		/// <returns>Прямоугольник, образованный пересечением данных
		/// (Может иметь отрицательную ширину или высоту,
		/// если изначальные прямоугольники не пересекаются) </returns>
		private static Rectangle CreateIntersectionSquare(Rectangle r1, Rectangle r2)
		{
			var left = Math.Max(r1.Left, r2.Left);
			var top = Math.Max(r1.Top, r2.Top);
			var right = Math.Min(r1.Left+r1.Width, r2.Left+r2.Width);
			var bottom = Math.Min(r1.Top+r1.Height, r2.Top+r2.Height);
			return new Rectangle(left, top, right - left, bottom - top);
		}
		
		/// <param name="r1">Первый прямоугольник</param>
		/// <param name="r2">Второй прямоугольник</param>
		/// <returns>Пересекаются ли данные прямоугольники </returns>
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			var r3 = CreateIntersectionSquare(r1, r2);
			return r3.Width >= 0 && r3.Height >= 0;
		}
		
		/// <param name="r1">Первый прямоугольник</param>
		/// <param name="r2">Второй прямоугольник</param>
		/// <returns>Площадь пересечения данных прямоугольников </returns>
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (!AreIntersected(r1, r2))
				return 0;
			
			var r3 = CreateIntersectionSquare(r1, r2);
			return r3.Width * r3.Height;
		}

		/// <param name="r1">Первый прямоугольник</param>
		/// <param name="r2">Второй прямоугольник</param>
		/// <returns>Находится ли целиком второй прямоугольник в первом</returns>
		private static bool IsInnerRectangle(Rectangle r1, Rectangle r2)
		{
			return r1.Left <= r2.Left
			       && r1.Left + r1.Width >= r2.Left + r2.Width
			       && r1.Top <= r2.Top
			       && r1.Top + r1.Height >= r2.Top + r2.Height;
		}
		
		/// <param name="r1">Первый прямоугольник</param>
		/// <param name="r2">Второй прямоугольник</param>
		/// <returns>Номер (с нуля) внутреннего прямоугольника,
		/// если один из прямоугольников целиком находится внутри другого,
		/// иначе -1</returns>
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			if (IsInnerRectangle(r1, r2))
				return 1;
			if (IsInnerRectangle(r2, r1))
				return 0;
			return -1;
		}
	}
}