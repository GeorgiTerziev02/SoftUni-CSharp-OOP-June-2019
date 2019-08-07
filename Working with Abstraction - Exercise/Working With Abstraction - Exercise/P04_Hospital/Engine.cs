using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;

        public Engine()
        {
            this.doctors = new Dictionary<string, List<string>>();
            this.departments = new Dictionary<string, List<List<string>>>();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] inputArgs = command.Split();

                var department = inputArgs[0];
                var firstName = inputArgs[1];
                var secondName = inputArgs[2];
                var patient = inputArgs[3];

                var fullName = firstName + secondName;

                AddDoctor(fullName);

                AddDepartment(department);

                bool isFree = departments[department].SelectMany(x => x).Count() < 60;

                if (isFree)
                {

                    doctors[fullName].Add(patient);

                    AddPatientToRoom(department, patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    string departmentName = args[0];

                    PrintPatientsInDepartment(departmentName);
                }
                else if (args.Length == 2)
                {
                    bool isRoom = int.TryParse(args[1], out int room);

                    string departmentName = args[0];

                    if (isRoom)
                    {
                        var allPatientsInRoom = departments[departmentName][room - 1].OrderBy(x => x).ToArray();

                        Console.WriteLine(string.Join(Environment.NewLine, allPatientsInRoom));
                    }
                    else
                    {
                        var doctorFullName = args[0] + args[1];
                        PrintAllDoctorsPatients(doctorFullName);
                    }
                }
                command = Console.ReadLine();
            }
        }

        private void PrintAllDoctorsPatients(string doctorFullName)
        {
            var allPatientsOfDoctor = doctors[doctorFullName].OrderBy(x => x).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsOfDoctor));
        }

        private void PrintPatientsInDepartment(string departmentName)
        {
            var allPatientsInDepartment = departments[departmentName]
                                    .Where(x => x.Count > 0)
                                    .SelectMany(x => x)
                                    .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsInDepartment));
        }

        private void AddPatientToRoom(string department, string patient)
        {
            int room = 0;

            for (int currentRoom = 0; currentRoom < departments[department].Count; currentRoom++)
            {
                if (departments[department][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }

            //    int targetRoom = departments[department].SelectMany(x => x).Where(x => x.Count() < 3).FirstOrDefault();

            departments[department][room].Add(patient);
        }

        private void AddDepartment(string department)
        {
            if (!departments.ContainsKey(department))
            {
                departments[department] = new List<List<string>>();

                for (int room = 0; room < 20; room++)
                {
                    departments[department].Add(new List<string>());
                }
            }
        }

        private void AddDoctor(string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
