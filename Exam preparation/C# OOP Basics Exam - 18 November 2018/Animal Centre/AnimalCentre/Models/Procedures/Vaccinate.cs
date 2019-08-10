using AnimalCentre.Exceptions;
using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        public Vaccinate()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTimeException);
            }

            animal.Energy -= 8;
            animal.IsVaccinated = true;
            animal.ProcedureTime -= procedureTime;
            base.procedureHistory.Add(animal);
        }
    }
}
