using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private GangNeighbourhood gangNeighbourhood;
        private Queue<IGun> gunRepository;
        private List<IPlayer> players;
        private IPlayer mainPlayer;
        public Controller()
        {
            this.gangNeighbourhood = new GangNeighbourhood();
            this.gunRepository = new Queue<IGun>();
            this.players = new List<IPlayer>();
            this.mainPlayer = new MainPlayer();
        }
        public string AddGun(string type, string name)
        {
            if (type != "Pistol" && type != "Rifle")
            {
                return "Invalid gun type!";
            }

            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else
            {
                gun = new Rifle(name);
            }

            this.gunRepository.Enqueue(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (!gunRepository.Any())
            {
                return "There are no guns in the queue!";
            }

            if (name == "Vercetti")
            {
                IGun gun = gunRepository.Dequeue();
                mainPlayer.GunRepository.Add(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            if (!players.Any(p => p.Name == name))
            {
                return $"Civil player with that name doesn't exists!";
            }

            IPlayer player = players.First(p => p.Name == name);
            IGun gunToAdd = gunRepository.Dequeue();

            player.GunRepository.Add(gunToAdd);

            return $"Successfully added {gunToAdd.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            players.Add(player);

            return $"Successfully added civil player: {player.Name}!";
        }

        public string Fight()
        {
            int civilsCount = players.Count;
            this.gangNeighbourhood.Action(mainPlayer, players);

            if (mainPlayer.LifePoints == 100 && players.All(p => p.LifePoints == 50 && p.IsAlive == true) && players.Count == civilsCount)
            {
                return "Everything is okay!";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("A fight happened:");
            sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
            sb.AppendLine($"Tommy has killed: {civilsCount - this.players.Count} players!");
            sb.AppendLine($"Left Civil Players: {this.players.Count}!");

            return sb.ToString().TrimEnd();
        }
    }
}
