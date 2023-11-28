using DatoriumBank.Data.Entity;

namespace DatoriumBank.Data.Managers.Interface
{
    public interface ITransactionManager
    {
        void AddTransaction(BankTransaction transaction);
        List<BankTransaction> GetTransactions(int accountId);
    }
}
