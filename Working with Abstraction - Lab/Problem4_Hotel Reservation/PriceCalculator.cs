using System;

namespace Problem4_Hotel_Reservation
{
    public class PriceCalculator
    {
        private decimal pricePerNight;
        private int nights;
        private SeasonMultiplier seasonMultiplier;
        private Discounts discount;
        public PriceCalculator(string[] command)
        {
            pricePerNight = decimal.Parse(command[0]);
            nights = int.Parse(command[1]);
            seasonMultiplier = Enum.Parse<SeasonMultiplier>(command[2]);
            discount = Discounts.None;

            if (command.Length==4)
            {
                discount = Enum.Parse<Discounts>(command[3]);
            }

        }

        public decimal GetTotalPrice()
        {
            decimal price = pricePerNight * nights * (int)seasonMultiplier;

            price = price - price * (decimal)discount / 100;

            return price;         
        }
    }
}
