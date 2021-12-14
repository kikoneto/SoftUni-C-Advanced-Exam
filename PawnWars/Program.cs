using System;

namespace PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            //White
            int whiteRow = 0;
            int whiteCol = 0;
            //Black
            int blackRow = 0;
            int blackCol = 0;
            //Coordinates
            string[] letters = new string[8] { "a", "b", "c", "d", "e", "f", "g", "h" };
            char[,] field = new char[8, 8];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                string n = Console.ReadLine();
                char[] input = n.ToCharArray();
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    field[i, j] = input[j];
                    if (field[i, j] == 'w')
                    {
                        whiteRow = i;
                        whiteCol = j;
                    }
                    else if (field[i, j] == 'b')
                    {
                        blackRow = i;
                        blackCol = j;
                    }
                }
            }
            int move = 0;
            while (whiteRow > 0 && blackRow < 7)
            {
                if (move % 2 == 0)
                {
                    field[whiteRow, whiteCol] = '-';
                    if (blackRow == whiteRow - 1 && blackCol == whiteCol - 1)
                    {
                        Console.WriteLine($"Game over! White capture on {letters[blackCol]}{8 - blackRow}.");
                        return;
                    }
                    else if (blackRow == whiteRow - 1 && blackCol == whiteCol + 1)
                    {
                        Console.WriteLine($"Game over! White capture on {letters[blackCol]}{8 - blackRow}.");
                        return;
                    }
                    whiteRow--;
                    field[whiteRow, whiteCol] = 'w';
                }
                else
                {
                    field[blackRow, blackCol] = '-';
                    if (whiteRow == blackRow + 1 && whiteCol == blackCol + 1)
                    {
                        Console.WriteLine($"Game over! Black capture on {letters[whiteCol]}{8 - whiteRow}.");
                        return;
                    }
                    else if (whiteRow == blackRow + 1 && whiteCol == blackCol - 1)
                    {
                        Console.WriteLine($"Game over! Black capture on {letters[whiteCol]}{8 - whiteRow}.");
                        return;
                    }
                    blackRow++;
                    field[blackRow, blackCol] = 'b';
                }
                move++;
            }
            //Print
            //White Winner
            if (whiteRow == 0)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {letters[whiteCol]}{8 - whiteRow}.");
            }
            //Black Winner
            if (blackRow == 7)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {letters[blackCol]}{8 - blackRow}.");
            }
        }
    }
}
