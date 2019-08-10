namespace StorageMaster.Models.Products
{
    public class Gpu : Product
    {
        private const double GPU_INITIAL_WEIGHT = 0.7;
        public Gpu(double price) 
            : base(price, GPU_INITIAL_WEIGHT)
        {

        }
    }
}
