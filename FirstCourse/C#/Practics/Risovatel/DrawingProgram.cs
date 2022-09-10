using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Painter
    {
        static float _x, _y;
        static Graphics _graphicsController;

        public static void Initialize (Graphics newGraphic)
        {
            _graphicsController = newGraphic;
            _graphicsController.SmoothingMode = SmoothingMode.None;
            _graphicsController.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            _x = x0; 
            _y = y0;
        }

        public static void DrawLine(Pen pen, double length, double angle)
        {
            //Делает шаг длиной length в направлении angle и рисует пройденную траекторию
            var endX = (float)(_x + length * Math.Cos(angle));
            var endY = (float)(_y + length * Math.Sin(angle));
            _graphicsController.DrawLine(pen, _x, _y, endX, endY);
            _x = endX;
            _y = endY;
        }

        public static void ChangePosition(double length, double angle)
        {
            _x = (float)(_x + length * Math.Cos(angle)); 
            _y = (float)(_y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        private const float SideRatio = 0.375f;
        private const float DiagonalRatio = 0.04f;
        private static void DrawSection(Pen color, float size, double angle)
        {
            Painter.DrawLine(color, size * SideRatio, angle);
            Painter.DrawLine(color, size * DiagonalRatio * Math.Sqrt(2), angle + Math.PI / 4);
            Painter.DrawLine(color, size * SideRatio, angle + Math.PI);
            Painter.DrawLine(color, size * SideRatio - size * DiagonalRatio, angle + Math.PI / 2);

            Painter.ChangePosition(size * DiagonalRatio, angle - Math.PI);
            Painter.ChangePosition(size * DiagonalRatio * Math.Sqrt(2), angle + 3 * Math.PI / 4);
        }
        
        public static void Draw(int width, int height, double angleRotation, Graphics graphicsController)
        {
            // angleRotation пока не используется, но будет использоваться в будущем
            Painter.Initialize(graphicsController);

            var size = Math.Min(width, height);
            var color = Pens.Yellow;

            var diagonalLength = Math.Sqrt(2) * (size * SideRatio + size * 0.04f) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Painter.SetPosition(x0, y0);

            DrawSection(color, size, 0);
            DrawSection(color, size, -Math.PI / 2);
            DrawSection(color, size, Math.PI);
            DrawSection(color, size, Math.PI / 2);
        }
    }
}