namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private IProductStock productStock;

        [SetUp]
        public void CreateTestObjects()
        {
            this.productStock = new ProductStock();

            this.productStock.Add(new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 100m
            });
        }

        [Test]
        public void DuplicateLabelAfterAddingNewProduct()
        {
            int countBeforeAdd = productStock.Count;
            this.productStock.Add(new Product()
            {
                Label = "MyProduct",
                Price = 100m
            });

            Assert.That(countBeforeAdd, Is.EqualTo(productStock.Count));
        }

        [Test]
        public void ProductQuantityIncreaseByQuantityAdded()
        {
            int quantityBefore = this.productStock.FirstOrDefault().Quantity;

            this.productStock.Add(new Product()
            {
                Label = "MyProduct",
                Quantity = 5,
                Price = 100m
            });

            Assert.That(this.productStock.FirstOrDefault().Quantity == 6);
        }

        [Test]
        public void PricePreservAfterNewProductAdded()
        {

            var product = new Product()
            {
                Label = "MyProduct",
                Price = 5.9m
            };

            Assert.That(() => this.productStock.Add(product), Throws.ArgumentException);
        }

        [Test]
        public void TrueIfContainsProduct()
        {
            var product = new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 100m
            };

            Assert.That(this.productStock.Contains(product));
        }

        [Test]
        public void FalseIfContainsProduct()
        {
            var product = new Product()
            {
                Label = "MyPro",
                Quantity = 5,
                Price = 100m
            };

            Assert.That(!this.productStock.Contains(product));
        }

        [Test]
        public void FindsNthProductInStock()
        {
            var product = new Product()
            {
                Label = "NewProduct",
                Quantity = 5,
                Price = 100m
            };

            this.productStock.Add(product);
            var findedProduct = this.productStock.Find(2);

            Assert.That(findedProduct.Label, Is.EqualTo(product.Label));
        }

        [Test]
        public void ErrorIfProductIndexIsNotValid()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock.Find(100);
            });
        }

        [Test]
        public void ProductFoundByLabel()
        {
            var product = this.productStock.FindByLabel("MyProduct");

            Assert.AreEqual(product, this.productStock.First());
        }

        [Test]
        public void ErrorIfLabelNotFount()
        {
            Assert.Throws<ArgumentException>(() => this.productStock.FindByLabel("alala"));
        }

        [Test]
        public void EmptyListIfNotFound()
        {
            var product = this.productStock.FindAllInRange(1.0, 2.0);

            Assert.That(product.Count() == 0);
        }

        [TearDown]
        public void DestroyObjects()
        {
            this.productStock = null;
        }

    }
}
