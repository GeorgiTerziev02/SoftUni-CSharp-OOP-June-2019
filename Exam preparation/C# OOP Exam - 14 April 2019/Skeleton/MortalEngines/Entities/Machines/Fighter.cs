using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double INITIAL_HP = 200;
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, INITIAL_HP)
        {
            this.AggressiveMode = true;
            this.AttackPoints += 50;
            this.DefensePoints -= 25;
        }

        public bool AggressiveMode { get; private set; }

        //INITIAL INCREASE???
        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            string mode = string.Empty;

            if (this.AggressiveMode == true)
            {
                mode = " *Aggressive: ON";
            }
            else
            {
                mode = " *Aggressive: OFF";
            }

            return base.ToString() + Environment.NewLine + mode.TrimEnd();
        }
    }
}
