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
			double a = GetDistanceToPoint(x, y, bx, by); // BC
			double b = GetDistanceToPoint(x, y, ax, ay); // AC
			double c = GetDistanceToPoint(ax, ay, bx, by); // AB

			double p = (a+b+c)/ 2;
			double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
			
			if (IsEqualDouble(ax, bx) && IsEqualDouble(ay, by)) 
				return GetDistanceToPoint(x, y, ax, ay); // Не отрезок, а точка 
			else if (IsEqualDouble(c, a + b)) 
				return 0; // точка на отрезке
			else if (a * a + c * c < b * b ||  b * b + c * c < a * a ) 
				return Math.Min(a, b); // Тупоугольный треугольник
			else return (2*s)/ c;
		}
	}
}