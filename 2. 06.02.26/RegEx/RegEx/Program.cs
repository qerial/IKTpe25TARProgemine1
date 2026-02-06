using System.Text.RegularExpressions;

namespace RegEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teeme Regular expression harjutuse");

            string word = "#CD5C5C";
            Console.WriteLine("Hex code: " + word);
            Console.WriteLine("Kas on regex: " + RegExTest(word));
        }

        public static bool RegExTest(string word)
        {
            //Regular Expression kontrollib, kas sisestav string
            //vastab nõuetele
            return Regex.IsMatch(word, @"[#][0-9A-Fa-f]{6}\b");

        }
    }
}
