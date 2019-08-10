using StorageMaster.Contracts;
using StorageMaster.Exceptions;
using System;

namespace StorageMaster.Models.Products
{
    public abstract class Product : IProduct
    {
        private double price;
        public Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if(value<0)
                {
                    throw new InvalidOperationException(ExceptionMessages.NegativePriceException);
                }

                this.price = value;
            }
        }

        public double Weight { get; private set; }
    }
}
