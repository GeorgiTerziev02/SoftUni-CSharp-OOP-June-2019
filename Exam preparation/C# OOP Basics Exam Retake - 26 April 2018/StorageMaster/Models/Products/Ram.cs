namespace StorageMaster.Models.Products
{
    public class Ram : Product
    {
        private const double RAM_INITIAL_WEIGHT = 0.1;

        public Ram(double price) 
            : base(price, RAM_INITIAL_WEIGHT)
        {

        }
    }
}
