using DatoriumBank.Data.Entity;
using DatoriumBank.Data.Managers.Interface;
using Microsoft.EntityFrameworkCore;

namespace DatoriumBank.Data.Managers
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

        public void UpdateAccount(Account account)
        {
            _bankDbContext.Accounts.Update(account);
            _bankDbContext.SaveChanges();
        }

        public void DeleteAccount(int id)
        {
            var account = _bankDbContext.Accounts
                .First(account => account.Id == id);
            _bankDbContext.Accounts.Remove(account);
            _bankDbContext.SaveChanges();
        }
    }
}