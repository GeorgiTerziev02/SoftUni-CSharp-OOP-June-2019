using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Exceptions;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            var cardType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(c => c.Name == type);

            if (cardType == null)
            {
                throw new ArgumentException(ExceptionMessages.NonExistingCardTypeException);
            }

            ICard card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
