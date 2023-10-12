using System;
using System.Data.SQLite;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Today we will create SQLight database using C#");
		
		var dbManager = new DatabaseManager("Data Source=madatabase.db;Version=3;");		
		dbManager.InitializeDatabase();
		
		var client1 = new Client("Anna", "Bērziņa", "anna.b@somemail.com");
		dbManager.AddClient(client1);
		
		
	}
}

class DatabaseManager
{
	private string _connectionString;
	
	public DatabaseManager(string connectionString)
	{
		this._connectionString = connectionString;
	}
	
	public void InitializeDatabase()
	{
		try
		{
			using (var connection = new SQLiteConnection(_connectionString))
			{
				//atvēram datubāzes pielēgumu
				connection.Open();

				//darbības ar datubāzi
				string createTableSQL = "CREATE TABLE IF NOT EXISTS Clients(ClientID INTEGER PRIMARY KEY AUTOINCREMENT, ClientName TEXT, ClientSurname TEXT, ClientEmail TEXT)";
				using (var createTableCmd = new SQLiteCommand(createTableSQL, connection))
				{
					createTableCmd.ExecuteNonQuery();
				}
				Console.WriteLine("Datbase successfully initialized!");
			}
		}
		catch(Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
		}
			
		//izmantosim using lai automātiski aizvertu datubāzi pēc darbībām ar to
	}
	
	public void AddClient(Client client)
	{
		//te mēs pievienosim klienta datus datubāzē
	}
		
}

class Client
{
	public string Name {get; set;}
	public string Surname {get; set;}
	public string Email {get; set;}	
	
	public Client(string name, string surname, string email)
	{
		Name = name;
		Surname = surname;
		Email = email;
	}		
}
