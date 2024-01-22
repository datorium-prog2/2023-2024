using System;

namespace DataStructures
{
    // 1. Uzģenērēt 10x10 masīvu ar 10% iespēju, ka konkrētajā cell ir mīna
    // 2. 
    public class Minesweeper
    {
        private int[][] Grid { get; set; }
        private int[][] MineGrid { get; set; }
        private int Size { get; set; } // 10

        public Minesweeper(int size = 10)
        {
            Size = size;
            Grid = new int[size][];
            MineGrid = new int[size][];
            PopulateGrids(); //Aizpildam režģi
            PopulateMines();
            GetMineGrid();
        }

        private void PopulateGrids() //Šeit mēs aizpildam masīvus ar nullītēm
        {
            for (int i = 0; i < Size; i++)
            {
                Grid[i] = new int[Size]; //Rinda, kurā mēs izveidojam jauno masīvu
                MineGrid[i] = new int[Size];
                for (int j = 0; j < Size; j++)
                {
                    Grid[i][j] = 0;
                    MineGrid[i][j] = 0;
                }
            }
        }

        private void PopulateMines()
        //0 drošība
        //1 mīna
        {
            var random = new Random();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var chance = random.Next(10);
                    if (chance == 0)
                    {
                        MineGrid[i][j] = 1;

                        PopulateDetectors(i, j);
                    }
                }
            }
        }

        private void PopulateDetectors(int i, int j)
        {
            // Check boundaries before incrementing
            // Vertikāli
            if (i - 1 >= 0 && i - 1 < Size)
                Grid[i - 1][j]++;
            if (i + 1 >= 0 && i + 1 < Size)
                Grid[i + 1][j]++;

            // Horizontāli
            if (j - 1 >= 0 && j - 1 < Size)
                Grid[i][j - 1]++;
            if (j + 1 >= 0 && j + 1 < Size)
                Grid[i][j + 1]++;

            // Kreisie stūri
            if (i - 1 >= 0 && i - 1 < Size && j - 1 >= 0 && j - 1 < Size)
                Grid[i - 1][j - 1]++;
            if (i + 1 >= 0 && i + 1 < Size && j - 1 >= 0 && j - 1 < Size)
                Grid[i + 1][j - 1]++;

            // Labie stūri
            if (i - 1 >= 0 && i - 1 < Size && j + 1 >= 0 && j + 1 < Size)
                Grid[i - 1][j + 1]++;
            if (i + 1 >= 0 && i + 1 < Size && j + 1 >= 0 && j + 1 < Size)
                Grid[i + 1][j + 1]++;
        }

        public void GetMineGrid()
        {   // 5x5
            // Size = 5
            // [  j  0  1  2  3  4
            //  i
            //  0: [ 0, 0, 0, 0, 0]
            //  1: [ 0, 0, 0, 0, X]
            //  2: [ 0, X, 0, 0, 0]
            //  3: [ 0, 0, 0, X, 0]
            //  4: [ 0, 0, 0, 0, 0]
            // ]
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Size; j++)
                {
                    if (MineGrid[i][j] == 1)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write(Grid[i][j] + " ");
                    }
                }
            }
        }
    }
}
