
using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext()
            : base("ContactStore")
        { 
            
        }
        public DbSet<Destination> Destinations { get; set; }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            using (var ctx = new ContactDbContext())
            {
                var province = ctx.Destinations.Find(1);
                ctx.Entry(province)
                    .Collection(p => p.Lodgings)
                    .Query()
                    .Load();

                foreach (var city in province.Lodgings)
                {
                    Console.WriteLine("{0}-{1}", province.Name, city.Name);
                }
                //var d = ctx.Destinations.Include(p => p.Lodgings);
                //foreach (var p in d) {
                //    foreach (var item in p.Lodgings)
                //    {
                //        Console.WriteLine("{0}-{1}",item.Name,item.LodgingIdentify);
                //    }
                //}
            }
            //{
            //    var provinces = ctx.Provinces
            //        .Include(p => p.Cities);

            //    foreach (var province in provinces)
            //    {
            //        foreach (var city in province.Cities)
            //        {
            //            Console.WriteLine("{0}-{1}", province.ProvinceName, city.CityName);
            //        }
            //    }
            //}
        }
    }
}
