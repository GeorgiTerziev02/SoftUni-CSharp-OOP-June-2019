namespace StorageMaster.Exceptions
{
    public static class ExceptionMessages
    {
        public static string NegativePriceException = "Price cannot be negative!";

        public static string VehicleIsFullException = "Vehicle is full!";

        public static string VehicleIsEmptyException = "No products left in vehicle!";

        public static string InvalidGarageSlotIndexException = "Invalid garage slot!";

        public static string EmptyGarageSlotException = "No vehicle in this garage slot!";

        public static string NoEmptySlotException = "No room in garage!";

        public static string StorageIsFullException = "Storage is full!";

        public static string InvalidProductTypeException = "Invalid product type!";

        public static string InvalidStorageTypeException = "Invalid storage type!";

        public static string OutOfStockException = "{0} is out of stock!";

        public static string InvalidSourceStorageException = "Invalid source storage!";

        public static string InvalidDestinationStorageException = "Invalid destination storage!";

    }
}
