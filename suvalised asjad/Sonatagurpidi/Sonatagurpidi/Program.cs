using System.ComponentModel.DataAnnotations;

namespace Sonatagurpidi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Vali mida soovid testida");
            Console.WriteLine("1.Sõnad tagurpidi.");
            Console.WriteLine("\n");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                default:
                    choice = 1;
                    sonatagurpidi();
                    break;
            }
            static void sonatagurpidi()
            {
                Console.Clear();
                string word = Console.ReadLine();

                char[] chars = word.ToCharArray();
                Array.Reverse(chars);
                string reversed = new string(chars);

                Console.WriteLine(reversed);
            }
        }
    }
}
