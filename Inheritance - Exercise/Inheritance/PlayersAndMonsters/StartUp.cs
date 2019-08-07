namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BladeKnight bladeKnight = new BladeKnight("Olof", 22);

            System.Console.WriteLine(bladeKnight);
        }
    }
}