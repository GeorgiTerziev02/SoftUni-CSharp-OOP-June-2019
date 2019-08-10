namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int INITIAL_DAMAGE = 120;
        private const int INITIAL_HEALTH = 5;
        public TrapCard(string name) 
            : base(name, INITIAL_DAMAGE, INITIAL_HEALTH)
        {

        }
    }
}
