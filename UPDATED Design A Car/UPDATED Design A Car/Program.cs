using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPDATED_Design_A_Car.DAO;

namespace UPDATED_Design_A_Car
{
    public class Program
    {
        private const string ApiUrl = "http://localhost:16078";

        //Connection String
        ICarDao carDao = new CarSqlDao(@"Server=.\SQLEXPRESS;Database=DescribeACar;Trusted_Connection=True;");

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
