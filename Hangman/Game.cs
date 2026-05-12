using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Game : IUser
    {
        private char[] hiddenword;
        private char[] enteredLetter;
        private string target = null;
        Player p = new Player();

        public char[] Hiddenword
        {
            set { hiddenword = value; }
            get { return hiddenword; }
        }

        public char[] EnteredLetter
        {
            set { enteredLetter = value; }
            get { return enteredLetter; }
        }
        public string Target
        {
            set { target = value; }
            get { return target; }
        }

        public char AskUser() 
        {
            char x;
            Console.WriteLine("Choose Diffculty\n----------------\n1-Easy\n2-Medium\n3-Hard");
            string input = Console.ReadLine();
            x = string.IsNullOrEmpty(input) ? ' ' : input[0];

            while (x < '1' || x > '3')
            {
                Console.Write("Enter choice (1-3): ");
                input = Console.ReadLine();
                x = string.IsNullOrEmpty(input) ? ' ' : input[0];
            }

            return x;
        }

        public void SetHidden() 
        {
            int ch = AskUser() - '0';
            Word word = null;

            if (ch == 1) word = new EasyWord();
            else if (ch == 2) word = new MediumWord();
            else if (ch == 3) word = new HardWord();

            target = word.RandomWord();
            hiddenword = new char[target.Length];

            for (int i = 0; i < target.Length; i++)
            {
                if (char.IsLetter(target[i]))
                    hiddenword[i] = '_';
                else
                    hiddenword[i] = target[i];
            }
        }

        public bool IsEntered(char x) 
        {
            for (int i = 0; i < EnteredLetter.Length; i++)
            {
                if (x == EnteredLetter[i])
                    return true;
            }
            return false;
        }

        public bool Finished() 
        {

            for (int i = 0; i < target.Length; i++)
            {
                if (hiddenword[i] != char.ToLower(target[i]))
                    return false;
            }
            return true;
        }

        public void StartGame()
        {
            p.Guesses = 6;
            EnteredLetter = new char[26];
            SetHidden();
            char y;
            int count = 0;
            Console.WriteLine($"The User score {p.Score}");
            while (p.Guesses >= 1 && !Finished())
            {
                Console.Clear();
                Console.WriteLine($"Avaliable Guesses: {p.Guesses} \n");
                Drawer();
                Console.Write("Entered letters: ");
                for (int i = 0; i < EnteredLetter.Length; i++)
                {
                    if (char.IsLetter(EnteredLetter[i]))
                        Console.Write(EnteredLetter[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine(hiddenword);


                y = p.AskUser();
                while (IsEntered(y))
                {
                    Console.WriteLine("\nEnter a different Letter");
                    y = p.AskUser();
                }
                EnteredLetter[count++] = y;
                bool found = false;
                for (int i = 0; i < target.Length; i++)
                {
                    if (y == char.ToLower(target[i]))
                    {
                        hiddenword[i] = y;
                        found = true;
                    }

                }
                if (!found)
                {
                    p.WrongLetter();
                    Console.WriteLine("\nWrong Letter");
                }
            }
            if (!Finished())
                Drawer();
            GameFinished();
        }


        public void GameFinished() 
        {
            if (Finished())
            {
                p.AddScore(target.Length);
                Console.WriteLine($"You Won. \nYour Score {p.Score}. \nThe Word is: {target}");
            }
            if (!Finished())
            {
                Console.WriteLine($"You Lost. \nThe Word is: {target}");
            }
        }

        public void Drawer()
        {
            Console.WriteLine("\t\t\t\t\t  +---+");
            Console.WriteLine("\t\t\t\t\t  |   |");

            switch (p.Guesses)
            {
                case 5:
                    Console.WriteLine("\t\t\t\t\t  O   |");
                    Console.WriteLine("\t\t\t\t\t      |");
                    Console.WriteLine("\t\t\t\t\t      |");
                    break;
                case 4:
                    Console.WriteLine("\t\t\t\t\t  O   |");
                    Console.WriteLine("\t\t\t\t\t  |   |");
                    Console.WriteLine("\t\t\t\t\t      |");
                    break;
                case 3:
                    Console.WriteLine("\t\t\t\t\t  O   |");
                    Console.WriteLine("\t\t\t\t\t /|   |");
                    Console.WriteLine("\t\t\t\t\t      |");
                    break;
                case 2:
                    Console.WriteLine("\t\t\t\t\t  O   |");
                    Console.WriteLine("\t\t\t\t\t /|\\  |");
                    Console.WriteLine("\t\t\t\t\t      |");
                    break;
                case 1:
                    Console.WriteLine("\t\t\t\t\t  O   |");
                    Console.WriteLine("\t\t\t\t\t /|\\  |");
                    Console.WriteLine("\t\t\t\t\t /    |");
                    break;
                case 0:
                    Console.WriteLine("\t\t\t\t\t  O   |");
                    Console.WriteLine("\t\t\t\t\t /|\\  |");
                    Console.WriteLine("\t\t\t\t\t / \\  |");
                    break;
                default:
                    Console.WriteLine("\t\t\t\t\t      |");
                    Console.WriteLine("\t\t\t\t\t      |");
                    Console.WriteLine("\t\t\t\t\t      |");
                    break;
            }

        }
    }
}



