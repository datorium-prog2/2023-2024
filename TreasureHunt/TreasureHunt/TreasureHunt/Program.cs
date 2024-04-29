using GameDatabase;
using TreasureHunt;

namespace GameDatabase
{
    public class Game
    {

        public char[,] Grid;
        public int PlayerX;
        public int PlayerY;
        public int points;
        public Dictionary<(int x, int y), PickableObjects> PickableObjects = new Dictionary<(int x, int y), PickableObjects>();
        public Game()
        {
            points = 0;
            Grid = new char[10, 10];

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (random.Next(0, 10) == 1)
                    {
                        if (random.Next(0, 2) == 1)
                        {
                            PickableObjects.Add((i, j), new Treasure() { Points = 100, Name = "zelta dālderis" });
                        }
                        else
                        {
                            PickableObjects.Add((i, j), new Trap() { Damage = 10, Name = "lāču slazds" });
                        }

                    }
                    else
                    {
                        Grid[i, j] = 'O';
                    }

                }
            }

            PlayerX = 0;
            PlayerY = 0;
            Grid[PlayerX, PlayerY] = 'V';
        }

        public void PrintGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Grid[i, j] == 'V')
                    {
                        Console.Write("V");
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Tev ir {points} punkti!");
        }

        public void MovePlayer(int deltaX, int deltaY)
        {
            int newX = PlayerX + deltaX;
            int newY = PlayerY + deltaY;

            Console.Clear();

            if (newX >= 0 && newX < 10 && newY >= 0 && newY < 10)
            {

                //int pointsToAdd = GetValue(Grid[newX, newY]);

                //points += pointsToAdd;

                Grid[PlayerX, PlayerY] = 'O';
                PlayerX = newX;
                PlayerY = newY;
                Grid[PlayerX, PlayerY] = 'V';

                PrintGrid();
                //if (pointsToAdd == 20)
                //{
                //    Console.WriteLine("Tu atradi sudraba gabalu, dabūji 20 dālderus!");
                //}
                //else if (pointsToAdd == 100)
                //{
                //    Console.WriteLine("Tu atradi zelta gabalu, dabūji 100 dālderus!");
                //}
                if (PickableObjects.ContainsKey((newX, newY)))
                {
                    var pickedUpObject = PickableObjects[(newX, newY)];
                    pickedUpObject.ActionOnPickup();
                    if (pickedUpObject is Treasure)
                    {
                        points += (pickedUpObject as Treasure).Points;
                    }
                    else if (pickedUpObject is Trap)
                    {
                        //Health -= (pickedUpObject as Trap).Damage;
                    }
                }
            }

            else
            {
                PrintGrid();
                Console.WriteLine("Tev nebūs pārkāpt spēles laukuma robežu!");
            }



        }

        public Dictionary<char, int> Treasures = new Dictionary<char, int>
        {
            { 'X', 100 },
            { 'H', 20 }
        };

        public int GetValue(char treasureType)
        {
            return Treasures.ContainsKey(treasureType) ? Treasures[treasureType] : 0;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.PrintGrid();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    game.MovePlayer(-1, 0);
                    break;
                case ConsoleKey.S:
                    game.MovePlayer(1, 0);
                    break;
                case ConsoleKey.A:
                    game.MovePlayer(0, -1);
                    break;
                case ConsoleKey.D:
                    game.MovePlayer(0, 1);
                    break;
                default:
                    continue;
            }
        }
    }
}