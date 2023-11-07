using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DatoriumBank.Console
{
    public class AccountManager : IAccountManager
    {
        private BankDbContext _bankDbContext;

        public AccountManager(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public void AddAccount(Account account)
        {
            _bankDbContext.Accounts.Add(account);
            _bankDbContext.SaveChanges();
        }
        public Account GetAccount(int id)
        {
            return _bankDbContext.Accounts
                .Include(x => x.Client)
                .First(account => account.Id == id);
        }
    }
}