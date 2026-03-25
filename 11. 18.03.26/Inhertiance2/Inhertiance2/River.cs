using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Inhertiance2
{
    class River : Water
    {
        //kui kirjutan override, siis kirjutab Water meetodis oleva DoSomething meetodi üle
        //kui panen siia public virtual void, siis ei kirjuta Water meetodi DoSomething-t üle
        public override void DoSomething()
        {
            //WaterProp waterProp = new WaterProp();
            //Water classis on olemas muutjuad Flow ja Lenght ja sellepärast ei pea neid siin uuesti defineerima
            Console.WriteLine("This river method and " + Flow + " is and " + Length + " is in meters");
        }
    }
}
