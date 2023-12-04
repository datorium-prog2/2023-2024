using DatoriumBank.Data.Entity;
using DatoriumBank.Data.Managers;
using DatoriumBank.Data.Managers.Interface;

namespace DatoriumBank.Business
{
    public class BankTransactionsService
    {
        private readonly ITransactionManager _transactionManager;
        private readonly IAccountManager _accountManager;
        public BankTransactionsService(ITransactionManager transactionManager, 
            IAccountManager accountManager)
        {

            _transactionManager = transactionManager;
            _accountManager = accountManager;
        }

        public void AddTransaction(BankTransaction bankTransaction)
        {
            //Pārbaudam vai sūtītāja konts eksistē
            //Pārbaudam vai ir nauda AccountManager
            //Pārbaudam vai saņēmēja konts eksistē
            //Nosūtīt naudu uz receiverAccount
            var senderAccount = _accountManager.GetAccount(bankTransaction.SenderAccountId);
            var receiverAccount = _accountManager.GetAccount(bankTransaction.ReceiverAccountId);
            if (senderAccount != null && receiverAccount != null && senderAccount.Money - bankTransaction.Amount > 0)
            {
                _transactionManager.AddTransaction(bankTransaction);
                //pieskaitam naudu
                //saņemam naudu
                //update abus account
            }
            else
            {
                //throw exception
            }
        }
    }
}
