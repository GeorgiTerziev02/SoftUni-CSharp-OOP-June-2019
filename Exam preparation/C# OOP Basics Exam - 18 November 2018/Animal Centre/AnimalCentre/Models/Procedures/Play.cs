using System;
using AnimalCentre.Exceptions;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        public Play()
        {

        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTimeException);
            }

            animal.Energy -= 6;
            animal.Happiness += 12;
            base.procedureHistory.Add(animal);

        }
    }
}
