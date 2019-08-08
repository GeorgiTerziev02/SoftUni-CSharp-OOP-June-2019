using ShoppingSpree.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
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
                    throw new ArgumentException(ExceptionMessages.NameException);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.MoneyException);
                }

                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (this.Money - product.Cost >= 0)
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");

                this.Money -= product.Cost;
                this.products.Add(product);
            }
            else
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.CannotAfforAProductException, this.Name, product.Name));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if(this.products.Count==0)
            {
                sb.AppendLine($"{this.Name} - Nothing bought");
            }
            else
            {
                sb.AppendLine($"{this.Name} - {string.Join(", ", this.products)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
