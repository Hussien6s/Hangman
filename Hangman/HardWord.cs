using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{
    internal class HardWord:Word
    {
        static List<string> Words = null;
        public HardWord()
        {
            if (Words == null || Words.Count == 0)
            {
                try {
                    Words = new List<string>(File.ReadAllLines("HardWords.txt"));
                } catch {
                    Words = new List<string> { 
                        "back to the drawing board", 
                        "Dad moved the new game to the bookshelf", 
                        "are you sure it is safe to ride my bike down that path", 
                        "Every player won an individual award", 
                        "Hangman game is not easy" };
                }
            }
        }
        public override string RandomWord()
        {
            int index = Random.Shared.Next(Words.Count);
            secret_Word = Words[index];
            Words.RemoveAt(index);
            return secret_Word;
        }
    }
}
