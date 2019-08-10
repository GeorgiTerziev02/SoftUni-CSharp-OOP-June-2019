using System;

namespace ValidPerson
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Person person = new Person("Gin4o", "gosh", 7);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("Exception thrown: {0}", ane.Message);
            }
            catch(ArgumentOutOfRangeException aore)
            {
                Console.WriteLine("Exception thrown: {0}", aore.Message);
            }
            catch(InvalidPersonNameException ipne)
            {
                Console.WriteLine("Exception thrown: {0}", ipne.Message);
            }
        }
    }
}
