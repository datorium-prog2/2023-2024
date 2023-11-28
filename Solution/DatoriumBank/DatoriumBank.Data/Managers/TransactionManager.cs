using DatoriumBank.Data.Entity;
using DatoriumBank.Data.Managers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatoriumBank.Data.Managers
{
    public class TransactionManager : ITransactionManager
    {
        private BankDbContext _bankDbContext;

        public TransactionManager(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public void AddTransaction(BankTransaction transaction)
        {
            _bankDbContext.Transactions.Add(transaction);
            _bankDbContext.SaveChanges();
        }

        public void DeleteTransaction(int transactionId)
        {
            var bankTransaction = _bankDbContext.Transactions.First(transaction => transaction.Id == transactionId);
            bankTransaction.IsDeleted = true;
            _bankDbContext.SaveChanges();
        }

        public List<BankTransaction> GetTransactions(int accountId)
        {
            return _bankDbContext.Transactions
                .Where(transaction => !transaction.IsDeleted 
                    && (transaction.SenderAccountId == accountId
                        || transaction.ReceiverAccountId == accountId))
                .ToList();
        }
    }
}
