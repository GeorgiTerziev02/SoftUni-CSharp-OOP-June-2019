namespace FootballTeam.Exceptions
{
    public static class ExceptionMessages
    {
        public static string InvalidStatException= "{0} should be between 0 and 100.";
        public static string EmptyName= "A name should not be empty.";
        public static string MissingPlayer= "Player {0} is not in {1} team.";
        public static string MissingTeam= "Team {0} does not exist.";
    }
}
