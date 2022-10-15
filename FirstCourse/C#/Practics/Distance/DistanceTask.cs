using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		/// <param name="ax">Кооридната X точки А</param>
		/// <param name="ay">Кооридната Y точки А</param>
		/// <param name="bx">Кооридната X точки Б</param>
		/// <param name="by">Кооридната Y точки Б</param> 
		/// <returns>Расстояние от точки А до точки Б</returns>
		private static double GetDistanceToPoint(double ax, double ay, double bx, double by)
		{
			// Расстояние от точки A(ax, ay) до точки B(bx, by)
			// d = sqrt( (x1-x2)^2 + (y1-y2)^2 )
			return Math.Sqrt((bx - ax) * (bx - ax) + (by - ay) * (by - ay));
		}
		
		/// <param name="a">Первое число с плавающей точкой для сравнения</param>
		/// <param name="b">Второе число с плавающей точкой для сравнения</param> 
		/// <returns>Равное ли первое число второму</returns>
		private static bool IsEqualDouble(double a, double b)
		{
			return Math.Abs(a - b) < 1e-9;
		}
		
		/// <param name="ax">Кооридната X начала отрезка AB</param>
		/// <param name="ay">Кооридната Y начала отрезка AB</param>
		/// <param name="bx">Кооридната X конца отрезка AB</param>
		/// <param name="by">Кооридната Y конца отрезка AB</param>
		/// <param name="x">Кооридната X точки С</param>
		/// <param name="y">Кооридната Y точки С</param>
		/// <returns>Расстояние от точки C(x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)</returns>
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			var lengthSegmentBC = GetDistanceToPoint(x, y, bx, by);
			var lengthSegmentAC = GetDistanceToPoint(x, y, ax, ay);
			var lengthSegmentAB = GetDistanceToPoint(ax, ay, bx, by);

			// Находим площадь череp полупериметр
			// S = sqrt(p(p-a)(p-b)(p-c))
			// p = (a+b+c)/2
			var p = (lengthSegmentBC+lengthSegmentAC+lengthSegmentAB)/ 2;
			var square = Math.Sqrt(p * (p - lengthSegmentBC) * (p - lengthSegmentAC) * (p - lengthSegmentAB));

			var squareBC = lengthSegmentBC * lengthSegmentBC;
			var squareAB = lengthSegmentAB * lengthSegmentAB;
			var squareAC = lengthSegmentAC * lengthSegmentAC;
			
			if (IsEqualDouble(ax, bx) && IsEqualDouble(ay, by)) 
				return GetDistanceToPoint(x, y, ax, ay); // Не отрезок, а точка 
			else if (IsEqualDouble(lengthSegmentAB, lengthSegmentBC + lengthSegmentAC)) 
				return 0; // точка на отрезке
			else if (squareBC + squareAB < squareAC || squareAC + squareAB < squareBC) 
				return Math.Min(lengthSegmentBC, lengthSegmentAC); // Тупоугольный треугольник
			return (2 * square) / lengthSegmentAB;
		}
	}
}