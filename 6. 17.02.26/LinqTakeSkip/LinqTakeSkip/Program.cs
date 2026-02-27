using System.Linq.Expressions;

namespace LinqTakeSkip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kutsume esile LINQ meetodid");
            Console.WriteLine("1. Skip");
            Console.WriteLine("2. SkipWhile");
            Console.WriteLine(" ");
            //siin kasutada switchi ja peab saama Skip meetodit kutsuda
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Skip();
                break;

                case 2:
                    SkipWhile();
                break;

                default:
                    Console.WriteLine("Vale valik");
                    break;
            }
        }

        public static void Skip()
        {
            Console.Clear();
            Console.WriteLine("--------Skip--------");
            //kasuta skip ja jäta kolm tükki vahele
            var skip = PeopleList.people.Skip(3);

            foreach (var item in skip)
            {
                Console.WriteLine(item.Name);
            }
        }
        //teete uue meetodi, aga kasutate SkipWhile ja vanemad, kui 18 peab olema tingimus
        public static void SkipWhile()
        {
            Console.Clear();
            Console.WriteLine("--------SkipWhile--------");
            var SkipWhile = PeopleList.people.SkipWhile(x => x.Age > 18);

            foreach (var item in SkipWhile)
            {
            Console.WriteLine( + item.Id + "|" + item.Name + "|" + item.Age); 
            }
        }
    }
}
