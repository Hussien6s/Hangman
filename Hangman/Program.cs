using System;
namespace Hangman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char playagain = 'n';
            Game g1 = new Game();

            do
            {
                g1.StartGame();
                while (true)
                {
                    Console.WriteLine("\nDo you want to play again? (y/n)");
                    string input = Console.ReadLine();
                    
                    if (!string.IsNullOrEmpty(input))
                    {
                        playagain = char.ToLower(input[0]);
                        if (playagain == 'y' || playagain == 'n')
                        {
                            break; // Exit the prompt loop if valid input
                        }
                    }
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            } while (playagain == 'y'); 
        }
    }
}