using System;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private readonly int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }
        public void Draw()
        {
            double thickness = 0.4;
            double rIn = this.radius - thickness;
            double rOut = this.radius + thickness;

            for (double y = this.radius; y >= -this.radius; y--)
            {
                for (double x = -this.radius; x < rOut; x += 0.5)
                {
                    double point = x * x + y * y;

                    if (point >= rIn * rIn && point <= rOut * rOut)
                    {
                        Console.Write('*');
                    }
                    else Console.Write(' ');
                }

                Console.WriteLine();
            }
        }
    }
}
