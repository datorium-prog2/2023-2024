using System;

class Program
{
    static void Main(string[] args)
    {        
        var auth = new Authentificator();    
        
        var client1 = new Client("Anna", "123456-12356");
        
        var acc1 = new Account("LV12345");
        var acc2 = new Account("EE23456");
        var acc3 = new Account("LT34567");
        
        
        
        if(auth.CheckPassword("abc123"))
        {
            client1.ChangeName("Elza");
        }
        else
        {
            Console.WriteLine("Authentification failed, password is incorrect!");
        }
           
        Console.WriteLine(client1.Introduce("Hey"));
        
    }
}

class Account
{
    private string _accountNumber;
    
    public string AccountNumber 
    {
        get {return _accountNumber;}
        private set 
        {
            if(value.Length == 7)
            {
                _accountNumber = value;    
            }
            else
            {
                throw new ArgumentException("Error: account number must contain 7 symbols!");
            }
                
        }    
    }
    
    public Account(string accountNumber)
    {
        try
        {
            AccountNumber = accountNumber;
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }    
    }        
}

class Client
{
    private string _name;
    private string _ssn;
    
    public string Name 
    {
        get {return _name;}        
        private set
        {
            if(value != null && value.Length >= 2)
            {
                _name = value;
            }
            else
            {
                throw new ArgumentException("Name can not be null or less than 2 symbols!");
            }    
        }    
    }
    
    public string SSN 
    {
        get {return _ssn;}        
        private set
        {
            if(value.Length == 12)
            {
                _ssn = value;
            }
            else
            {
                throw new ArgumentException("SSN must contain 12 symbols!");
            }    
        }    
    }
    
    public Client(string name, string ssn)
    {
        try
        {
            Name = name;
            SSN = ssn;
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    public void ChangeName(string newName)
    {
        //Autherntificate first    
        Name = newName;        
    }
    
    public string Introduce(string greeting)
    {
        return $"{greeting}, my name is {Name} and my SSN is {SSN}";
    }
}

class Authentificator
{
    private string _correctPassword = "abc123";
    
    public bool CheckPassword(string password)
    {
        if(password == _correctPassword)
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }    
}
