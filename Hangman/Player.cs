using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class InvalidInputException : Exception  //3yzeen nzbot el exception deh
    {
        public InvalidInputException(string message) : base(message) { }
    }
    internal class Player: IUser
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
        public int Score {
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
            Console.WriteLine("Enter a letter");
            char x = char.ToLower(Console.ReadLine()[0]);
            if (x>='a'&&x<='z')
                return x;
            else
                throw new InvalidInputException("The character '" + x + "' is not a valid letter.");
        }
        public void AddScore(int x) 
        {
            score += x;
        }

    }
}

