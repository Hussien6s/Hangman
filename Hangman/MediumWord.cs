using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class MediumWord:Word
    {
        List<string> Words;
        public MediumWord()
        {
            Words = new List<string> { "Hello World", "University of Canada", "Welcome Engineer", "World of Legends", "once upon a time" };
        }
        public override string RandomWord()
        {
            secret_Word = Words[Random.Shared.Next(Words.Count)];
            return secret_Word;
        }
    }
}
