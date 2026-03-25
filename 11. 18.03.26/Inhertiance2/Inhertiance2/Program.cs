using System.ComponentModel;
namespace Inhertiance2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inheritance 2");

            Water water = new Water();
            water.Flow = true;
            water.Length = "123";

            //kuidas saada see korda???
            water.DoSomething();
        }
    }
}
