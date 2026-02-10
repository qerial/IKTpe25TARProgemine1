using System.Threading.Channels;

namespace Enum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enum");

            //kasutate enumit ja tahaks näha Friday
            Console.WriteLine(Weekdays.Friday);
            //tahame näha Friday numbrilist väärtust
            int days = (int)Weekdays.Friday;
            Console.WriteLine(days);
            //(int) - castimine e teisendab teiseks andmetüübiks
            Console.WriteLine("\n");

            Console.WriteLine(Colors.White);
            Console.WriteLine((int)Colors.White);
            //tehke uus enum Colors
            //väärtused on 
        }
        enum Weekdays
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        enum Colors
        {
            Red = 3,
            Green = 10,
            Blue = 13,
            Yellow = 5,
            Black = 1,
            White = 8
        }
    }
}