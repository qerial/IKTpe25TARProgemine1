namespace LINQall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello LINQ");
            Console.WriteLine("1. All");
            Console.WriteLine("2. Any");
            Console.WriteLine("3. Join");
            Console.WriteLine("\n");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AllLinq();
                    break;
                case 2:
                    AnyLinq();
                    break;
                case 3:
                    JoinLinq();
                    break;
                default:
                    Console.WriteLine("valikut pole ERROR1");
                    break;
            }
        }

        public static void AllLinq()
        {
            Console.Clear();
            Console.WriteLine("--------AllLinq--------");
            //kasutate All
            //kontrollite, kas on vanemaid, kui 12 ja nooremaid, kui 20
            var all = StudentData.students.All(x => x.Age >= 12 && x.Age <= 20);

            Console.WriteLine("kas inimesi on alla 20 ja üle 12: " + all);
        }
        //teeme uue meetodi nimega AnyLinq
        //kasutame Any-t
        //vastus on true
        public static void AnyLinq()
        {
            Console.Clear();
            Console.WriteLine("--------AnyLinq--------");
            bool any = StudentData.students.Any(x => x.Age >= 12 &&
            x.Age <= 20);
            Console.WriteLine(any);
        }

        public static void JoinLinq()
        {
            //teha meetod nimega JoinLinq
            //kasutada Join-i
            Console.Clear();
            Console.WriteLine("--------JoinLinq--------");
            var innerJoin = StudentData.students
                .Join
                (
                StandardData.standards,
                students => students.StandardId,
                StandardId => StandardId.StandardId,
                (students, standardId) => new
                {
                    Name = students.Name,
                    StandardId = standardId.StandardId,
                }
            );

            foreach (var item in innerJoin)
            {
                Console.WriteLine("{0} - {1}", item.Name, item.StandardId);
            }
        }
    }
}
