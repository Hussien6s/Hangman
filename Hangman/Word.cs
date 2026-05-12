using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal abstract class Word
    {
        private string secret_Word = null;

        public string Secret_Word
        {
            set { secret_Word = value; }
            get { return secret_Word; }
        }
        public abstract string RandomWord();
    }
}
