namespace PlayersAndMonsters.Exceptions
{
    public static class ExceptionMessages
    {
        public static string NullOrEmptyPlayerNameException = "Player's username cannot be null or an empty string.";

        public static string NegativeHealthException = "Player's health bonus cannot be less than zero.";

        public static string NegativeDamagePointsException = "Damage points cannot be less than zero.";

        public static string NullOrEmptyCardNameException = "Card's name cannot be null or an empty string.";

        public static string NegativeCardDamagePointsException = "Card's damage points cannot be less than zero.";

        public static string NegativeCardHealthException = "Card's HP cannot be less than zero.";

        public static string DeadPlayerException = "Player is dead!";

        public static string NullCardException = "Card cannot be null!";

        public static string NullPlayerException = "Player cannot be null!";

        public static string CardAlreadyExistsException = "Card {0} already exists!";

        public static string PlayerAlreadyExistsException = "Player {0} already exists!";

        public static string NonExistingPlayerTypeException = "Player of this type does not exists!";

        public static string NonExistingCardTypeException = "Card of this type does not exists!";
    }
}
