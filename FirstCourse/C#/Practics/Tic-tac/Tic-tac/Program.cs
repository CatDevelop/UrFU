using System;
namespace Tic_tac
{
    internal class Program
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        public static void Main()
        {
            Run("XXX OO. ...");
            Run("OXO XO. .XO");
            Run("OXO XOX OX.");
            Run("XOX OXO OXO");
            Run("... ... ...");
            Run("XXX OOO ...");
            Run("XOO XOO XX.");
            Run(".O. XO. XOX");
        }

        private static bool IsWin(Mark[,] field, Mark check)
        {
            // По строкам и столбцам
            for (var i = 0; i < 3; i++)
                if ((field[i, 0] == check && field[i, 1] == check && field[i, 2] == check) 
                    || (field[0, i] == check && field[1, i] == check && field[2, i] == check))
                    return true;
            // По диагонали 
            return (field[0, 0] == check && field[1, 1] == check && field[2, 2] == check)
                    || (field[2, 0] == check && field[1, 1] == check && field[0, 2] == check);
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            if (IsWin(field, Mark.Circle) && !IsWin(field, Mark.Cross)) return GameResult.CircleWin;
            if (IsWin(field, Mark.Cross) && !IsWin(field, Mark.Circle)) return GameResult.CrossWin;
            return GameResult.Draw;
        }


        private static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
            for (var y = 0; y < field.Length; y++)
                ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }
    }
}