using SoftUniRestaurant.Exceptions;
using SoftUniRestaurant.Models.Foods.Contracts;
using System;

namespace SoftUniRestaurant.Models.Foods.Entities
{
    public abstract class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;

        public Food(string name, int servingSize, decimal price)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpaceException);
                }

                this.name = value;
            }
        }

        public int ServingSize
        {
            get
            {
                return this.servingSize;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.ServingSizeNegativeOrZeroException);
                }

                this.servingSize = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.PriceNegativeOrZeroException);
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.ServingSize}g - {this.Price:f2}";
        }
    }
}
