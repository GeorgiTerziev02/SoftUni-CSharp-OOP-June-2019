using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine, ITank
    {
        private const double INITIAL_HP = 100;
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, INITIAL_HP)
        {
            this.DefenseMode = true;
            this.AttackPoints -= 40;
            this.DefensePoints += 30;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            string mode = string.Empty;

            if (this.DefenseMode == true)
            {
                mode = " *Defense: ON";
            }
            else
            {
                mode = " *Defense: OFF";
            }

            return base.ToString() + Environment.NewLine + mode.TrimEnd();
        }
    }
}
