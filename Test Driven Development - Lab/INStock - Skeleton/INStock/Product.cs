using INStock.Contracts;

namespace INStock
{
    public class Product : IProduct
    {
        public string Label { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CompareTo(IProduct other)
        {
            throw new System.NotImplementedException();
        }
    }
}
