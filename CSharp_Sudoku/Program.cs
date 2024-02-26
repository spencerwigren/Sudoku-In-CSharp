
namespace CSharp_Sudoku;
using System;

public class Program
{
        public static void ShowBoard(int[,] board)
        {
            int newLine = 1;
            int verticalLineCount = 0;
            string horizontalLine = " | - - - + - - - + - - - |";
            string horizontalLineDivider = " |-------+-------+-------|";
            int sideNumber = 2;
            
            Console.Write("\n   1 2 3   4 5 6   7 8 9\n +-------+-------+-------+\n1| ");

            foreach (var item in board)
            {
                // Settings Vertical lines
                if (verticalLineCount is 3)
                {
                    Console.Write("| "); // Want two space
                    verticalLineCount = 1;
                }
                else
                {
                    verticalLineCount++;
                }
                
                // Settings value 0 in board to blank
                if (item == 0)
                {
                    Console.Write(" "); // replacing all 0 in the list to blank
                }
                else
                {
                    Console.Write(item);
                }
                
                // Starting New line info
                if (newLine % 9 == 0)
                {
                    Console.Write(" |"); // Want no space
                    Console.WriteLine();
                    if (sideNumber is 4 || sideNumber is 7)
                    {
                        Console.WriteLine(horizontalLineDivider);
                        Console.Write(sideNumber++ + "|"); // Want one space
                        // Settings here to start a new line count
                        verticalLineCount = 0;
                    }
                    // Did this becuase it would write line 10
                    // Where I need it to stop at 9
                    else if (sideNumber < 10)
                    {
                        Console.WriteLine(horizontalLine);
                        Console.Write(sideNumber++ + "|"); // Want one space
                        // Settings here to start a new line count
                        verticalLineCount = 0;
                    }


                }
                newLine++;
                Console.Write(" ");
            }
            // Helps with spacing in terminal
            Console.WriteLine("+-------+-------+-------+\n");
        }


        private static void Main()
    {
        int[,] Board = {
            {5,3,0,0,7,0,0,0,0},
            {6,0,0,1,9,5,0,0,0},
            {0,9,8,0,0,0,0,6,0},
            {8,0,0,0,6,0,0,0,3},
            {4,0,0,8,0,3,0,0,1},
            {7,0,0,0,2,0,0,0,6},
            {0,6,0,0,0,0,2,8,0},
            {0,0,0,4,1,9,0,0,5},
            {0,0,0,0,8,0,0,7,9}
            };

        ShowBoard(Board);
    }
}