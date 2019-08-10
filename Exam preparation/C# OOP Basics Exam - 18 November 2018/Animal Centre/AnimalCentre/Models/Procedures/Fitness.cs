using AnimalCentre.Exceptions;
using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        public Fitness()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTimeException);
            }

            animal.Happiness -= 3;
            animal.Energy += 10;
            base.procedureHistory.Add(animal);

        }
    }
}
