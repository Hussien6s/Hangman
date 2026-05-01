using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class HardWord:Word
    {
        List<string> Words;
        public HardWord()
        {
            Words = new List<string> { 
                "back to the drawing board", 
                "Dad moved the new game to the bookshelf", 
                "are you sure it is safe to ride my bike down that path", 
                "Every player won an individual award", 
                "Hangman game is not easy" };
        }
        public override string RandomWord()
        {
            secret_Word = Words[Random.Shared.Next(Words.Count)];
            return secret_Word;
        }
    }
}
