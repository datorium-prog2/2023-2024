
using DatoriumBank.Data.Entity;

namespace DatoriumBank.Data.Managers.Interface
{
    public interface IUserManager
    {
        public void AddClient(Client client);
        public List<Client> GetClients(string name);
    }
}