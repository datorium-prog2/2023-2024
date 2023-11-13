
using DatoriumBank.Data.Entity;

namespace DatoriumBank.Data.Managers.Interface
{
    public interface IAccountManager
    {
        public void AddAccount(Account account);
        public Account GetAccount(int id);
        public void UpdateAccount(Account account);

        //CRUD -> Create(Add) Read(Get) Update Delete
    }
}
