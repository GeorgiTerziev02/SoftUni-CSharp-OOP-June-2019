namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private const int initialWeight = 5;
        public PoisonPotion()
            : base(initialWeight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
                character.Health = 0;
            }
        }
    }
}
