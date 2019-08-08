namespace PizzaCalories.ExceptionMessages
{
    public static class ExceptionMessage
    {
        public static string InvalidTypeOfDoughException = "Invalid type of dough.";

        public static string DoughWeightOutOfRangeException = "Dough weight should be in the range [1..200].";

        public static string ToppingWeightOutOfRangeException = "{0} weight should be in the range [1..50].";

        public static string InvalidToppingException = "Cannot place {0} on top of your pizza.";

        public static string InvalidPizzaNameException = "Pizza name should be between 1 and 15 symbols.";

        public static string ToppingsCountException = "Number of toppings should be in range [0..10].";
    }
}
