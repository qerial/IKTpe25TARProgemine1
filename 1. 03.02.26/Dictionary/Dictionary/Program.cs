using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dictionary ja foreach");
            int numberIndex = 1;
            // var on muutuja
            var domains = new Dictionary<string, string>()
            {
            {"fi", "Finland"},
            {"se", "Sweden"},
            {"de", "Germany"},
            {"fr", "France"},
            {"es", "Spain"}
            };
            //kasutate foreachi ja juurde tuleb lisada kolmas rida
            foreach (var domain in domains)
            {
                Console.WriteLine($" {domain.Key} - {domain.Value} - {numberIndex}");
                numberIndex++;
            }
        }
    }
}
