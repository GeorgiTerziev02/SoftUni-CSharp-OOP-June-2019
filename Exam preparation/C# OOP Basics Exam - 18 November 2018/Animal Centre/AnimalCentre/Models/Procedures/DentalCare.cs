using System;
using AnimalCentre.Exceptions;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure
    {
        public DentalCare()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTimeException);
            }

            animal.Happiness += 12;
            animal.Energy += 10;
            base.procedureHistory.Add(animal);
        }
    }
}
