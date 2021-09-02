using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public static class AnswerList
    {
        // lastFiveAnswersPulled prevents us from randomly choosing the same answer too soon.
        private static List<string> lastFiveAnswersPulled = new List<string>();
        static List<string> possibleAnswers = new List<string>()
        {
            "Animal", "Frog", "School", "Apple", "Blue", "Lion", "Alphabet", "Yellow", "Orange", "Elephant", ""
        };


        /// <summary>
        /// Assign a new answer that has not been selected for the last five rounds. Update last five list after selecting a new answer.
        /// </summary>
        /// <returns></returns>
        public static string GetNewAnswer()
        {
            var newAnswer = string.Empty;
            // random object to get a random next string for answer
            var random = new Random();
            do
            {
                newAnswer = possibleAnswers[random.Next(0, possibleAnswers.Count - 1)];
            }
            // will continue generating a new answer until we have one that is not a match of last five.
            while (lastFiveAnswersPulled.Contains(newAnswer));
            UpdateLastFive(newAnswer);
            return newAnswer;
        }

        /// <summary>
        /// Update the lastFiveAnswersPulled list. If list already has five, then will remove the one at index 0.
        /// </summary>
        /// <param name="newAnswer"></param>
        static void UpdateLastFive(string newAnswer)
        {
            // add the newAnswer to last five list.
            lastFiveAnswersPulled.Add(newAnswer);
            {
                // if list count is greater than five
                if (lastFiveAnswersPulled.Count > 5)
                {
                    // then remove the oldest answer (index 0)
                    lastFiveAnswersPulled.RemoveAt(0);
                }
            }
        }

    }
}
