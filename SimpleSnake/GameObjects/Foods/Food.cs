using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private Wall wall;
        private char foodSymbol;
        private Random random;

        public Food(Wall wall, char foodSymbol, int points) 
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = this.random.Next(2, wall.LeftX - 2);
            this.TopY = this.random.Next(2, wall.TopY - 2);

            bool isPointOnSnake = snakeElements
                .Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);

            while (isPointOnSnake)
            {
                this.LeftX = this.random.Next(2, wall.LeftX - 2);
                this.TopY = this.random.Next(2, wall.TopY - 2);

                isPointOnSnake = snakeElements
                .Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;
        }
    }
}
