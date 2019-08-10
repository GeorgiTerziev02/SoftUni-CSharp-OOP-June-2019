using NUnit.Framework;
using Chainblock.Models;
using System;
using Chainblock.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTest
    {
        private const int id = 1;
        private const TransactionStatus ts = TransactionStatus.Successfull;
        private const string from = "Pesho";
        private const string to = "Gosho";
        private const double amount = 650;

        private Models.Chainblock chainblock;
        private Transaction transaction;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Models.Chainblock();
            this.transaction = new Transaction(id, ts, from, to, amount);

            //First add
            this.chainblock.Add(this.transaction);
        }

        [Test]
        public void TestIfAddWorksCorrectly()
        {
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void TestAddingSameTransactionTwice()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.Add(this.transaction);
            });
        }

        [Test]
        public void TestIfContainsByTrasactionWorksCorrectly()
        {
            bool actualResult = this.chainblock.Contains(this.transaction);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void TestContainsNonExistingTransaction()
        {
            Transaction nonExistingTr = new Transaction(10, TransactionStatus.Unauthorized, from, to, amount);

            bool result = this.chainblock.Contains(nonExistingTr);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestContainsById()
        {
            bool result = this.chainblock.Contains(id);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestContainsNonExistingId()
        {
            bool result = this.chainblock.Contains(5);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestContainsWithNegativeId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.Contains(-5);
            });
        }

        [Test]
        public void TestIfCountWorksCorrectly()
        {
            int expectedCount = 2;
            Transaction tr = new Transaction(10, TransactionStatus.Unauthorized, from, to, amount);

            this.chainblock.Add(tr);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void TestIfGetByIdWorksCorrectly()
        {
            ITransaction result = this.chainblock.GetById(id);

            Assert.AreSame(this.transaction, result);
            Assert.AreEqual(this.transaction.Id, result.Id);
        }

        [Test]
        public void TestGettingNonExistingTransaction()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetById(5);
            });
        }

        [Test]
        public void TestIfChangeTransactionStatusWorksCorrectly()
        {
            TransactionStatus newStatus = TransactionStatus.Aborted;

            this.chainblock.ChangeTransactionStatus(id, newStatus);

            ITransaction result = this.chainblock.GetById(id);

            Assert.AreEqual(newStatus, result.Status);
        }

        [Test]
        public void TestChangingStatusOnNonExistingTransaction()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.chainblock.ChangeTransactionStatus(5, TransactionStatus.Unauthorized);
            });
        }

        [Test]
        public void TestIfRemoveTransactionByIdWorksCorrectly()
        {
            int expectedCount = 0;

            this.chainblock.RemoveTransactionById(id);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void TestRemoveTransactionWithNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.RemoveTransactionById(5);
            });
        }

        [Test]
        public void TestIfGetByStatusReturnsAllWithIntendedStatus()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetByTransactionStatus(ts);

            bool result = resultCollection.All(t => t.Status == ts);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetByStatusReturnsCollectionWithCorrectCount()
        {
            int expectedCount = 3;
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            IEnumerable<ITransaction> resultCollection = this.chainblock.GetByTransactionStatus(ts);

            Assert.AreEqual(expectedCount, resultCollection.Count());
        }

        [Test]
        public void TestIfGetByStatusReturnsCollectionWithCorrectIds()
        {
            IEnumerable<ITransaction> resultCollection = this.chainblock.GetByTransactionStatus(ts);

            Assert.AreEqual(this.transaction, resultCollection.First());
        }

        [Test]
        public void TestIfGetByStatusReturnsOrderedTransaction()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            var resultCollection = this.chainblock.GetByTransactionStatus(ts).ToList();

            bool areOrdered = true;
            double currentMax = resultCollection.First().Amount;

            for (int i = 1; i < resultCollection.Count(); i++)
            {
                ITransaction currentTransaction = resultCollection[i];

                if (currentTransaction.Amount > currentMax)
                {
                    areOrdered = false;
                }

                currentMax = currentTransaction.Amount;
            }

            Assert.IsTrue(areOrdered);
        }

        [Test]
        public void TestGetByNonExistingStatus()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByTransactionStatus(TransactionStatus.Aborted);
            });
        }

        [Test]
        public void TestIfGetAllSendersWithStatusReturnsCorrectly()
        {
            int expectedCount = 3;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            var result = this.chainblock.GetAllSendersWithTransactionStatus(ts);

            Assert.AreEqual(expectedCount, result.Count());
        }

        [Test]
        public void TestIfGetAllSendersWithStatusReturnsCorrectCollection()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            var result = this.chainblock.GetByTransactionStatus(ts).Select(t => t.From).ToArray();

            IEnumerable<string> actual = this.chainblock.GetAllSendersWithTransactionStatus(ts);

            CollectionAssert.AreEqual(result, actual);
        }

        [Test]
        public void TestGettinAllSendersWithNonExistingStatus()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized);
            });
        }

        [Test]
        public void TestIfGetAllReceiversWithStatusReturnsCorrectly()
        {
            int expectedCount = 3;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            var result = this.chainblock.GetAllReceiversWithTransactionStatus(ts);

            Assert.AreEqual(expectedCount, result.Count());
        }

        [Test]
        public void TestIfGetAllReceiversWithStatusReturnsCorrectCollection()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            var result = this.chainblock.GetByTransactionStatus(ts).Select(t => t.To).ToArray();

            IEnumerable<string> actual = this.chainblock.GetAllReceiversWithTransactionStatus(ts);

            CollectionAssert.AreEqual(result, actual);
        }

        [Test]
        public void TestGettinAllReceiversWithNonExistingStatus()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized);
            });
        }

        [Test]
        public void TestGetAllOrderedByAmountDescendingThenByIdReturnsOrderedCollection()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            var resultCollection = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            bool areOrdered = true;
            double currentMax = resultCollection.First().Amount;
            double currentIdMax = resultCollection.First().Id;


            for (int i = 1; i < resultCollection.Count(); i++)
            {
                ITransaction currentTransaction = resultCollection[i];

                if (currentTransaction.Amount > currentMax)
                {
                    areOrdered = false;
                }
                else if (currentTransaction.Amount == currentMax)
                {
                    if (currentTransaction.Id < currentIdMax)
                    {
                        areOrdered = false;
                    }
                }

                currentMax = currentTransaction.Amount;
                currentIdMax = currentTransaction.Id;
            }

            Assert.IsTrue(areOrdered);
        }

        [Test]
        public void TestIfGetBySenderOrderedByAmountDescendingRetrnsCorrectCount()
        {
            int expectedCount = 3;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, ts, "Vanko", to, amount + 30));

            var resultCollection = this.chainblock.GetBySenderOrderedByAmountDescending(from);

            Assert.AreEqual(expectedCount, resultCollection.Count());
        }

        [Test]
        public void TestIfGetBySenderOrderedByAmountDescendingRetrnsCorrectNames()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, ts, "Vanko", to, amount + 30));

            var resultCollection = this.chainblock.GetBySenderOrderedByAmountDescending(from);

            bool result = resultCollection
                .All(t => t.From == from);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetBySenderOrderedByAmountDescendingRetrnsOrderedCollection()
        {
            Transaction t1 = new Transaction(2, ts, from, to, amount + 10);
            Transaction t2 = new Transaction(3, ts, from, to, amount + 20);

            this.chainblock.Add(t1);
            this.chainblock.Add(t2);
            this.chainblock.Add(new Transaction(4, ts, "Vanko", to, amount + 30));

            var expectedResult = new List<ITransaction>()
            {t2,t1, this.transaction };

            var resultCollection = this.chainblock.GetBySenderOrderedByAmountDescending(from).ToList();

            CollectionAssert.AreEqual(expectedResult, resultCollection);
        }

        [Test]
        public void TestGetBySenderOrderedByAmountDescendingWithNonExistingSender()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderOrderedByAmountDescending("Vanko");
            });
        }

        [Test]
        public void TestIfGetByReceiverOrderedByAmountDescendingRetrnsCorrectCount()
        {
            int expectedCount = 3;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, ts, from, "Vanko", amount + 30));

            var resultCollection = this.chainblock.GetByReceiverOrderedByAmountThenById(to);

            Assert.AreEqual(expectedCount, resultCollection.Count());
        }

        [Test]
        public void TestIfGetByReceiverOrderedByAmountDescendingRetrnsCorrectNames()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, ts, from, "Vanko", amount + 30));

            var resultCollection = this.chainblock.GetByReceiverOrderedByAmountThenById(to);

            bool result = resultCollection
                .All(t => t.To == to);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetByReceiverOrderedByAmountDescendingRetrnsOrderedCollection()
        {
            Transaction t1 = new Transaction(2, ts, from, to, amount);
            Transaction t2 = new Transaction(3, ts, from, to, amount + 20);

            this.chainblock.Add(t1);
            this.chainblock.Add(t2);
            this.chainblock.Add(new Transaction(4, ts, from, "Vanko", amount + 30));

            var expectedResult = new List<ITransaction>()
            {t2, this.transaction, t1 };

            var resultCollection = this.chainblock.GetByReceiverOrderedByAmountThenById(to).ToList();

            CollectionAssert.AreEqual(expectedResult, resultCollection);
        }

        [Test]
        public void TestGetByReceiverOrderedByAmountDescendingWithNonExistingReceiver()
        {
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByReceiverOrderedByAmountThenById("Vanko");
            });
        }

        [Test]
        public void TestIfGetByTransactionStatusAndMaxAmountReturnsCorrectTr()
        {
            double maxAmount = amount + 20;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Unauthorized, from, to, amount));
            this.chainblock.Add(new Transaction(5, ts, from, to, amount + 30));

            var resultCollection = this.chainblock.GetByTransactionStatusAndMaximumAmount(ts, maxAmount);

            bool result = resultCollection.All(t => t.Status == ts && t.Amount <= maxAmount);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetByTransactionCodeAndMaxAmountReturnsOrderedCollection()
        {
            double maxAmount = amount + 20;

            Transaction t1 = new Transaction(2, ts, from, to, amount);
            Transaction t2 = new Transaction(3, ts, from, to, amount + 20);
            Transaction t3 = new Transaction(4, TransactionStatus.Unauthorized, from, to, amount);
            Transaction t4 = new Transaction(5, ts, from, to, amount + 30);

            var expectedResult = new List<ITransaction>()
            {
                t2,
                t1,
                this.transaction
            };

            this.chainblock.Add(t1);
            this.chainblock.Add(t2);
            this.chainblock.Add(t3);
            this.chainblock.Add(t4);

            List<ITransaction> actual = this.chainblock.GetByTransactionStatusAndMaximumAmount(ts, maxAmount).ToList();

            CollectionAssert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void TestGetByStatusAndMaxAmountWhenThereIsNoCorrespondingItemsToStatus()
        {
            IEnumerable<ITransaction> resultCollection = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorized, amount + 10);

            CollectionAssert.IsEmpty(resultCollection);
        }

        [Test]
        public void TestGetByStatusAndMaxAmountWhenThereIsNoCorrespondingItemsToAmount()
        {
            IEnumerable<ITransaction> resultCollection = this.chainblock.GetByTransactionStatusAndMaximumAmount(ts, amount - 10);

            CollectionAssert.IsEmpty(resultCollection);
        }

        [Test]
        public void TestGetBySenderAndMinAmountDescendingReturnsIntendetTransactions()
        {
            double minAmount = amount - 20;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            this.chainblock.Add(new Transaction(4, ts, "Vanko", to, amount));
            this.chainblock.Add(new Transaction(5, ts, from, to, amount - 30));

            var resultCollection = this.chainblock.GetBySenderAndMinimumAmountDescending(from, minAmount);

            bool result = resultCollection.All(t => t.From == from && t.Amount >= minAmount);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetBySenderAndMinAmountDescendingReturnsOrderedCollection()
        {
            double minAmount = amount - 10;

            Transaction t1 = new Transaction(2, ts, from, to, amount + 10);
            Transaction t2 = new Transaction(3, ts, from, to, amount + 20);
            Transaction t3 = new Transaction(4, ts, "Vanko", to, amount);
            Transaction t4 = new Transaction(5, ts, from, to, amount - 30);

            var expectedResult = new List<ITransaction>()
            {
                t2,
                t1,
                this.transaction
            };

            this.chainblock.Add(t1);
            this.chainblock.Add(t2);
            this.chainblock.Add(t3);
            this.chainblock.Add(t4);

            List<ITransaction> actual = this.chainblock.GetBySenderAndMinimumAmountDescending(from, minAmount).ToList();

            CollectionAssert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void TestGetBySenderAndMinAmountDescendingWithNonExistingSender()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderAndMinimumAmountDescending("Vank0", amount - 10);
            });
        }

        [Test]
        public void TestGetBySenderAndMinAmountDescendingWithInvalidAmount()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderAndMinimumAmountDescending("Vank0", amount + 10);
            });
        }

        [Test]
        public void TestGetAllInAmountRangeWorksCorrectly()
        {
            double minAmount = amount + 5;
            double maxAmount = amount + 25;

            int expectedCount = 2;
            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            var resultCollection = this.chainblock.GetAllInAmountRange(minAmount, maxAmount);

            bool result = resultCollection.All(t => t.Amount >= minAmount && t.Amount < maxAmount);

            Assert.AreEqual(expectedCount, resultCollection.Count());
            Assert.IsTrue(result);
        }

        [Test]
        public void TestGetAllInAmountRangeWorksWithoutTransactionRespondingToTheArgs()
        {
            double minAmount = amount + 35;
            double maxAmount = amount + 45;

            this.chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            this.chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            var resultCollection = this.chainblock.GetAllInAmountRange(minAmount, maxAmount);

            CollectionAssert.IsEmpty(resultCollection);
        }


        //To Do GetByReceiverAndAmountRange(receiver, lo, hi) tests
    }
}
