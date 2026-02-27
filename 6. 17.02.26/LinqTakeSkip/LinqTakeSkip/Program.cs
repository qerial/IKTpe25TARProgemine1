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
            Console.WriteLine("3. TakeWhile");
            Console.WriteLine("4. FirstOfDefault");
            Console.WriteLine("5. AverageLINQ");
            Console.WriteLine("6. CountLINQ");
            Console.WriteLine("7. Sum");
            Console.WriteLine("\n");
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

                case 3:
                    TakeWhile();
                    break;

                case 4:
                    FirstOfDefault();
                    break;

                case 5:
                    AverageLINQ();
                    break;
                case 6:
                    CountLINQ();
                    break;
                case 7:
                    Sum();
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
            //mis tähendab: => . See tähendab lambda märki ja selle
            //abil saab kasutada pikema classi nimetuse asemel lühendit
            //koos sees oleva muutujaga, mis antud juhul on x.
            var SkipWhile = PeopleList.people.SkipWhile(x => x.Age > 18);

            foreach (var item in SkipWhile)
            {
                Console.WriteLine(+item.Id + "|" + item.Name + "|" + item.Age);
            }
            //SkipWhile jätab loendis nii kaua vahele ridu kuni vastab tingimustele
            //e antud juhul jätab read vahele kuni leiab 18 a isiku ja
            //peale seda hakkab infot jälle kuvama olenemata vanuse tingimusest
        }
        //kasutada TakeWhile ja kutsuda see esile switchis

        //vooskeem teha TakeWhile meetodist
        public static void TakeWhile()
        {
            Console.Clear();
            Console.WriteLine("--------TakeWhile--------");
            var TakeWhile = PeopleList.people.TakeWhile(x => x.Age > 18);

            foreach (var item in TakeWhile)
            {
                Console.WriteLine(item.Id + "|" + item.Name + "|" + item.Age);
            }
            //TakeWhile näitab isikuid kuni vastab tingimusele
            //e antud juhul näitab kuni leiab 18 a isiku ja 
            //peale seda enam ei näita andmeid

        }
        public static void FirstOfDefault()
        {
            //peate kasutama Name ja Length-i. Nimi peab olema vähemalt 5 
            //tähemärki pikk
            //kuvab esimese elemendi, mis järjestuses
            //vastab tingimustele
            Console.Clear();
            Console.WriteLine("--------FirstOfDefault--------");
            string firstLongName = PeopleList.people.FirstOrDefault(x => x.Name.Length > 5)?.Name;


            
            Console.WriteLine("The first long name is '{0}'.", firstLongName);

            
        }
        //kasutame Average Linq
        public static void AverageLINQ()
        {
            Console.Clear();
            Console.WriteLine("--------Average--------");
            var Average = PeopleList.people
                .Average(x => x.Age);

            Console.WriteLine("kõikide keskmine vanus on " + Average);
        }
        public static void CountLINQ()
        {
            Console.Clear();
            Console.WriteLine("--------CountLINQ--------");

            var totalPersons = PeopleList.people.Count();
            Console.WriteLine("Inimesi on kokku: " + totalPersons);
            Console.WriteLine("---------------------------------");

            var adultPerson = PeopleList.people.Count(x => x.Age >= 18);
            Console.WriteLine("Inimesi on kokku: " + adultPerson);

            //kasutame summat e Sum
        }
        public static void Sum()
        {
            Console.Clear();
            Console.WriteLine("--------Sum--------");
            var summary = PeopleList.people.Sum(x => x.Age);
            Console.WriteLine("Kõikide vanus on kokku " + summary);
        }
    }
}
