using StorageMaster.Contracts;
using StorageMaster.Exceptions;
using StorageMaster.Models.Storages;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            var storageType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Storage).IsAssignableFrom(t) && t.Name == type && !t.IsAbstract);

            if(storageType==null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidStorageTypeException);
            }

            try
            {
                var storage = (Storage)Activator.CreateInstance(storageType, name);
                return storage;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}
