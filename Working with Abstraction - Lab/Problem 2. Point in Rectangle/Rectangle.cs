namespace Problem2.PointinRectangle
{
    public class Rectangle
    {
        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }
        public bool Contains(Point point)
        {
            bool InsideByX = point.CoordinateX >= this.TopLeft.CoordinateX
                && point.CoordinateX <= this.BottomRight.CoordinateX;

            bool InsideByY = point.CoordinateY >= this.TopLeft.CoordinateY
                && point.CoordinateY <= this.BottomRight.CoordinateY;

            return InsideByX && InsideByY;
        }
    }
}
