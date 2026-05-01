using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Game: IUser
    {
        protected char[] hiddenword = new char[60];
        protected char[] EnteredLetter = new char[26];
        protected string target = null;
        Player p = new Player();
        

        public char AskUser() //bna5od mostawa el so3oba mn el user
        {
            char x;
            Console.WriteLine("Choose Diffculty\n----------------\n1-Easy\n2-Medium\n3-Hard");
            x = Console.ReadLine()[0];

            while (x < '1' || x > '3') 
            {
                Console.Write("Enter choice (1-3): ");
                x = Console.ReadLine()[0];
            }
            
            return x;
        }
            
        public void SetHidden() //bnst3ml el words classes 3lshan na5od el kelma el sereya mn el user
        {
            int ch = AskUser()-'0';
            if (ch == 1)
            {
                EasyWord word = new EasyWord();
                target = word.RandomWord();
                hiddenword = new char[target.Length];
                for (int i = 0; i < target.Length; i++)
                {
                    if (char.IsLetter(target[i]))
                        hiddenword[i] = '_';

                    else if (target[i] == ' ')
                        hiddenword[i] = ' ';
                }
            }

            else if (ch == 2)
            {
                MediumWord word = new MediumWord();
                target = word.RandomWord();
                hiddenword = new char[target.Length];
                for (int i = 0; i < target.Length; i++)
                {
                    if (char.IsLetter(target[i]))
                        hiddenword[i] = '_';

                    else if (target[i] == ' ')
                        hiddenword[i] = ' ';
                }
            }
            else if (ch == 3)
            {
                HardWord word = new HardWord();
                target = word.RandomWord();
                hiddenword = new char[target.Length];
                for (int i = 0; i < target.Length; i++)
                {
                    if (char.IsLetter(target[i]))
                        hiddenword[i] = '_';

                    else if (target[i] == ' ')
                        hiddenword[i] = ' ';
                }         
            }
            
        }

        public bool IsEntered(char x) //bnt2aked lw el 7arf da5al abl kda
        {
            for(int i = 0; i < EnteredLetter.Length; i++)
            {
                if (x == EnteredLetter[i])
                    return true;
            }
            return false;
        }

        public bool Finished() //bnshof el user gab el kelma kolaha s7 wla lesa
        {
            
            for(int i=0;i<target.Length;i++)
            {
                if (hiddenword[i] != char.ToLower(target[i]))
                    return false;
            }
            return true;
        }

        public void StartGame() 
        {
            SetHidden();
            char y;
            int count = 0;
            Console.WriteLine($"The User score {p.Score}");
            while (p.Guesses >= 1 && !Finished())
            {
                
                Console.WriteLine($"Avaliable Guesses: {p.Guesses} \n");
                Console.Write("Entered letters: ");
                for(int i = 0; i < EnteredLetter.Length; i++)
                {
                    if (char.IsLetter(EnteredLetter[i]))
                        Console.Write(EnteredLetter[i]+" ");
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
            GameFinished();
        }

       
        public void GameFinished() // bnshof lw el game 5eles
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
    } 
}

    

