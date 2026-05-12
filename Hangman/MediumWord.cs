using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{
    internal class MediumWord:Word
    {
        static List<string> Words = null;
        public MediumWord()
        {
            if (Words == null || Words.Count == 0)
            {
                try {
                    Words = new List<string>(File.ReadAllLines("MediumWords.txt"));
                } catch {
                    Words = new List<string> { "Hello World", "University of Canada", "Welcome Engineer", "World of Legends", "once upon a time" };
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
