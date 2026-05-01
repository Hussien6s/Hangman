using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class EasyWord : Word
    {
        List<string> Words;
        public EasyWord()
        {
            Words = new List<string> { "Hello", "University", "Welcome", "World", "Classes" };
        }
        public override string RandomWord()
        {
            secret_Word = Words[Random.Shared.Next(Words.Count)];
            return secret_Word;
        }

    }
}

