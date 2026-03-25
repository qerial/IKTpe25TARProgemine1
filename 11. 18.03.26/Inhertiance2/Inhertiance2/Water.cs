using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Inhertiance2
{
    internal class Water
    {
        public bool Flow;
        public string Length;

        public virtual void DoSomething()
        {
            Console.WriteLine("Do Something method");
        }
    }

    //internal class WaterProp
    // {
    //     WaterProp waterProp = new WaterProp();
    //
    //     public bool Flow;
    //    public string Length;
    //}
}
