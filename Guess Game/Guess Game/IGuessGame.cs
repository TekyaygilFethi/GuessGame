using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guess_Game
{
    interface IGuessGame
    {
        int level { get; set; }
        int counterLevel { get; set; }
        int[] userGuess { get; set; }
        int[] pcGuess { get; set; }
        
        String Complete();


        void PcGuess(int[] pcGuess, int level, int counterLevel);
        void UserGuess(int[] userGuess, int level, int counterLevel);
        void Compare(int[] pcGuess, int[] userGuess, int level, int counterLevel);

    }
}
