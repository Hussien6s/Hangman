using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal abstract class Word
    {
        protected string secret_Word=null;
        public abstract string RandomWord();
    }
}
