using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    static class GuessHandler
    {
        // will store the guesses made in this list to prevent wasting guesses on duplicate chars.
        static List<char> guessesMade = new List<char>();
        // will store the currentAnswer to refer to when making guesses
        static string currentAnswer = string.Empty;

        /// <summary>
        /// Return a string that will either show all guesses made, "No Guesses Made Yet!"
        /// </summary>
        /// <returns></returns>
        public static string PullGuessesMade()
        {
            var guessesToReturn = string.Empty;
            foreach (var letter in guessesMade)
            {
                guessesToReturn += $" {letter},";
            }
            guessesToReturn.TrimEnd(',');
            if (guessesToReturn == string.Empty)
            {
                guessesToReturn = "No Guesses Made Yet!";
            }
            return guessesToReturn;
        }

        public static string GetCurrentAnswer()
        {
            return currentAnswer.ToLower();
        }

        /// <summary>
        /// Update GuessHandler.currentAnswer to the provided newAnswer
        /// </summary>
        /// <param name="newAnswer"></param>
        public static void UpdateCurrentAnswer(string newAnswer)
        {
            currentAnswer = newAnswer;
        }

        /// <summary>
        /// Pass in a letter to check for. Return true if the character has already been used. Return False if not.
        /// </summary>
        /// <param name="letterToCheck"></param>
        /// <returns></returns>
        public static bool LetterAlreadyUsed (char letterToCheck)
        {
            return guessesMade.Contains(letterToCheck) ? true : false;
        }

        /// <summary>
        /// Clear the list of guessesMade.
        /// </summary>
        public static void ClearGuesses()
        {
            guessesMade.Clear();
        }

        /// <summary>
        /// Return false if the letter provided has already been guessed. Otherwise will add the guess to guessesMade list and return true
        /// </summary>
        /// <param name="letterToAdd"></param>
        /// <returns></returns>
        static bool AddNewGuess (char letterToAdd)
        {
            if(LetterAlreadyUsed(letterToAdd))
            {
                return false;
            }
            else
            {
                guessesMade.Add(letterToAdd);
                return true;
            }
        }


        public static void CheckGuess(char letterGuessed)
        {
            // if this letter has not already been guessed
            if(AddNewGuess(letterGuessed))
            {
                if (currentAnswer.ToLower().Contains(letterGuessed))
                {
                    bool userWasRight = PagePrinter.UpdateAnswerDisplayed();
                    if(userWasRight)
                    {
                        PagePrinter.PrintPage("Great Job! You beat the game!");
                        if(PagePrinter.PrintNewGameOffer(true))
                        {
                            GameManager.StartGame();
                        }
                       
                        PagePrinter.EndGame();
                    }
                    else
                    {
                        PagePrinter.PrintPage($"Good Guess! {letterGuessed} was a match!");
                        InputHandler.GetInput();
                    }
                }
                else
                {
                    GameManager.WrongAnswerReceived(letterGuessed);
                }
            }
            // if the letter has already beene guessed
            else
            {
                PagePrinter.PrintPage(letterGuessed);
                InputHandler.GetInput();
                // notify player that the guess they entered has already been guessed previously.
            }

        }

    }
}
