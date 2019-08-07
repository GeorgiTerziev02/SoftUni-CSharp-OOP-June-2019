using Animals.Cats;
using System;
using System.Collections.Generic;

namespace Animals
{
    public class Engine
    {
        public void Run()
        {
            string animal = Console.ReadLine();

            string[] properties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {

                string name = properties[0];
                int age = int.Parse(properties[1]);
                string gender = string.Empty;

                if(age<=0)
                {
                    Console.WriteLine("Invalid input!");


                    animal = Console.ReadLine();

                    if (animal == "Beast!")
                    {
                        break;
                    }

                    properties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    continue;
                }

                if(properties.Length>2)
                {
                    gender = properties[2];
                }

                switch (animal)
                {
                    case "Cat":
                        {
                            Console.WriteLine(animal);
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            Console.WriteLine(cat.ProduceSound());
                        }
                        break;
                    case "Dog":
                        {
                            Dog dog = new Dog(name, age, gender);
                            Console.WriteLine(animal);
                            Console.WriteLine(dog);
                            Console.WriteLine(dog.ProduceSound());
                        }
                        break;
                    case "Frog":
                        {
                            Console.WriteLine(animal);
                            Frog frog = new Frog(name, age, gender);
                            Console.WriteLine(frog);
                            Console.WriteLine(frog.ProduceSound());
                        }
                        break;
                    case "Tomcat":
                        {
                            Console.WriteLine(animal);
                            Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine(tomcat);
                            Console.WriteLine(tomcat.ProduceSound());
                        }
                        break;
                    case "Kitten":
                        {
                            Console.WriteLine(animal);
                            Kitten kitten = new Kitten(name, age);
                            Console.WriteLine(kitten);
                            Console.WriteLine(kitten.ProduceSound());
                        }
                        break;
                       
                }
                animal = Console.ReadLine();

                if(animal=="Beast!")
                {
                    break;
                }

                properties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
