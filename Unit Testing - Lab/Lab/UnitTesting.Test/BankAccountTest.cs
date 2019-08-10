using NUnit.Framework;
using Skeleton;

namespace UnitTesting.Test
{
    [TestFixture]
    public class BankAccountTest
    {
        private BankAccount bankAccount;

        [SetUp]
        public void CreateBankAccount()
        {
            this.bankAccount = new BankAccount(100m);
        }

        [TearDown]
        public void DestroyBankAccount()
        {
            this.bankAccount = null;
        }

        [Test]
        public void TestNewBankAccount()
        {
            Assert.That(bankAccount.Balance, Is.EqualTo(100m), "Creating new Bank Account");
        }

        [Test]
        public void TestNewBankAccountWithNegativeBalance()
        {
            Assert.That(() => new BankAccount(-100m), Throws.ArgumentException.With.Message.EqualTo("Balance can not be negative!"));
        }

        [Test]
        public void TestDeposit()
        {
            bankAccount.Depotsit(100m);

            Assert.That(bankAccount.Balance, Is.EqualTo(200m));
        }

        [Test]
        public void TestDepositWithNegativeSum()
        {
            Assert.That(() => bankAccount.Depotsit(-50), Throws.ArgumentException.With.Message.EqualTo("Sum must be positive number!"));
        }

        [Test]
        public void TestWithdraw()
        {
            decimal balance = bankAccount.Withdraw(34m);

            Assert.That(bankAccount.Balance, Is.EqualTo(balance));
        }

        [Test]
        public void TestWithdrawMoreThanBalance()
        {
            Assert.That(() => bankAccount.Withdraw(500m), Throws.Exception.With.Message.EqualTo("Balance can not be negative!"));
        }
    }
}
