using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
