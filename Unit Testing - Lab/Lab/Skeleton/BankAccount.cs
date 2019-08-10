using System;

namespace Skeleton
{
    public class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal balance)
        {
            this.Balance = balance;
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance can not be negative!");
                }

                this.balance = value;
            }
        }

        public void Depotsit(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum must be positive number!");
            }

            this.Balance += sum;
        }

        public decimal Withdraw(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum must be positive number!");
            }

            this.Balance -= sum;

            return this.Balance;
        }
    }
}
