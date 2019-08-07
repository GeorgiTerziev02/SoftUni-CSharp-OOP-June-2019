using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandBox
{
    public class Department
    {
        public Department(string name)
        {
            this.Name = name;

            this.Rooms = new List<Room>();

            this.CreateRooms();
        }

        private void CreateRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                this.Rooms.Add(new Room());
            }
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        public void AddPatientInRoom(Patient patient)
        {
            var currentRoom = this.Rooms.Where(x => x.IsFull == false).FirstOrDefault();

            if (currentRoom != null)
            {
                currentRoom.Patients.Add(patient);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var room in this.Rooms)
            {
                foreach (var patient in room.Patients)
                {
                    sb.AppendLine(patient.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
