using System.Xml;

namespace MinMaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List numbrites");

            int[] numbers = new int[10] { 6, 24, 67, 11, 7, 4, 9, 8, 5, 10 };
            Console.WriteLine(numbers.Min());
            //min
            Console.WriteLine(numbers.Max());
            //max
            Console.WriteLine(numbers.Sum());
            //sum
            Console.WriteLine(numbers.Average());
            //average

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Sorteerib numbrid alates väiksemast suuremani");

            //peate kasutama Array

            Array.Sort(numbers);
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Sorteerib numbrid alates suuremast väiksemani");


            //sorteerib numbrid alates suuremast väiksemani
            Array.Reverse(numbers);
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("---------------------------------------------");
            //kasutate binarysearch
            //kirjuta lühidalt, mis see tähendab 

            Console.WriteLine(Array.BinarySearch(numbers, 9));
        
            
        }
    }
}
