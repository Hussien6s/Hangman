using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{

    internal class Player : IUser
    {
        int score;
        int guesses;

        public Player() 
        {
            this.score = 0;
            this.guesses = 6;
        }

        public bool WrongLetter() 
        {
            if (guesses >= 1)
            {
                guesses--;
                return true;
            }
            else
            { 
                return false;
            }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public int Guesses
        {
            get { return guesses; }
            set { guesses = value; }
        }
        public char AskUser() 
        {
            while (true)
            {

                try
                {
                    Console.WriteLine("Enter a letter:");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                        throw new InvalidInputException("Input cannot be empty.");

                    if (input.Length > 1)
                        throw new InvalidInputException("Please enter exactly one letter.");

                    char x = char.ToLower(input[0]);
                    if (x >= 'a' && x <= 'z')
                    {
                        return x; 
                    }
                    else
                    {
                        
                        throw new InvalidInputException("That is not a letter.");
                    }
                }
                catch (InvalidInputException e)
                {
                    Console.WriteLine($"Error: {e.Message} Please try again.");
                }
            }
        }
        public void AddScore(int x)
        {
            score += x;
        }

    }
}

