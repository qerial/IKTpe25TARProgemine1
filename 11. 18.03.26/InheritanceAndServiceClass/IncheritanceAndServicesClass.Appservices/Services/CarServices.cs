using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceAndServiceClass.Core.NewFolder;

namespace InheritanceAndServiceClass.Services
{
    public class CarServices : ICarServices
    {

        public void GetData()
        {
            Console.WriteLine("Car Services");
        }

        public void PostData()
        {
            Console.WriteLine("andmed on edukalt salvestatud");
        }
    }
}
