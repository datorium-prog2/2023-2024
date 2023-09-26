using System;
                    
public class Program
{
    public static void Main()
    {
        var cat1 = new Cat("Emi");        
        cat1.MakeSound();
        
        var dog1 = new Dog("Buddy");
        dog1.MakeSound();
    }
}

public abstract class Animal
{
    private string _name;    
    public string Name {get; set;}
    
    public Animal(string name)
    {
        Name = name;
    }
    
    public virtual void MakeSound()
    {
        Console.WriteLine($"{Name} is making sound...");
    }
}

public class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }
    
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says meow...");
    }
}

public class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }
}
