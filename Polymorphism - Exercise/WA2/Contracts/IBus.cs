using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
    public interface IBus : IVehicle
    {
        void Drive(double distance, string command);
    }
}
