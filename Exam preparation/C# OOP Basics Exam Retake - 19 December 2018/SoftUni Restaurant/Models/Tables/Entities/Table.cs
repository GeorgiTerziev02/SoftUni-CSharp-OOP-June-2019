using SoftUniRestaurant.Exceptions;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.Entities
{
    public abstract class Table : ITable
    {
        private readonly List<IFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            IsReserved = false;
        }

        public IReadOnlyCollection<IFood> FoodOrders => this.foodOrders.AsReadOnly();

        public IReadOnlyCollection<IDrink> DrinkOrders => this.drinkOrders.AsReadOnly();

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegativeOrZeroException);
                }

                this.capacity = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.PeopleCountNegativeOrZeroException);
                }

                this.numberOfPeople = value;
            }
        }

        public bool IsReserved { get; private set; }

        public decimal Price
        {
            get
            {
                return this.PricePerPerson * this.NumberOfPeople;
            }
        }

        public void Reserve(int numberOfPeople)
        {
            if (numberOfPeople <= this.Capacity)
            {
                IsReserved = true;
                this.NumberOfPeople = numberOfPeople;
            }
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal totalPrice = Price;

            foreach (var food in this.foodOrders)
            {
                totalPrice += food.Price;
            }

            foreach (var drink in this.drinkOrders)
            {
                totalPrice += drink.Price;
            }

            return totalPrice;
        }

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.numberOfPeople = 0;
            IsReserved = false;
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");

            if (foodOrders.Count == 0)
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");

                foreach (var food in foodOrders)
                {
                    sb.AppendLine(food.ToString());
                }
            }

            if (drinkOrders.Count == 0)
            {
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");

                foreach (var drink in drinkOrders)
                {
                    sb.AppendLine(drink.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {this.Capacity}")
                .AppendLine($"Price per Person: {this.PricePerPerson}");


            return sb.ToString().TrimEnd();
        }
    }
}
