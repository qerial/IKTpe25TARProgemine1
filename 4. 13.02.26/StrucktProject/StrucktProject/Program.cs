using System.Threading.Channels;

namespace StrucktProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Struct");

            Coordinate point = new Coordinate();
            Console.WriteLine(point.X);
            Console.WriteLine(point.Y);
            Console.WriteLine("------------------------------------");
            IntAndString intAndString = new IntAndString();
            Console.WriteLine(intAndString.Name);
            Console.WriteLine(intAndString.Age);
            Console.WriteLine("------------------------------------");
            InsertedIntAndString insertedIntAndString = new InsertedIntAndString(Tallinn, 7942); 
            Console.WriteLine(insertedIntAndString.City);
            Console.WriteLine(insertedIntAndString.Postalcode);
        }
    }

    //Mis on struct?
    //See on väärtustüüp (value type), mis sarnaneb klassile
    struct Coordinate
    {
        public int X;
        public int Y;

        //teha konstruktor

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    //teha stuct nimega IntAndString
    //string Name ja Int on Age
    //kutsuda see struct Main-s välja
    struct IntAndString
    {
        public string Name;
        public int Age;

        public IntAndString(string name, int age) 
        {
           Name = name;
            Age = age;
        }
    }

    //teha struct nimega InstertedIntAndString
    //string City ja int on PostalCode
    //kutsuda see struct Main-s välja
    //structi sees tuleb sellele anda juba väärtus
    struct InsertedIntAndString
    {
        public string City;
        public int Postalcode;

        public InsertedIntAndString(string city, int postalcode)
        {
            City = city;
            Postalcode = postalcode;

            city = "Tallinn";
            postalcode = 79492;


        }
    }
}