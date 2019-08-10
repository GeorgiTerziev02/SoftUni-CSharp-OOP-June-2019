using Chainblock.Contracts;
using System;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;
        private TransactionStatus transactionStatus;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus transactionStatus, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = transactionStatus;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id should be positive!");
                }

                this.id = value;
            }
        }
        public TransactionStatus Status
        {
            get
            {
                return this.transactionStatus;
            }
            set
            {
                this.transactionStatus = value;
            }
        }
        public string From
        {
            get
            {
                return this.from;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sender name should not be whitespace or empty!");
                }

                this.from = value;
            }
        }

        public string To
        {
            get
            {
                return this.to;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Receiver name should not be whitespace or empty!");
                }

                this.to = value;
            }
        }

        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount value must be positive!");
                }

                this.amount = value;
            }
        }

        public int CompareTo(ITransaction other)
        {
            throw new NotImplementedException();
        }
    }
}
