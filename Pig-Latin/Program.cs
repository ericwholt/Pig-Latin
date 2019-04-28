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

                if (userInput.Trim().Length < 1)//Check if user actually entered anything besides spaces
                {
                    Console.Clear();
                    Console.WriteLine("Your nothing translates into: ");
                }
                else if (userInput.Trim().Contains(" "))//Checks if the input contains spaces in middle of string
                {
                    Console.Clear();
                    Console.WriteLine("Your sentence translation");
                    Console.WriteLine(TranslateSentenceToPigLatin(userInput));//String is a sentence so we call SentenceTranslator to do individual words in the sentence
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Your word translation: ");
                    Console.WriteLine(TranslateWordToPigLatin(userInput));// Its just a word so translate it.
                }
                Console.WriteLine();
                userStillTranslating = Continue("Continue Translating? y/n");//See if the user wants to translate again
            }
        }

        /// <summary>
        /// Takes a string and returns a string array. Splits string based on whitespace
        /// </summary>
        /// <param name="sentence">string</param>
        /// <returns>string array of sentence split by whitespace</returns>
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

        /// <summary>
        /// Translate a single word into pig latin if it doesn't contain a number or non punctuation symbols
        /// </summary>
        /// <param name="word">string</param>
        /// <returns>string of either a translated word or just the orginal word if it doesn't meet requirements</returns>
        public static string TranslateWordToPigLatin(string word)
        {
            if (Regex.IsMatch(word, @"^[a-zA-Z.!?']+$"))//If the word contains only letters or any number the following symbols .!?'
            {
                if (Regex.IsMatch(word, @"^[.!?']+$"))//If the word is only contains any number of allowed symbols then just return that word.
                {
                    return word;
                }

                char[] vowelsLower = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };                
                foreach (char letter in vowelsLower)//Iterate through vowels array
                {
                    if (word[0] == letter)//Compare first letter of word for a vowel
                    {
                        return word + "way";
                    }
                }

                string[] wordArraySplitByVowel = Regex.Split(word, "[aeiouAEIOU]");
                return word.Substring(wordArraySplitByVowel[0].Length) + wordArraySplitByVowel[0] + "ay";
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
