
using DataStructures;

var spore = new GraphExample();
spore.StartGame();

while (true)
{
    spore.GetDestinations();
    Console.WriteLine("Enter destination:");
    string destination = Console.ReadLine();

    spore.GoTo(destination);
    if (destination.ToLower() == "exit")
    {
        break;
    }
}