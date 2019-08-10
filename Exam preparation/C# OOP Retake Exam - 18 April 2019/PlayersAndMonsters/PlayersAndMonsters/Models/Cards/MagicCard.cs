namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int INITIAL_DAMAGE = 5;
        private const int INITIAL_HEALTH = 80;

        public MagicCard(string name) 
            : base(name, INITIAL_DAMAGE, INITIAL_HEALTH)
        {

        }
    }
}
