using PizzaCalories.ExceptionMessages;
using PizzaCalories.Models.Ingridients.DoughModifiers;
using System;

namespace PizzaCalories.Models.Ingridients
{
    public class Dough
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 200;

        private const double DefaultDoughCalories = 2;


        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (!(value.ToLower() == "white" || value.ToLower() == "wholegrain"))
                {
                    throw new ArgumentException(ExceptionMessage.InvalidTypeOfDoughException);
                }

                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (!(value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade"))
                {
                    throw new ArgumentException(ExceptionMessage.InvalidTypeOfDoughException);
                }

                this.bakingTechnique = value;
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
                    throw new ArgumentException(ExceptionMessage.DoughWeightOutOfRangeException);
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double total = this.Weight * DefaultDoughCalories;

            double flourTypeModifier = 1;
            double bakingTechniqueModifier = 1;

            switch (this.FlourType.ToLower())
            {
                case "white": flourTypeModifier = DoughModifier.WhiteModifier; break;
                case "wholegrain": flourTypeModifier = DoughModifier.WholegrainModifier; break;
            }

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy": bakingTechniqueModifier = DoughModifier.CrispyModifier; break;
                case "chewy": bakingTechniqueModifier = DoughModifier.ChewyModifier; break;
                case "homemade": bakingTechniqueModifier = DoughModifier.HomemadeModifier; break;
            }

            total = total * flourTypeModifier * bakingTechniqueModifier;

            return total;
        }
    }
}
