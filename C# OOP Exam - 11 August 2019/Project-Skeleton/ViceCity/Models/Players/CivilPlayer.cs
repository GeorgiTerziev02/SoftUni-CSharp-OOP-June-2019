namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        private const int INITIAL_LIFE_POINTS = 50;
        public CivilPlayer(string name) 
            : base(name, INITIAL_LIFE_POINTS)
        {

        }
    }
}
