using System.Linq;
using FileData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WebAppiDNP.Models;

namespace WebAppiDNP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (AdultContext adultcontext = new AdultContext())
            {
                if (!adultcontext.Adults.Any())
                {
                    Seed(adultcontext);
                }
            }
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        private static void Seed(AdultContext adultcontext){
            Adult adult = new Adult()
            {
                Id = 1,
                FirstName = "catman",
                LastName = "Johnon",
                Age = 12,
                EyeColor = "Black",
                Height = 120,
                HairColor = "Black",
                Sex = "man",
                Weight = 21
            };
            adultcontext.Add(adult);
            Adult adult1 = new Adult()
            {
                Id = 12,
                FirstName = "Sally",
                LastName = "Johnon",
                Age = 10,
                EyeColor = "Green",
                Height = 13,
                HairColor = "Brown",
                Sex = "woman",
                Weight = 20
            };
            adultcontext.Add(adult1);
            Adult adult3 = new Adult()
            {
                Id = 11,
                FirstName = "cato",
                LastName = "John",
                Age = 16,
                EyeColor = "Blue",
                Height = 11,
                HairColor = "Black",
                Sex = "man",
                Weight = 111
            };
            adultcontext.Add(adult3);
            adultcontext.SaveChanges();
        }
         
      
    }
    
}