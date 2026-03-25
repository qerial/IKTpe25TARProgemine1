using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Inhertiance2
{
    class River : Water
    {

        public override void DoSomething()
        {
            //WaterProp waterProp = new WaterProp();
            //kuidas saada ära kasutada WaterProp classis olevaid muutujaid siin
            Console.WriteLine("This river method and " + Flow + " is and " + Length + " is in meters");
        }
    }
}
