using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Linq;
using System.Reflection;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var playerType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (playerType == null)
            {
                throw new ArgumentException(Exceptions.ExceptionMessages.NonExistingPlayerTypeException);
            }

            var repository = new CardRepository();

            IPlayer player = (IPlayer)Activator.CreateInstance(playerType, repository, username);

            return player;
        }
    }
}
