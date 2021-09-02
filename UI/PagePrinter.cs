using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class PagePrinter : ConsoleHandler
    {
        // string arrays of hangman to display
        private static string[] hangman6 = new string[]
        {
            "     _______     ",
            "    _|_     |    ",
            "   |x x|    |    ",
            "   |___|    |    ",
            "     |      |    ",
            "    /|\\     |    ",
            "   / | \\    |    ",
            "     |      |    ",
            "    / \\     |    ",
            "   /   \\    |    ",
            "            |    ",
            "         ___|___ ",
        };
        private static string[] hangman5 = new string[]
        {
            "     _______     ",
            "    _|_     |    ",
            "   |x x|    |    ",
            "   |___|    |    ",
            "     |      |    ",
            "    /|\\     |    ",
            "   / | \\    |    ",
            "     |      |    ",
            "      \\     |    ",
            "       \\    |    ",
            "            |    ",
            "         ___|___ ",
        };
        private static string[] hangman4 = new string[]
       {
            "     _______     ",
            "    _|_     |    ",
            "   |x x|    |    ",
            "   |___|    |    ",
            "     |      |    ",
            "    /|\\     |    ",
            "   / | \\    |    ",
            "     |      |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "         ___|___ ",
       };
        private static string[] hangman3 = new string[]
       {
            "     _______     ",
            "    _|_     |    ",
            "   |x x|    |    ",
            "   |___|    |    ",
            "     |      |    ",
            "    /|      |    ",
            "   / |      |    ",
            "     |      |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "         ___|___ ",
       };
        private static string[] hangman2 = new string[]
       {
            "     _______     ",
            "    _|_     |    ",
            "   |x x|    |    ",
            "   |___|    |    ",
            "     |      |    ",
            "     |      |    ",
            "     |      |    ",
            "     |      |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "         ___|___ ",
       };
        private static string[] hangman1 = new string[]
       {
            "     _______     ",
            "    _|_     |    ",
            "   |x x|    |    ",
            "   |___|    |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "         ___|___ ",
       };
        private static string[] hangman0 = new string[]
       {
            "     _______     ",
            "     |      |    ",
            "     |      |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "            |    ",
            "         ___|___ ",
       };

        static List<string[]> hangmanArrays = new List<string[]>()
        {
            hangman0, hangman1, hangman2, hangman3, hangman4, hangman5, hangman6
        };

        static string answerDisplayed;


        /// <summary>
        /// int is really only used to define that the game is over, param isn't actually used.
        /// </summary>
        /// <param name="wrongGuessCount"></param>
        public static void PrintPage(int wrongGuessCount)
        {
            PrintBase();
            CenterAndPrint(new string[] { "Game Over", "",
            "Press any key to play again."}, true);
        }


        public static void PrintPage(string customMessage)
        {
            PrintBase();
            CenterAndPrint(new string[] { customMessage, "" });
            PrintNextGuessRequest();
        }

        /// <summary>
        /// Print the page again because the provided char was a guess already submitted.
        /// </summary>
        /// <param name="letterGuessed"></param>
        public static void PrintPage(char letterGuessed)
        {
            PrintBase();
            CenterAndPrint(new string[] { $"You have already tried '{letterGuessed}' previously.", "" });          
            PrintNextGuessRequest();
        }

        /// <summary>
        /// Print the page again because the char entered was not a letter. Must be true.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="invalidEntry"></param>
        public static void PrintPage(char input, bool invalidEntry)
        {
            if (invalidEntry)
            {
                PrintBase();
                CenterAndPrint(new string[] { 
                    $"'{input}' is not a letter.", "",
                    "Please only enter Letters.", ""
                });
                PrintNextGuessRequest();
                InputHandler.GetInput();
            }
        }

        static void PrintNextGuessRequest()
        {
            CenterAndPrint(new string[]{
                "What letter would you like to guess next?", "",
                "Your Guess: "
            }, true);
        }

        static void PrintBase()
        {
            Console.Clear();
            var guesses = GuessHandler.PullGuessesMade();
            SkipLines(2);
            CenterAndPrint(new string[] {
                "Letters already Guessed: ", "",
                guesses
            });
            SkipLines(2);
            CenterAndPrint(hangmanArrays[GameManager.wrongGuessCount]);
            SkipLines(2);
            CenterAndPrint(answerDisplayed);
            SkipLines(2);
        }

        /// <summary>
        /// Default for printing a page.
        /// </summary>
        public static void PrintPage()
        {
            PrintBase();
            PrintNextGuessRequest();
        }

        public static bool PrintNewGameOffer(bool playerWon, char invalidCharEntered)
        {
                string gameWonMessage = playerWon ? "Congrats on winning the game!" : "You didn't win this time, but you might next time!";
                //ClearAfterKeyPress();
                CenterMidScreenAndPrint(new string[] {
                gameWonMessage, "",
                "Would you like to play again?", "",
                $"You entered '{invalidCharEntered}', which is not a valid option.", "",
                "Please enter y/n "
                }, true);
            return InputHandler.OfferReplay(playerWon);
            
        }

        public static bool PrintNewGameOffer(bool playerWon)
        {
            string gameWonMessage = playerWon ? "Congrats on winning the game!" : "You didn't win this time, but you might next time!";
            //ClearAfterKeyPress();
            CenterMidScreenAndPrint(new string[] {
                gameWonMessage, "",
                "Would you like to play again?", "",
                "Please enter y/n "
            }, true);
            return InputHandler.OfferReplay(playerWon);

        }

        /// <summary>
        /// Update the answer displayed based on guesses made and return true if the answer has been completely filled
        /// </summary>
        public static bool UpdateAnswerDisplayed()
        {
            string answerToDisplay = string.Empty;
            char[] currentAnswer = GuessHandler.GetCurrentAnswer().ToCharArray();
            foreach (var letter in currentAnswer)
            {
                if (GuessHandler.LetterAlreadyUsed(letter))
                {
                    answerToDisplay += $"{letter} ";
                }
                else answerToDisplay += "_ ";
            }
            answerDisplayed = answerToDisplay;

            return answerDisplayed.Contains('_') ? false : true;

        }


        public static void EndGame()
        {
            CenterMidScreenAndPrint(new string[]
            {
                "Thank you for playing Hangman!", "",
                "Created by Daniel Aguirre. "
            }, true );
            ClearAfterKeyPress();
            Environment.Exit(0);
        }


    }
}
