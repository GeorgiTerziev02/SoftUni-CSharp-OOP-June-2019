using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Exceptions;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.NullPlayerException);
            }

            if (this.players.Any(p => p.Username == player.Username))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerAlreadyExistsException, player.Username));
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return this.players.FirstOrDefault(p => p.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.NullPlayerException);
            }

            return this.players.Remove(player);
        }
    }
}
