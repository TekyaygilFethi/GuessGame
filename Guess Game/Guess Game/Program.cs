using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guess_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            IGuessGame game = new GuessGameClass();

            game.level = 10; //oyundaki level sayısı
            game.counterLevel = 4; //kaç oyunda bir basamak arttırsın?

            StartGame(game, game.level, game.counterLevel, game.pcGuess, game.userGuess);

            Console.WriteLine("\nLevel:" + game.level);
        }

        public static void StartGame(IGuessGame game, int level, int counterLevel, int[] pcGuess, int[] userGuess)
        {

            for (int i = 1; i <= level; i++)
            {
                Console.WriteLine("\nLEVEL" + i);

                if (i % 3 == 0)
                {
                    counterLevel++;
                }
                game.pcGuess = new int[game.counterLevel];
                game.userGuess = new int[game.counterLevel];


                Console.WriteLine("Lütfen " + counterLevel + " basamaklı bir sayı giriniz:");


                #region IGuessGame

                game.PcGuess(game.pcGuess, i, counterLevel);//bilgisayarın üreteceği sayı

                game.UserGuess(game.userGuess, i, counterLevel); //kullanıcının gireceği sayı

                game.Compare(game.pcGuess, game.userGuess, i, counterLevel);

                #endregion


                if (i == level)
                {
                    Console.WriteLine(game.Complete());
                    Console.ReadLine();
                }
            }
        }
    }
}
