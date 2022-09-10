using System;

namespace AngryBirds
{
	public static class AngryBirdsTask
	{
		const float G = 9.8f;
		
		// Ниже — это XML документация, её использует ваша среда разработки, 
		// чтобы показывать подсказки по использованию методов. 
		// Но писать её естественно не обязательно.
		/// <param name="v">Начальная скорость</param>
		/// <param name="distance">Расстояние до цели</param>
		/// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
		public static double FindSightAngle(double v, double distance)
		{
			// S = (V^2 * sin2x)/g
			// sin2x = (S * g) / V^2
			// 2x = arcsin((S * g) / V^2)
			// x = arcsin((S * g) / V^2) / 2

			return Math.Asin((distance * G) / (v * v))*0.5;
		}
	}
}