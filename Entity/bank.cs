using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
					
public class Program
{
	public static void Main()
	{
		var client1 = new Client("Anna", "Bērziņa", "anna.b@somemail.com");		
		var client2 = new Client("Nikola", "Ozoliņa", "nikola.o@somemail.com");
		Console.WriteLine("Šeit ir jaunā datubāzes menedžēšana");
		
		var bankDbContext = new BankDbContext();
		var userManager = new UserManager(bankDbContext);
		userManager.AddClient(client1);
		userManager.AddClient(client2);
		var clientsFromORM = userManager.GetClients("Anna");
		foreach(var client in clientsFromORM){
			Console.WriteLine($"{client.Name} {client.Surname} {client.Email}");
		}
	}
}

class BankDbContext : DbContext {
	public DbSet<Client> Clients{get;set;}
	public BankDbContext() {
		base.Database.EnsureCreated();
	}
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source=madatabase.db;");
	}
}

class UserManager : IUserManager {
	private BankDbContext _bankDbContext;
	
	public UserManager(BankDbContext bankDbContext){
		_bankDbContext = bankDbContext;
	}
	
	public void AddClient(Client client){
		_bankDbContext.Clients.Add(client);
		_bankDbContext.SaveChanges();
	}

	public List<Client> GetClients(string name){
		return _bankDbContext.Clients
			.Where(client => client.Name == name)
			.ToList();
	}
}

interface IUserManager {
	public void AddClient(Client client);
	public List<Client> GetClients(string name);
}

class Client
{
	[Key]
	[Column("ClientId")]
	public int Id {get;set;}
	[Column("ClientName")]
	public string Name {get; set;}
	[Column("ClientSurname")]
	public string Surname {get; set;}
	[Column("ClientEmail")]
	public string Email {get; set;}	
	
	public Client(string name, string surname, string email)
	{
		Name = name;
		Surname = surname;
		Email = email;
	}		
}
