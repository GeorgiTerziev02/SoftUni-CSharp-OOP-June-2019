using System;
using System.Collections.Generic;
using System.Text;

namespace SandBox
{
    public class Patient
    {

        public Patient(string patientsName)
        {
            this.Name = patientsName;
        }

        public string Name { get; set; }
    }
}
