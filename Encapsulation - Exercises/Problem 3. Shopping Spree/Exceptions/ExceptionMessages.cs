using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Exceptions
{
    public static class ExceptionMessages
    {
        public static string NameException = "Name cannot be empty";

        public static string MoneyException = "Money cannot be negative";

        public static string CannotAfforAProductException = "{0} can't afford {1}";
    }
}
