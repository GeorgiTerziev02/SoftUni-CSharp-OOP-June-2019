using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private int capacity;

        private const int BULLETS_PER_BARREL = 50;
        private const int TOTAL_BULLETS = 500;
        private const int BULLETS_TO_SHOOT = 5;

        public Rifle(string name)
            : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
        {
            this.capacity = BULLETS_PER_BARREL;
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel = capacity;
                this.TotalBullets -= capacity;
            }

            this.BulletsPerBarrel -= BULLETS_TO_SHOOT;

            return BULLETS_TO_SHOOT;
        }
    }
}
