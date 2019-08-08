using PizzaCalories.ExceptionMessages;
using PizzaCalories.Models.Ingridients.ToppingModifiers;
using System;

namespace PizzaCalories.Models.Ingridients
{
    public class Topping
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 50;

        private const double DefaultToppingCalories = 2;

        private double weight;
        private string type;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "sauce" && value.ToLower() != "cheese" && value.ToLower() != "veggies")
                {
                    throw new ArgumentException(string.Format(ExceptionMessage.InvalidToppingException, value));
                }
                this.type = value;
            }
        }

        private double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException(string.Format(ExceptionMessage.ToppingWeightOutOfRangeException, this.Type));
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double total = this.Weight * DefaultToppingCalories;
            double toppingModifier = 1;

            switch (this.Type.ToLower())
            {
                case "meat": toppingModifier = ToppingModifier.MeatModifier; break;
                case "cheese": toppingModifier = ToppingModifier.CheeseModifier; break;
                case "veggies": toppingModifier = ToppingModifier.VeggiesModifier; break;
                case "sauce": toppingModifier = ToppingModifier.SauceModifier; break;
            }

            total = total * toppingModifier;

            return total;
        }
    }
}
