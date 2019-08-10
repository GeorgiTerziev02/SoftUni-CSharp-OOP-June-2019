namespace DungeonsAndCodeWizards.Models.Contracts
{
    public interface IItem
    {
        int Weight { get;}

        void AffectCharacter(Character character);
    }
}
