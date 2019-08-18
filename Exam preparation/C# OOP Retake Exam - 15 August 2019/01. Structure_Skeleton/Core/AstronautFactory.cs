using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Linq;
using System.Reflection;

namespace SpaceStation.Core
{
    public class AstronautFactory
    {
        public IAstronaut CreateAstronaut(string type, string astronautName)
        {
            Type astronautType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (astronautType == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            IAstronaut astronaut = (IAstronaut) Activator.CreateInstance(astronautType, astronautName);

            return astronaut;
        }
    }
}
