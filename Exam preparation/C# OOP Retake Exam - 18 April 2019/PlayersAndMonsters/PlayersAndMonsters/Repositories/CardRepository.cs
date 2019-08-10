using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Exceptions;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }
        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.NullCardException);
            }

            if (this.cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CardAlreadyExistsException, card.Name));
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            return this.cards.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.NullCardException);
            }

            return this.cards.Remove(card);
        }
    }
}
