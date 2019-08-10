namespace StorageMaster.Models.Products
{
    public class HardDrive : Product
    {
        private const double HARD_DRIVE_INITIAL_WEIGHT = 1;

        public HardDrive(double price) 
            : base(price, HARD_DRIVE_INITIAL_WEIGHT)
        {

        }
    }
}
