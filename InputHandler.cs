using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public static class InputHandler
    {

        public static void GetInput()
        {
            var input = Console.ReadKey().KeyChar;
            if (Char.IsLetter(input))
            {
                GuessHandler.CheckGuess(input);
            }
            else
            {
                PagePrinter.PrintPage(input, true);
                InputHandler.GetInput();
            }
        }


        public static bool OfferReplay(bool playerWon)
        {           
            char response = Console.ReadKey().KeyChar;
            switch (response)
            {
                case (char)ConsoleKey.Enter:
                case 'y':
                    return true;
                case 'n':
                    return false;
                default:
                    return PagePrinter.PrintNewGameOffer(playerWon, response);
            }
        }


    }
}
