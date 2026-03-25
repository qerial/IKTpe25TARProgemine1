using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inhertiance2
{
    internal class Lake : Water
    {
        //tehke sama asi, mis River-ga ja kutsuge see Programm classi Main meetodis esile
        public override void DoSomething()
        {
            Console.WriteLine("Lake method and " + Flow + " is and " + Length + " is in meters");
        }
    }
}
