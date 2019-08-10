using System;
using AnimalCentre.Exceptions;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        public Chip()
        {

        }

        public override void DoService(IAnimal animal, int procedureTime)
        {

            if (animal.IsChipped == true)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChippedAnimalException, animal.Name));

            }

            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTimeException);
            }

            animal.IsChipped = true;
            animal.Happiness -= 5;
            animal.ProcedureTime -= procedureTime;
            base.procedureHistory.Add(animal);
        }
    }
}
