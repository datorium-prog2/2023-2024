using DatoriumDex;

var fireMonster = new FireMonster();
var grassMonster = new GrassMonster();


Console.WriteLine("Sveiks, Ogles salamander.");
Console.WriteLine("Tu esi saticis siipolinu.");


while (fireMonster.Health > 0 && grassMonster.Health > 0)
{
    Console.WriteLine($"Tavas dzivibas {fireMonster.Health}");
    Console.WriteLine($"Siipolina dzivibas {grassMonster.Health}");
    Console.WriteLine();

    Console.WriteLine("Izvelies action");
    Console.WriteLine("1. Basic attack");
    Console.WriteLine("2. Special attack");

    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
    Console.Clear();
    if (keyInfo.Key == ConsoleKey.D1)
    {
        Console.WriteLine("Tu uzbruki ar parasto sitienu");

        fireMonster.BasicAttackMonster(grassMonster);
    }
    else if (keyInfo.Key == ConsoleKey.D2)
    {
        Console.WriteLine($"Tu uzbruki ar {fireMonster.MonsterType} sitienu");

        fireMonster.SpecialAttackMonster(grassMonster);
    }

    Console.WriteLine();

    var rand = new Random();
    if(rand.NextDouble() >= 0.5)
    {
        Console.WriteLine($"Tev uzbruka ar {grassMonster.MonsterType} sitienu");

        grassMonster.SpecialAttackMonster(fireMonster);
    }
    else
    {
        Console.WriteLine("Tev uzbruka ar parasto sitienu");

        grassMonster.BasicAttackMonster(fireMonster);
    }
    Console.ReadLine();
}