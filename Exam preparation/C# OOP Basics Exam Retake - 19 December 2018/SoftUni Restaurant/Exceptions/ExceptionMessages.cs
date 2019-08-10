namespace SoftUniRestaurant.Exceptions
{
    public static class ExceptionMessages
    {
        public static string NameNullOrWhiteSpaceException = "Name cannot be null or white space!";

        public static string ServingSizeNegativeOrZeroException = "Serving size cannot be less or equal to zero";

        public static string PriceNegativeOrZeroException = "Price cannot be less or equal to zero!";

        public static string BrandNullOrWhiteSpaceException = "Brand cannot be null or white space!";

        public static string CapacityNegativeOrZeroException = "Capacity has to be greater than 0";

        public static string PeopleCountNegativeOrZeroException = "Cannot place zero or less people!";

        public static string TableAlreadyReservedException = "Table is already reserved!";

    }
}
