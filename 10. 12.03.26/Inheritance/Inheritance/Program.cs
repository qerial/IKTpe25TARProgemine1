using System.Runtime.ExceptionServices;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert to numbers: ");
            Console.WriteLine("First number: ");
            int firstNr = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Second number: ");
            int secondNr = Convert.ToInt32(Console.ReadLine());

            Rectangle rectangle = new Rectangle();
            rectangle.SetWidth(firstNr);
            rectangle.SetHeight(secondNr);

            Console.WriteLine("Total area: {0}", rectangle.GetArea);

        }
    }
    class Shape 
    {
        public void SetWidth(int w)
        {
            width = w;
        }
        public void SetHeight(int h)
        {
            width = h;
        }

        protected int width;
        protected int height;
    }
    //koolon tähendab pärimist
    //läbi pärimise saame kasutada muutujaid width ja height, mis asuvad Shape classis
    //ning neid ei pea siis defineerima rectangle classis
    class Rectangle : Shape
    {
        public int GetArea()
        {
            //return tagasitab info selles meetodis toimunud loogika kohta
            return (width + height);
        }

    }
}
