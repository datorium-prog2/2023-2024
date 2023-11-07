namespace DatoriumBank.Data
{
    public interface IAccountManager
    {
        public void AddAccount(Account account);
        public Account GetAccount(int id);
    }
}
