using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public static class GameManager
    {

        // wrong Guess Count and maxWrongCount will control the. 
        public static int wrongGuessCount;
        // maximum amount of wrong guesses that can be made.
        static int maxWrongCount = 5;


        /// <summary>
        /// Set wrongGuessCount to 0, ClearGuesses, Get a new answer, then print the page and get input.
        /// </summary>
        public static void StartGame()
        {
            wrongGuessCount = 0;
            GuessHandler.ClearGuesses();
            GetNewAnswer();
            PagePrinter.PrintPage();
            InputHandler.GetInput();
        }

        /// <summary>
        /// Get a random new answer from AnswerList and then update PagePrinter
        /// </summary>
        static void GetNewAnswer()
        {
            GuessHandler.UpdateCurrentAnswer(AnswerList.GetNewAnswer());
            PagePrinter.UpdateAnswerDisplayed();
           
        }

        /// <summary>
        /// Increase wrong guess count by one. Continue Playing or Offer to start a new game if game over
        /// </summary>
        /// <returns></returns>
        public static void WrongAnswerReceived(char letterEntered)
        {
            wrongGuessCount++;
            if (wrongGuessCount <= maxWrongCount)
            {
                PagePrinter.PrintPage($"Good Try, but '{letterEntered}' was not a match.");
                InputHandler.GetInput();
            }
            else
            {
                PagePrinter.PrintPage(wrongGuessCount);
                if(PagePrinter.PrintNewGameOffer(false))
                {
                    StartGame();
                }
                else
                {
                    PagePrinter.EndGame();
                }
                

            }

                
       
     
        }

    }
}
