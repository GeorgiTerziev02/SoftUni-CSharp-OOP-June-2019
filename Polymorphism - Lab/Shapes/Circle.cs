using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double CalculateArea()
        {
            return this.radius * this.radius * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return this.radius * 2 * Math.PI;
        }

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
