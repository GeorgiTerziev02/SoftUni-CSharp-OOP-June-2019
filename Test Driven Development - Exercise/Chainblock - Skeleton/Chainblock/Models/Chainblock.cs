using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private Dictionary<int, ITransaction> byId;
        private Dictionary<TransactionStatus, HashSet<ITransaction>> byStatus;
        public Chainblock()
        {
            this.byId = new Dictionary<int, ITransaction>();
            this.byStatus = new Dictionary<TransactionStatus, HashSet<ITransaction>>();
        }

        public int Count => this.byId.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new InvalidOperationException("Transaction already exists!");
            }

            this.byId[tx.Id] = tx;

            if (!this.byStatus.ContainsKey(tx.Status))
            {
                this.byStatus[tx.Status] = new HashSet<ITransaction>();
            }

            this.byStatus[tx.Status].Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.byId.ContainsKey(id))
            {
                throw new ArgumentException("The was no such transaction with this id!");
            }

            ITransaction transaction = this.byId[id];
            this.byStatus[transaction.Status].Remove(transaction);

            transaction.Status = newStatus;

            if (!this.byStatus.ContainsKey(newStatus))
            {
                this.byStatus[newStatus] = new HashSet<ITransaction>();
            }

            this.byStatus[newStatus].Add(transaction);
        }

        public bool Contains(ITransaction tx)
        {
            return this.byId.Values.Contains(tx);
        }

        public bool Contains(int id)
        {
            if (id < 0)
            {
                throw new InvalidOperationException("Id must be zero or positive");
            }

            return this.byId.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            IEnumerable<ITransaction> result = this.byId.Values
                  .Where(tr => tr.Amount < hi)
                  .Where(tr => tr.Amount >= lo)
                  .OrderByDescending(tr => tr.Amount);

            return result;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.byId.Values.OrderByDescending(tr => tr.Amount).ThenBy(tr => tr.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (!this.byStatus.ContainsKey(status))
            {
                throw new InvalidOperationException("There are not any transactions with this status!");
            }

            List<string> receivers = this.byStatus[status]
                .OrderByDescending(tr => tr.Amount)
                .Select(tr => tr.To)
                .ToList();

            if (receivers.Count == 0)
            {
                throw new InvalidOperationException("There are not any transactions with this status!");
            }

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (!this.byStatus.ContainsKey(status))
            {
                throw new InvalidOperationException("There are not any transactions with this status!");
            }

            List<string> senders = this.byStatus[status]
                .OrderByDescending(tr => tr.Amount)
                .Select(tr => tr.From)
                .ToList();

            if (senders.Count == 0)
            {
                throw new InvalidOperationException("There are not any transactions with this status!");
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!this.byId.ContainsKey(id))
            {
                throw new InvalidOperationException("Non existing id provided!");
            }

            return this.byId[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            if (!this.byId.Values.Any(tr => tr.To == receiver))
            {
                throw new InvalidOperationException("There is not receiver with that name");
            }

            IEnumerable<ITransaction> result = this.byId.Values
                .Where(tr => tr.To == receiver)
                .Where(tr => tr.Amount < hi)
                .Where(tr => tr.Amount >= lo)
                .OrderByDescending(tr => tr.Amount);

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> result = this.byId.Values
                .Where(tr => tr.To == receiver)
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            if (!this.byId.Values.Any(t => t.From == sender))
            {
                throw new InvalidOperationException("There is not sender with this name!");
            }

            IEnumerable<ITransaction> result = this.byId.Values
                .Where(t => t.From == sender)
                .Where(tr => tr.Amount >= amount)
                .OrderByDescending(tr => tr.Amount);

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> result = this.byId.Values.Where(tr => tr.From == sender).OrderByDescending(tr => tr.Amount);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!this.byStatus.ContainsKey(status))
            {
                throw new InvalidOperationException("There are not any transactions with this status!");
            }

            HashSet<ITransaction> wantedTr = this.byStatus[status];

            if (wantedTr.Count == 0)
            {
                throw new InvalidOperationException("There are not any transactions with this status!");
            }

            return wantedTr
                .OrderByDescending(t => t.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            IEnumerable<ITransaction> result = this.byId.Values
                .Where(tr => tr.Status == status)
                 .Where(tr => tr.Amount <= amount)
                 .OrderByDescending(tr => tr.Amount)
                 .ThenByDescending(tr => tr.Id);

            return result;
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.byId.ContainsKey(id))
            {
                throw new InvalidOperationException("You can not remove non existing transaction!");
            }

            ITransaction tr = this.byId[id];

            this.byStatus[tr.Status].Remove(tr);
            this.byId.Remove(tr.Id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
