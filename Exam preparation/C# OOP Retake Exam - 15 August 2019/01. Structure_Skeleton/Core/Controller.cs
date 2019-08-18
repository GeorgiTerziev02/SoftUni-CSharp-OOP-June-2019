using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private PlanetRepository planetRepository;
        private AstronautFactory astronautFactory;
        private int explored = 0;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.astronautFactory = new AstronautFactory();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronautNew = null;

            switch (type)
            {
                case nameof(Biologist):
                    astronautNew = new Biologist(astronautName);
                    break;
                case nameof(Geodesist):
                    astronautNew = new Geodesist(astronautName);
                    break;
                case nameof(Meteorologist):
                   astronautNew = new Meteorologist(astronautName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronautRepository.Add(astronautNew);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstronauts = this.astronautRepository.Models.Where(a => a.Oxygen > 60).ToList();

            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planetToExplore = this.planetRepository.FindByName(planetName);

            Mission mission = new Mission();
            mission.Explore(planetToExplore, suitableAstronauts);
            explored++;

            return string.Format(OutputMessages.PlanetExplored,
                planetName, suitableAstronauts.Where(a => a.CanBreath == false).ToList().Count);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{explored} planets were explored!")
                .AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}")
                    .AppendLine($"Oxygen: {astronaut.Oxygen}");

                string bagInfo = string.Empty;

                if (astronaut.Bag.Items.Count == 0)
                {
                    bagInfo = "none";
                }
                else
                {
                    bagInfo = string.Join(", ", astronaut.Bag.Items);
                }

                sb.AppendLine($"Bag items: {bagInfo}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (this.astronautRepository.FindByName(astronautName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            IAstronaut astronautToRetire = this.astronautRepository.FindByName(astronautName);
            this.astronautRepository.Remove(astronautToRetire);

            return string.Format(OutputMessages.AstronautRetired, astronautToRetire.Name);
        }
    }
}
