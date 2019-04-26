using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TranslateToPigLatin("Translate."));
            Console.WriteLine(TranslateToPigLatin("united"));
            string userInput = Console.ReadLine();

            if (userInput.Trim().Contains(" "))
            {
                string[] sentenceSplit = userInput.Split(' ');
                string translatedSentence = "";
                foreach (string item in sentenceSplit)
                {
                    translatedSentence += TranslateToPigLatin(item) + " ";
                }
                Console.WriteLine(translatedSentence.Trim());
            }
            else
            {
                Console.WriteLine(TranslateToPigLatin(userInput));
            }
        }

        public static string TranslateToPigLatin(string word)
        {
            if (Regex.IsMatch(word, @"^[a-zA-Z.!?]+$"))
            {


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

    }
}
