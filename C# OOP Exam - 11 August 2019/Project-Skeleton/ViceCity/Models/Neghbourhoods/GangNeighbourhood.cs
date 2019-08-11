using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            List<IGun> repository = mainPlayer.GunRepository.Models.ToList();

            while (civilPlayers.Count != 0)
            {
                if (repository.Count == 0)
                {
                    break;
                }

                IGun gun = repository.First();
                IPlayer player = civilPlayers.First();

                while (gun.CanFire && player.IsAlive)
                {
                    player.TakeLifePoints(gun.Fire());
                }

                if (player.IsAlive == false)
                {
                    civilPlayers.Remove(player);
                }

                if (gun.CanFire == false)
                {
                    mainPlayer.GunRepository.Remove(gun);
                    repository.Remove(gun);
                }
            }

            if (civilPlayers.Count != 0)
            {
                bool alive = true;

                foreach (var player in civilPlayers)
                {
                    List<IGun> playerRepo = player.GunRepository.Models.ToList();

                    if (playerRepo.Count != 0)
                    {
                        foreach (var gun in playerRepo)
                        {
                            while (gun.CanFire && mainPlayer.IsAlive)
                            {
                                mainPlayer.TakeLifePoints(gun.Fire());
                            }

                            if (mainPlayer.IsAlive == false)
                            {
                                alive = false;
                                break;
                            }
                        }
                    }

                    if (!alive)
                    {
                        break;
                    }
                }
            }
        }
    }
}
