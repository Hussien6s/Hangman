using System;
namespace Hangman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char playagain='n';
            Game g1 = new Game();

            do
            {
                g1.StartGame();
                Console.WriteLine("\nDo you want to play again? (y/n)");
                playagain = char.ToLower(Console.ReadLine()[0]);
            } while (playagain == 'y'); // feh moshkela fel playagain msh by3ml 7aga
        }
    }
}