using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Enumeration;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private readonly List<Character> characters;
        private readonly List<Item> items;
        private int lastSurvivors = 0;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
            this.characterFactory = new CharacterFactory();
        }

        public string JoinParty(string[] args)
        {
            string factionName = args[0];
            var characterType = args[1];
            var name = args[2];

            //if (factionName != "CSharp" && factionName != "Java")
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.InvalidFactionException, factionName));
            //}

            //Faction faction = Enum.Parse<Faction>(args[0]);

            //if (characterType != "Warrior" && characterType != "Cleric")
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterTypeException, characterType));
            //}

            //Character character = null;

            //if (characterType == "Warrior")
            //{
            //    character = new Warrior(name, faction);
            //}
            //else
            //{
            //    character = new Cleric(name, faction);
            //}

            Character character = this.characterFactory.CreateCharacter(factionName, characterType, name);

            this.characters.Add(character);

            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            //if (itemName != "ArmorRepairKit" && itemName != "HealthPotion" && itemName != "PoisonPotion")
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.InvalidItemException, itemName));
            //}

            Item item = this.itemFactory.CreateItem(itemName);

            //if (itemName == "ArmorRepairKit")
            //{
            //    item = new ArmorRepairKit();
            //}
            //else if (itemName == "HealthPotion")
            //{
            //    item = new HealthPotion();
            //}
            //else
            //{
            //    item = new PoisonPotion();
            //}

            this.items.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character characterToPickUpItem = CheckIfCharacterExist(characterName);
            CheckIfItemPoolIsEmpty();

            Item itemToBePicked = this.items[this.items.Count - 1];
            characterToPickUpItem.ReceiveItem(itemToBePicked);

            this.items.RemoveAt(this.items.Count - 1);
            return $"{characterName} picked up {itemToBePicked.GetType().Name}!".TrimEnd();
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character characterToUseItem = CheckIfCharacterExist(characterName);

            Item itemToBeUsed = characterToUseItem.Bag.GetItem(itemName);
            characterToUseItem.UseItem(itemToBeUsed);

            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {

            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = CheckIfCharacterExist(giverName);
            Character receiver = CheckIfCharacterExist(receiverName);

            Item itemToBeGiven = giver.Bag.GetItem(itemName);

            giver.UseItemOn(itemToBeGiven, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = CheckIfCharacterExist(giverName);
            Character receiver = CheckIfCharacterExist(receiverName);

            Item itemToBeGiven = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(itemToBeGiven, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder result = new StringBuilder();

            foreach (var character in this.characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                result.AppendLine(character.ToString());
            }

            return result.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attackerCh = CheckIfCharacterExist(attackerName);
            Character receiver = CheckIfCharacterExist(receiverName);

            if (attackerCh.GetType().Name != "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackerCanNotAttackException, attackerName));
            }

            Warrior attacker = (Warrior)attackerCh;

            attacker.Attack(receiver);

            if (receiver.IsAlive == true)
            {
                return $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";
            }
            else
            {
                return $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!"
                    + Environment.NewLine
                    + $"{receiver.Name} is dead!";
            }

        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = CheckIfCharacterExist(healerName);
            Character receiver = CheckIfCharacterExist(receiverName);

            if (healer.GetType().Name != "Cleric")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCanNotHealException, healerName));
            }

            Cleric realHealer = (Cleric)healer;

            realHealer.Heal(receiver);

            return $"{realHealer.Name} heals {receiver.Name} for {realHealer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in this.characters.Where(p => p.IsAlive == true))
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            List<Character> aliveCharacters = this.characters.Where(p => p.IsAlive == true).ToList();

            if (aliveCharacters.Count == 0 || aliveCharacters.Count == 1)
            {
                this.lastSurvivors++;
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (this.lastSurvivors > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Character CheckIfCharacterExist(string characterName)
        {
            Character characterToUseItem = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (characterToUseItem == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterNameException, characterName));
            }

            return characterToUseItem;
        }

        private void CheckIfItemPoolIsEmpty()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyItemPoolException);
            }
        }
    }
}
