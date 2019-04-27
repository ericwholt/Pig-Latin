using System;
using System.Text.RegularExpressions;

namespace Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool userStillTranslating = true;
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            Console.WriteLine();
            while (userStillTranslating)
            {
                Console.Write("Enter a line to be translated: ");
                string userInput = Console.ReadLine();
                if (userInput.Length < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Your nothing translates into: ");
                }
                else if (userInput.Trim().Contains(" "))
                {
                    Console.Clear();
                    Console.WriteLine("Your sentence translation");
                    Console.WriteLine(TranslateSentenceToPigLatin(userInput));
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Your word translation: ");
                    Console.WriteLine(TranslateWordToPigLatin(userInput));
                }
                Console.WriteLine();
                userStillTranslating = Continue("Continue Translating? y/n");
            }
        }

        private static string[] SplitSentence(string sentence)
        {
            return sentence.Split(' ');
        }
        public static string TranslateSentenceToPigLatin(string sentence)
        {
            string[] wordArray = SplitSentence(sentence);
            sentence = "";
            foreach (string item in wordArray)
            {
                sentence += TranslateWordToPigLatin(item) + " ";
            }

            return sentence;
        }
        public static string TranslateWordToPigLatin(string word)
        {
            if (Regex.IsMatch(word, @"^[a-zA-Z.!?']+$"))
            {
                if (Regex.IsMatch(word, @"^[.!?']+$"))
                {
                    return word;
                }

                char[] vowelsLower = { 'a', 'e', 'i', 'o', 'u' };
                string[] res = Regex.Split(word, "[aeiouAEIOU]");

                foreach (char letter in vowelsLower)
                {
                    if (word[0] == letter)
                    {
                        return word + "way";
                    }
                }

                return word.Substring(res[0].Length) + res[0] + "ay";
            }
            else
            {
                return word;
            }
        }

        /// <summary>
        /// Allows to display custom message to see if they want to continue with n,no,y,yes
        /// </summary>
        /// <returns>bool</returns>
        public static bool Continue(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().Trim().ToLower();
            bool run = false;

            if (input == "n" || input == "no")
            {
                Console.Clear();
                Console.WriteLine("Good bye");
                run = false;
            }
            else if (input == "y" || input == "yes")
            {
                run = true;
            }
            else
            {
                Console.WriteLine("I don't understand. Try again!");
                run = Continue(message);
            }
            return run;
        }
    }
}
