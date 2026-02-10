using System.Runtime.InteropServices;
using System.Threading.Channels;

namespace ListLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List and LINQ");

            //teeme "andmebaas"
            //ja selleks on vaja luua class nimega Person
            IList<Person> person = new List<Person>()
                new Person() { Id = 1, Name = "Juku", Age = 10 },
                new Person() { Id = 2, Name = "Jaanus", Age = 11 },
                new Person() { Id = 3, Name = "Joosep", Age = 8 },
                new Person() { Id = 4, Name = "Toomas", Age = 15 },
            };

            //nüüd kasutame person muutjat uue muutja all
            //mille nimeks on persons

            var persons = from p in person
                          select new
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Age = p.Age,
                          };
            //kasutame muutujat persons, et näidata konsoolis tulemust
            foreach (var item in persons)
            {
                Console.WriteLine($"ID = {item.Id} Nimi: {item.Name} Vanus: {item.Age}");


            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Kasutame LINQ Selecti ehk teine variant");
            //Siin koondame kogu info result muutja sisse
            var result = person
                //Where-ga saab teha konkreetse päringu, et vastab mingitele tingimustele
                .Where(p => p.Id == 1 || p.Age == 9)
                .OrderBy(p => p.Name) //järjestab iskid nime järgi
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age
                });

            //kasutame result muutujat ja teeme ta lahti rea kaupa
            foreach (var item in result)
            {
                Console.WriteLine($"ID = {item.Id} Nimi: {item.Name} Vanus: {item.Age}");
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Gruppide kaupa sorteerimine");

            var groupBy = person
                .GroupBy(p => p.Age);
            //kuvab gruppide kaupa ja anutd juhul paneb vanused gruppidesse
            //e tulemuseks on kolm rida andmeid kuna kaks isikut on 9 a
            foreach (var item in groupBy)
            {
                Console.WriteLine("vanuse grupp on: {0}", item.Key);
            }
        }
    }
}