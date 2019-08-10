using AnimalCentre.Exceptions;
using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        public NailTrim()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTimeException);
            }

            animal.Happiness -=7;
            base.procedureHistory.Add(animal);
        }
    }
}
