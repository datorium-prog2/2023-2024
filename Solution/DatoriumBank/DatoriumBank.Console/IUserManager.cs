public interface IUserManager
{
    public void AddClient(Client client);
    public List<Client> GetClients(string name);
}
