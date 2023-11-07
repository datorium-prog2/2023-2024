class UserManager : IUserManager
{
    private BankDbContext _bankDbContext;

    public UserManager(BankDbContext bankDbContext)
    {
        _bankDbContext = bankDbContext;
    }

    public void AddClient(Client client)
    {
        _bankDbContext.Clients.Add(client);
        _bankDbContext.SaveChanges();
    }

    public List<Client> GetClients(string name)
    {
        return _bankDbContext.Clients
            .Where(client => client.Name == name)
            .ToList();
    }
}
