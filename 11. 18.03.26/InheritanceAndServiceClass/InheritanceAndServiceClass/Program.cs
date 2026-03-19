using System.Xml.Serialization;
using IncheritanceAndServicesClass.Services;
using InheritanceAndServiceClass.Core.NewFolder;
using InheritanceAndServiceClass.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace IncheritanceAndServicesClass.Appservices
{
    internal class Program
    {
        private readonly IDataServices _dataServices;
        private readonly ICarServices _carServices;

        public Program
            (
                IDataServices dataServices
            )
        {
            _dataServices = dataServices;
        }


        public Program
            (
                ICarServices carServices
            )
        {
            _carServices = carServices;
        }

        static void Main(string[] args)
        {
            var builder1 = WebApplication.CreateBuilder(args);

            builder1.Services.AddScoped<IDataServices, DataServices>();

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICarServices, CarServices>();

            Console.WriteLine("Hello, World Switch!");
            Console.WriteLine("1. ");
            Console.WriteLine("2. ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var app = builder.Build();
                    using (var scope = app.Services.CreateScope())
                    {
                        var carServices = scope.ServiceProvider.GetRequiredService<ICarServices>();
                        var program = new Program(carServices);
                        program.GetAsync();
                    }
                    break;

                case 2:
                    var app1 = builder.Build();
                    using (var scope = app1.Services.CreateScope())
                    {
                        var dataServices = scope.ServiceProvider.GetRequiredService<IDataServices>();
                        var program = new Program(dataServices);
                        program.SaveAsync();
                    }
                    break;

                case 3:

                    break;
                case 4:

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
                    

        public IActionResult GetAsync()
        {
            _carServices.GetData();

            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

        public IActionResult SaveAsync()
        {
            _dataServices.GetData();

            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

        
    }
}