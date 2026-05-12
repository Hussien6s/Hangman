using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{
    internal class EasyWord : Word
    {
        static List<string> Words = null;
        public EasyWord()
        {
            if (Words == null || Words.Count == 0)
            {
                try {
                    Words = new List<string>(File.ReadAllLines("EasyWords.txt"));
                } catch {
                    Words = new List<string> { "Hello", "University", "Welcome", "World", "Classes" };
                }
            }
        }
        public override string RandomWord()
        {
            int index = Random.Shared.Next(Words.Count);
            Secret_Word = Words[index];
            Words.RemoveAt(index);
            return Secret_Word;
        }

    }
}

