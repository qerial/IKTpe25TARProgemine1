using LINQ.Models;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kutsume esile LINQ läbi switchi");
            Console.WriteLine("Vali vastav link numbriga");
            Console.WriteLine("1. Where");
            Console.WriteLine("2. Where Name");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 1) WhereLINQ();
            else if (choice == 2) WhereByNameLINQ();


        }
        

        //teeme uue meetodi
        public static void WhereLINQ()
        {
            var peoepleAge = PeopleData.peoples
                .Where(x => x.Age > 20 && x.Age < 23);

        //kasutada muutjat peopleAge ja kuvada andmed esile
        //kasuta foreachi

        foreach (var people in peoepleAge)
            { 
            Console.WriteLine(people.Name); 
            }
        }


        public static void WhereByNameLINQ()
        {
            Console.WriteLine("Kirjuta inimese nimi: ");
            string name = Console.ReadLine();

            //kasuta where inimese otsimiseks
            //otsimine toimub nime alusel
            var people = PeopleData.peoples
                .Where (x => x.Name == name);
            foreach (var  person in people)
                Console.WriteLine(person.Name);
        }
    }
}
