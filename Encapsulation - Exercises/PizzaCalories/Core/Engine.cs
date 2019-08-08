using PizzaCalories.Models;
using PizzaCalories.Models.Ingridients;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {

            try
            {
                var inputForPizza = Console.ReadLine().Split(" ");
                var inputForDough = Console.ReadLine().Split(" ");
                var dough = new Dough(inputForDough[1], inputForDough[2], double.Parse(inputForDough[3]));

                var pizza = new Pizza(inputForPizza[1], dough);

                string input = Console.ReadLine();
                while (input.ToLower() != "end")
                {
                    var tokens = input.Split(" ");

                     if (tokens[0].ToLower() == "topping")
                     {
                        var topping = new Topping(tokens[1], double.Parse(tokens[2]));

                        pizza.AddTopping(topping);
                     }

                    input = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);

            }

        }
    }
}
