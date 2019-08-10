using MXGP.Utilities.Messages;
using System;

namespace MXGP.Models.Motorcycles
{
    class SpeedMotorcycle : Motorcycle
    {
        private const int MIN_HP = 50;
        private const int MAX_HP = 69;
        private const double INITIAL_CUBIC_CENTIMETERS = 125;

        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, INITIAL_CUBIC_CENTIMETERS)
        {

        }

        public override int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value < MIN_HP || value > MAX_HP)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
