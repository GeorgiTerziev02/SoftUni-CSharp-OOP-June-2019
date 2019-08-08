using System;

namespace Problem03Ferrari
{
    public class Ferrari : ICar
    {
        private const string MODEL = "488-Spider";

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver { get; private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{MODEL}/{this.Brakes()}/{this.Gas()}/{this.Driver}";
        }
    }
}
