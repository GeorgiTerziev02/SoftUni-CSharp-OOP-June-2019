using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (astronauts.Count > 0 && planet.Items.Count != 0)
            {
                var astronaut = astronauts.First(a => a.Oxygen > 0);

                while (astronaut.CanBreath && planet.Items.Count != 0)
                {
                    string itemToCollect = planet.Items.First();
                    astronaut.Bag.Items.Add(itemToCollect);

                    planet.Items.Remove(itemToCollect);
                    astronaut.Breath();
                }
            }
        }
    }
}
