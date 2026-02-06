namespace ArraySortNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kasutame Array ja Sort-i");

            string[] animals = {"cat", "alligator", "fox",
                "donkey", "bear", "elephant", "goat" };
            //tuleb kasutada foreachi ja näidata kõiki loomi
            //paneb kõik tähestikulisse järjekorda
            //Array.Sort(animals);
            foreach (string animal in animals) 
            {
                Console.WriteLine(animal);

            }
            Console.WriteLine("--------------------------------------------");

            //järjest kolm esimest sõna tähestikulises järjestuses
            //vaadake sort meetodit ja mitu overloadi sel on
            Array.Sort(animals, 0, 3);
            foreach (string animal in animals)
            {
                Console.WriteLine(animal);
            }

            Console.WriteLine("--------------------------------------------");
            int[] numbers = { 1, 2, 3, 4, 3, 55, 23, 2 };
            //tuleb välistada kordused
            //mida teha, et numbrid ei korduks????
            int[] distinct = numbers.Distinct().ToArray();
            foreach (int number in distinct)
            {
                {
                    Console.WriteLine(number);

                }
            }
        }
    }
}
