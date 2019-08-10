using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public IProduct this[int index] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Count
        {
            get
            {
                return this.products.Count;
            }
        }

        public void Add(IProduct product)
        {
            // var existingProduct = (Product)this.FindByLabel(product.Label);
            var existingProduct = (Product)this.products.FirstOrDefault(p => p.Label == product.Label);

            if (existingProduct == null)
            {
                products.Add(product);
            }
            else
            {
                if (existingProduct.Price != product.Price)
                {
                    throw new ArgumentException();
                }

                existingProduct.Quantity += product.Quantity;
            }
        }

        public bool Contains(IProduct product)
        {
            return this.products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            try
            {
                return this.products[index - 1];
            }
            catch (ArgumentOutOfRangeException ae)
            {
                throw new IndexOutOfRangeException(ae.Message, ae);
            }

        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            return products
                .Where(p => (double)p.Price > lo)
                .Where(p => (double)p.Price < hi)
                .ToList();
        }

        public IProduct FindByLabel(string label)
        {
            var product = this.products.FirstOrDefault(p => p.Label == label);

            if (product == null)
            {
                throw new ArgumentException();
            }

            return product;
        }


        public IProduct FindMostExpensiveProduct()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        public bool Remove(IProduct product)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return products.GetEnumerator();
        }
    }
}
