using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
