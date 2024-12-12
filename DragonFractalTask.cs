using System;

namespace Fractals
{
    internal static class DragonFractalTask
    {
        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            var point = (x: 1.0, y: 0.0);
            var random = new Random(seed);
            for (int i = 0; i < iterationsCount; i++)
            {
                var angle = GetRandomAngle(random);
                point = TransformPoint(point.x, point.y, angle);
                pixels.SetPixel(point.x, point.y);
            }
        }

        private static (double x, double y) TransformPoint(double x, double y, double angle)
        {
            var cos = Math.Cos(angle) / Math.Sqrt(2);
            var sin = Math.Sin(angle) / Math.Sqrt(2);
            var newX = x * cos - y * sin;
            var newY = x * sin + y * cos;
            if (angle > Math.PI / 2)
                newX += 1;
            return (newX, newY);
        }

        private static double GetRandomAngle(Random random)
        {
            return random.Next(1, 3) == 1 ? Math.PI / 4 : Math.PI * 3 / 4;
        }
    }
}
