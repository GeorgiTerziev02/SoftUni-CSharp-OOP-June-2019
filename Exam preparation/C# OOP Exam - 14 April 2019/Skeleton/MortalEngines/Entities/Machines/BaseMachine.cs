using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Common;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private List<string> targets;
        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.targets = new List<string>();

            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.MachineNameNullOrEmptyException);
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.PilotNullException);
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.TargetNullException);
            }

            double pointToDecrease = this.AttackPoints - target.DefensePoints;

            if (target.HealthPoints - pointToDecrease < 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= pointToDecrease;
            }

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints :f2}")
                .AppendLine($" *Attack: {this.AttackPoints :f2}")
                .AppendLine($" *Defense: {this.DefensePoints :f2}");

            if (this.targets.Count == 0)
            {
                sb.AppendLine(" *Targets: " + "None");
            }
            else
            {
                sb.AppendLine(" *Targets: " + string.Join(",",this.targets));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
