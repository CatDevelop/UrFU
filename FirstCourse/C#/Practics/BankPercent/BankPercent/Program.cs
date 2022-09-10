using System;

namespace BankPercent
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            double endSum = Calculate(userInput);
            Console.WriteLine(endSum);
        }
        
        /// <param name="userInput">Строка, введённая пользователем
        /// (исходная сумма, процентная ставка (в %) и срок вклада (в месяцах)</param> 
        /// <returns>Накопившаяся сумма на момент окончания вклада</returns>
        public static double Calculate(string userInput)
        {
            // Sn = (1+p/100)^n * S
            // Sn - сумма через n лет
            // p - процентная ставка
            // S - изначальная сумма
            
            string[] inputs = userInput.Split(' ');
            
            double initialSum = double.Parse(inputs[0], System.Globalization.CultureInfo.InvariantCulture);
            double percents = double.Parse(inputs[1], System.Globalization.CultureInfo.InvariantCulture);
            int depositTermMonths = int.Parse(inputs[2]);
            
            double endSum = Math.Pow((1 + percents / (100 * 12)), depositTermMonths) * initialSum;
            
            return endSum;
        }
    }
}