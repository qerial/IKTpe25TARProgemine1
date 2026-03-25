using System.ComponentModel;
namespace Inhertiance2
{
    //River on antud juhul alamklass ja viitab Waterile e peamisele classile
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Inheritance 2");

            //kui siin on Water class, siis kuvatakse seal olevat DoSomething meetodi sisu
            Water water = new Water();

            //kui panna Water water = new River(); , siis kuvatakse River classis olevat DoSomething
            //meetodi sisu.
            Water water2 = new River();
            water2.Flow = true;
            water2.Length = "123";

            Water water3 = new Lake();
            water3.Length = "422";
            water3.Flow = false;
            

            //kutsume soovitud meetodi esile.
            water.DoSomething();
            water2.DoSomething();
            water3.DoSomething();
        }
    }
}
