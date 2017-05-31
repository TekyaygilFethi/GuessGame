using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guess_Game
{
    class GuessGameClass : IGuessGame
    {
        int IGuessGame.level { get; set; }

        int IGuessGame.counterLevel { get; set; }

        int[] IGuessGame.userGuess { get; set; }

        int[] IGuessGame.pcGuess { get; set; }


        public String Complete()
        {
            return "YOU COMPLETED THE GAME!!!";
        }


        public void PcGuess(int[] pcGuess, int level, int counterLevel)
        {
           // pcGuess = new int[counterLevel];

            int guess;
            Random rand = new Random();

            for (int i = 0; i < pcGuess.Length; i++)
            {
                guess = rand.Next(9);

                if (i == 0)
                {
                    pcGuess[i] = guess;
                }

                else
                {
                    if (!pcGuess.Contains(guess))
                    {
                        pcGuess[i] = guess;

                    }
                    else
                    {
                        i--;
                    }
                }
            }

            foreach (int i in pcGuess)
            {
                Console.Write(i);
            }


           
        }

        public void UserGuess(int[] userGuess, int level, int counterLevel)
        {
            //userGuess = new int[counterLevel];
            int counter = 1;
            int userTahmin;


            //Console.WriteLine("\nLütfen basamaklı bir sayı girin:");
            Console.WriteLine("");
            userTahmin = Convert.ToInt32(Console.ReadLine());

            for (int i = userGuess.Length - 1; i >= 0; i--)
            {
                //Console.WriteLine(userTahmin % 10);

                userGuess[i] = userTahmin % (int)Math.Pow(10, counter);

                userGuess[i] /= (int)Math.Pow(10, counter - 1);
                counter++;
            }

            //foreach (int i in userGuess)
            //{
            //    Console.Write(i);
            //}
            
        }

        public void Compare(int[] pcGuess, int[] userGuess, int level, int counterLevel)
        {
            int steps = 0;
            int counterPositive = 0;
            int counterNegative = 0;
            char positiveSign = '*';
            char negativeSign = '*';


            //pcGuess = new int[counterLevel];
            //userGuess = new int[counterLevel];


            while (counterPositive != pcGuess.Length)
            {

                //counterPositive = 0;
                //counterNegative = 0;
                //positiveSign = '*';
                //negativeSign = '*';

                for (int i = 0; i < pcGuess.Length; i++)
                {
                    if (pcGuess.Contains(userGuess[i]))
                    {

                        if (pcGuess[i] == userGuess[i])
                        {
                            counterPositive++;
                            positiveSign = '+';
                        }
                        else
                        {
                            counterNegative++;
                            negativeSign = '-';
                        }
                    }
                }

                if (counterPositive > 0)
                {
                    Console.WriteLine("\n" + positiveSign + counterPositive);
                }

                if (counterNegative > 0)
                {
                    Console.WriteLine("\n" + negativeSign + counterNegative);
                }

                if (counterNegative == 0 && counterPositive == 0)
                {
                    Console.WriteLine("None of them your numbers are matching!");
                }

                if (counterPositive < pcGuess.Length)
                {
                    Console.WriteLine("Lütfen " + counterLevel + " basamaklı bir sayı giriniz");
                    UserGuess(userGuess, level, counterLevel); //kullanıcıya sürekli sorsun
                    counterNegative = 0;
                    counterPositive = 0;
                }
                steps++;
            }

            if (counterPositive == pcGuess.Length)
            {
                Console.WriteLine("Congratulations you have found the number in " + steps + " steps");
            }
        }



    }
}
