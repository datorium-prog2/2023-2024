
using DatoriumBank.Business;
using DatoriumBank.Data;
using DatoriumBank.Data.Entity;
using DatoriumBank.Data.Managers;

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
        Console.WriteLine($"Konts pēc pievienošanas {accountFromDb.Client.Name} {accountFromDb.IBAN} {accountFromDb.Name}");

        accountFromDb.Name = "Izklaides konts";
        accountManager.UpdateAccount(accountFromDb);
        Console.WriteLine($"Konts pēc Update {accountFromDb.Client.Name} {accountFromDb.IBAN} {accountFromDb.Name}");

        var newAccountFromDb = accountManager.GetAccount(account.Id);
        Console.WriteLine($"Update'otais konts no datubāzes pēc Update {newAccountFromDb.Client.Name} {newAccountFromDb.IBAN} {newAccountFromDb.Name}");
        ShowMenu();
    }

    public static void ShowMenu()
    {
        Console.WriteLine("Pieejamās darbības:");
        Console.WriteLine("1. Pievienot jaunu klientu");
        Console.WriteLine("2. Dzēst klienta informāciju");
        ChooseAction();
    }

    public static void ChooseAction()
    {
        var action = Console.ReadLine();

        Console.WriteLine($"Klients veica {action}");
    }

    /*
    //Saraksts ar klientiem:
    //1. Anna Bērziņa - epasts
    //2. vārds uzvārds epasts
    //3.  asdasdas
    //4. asdasdasd
    //
    //Pieejamās darbības:
    //1. Pievienot jaunu klientu
    //2. Dzēst klienta informāciju



    1

    //Ievadi klienta vārdu
    //Ievadi klienta uzvārdu
    //Ievadi klienta e-pastu

    2

    Ievadi klienta ID
    //*/
}