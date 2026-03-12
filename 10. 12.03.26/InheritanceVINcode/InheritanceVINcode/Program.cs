using System.Reflection.Metadata.Ecma335;

namespace InheritanceVINcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //teha pärilus
            //On olemas class nimega Machine
            //See pärib Cars classi
            //Saab sisestada masina numbri
            //konsool annab vastuse: Edukalt sisestatud
            //VIN kood: Vin koodi nr
            Console.WriteLine("Enter machine number: ");
            int vinCode = Convert.ToInt32(Console.ReadLine());


            Machine machine = new Machine();
            machine.SetVinCode(vinCode);

            Console.WriteLine("Vin code is: " + machine.GetVinCode());

        }
    }

    class Car
    {
        public void SetVinCode(int vinCode)
        {
            vin = vinCode;
        }

        protected int vin;
    }
    class Machine : Car
    {
        public int GetVinCode()
        {
            return vin;
        }
    }
}
