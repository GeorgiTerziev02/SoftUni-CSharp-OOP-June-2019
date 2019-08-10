namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private Dictionary<string, IPilot> pilotsByName;
        private Dictionary<string, ITank> tanksByName;
        private Dictionary<string, IFighter> fightersByName;
        private List<IMachine> machines;
        public MachinesManager()
        {
            this.pilotsByName = new Dictionary<string, IPilot>();
            this.tanksByName = new Dictionary<string, ITank>();
            this.fightersByName = new Dictionary<string, IFighter>();
            this.machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            if (this.pilotsByName.ContainsKey(name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            IPilot pilot = new Pilot(name);
            this.pilotsByName.Add(name, pilot);

            return string.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.tanksByName.ContainsKey(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);
            IMachine machine = new Tank(name, attackPoints, defensePoints);

            this.machines.Add(machine);
            this.tanksByName.Add(name, tank);

            return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.fightersByName.ContainsKey(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            IMachine machine = new Fighter(name, attackPoints, defensePoints);

            this.machines.Add(machine);
            this.fightersByName.Add(name, fighter);

            return string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, "ON");
        }

        //diff between lists
        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!this.pilotsByName.ContainsKey(selectedPilotName))
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (this.machines.Any(m => m.Name == selectedMachineName) == false)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            IMachine machine = this.machines.First(m => m.Name == selectedMachineName);

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            this.pilotsByName[selectedPilotName].AddMachine(machine);
            machine.Pilot = this.pilotsByName[selectedPilotName];

            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (this.machines.Any(m => m.Name == attackingMachineName) == false)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (this.machines.Any(m => m.Name == defendingMachineName) == false)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            IMachine attacker = this.machines.First(m => m.Name == attackingMachineName);
            IMachine deffender = this.machines.First(m => m.Name == defendingMachineName);

            if (attacker.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if (deffender.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attacker.Attack(deffender);

            return string.Format(OutputMessages.AttackSuccessful, deffender.Name, attacker.Name, deffender.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            if (!this.pilotsByName.ContainsKey(pilotReporting))
            {
                return null;
            }

            return this.pilotsByName[pilotReporting].Report();
        }

        public string MachineReport(string machineName)
        {
            if (this.machines.Any(m => m.Name == machineName) == false)
            {
                return null;
            }

            return this.machines.First(m => m.Name == machineName).ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!this.fightersByName.ContainsKey(fighterName))
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            this.fightersByName[fighterName].ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (!this.tanksByName.ContainsKey(tankName))
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            this.tanksByName[tankName].ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}