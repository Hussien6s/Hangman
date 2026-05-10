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

        public bool WrongLetter() //lw el 7arf 8alat bn2alel el guess
        {
            if (guesses >= 1)
            {
                guesses--;
                return true;
            }
            else
            {
                //  throw new NoGuessesRemainingException("No more guesses remaining! Game Over.");
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
        public char AskUser() //bna5od mn el user el 7arf
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
                        return x; // Success! Exit the method
                    }
                    else
                    {
                        // This triggers the catch block below
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

