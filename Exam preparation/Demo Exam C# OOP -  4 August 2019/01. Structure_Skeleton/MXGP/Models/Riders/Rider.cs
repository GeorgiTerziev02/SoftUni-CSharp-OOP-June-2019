using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private const int MIN_LENGTH = 5;

        private string name;

        public Rider(string name)
        {
            this.Name = name;

            this.NumberOfWins = 0;
       //   this.CanParticipate = false;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MIN_LENGTH)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MIN_LENGTH));
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; protected set; }

        public bool CanParticipate => this.Motorcycle != null;


        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(ExceptionMessages.MotorcycleInvalid);
            }

            this.Motorcycle = motorcycle;
     //     this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        private bool CheckIfRiderCanParticipate()
        {
            if (this.Motorcycle == null)
            {
                return false;
            }

            return true;
        }
    }
}
