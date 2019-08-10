namespace StorageMaster.Models.Products
{
    public class SolidStateDrive : Product
    {
        private const double SOLID_STATE_DRIVE_INITIAL_WEIGHT = 0.2;

        public SolidStateDrive(double price) 
            : base(price, SOLID_STATE_DRIVE_INITIAL_WEIGHT)
        {

        }
    }
}
