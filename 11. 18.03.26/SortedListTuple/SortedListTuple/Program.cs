using System.Xml.Serialization;

namespace SortedListTuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vali meetod!");
            Console.WriteLine("1.SortedList");
            Console.WriteLine("2.Tuple-t");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:

                    break;

                case 2:

                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }

        }

        static void SortedList()
        {
            SortedList<int, string> sl = new SortedList<int, string>();

            // Adding key-value pairs
            sl.Add(3, "Three");
            sl.Add(1, "One");
            sl.Add(2, "Two");

            // Displaying elements in sorted by key
            foreach (var item in sl)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }

        static void TupleT()
        {

        }
    }
}
