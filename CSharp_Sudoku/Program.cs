
namespace CSharp_Sudoku;
using System;

public class Program
{
    public static Tuple<string?, string?, string?> UserModInput() 
    {
        Console.Write("Vetical Cell Number: ");
        string? VerticalNumber = Console.ReadLine();

        Console.Write("Horizonal Cell Number: ");
        string? HorizonalNumner = Console.ReadLine();
        // The ? infront of the string type is to help with nullable inputs

        Console.Write("New Value: ");
        string? NewValue = Console.ReadLine();

        Tuple<string?, string?, string?> ModValues = Tuple.Create(VerticalNumber, HorizonalNumner, NewValue);

        return ModValues;
    }
    
    public static int[,] EditBoard(int[,] board)
    {
        Tuple<string?, string?, string?> modInput = UserModInput();

        int row = Convert.ToInt32(modInput.Item1) -1;
        int col = Convert.ToInt32(modInput.Item2) - 1;
        int newValue = Convert.ToInt32(modInput.Item3); 
        
        board[col, row] = newValue;

        return board;
    }

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
        
    public static void ShowOptions()
    {
            Console.WriteLine("Options: \nShow Options again - S");
            Console.WriteLine("Display Baord - D");
            Console.WriteLine("Edit the Board - E");
            Console.WriteLine("Load File - F");
            Console.WriteLine("End Game - G\n");
    }
    
    public static string? UserInput()
    {
        Console.Write("> ");
        string? input = Console.ReadLine();
        return input;
    }

    private static void GameRunner(int[,] board)
    {
        bool run = true;

        while (run is true)
        {
            string? userInput = UserInput().ToUpper();

            switch (userInput)
            {
                case "S":
                    Console.WriteLine("Show Options");
                    ShowOptions();
                    break;

                case "D":
                    Console.WriteLine("Displaying Board");
                    ShowBoard(board);
                    break;

                case "E":
                    Console.WriteLine("Editing Board");
                    EditBoard(board);
                    ShowBoard(board);
                    break;

                case "F":
                    Console.WriteLine("Loading File");
                    break;

                case "G":
                    Console.WriteLine("End Game");
                    run = false;
                    break;
            }
        }
    }

    private static void Main()
    {
        int[,] board = {
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

        ShowBoard(board);
        ShowOptions();
        GameRunner(board);
    }
}