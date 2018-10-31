using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Hello! Welcome to TicTacToe!");
            Console.WriteLine("Instructions:");
            Console.WriteLine("This is the classic TicTacToe game, you will enter your moves according to the diagram below");
            Console.WriteLine();
            Console.WriteLine(" 1 | 2 | 3 ");
            Console.WriteLine("-----------");
            Console.WriteLine(" 4 | 5 | 6 ");
            Console.WriteLine("-----------");
            Console.WriteLine(" 7 | 8 | 9 ");
            Console.WriteLine();
            Console.Write("Would you like to play? (Y/N): ");
            String input = Console.ReadLine();
            while ((input != "N") && (input != "Y") && (input != "n") && (input != "y"))
            {
                Console.WriteLine("Invalid response, please type either Y or N");
                input = Console.ReadLine();
            }
            if (input == "n" || input == "N")
            {
                Console.WriteLine("Ok Bye");
            }
            else
            {
                Boolean done = false;
                while (!done)
                {
                    Console.WriteLine("Let's play!");
                    Console.Write("Enter name of Player1: ");
                    String p1 = Console.ReadLine();
                    Console.Write("Enter name of Player2: ");
                    String p2 = Console.ReadLine();
                    Player first = new Player(p1, "X");
                    Player second = new Player(p2, "O");
                    Game newGame = new Game(first, second);
                    newGame.play();
                    Console.Write("Would you like to play again? (Y/N): ");
                    input = Console.ReadLine();
                    while ((input != "N") && (input != "Y") && (input != "n") && (input != "y"))
                    {
                        Console.WriteLine("Invalid response, please type either Y or N");
                        input = Console.ReadLine();
                    }
                    if (input == "n" || input == "N")
                    {
                        Console.WriteLine("Ok Bye");
                        done = true;
                    }
                }
            }
        }
    }
}
