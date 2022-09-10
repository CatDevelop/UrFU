namespace Pluralize
{
	public static class PluralizeTask
	{
		/// <param name="count">Количество рублей</param> 
		/// <returns>Склонённое существительное «рублей», следующее за указанным числительным</returns>
		public static string PluralizeRubles(int count)
		{
			int lastDigit = count % 10;
			int lastTwoDigits = count % 100;
			
			if (lastTwoDigits > 10 && lastTwoDigits < 15) return "рублей";
			else if (lastDigit == 1) return "рубль";
			else if (lastDigit > 1 && lastDigit < 5) return "рубля";
			else return "рублей";
		}
	}
}