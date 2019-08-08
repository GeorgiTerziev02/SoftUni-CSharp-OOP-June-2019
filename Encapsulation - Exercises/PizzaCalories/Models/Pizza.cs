using PizzaCalories.ExceptionMessages;
using PizzaCalories.Models.Ingridients;
using System;
using System.Collections.Generic;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException(ExceptionMessage.InvalidPizzaNameException);
                }

                this.name = value;
            }
        }

        private Dough Dough
        {
            get
            {
                return this.dough;
            }
            set
            {
                this.dough = value;
            }

        }

        public int ToppingsCount
        {
            get => this.toppings.Count;
        }

        public void AddTopping(Topping topping)
        {
            if (this.ToppingsCount + 1 > 10)
            {
                throw new ArgumentException(ExceptionMessage.ToppingsCountException);
            }

            else toppings.Add(topping);
        }

        public double GetTotalCalories()
        {
            double total = 0;

            total += this.Dough.GetCalories();

            if (this.ToppingsCount > 0)
            {
                foreach (var topping in this.toppings)
                {
                    total += topping.GetCalories();
                }
            }

            return total;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetTotalCalories():f2} Calories.";
        }
    }
}
