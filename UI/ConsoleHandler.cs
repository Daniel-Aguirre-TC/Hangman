using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class ConsoleHandler
    {


        /// <summary>
        /// Skip lines to center the current line vertically.
        /// </summary>
        protected static void SkipLines()
        {
            for (int i = 0; i < (Console.WindowHeight / 2); i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Skip a specified number of lines.
        /// </summary>
        /// <param name="linesToSkip"></param>
        protected static void SkipLines(int linesToSkip)
        {
            for (int i = 0; i < linesToSkip; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Skip lines based on a provided array of strings to center the array of strings vertically.
        /// </summary>
        /// <param name="arrayToReference"></param>
        protected static void SkipLines(string[] arrayToReference)
        {
            for (int i = 0; i < (Console.WindowHeight / 2) - (arrayToReference.Length); i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Return the provided string with the left side padded to center the text based on Console.WindowWidth.
        /// </summary>
        /// <param name="textToCenter"></param>
        /// <returns></returns>
        protected static string CenterHorizontal(string textToCenter)
        {
            return textToCenter.PadLeft((int)MathF.Round((Console.WindowWidth / 2) + (textToCenter.Length / 2)));
        }

        protected static void CenterAndPrint(string textToPrint, bool dontEndLine)
        {
            if (dontEndLine)
            {
                Console.Write(CenterHorizontal(textToPrint));
            }
            else CenterAndPrint(textToPrint);
        }

        // print the provided string or string[] centered on the current line.
        protected static void CenterAndPrint(string textToPrint)
        {
            Console.WriteLine(CenterHorizontal(textToPrint));
        }
        protected static void CenterAndPrint(string[] arrayOfStringsToPrint)
        {
            foreach (var str in arrayOfStringsToPrint)
            {
                CenterAndPrint(str);
            }
        }
        protected static void CenterAndPrint(string[] arrayOfStringsToPrint, bool dontEndLine)
        {
            if (dontEndLine)
            {
                for (int i = 0; i < arrayOfStringsToPrint.Length; i++)
                {
                    // if it's not on the last cycle
                    if (i != arrayOfStringsToPrint.Length - 1)
                    {
                        Console.WriteLine(CenterHorizontal(arrayOfStringsToPrint[i]));
                    }
                    else Console.Write(CenterHorizontal(arrayOfStringsToPrint[i]));
                }
            }
            else CenterAndPrint(arrayOfStringsToPrint);          
        }

        //Clear Console, then print the provided string or string[] centered vertically and horizontally
        protected static void CenterMidScreenAndPrint(string stringToPrint)
        {
            Console.Clear();
            SkipLines();
            Console.WriteLine(CenterHorizontal(stringToPrint));
        }
        protected static void CenterMidScreenAndPrint(string[] arrayOfStringsToPrint)
        {
            Console.Clear();
            SkipLines(arrayOfStringsToPrint);
            foreach (var textLine in arrayOfStringsToPrint)
            {
                Console.WriteLine(CenterHorizontal(textLine));
            }
        }
        // CenterMidScreenAndPrint but if bool is true then we will do a Write instead of WriteLine.
        protected static void CenterMidScreenAndPrint(string stringToPrint, bool dontEndLine)
        {
            Console.Clear();
            SkipLines(Console.WindowHeight / 2);
            if (dontEndLine)
            {
                Console.Write(CenterHorizontal(stringToPrint));
            }
            else Console.WriteLine(CenterHorizontal(stringToPrint));
        }
        protected static void CenterMidScreenAndPrint(string[] arrayOfStringsToPrint, bool dontEndLastLine)
        {
            Console.Clear();
            SkipLines(arrayOfStringsToPrint);
            for (int i = 0; i < arrayOfStringsToPrint.Length; i++)
            {
                // if it's not on the last cycle
                if (i != arrayOfStringsToPrint.Length - 1)
                {
                    Console.WriteLine(CenterHorizontal(arrayOfStringsToPrint[i]));
                }
                else Console.Write(CenterHorizontal(arrayOfStringsToPrint[i]));
            }
        }
        protected static void CenterMidScreenAndPrint(string[] arrayOfStringsToPrint, int lengthOfStringToMatchPaddingOf)
        {
            Console.Clear();
            for (int i = 0; i < (Console.WindowHeight / 2) - (arrayOfStringsToPrint.Length); i++)
            {
                Console.WriteLine();
            }
            for (int i = 0; i < arrayOfStringsToPrint.Length; i++)
            {
                // if it's not on the last cycle
                if (i != arrayOfStringsToPrint.Length - 1)
                {
                    Console.WriteLine(CenterHorizontal(arrayOfStringsToPrint[i]));
                }
                else Console.Write(arrayOfStringsToPrint[i].PadLeft((Console.WindowWidth / 2) - ((lengthOfStringToMatchPaddingOf / 2) - arrayOfStringsToPrint[i].Length)));
            }
        }


        // Clear the console after the user presses any key.
        protected static void ClearAfterKeyPress()
        {
            Console.ReadKey();
            Console.Clear();
        }


    }
}
