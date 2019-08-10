namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Drinks.Entities;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Foods.Entities;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using SoftUniRestaurant.Models.Tables.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private readonly List<IFood> menu;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;
        private decimal totalIncome;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            totalIncome = 0;
        }
        public string AddFood(string type, string name, decimal price)
        {
            IFood food = null;
            switch (type)
            {
                case "Dessert":
                    food = new Dessert(name, price);
                    break;
                case "MainCourse":
                    food = new MainCourse(name, price);
                    break;
                case "Salad":
                    food = new Salad(name, price);
                    break;
                case "Soup":
                    food = new Soup(name, price);
                    break;
            }

            menu.Add(food);

            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = null;

            switch (type)
            {
                case "Alcohol":
                    drink = new Alcohol(name, servingSize, brand);
                    break;
                case "FuzzyDrink":
                    drink = new FuzzyDrink(name, servingSize, brand);
                    break;
                case "Juice":
                    drink = new Juice(name, servingSize, brand);
                    break;
                case "Water":
                    drink = new Water(name, servingSize, brand);
                    break;
            }

            this.drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            switch (type)
            {
                case "Inside":
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case "Outside":
                    table = new OutsideTable(tableNumber, capacity);
                    break;
            }

            this.tables.Add(table);

            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = this.tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if (freeTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                freeTable.Reserve(numberOfPeople);
                return $"Table {freeTable.TableNumber} has been reserved for {numberOfPeople} people";
            }

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IFood foodToFind = this.menu.FirstOrDefault(x => x.Name == foodName);

            if (foodToFind == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(foodToFind);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IDrink drinkToFind = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (drinkToFind == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drinkToFind);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            StringBuilder result = new StringBuilder();

            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            result.AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {table.GetBill():f2}");
            totalIncome += table.GetBill();

            table.Clear();

            return result.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            var freeTables = this.tables.Where(x => x.IsReserved == false).ToList();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            var reservedTables = this.tables.Where(x => x.IsReserved == true).ToList();

            foreach (var table in reservedTables)
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {totalIncome:f2}lv";
        }
    }
}
