using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private RiderRepository riderRepository;
        private RaceRepository raceRepository;
        private MotorcycleRepository motorcycleRepository;
        public ChampionshipController()
        {
            this.riderRepository = new RiderRepository();
            this.raceRepository = new RaceRepository();
            this.motorcycleRepository = new MotorcycleRepository();
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = CheckIfRiderExists(riderName);
            IMotorcycle motorcycle = CheckIfMotorExists(motorcycleModel);

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = CheckIfRaceExists(raceName);
            IRider rider = CheckIfRiderExists(riderName);

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            IMotorcycle motorcycle = null;

            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            this.motorcycleRepository.Add(motorcycle);

            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            IRider rider = new Rider(riderName);

            this.riderRepository.Add(rider);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            IRace race = CheckIfRaceExists(raceName);

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3).TrimEnd());
            }

            StringBuilder result = new StringBuilder();

            int firstWins = 0;

            foreach (var rider in race.Riders.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps)))
            {
                if (firstWins == 0)
                {
                    rider.WinRace();
                    firstWins++;
                    result.AppendLine(string.Format(OutputMessages.RiderFirstPosition, rider.Name, raceName));
                }
                else if (firstWins == 1)
                {
                    firstWins++;
                    result.AppendLine(string.Format(OutputMessages.RiderSecondPosition, rider.Name, raceName));
                }
                else if (firstWins == 2)
                {
                    firstWins++;
                    result.AppendLine(string.Format(OutputMessages.RiderThirdPosition, rider.Name, raceName));
                    break;
                }
            }

            this.raceRepository.Remove(race);

            return result.ToString().TrimEnd();
        }

        private IRider CheckIfRiderExists(string name)
        {
            if (this.riderRepository.GetByName(name) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, name));
            }

            return this.riderRepository.GetByName(name);
        }

        private IMotorcycle CheckIfMotorExists(string model)
        {
            if (this.motorcycleRepository.GetByName(model) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, model));
            }

            return this.motorcycleRepository.GetByName(model);
        }

        private IRace CheckIfRaceExists(string name)
        {
            if (this.raceRepository.GetByName(name) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, name));
            }

            return this.raceRepository.GetByName(name);
        }
    }
}
