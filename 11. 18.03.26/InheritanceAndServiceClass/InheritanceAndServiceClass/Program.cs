using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace IncheritanceAndServicesClass.Appservices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Console.WriteLine("Hello World!");
        }
    }
}
