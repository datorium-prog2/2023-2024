
using DatoriumBank.Business;
using DatoriumBank.Data;

public class Program
{
    public static void Main()
    {
        var client1 = new Client("Anna", "Bērziņa", "anna.b@somemail.com");
        var client2 = new Client("Nikola", "Ozoliņa", "nikola.o@somemail.com");
        Console.WriteLine("Šeit ir jaunā datubāzes menedžēšana");

        var userService = new UserService();

        var bankDbContext = new BankDbContext();
        var userManager = new UserManager(bankDbContext);
        userManager.AddClient(client1);
        userManager.AddClient(client2);
        var clientsFromORM = userManager.GetClients("Anna");
        foreach (var client in clientsFromORM)
        {
            Console.WriteLine($"{client.Name} {client.Surname} {client.Email}");
        }
        var account = new Account()
        {
            IBAN = "LV12UNLA121354567567",
            ClientId = client1.Id,
            Name = "Darba konts"
        };
        var accountManager = new AccountManager(bankDbContext);
        accountManager.AddAccount(account);
        var accountFromDb = accountManager.GetAccount(account.Id);
        Console.WriteLine($"{accountFromDb.Client.Name} {accountFromDb.IBAN}");
    }
}