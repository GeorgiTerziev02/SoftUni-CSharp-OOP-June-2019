using CollectionHierarchy.Contracts;
using CollectionHierarchy.Models;
using System;

namespace CollectionHierarchy.Core
{
    public class Engine
    {
        private IAddable addCollection;
        private IRemovable addRemoveCollection;
        private ICountable myListCollection;
        public Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myListCollection = new MyList();
        }

        public void Run()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int numberOfRemoveOperations = int.Parse(Console.ReadLine());

            foreach (var item in input)
            {
                Console.Write(this.addCollection.Add(item) + " ");
            }
            Console.WriteLine();

            foreach (var item in input)
            {
                Console.Write(this.addRemoveCollection.Add(item) + " ");
            }
            Console.WriteLine();

            foreach (var item in input)
            {
                Console.Write(this.myListCollection.Add(item) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < numberOfRemoveOperations; i++)
            {
                Console.Write(this.addRemoveCollection.Remove() + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < numberOfRemoveOperations; i++)
            {
                Console.Write(this.myListCollection.Remove() + " ");
            }

        }
    }
}
