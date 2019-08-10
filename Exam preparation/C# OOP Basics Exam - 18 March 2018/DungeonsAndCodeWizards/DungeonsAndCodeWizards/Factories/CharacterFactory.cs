using DungeonsAndCodeWizards.Enumeration;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Models;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factionName, string characterType, string name)
        {
            if (factionName != "CSharp" && factionName != "Java")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidFactionException, factionName));
            }

            Faction faction = Enum.Parse<Faction>(factionName);

            if (characterType != "Warrior" && characterType != "Cleric")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterTypeException, characterType));
            }

            Character character = null;

            if (characterType == "Warrior")
            {
                character = new Warrior(name, faction);
            }
            else if (characterType == "Cleric")
            {
                character = new Cleric(name, faction);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterTypeException, characterType));
            }

            return character;
        }
    }
}
