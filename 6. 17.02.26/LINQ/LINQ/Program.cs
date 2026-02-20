using System.Globalization;
using LINQ.Models;
using LINQ.Models.LINQ.Models;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Tuleb teha class nimega PeopleList
            //Seal on kuus rida andmeid
            //kindlasti peab olema kaks Mari nimega isikut,
            //aga erinevate vanustega


            Console.WriteLine("Tee valik numbriga");
            Console.WriteLine("1. ThenByLINQ");
            Console.WriteLine("2. ThenByDescendingLINQ");
            Console.WriteLine("3. SelectLINQ");


            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ThenByLINQ();
                    break;
                case 2:
                    ThenByDescendingLINQ();
                    break;
                case 3:
                    SelectLINQ();
                    break;

                default:
                    Console.WriteLine("vale valik");
                    break;

            }
        }

        //thenby sorteerib numbrilises järjestuses
        public static void ThenByLINQ()
        {
            var thenByResult = People.peoples
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Age);

            Console.WriteLine("ThenBy järgi sorteerimine");
            foreach (var people in thenByResult)
            {
                Console.WriteLine(people.Name + " " + people.Age);

            }
        }
        public static void ThenByDescendingLINQ()
        {
            var ThenByDescending = People.peoples
                .OrderByDescending(x => x.Name)
                .ThenByDescending(x => x.Age);

            Console.WriteLine("ThenBy järgi sorteerimine");
            foreach (var people in ThenByDescending)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }

        public static void SelectLINQ()
        {
            //select lihtsalt annab andmed, 
            //ei mingit järjestust lihtsalt 
            // nii nagu need on andmebaasis
            var selectResult = People.peoples
                .Select(x => new
                {
                    x.Name,
                    x.Age
                });

            foreach (var people in selectResult)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }
    }
}
