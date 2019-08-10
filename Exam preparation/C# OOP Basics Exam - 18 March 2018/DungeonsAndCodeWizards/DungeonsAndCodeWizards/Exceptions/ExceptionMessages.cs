namespace DungeonsAndCodeWizards.Exceptions
{
    public static class ExceptionMessages
    {
        public static string CharacterMustBeAliveException = "Must be alive to perform this action!";

        public static string BagIsFullException = "Bag is full!";

        public static string BagIsEmptyException = "Bag is empty!";

        public static string ItemDoesntExistInTheBagException = "No item with name {0} in bag!";

        public static string NameNullOrWhitespaceException = "Name cannot be null or whitespace!";

        public static string CanNotAttackYourselfException = "Cannot attack self!";

        public static string FriendlyFireException = "Friendly fire! Both characters are from {0} faction!";

        public static string CanNotHealEnemyException = "Cannot heal enemy character!";

        public static string InvalidFactionException = "Invalid faction \"{0}\"!";

        public static string InvalidCharacterTypeException = "Invalid character type \"{0}\"!";

        public static string InvalidItemException = "Invalid item \"{0}\"!";

        public static string InvalidCharacterNameException = "Character {0} not found!";

        public static string EmptyItemPoolException = "No items left in pool!";

        public static string AttackerCanNotAttackException= "{0} cannot attack!";

        public static string HealerCanNotHealException= "{0} cannot heal!";

        public static string InvalidItemTypeException= "Invalid item type \"{0}\"!";
    }
}
