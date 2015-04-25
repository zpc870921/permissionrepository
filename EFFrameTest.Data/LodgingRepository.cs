using EFFrameTest2.Data.Infrastructure;
using EFFrameTest2.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Data
{
    public partial class LodgingRepository : RepositoryBase<Lodging>, ILodgingRepository
    {
        public LodgingRepository(IDatabaseFactory factory) : base(factory) { 
            
        }

        public Destination GetSingle(int id)
        {
           //var d= this.DataContext.Set<Destination>().Find(1);
           // //var d= this.GetById(id);
           // foreach(var item in d.Lodgings)
           // {

           // }
           // return d;


            //var province = this.DataContext.Set<Destination>().Find(1);


            //entry collection和reference

            //var city = this.DataContext.Set<Lodging>().Find(id);

            //this.DataContext.Entry(city)
            //    .Reference(p => p.Destination)
            //    .Load();

            //检查集合属性是否已经加载
            //var city = this.DataContext.Set<Destination>().Find(id);

            //var a= this.DataContext.Entry(city)
            //    .Collection(p=>p.Lodgings)
            //    .IsLoaded;

            
            //this.DataContext.Entry(city)
            //    .Collection(p=>p.Lodgings)
            //    .Load();

            //var b = this.DataContext.Entry(city)
            //    .Collection(p => p.Lodgings)
            //    .IsLoaded;

            //var city = this.DataContext.Set<Destination>().Find(id);

            //var expr= this.DataContext.Entry(city)
            //    .Collection(p => p.Lodgings).Query().Where(p=>p.LodgingIdentify==2).Where(p=>p.Name.Contains("Day"));

            //foreach(var item in expr){
            
            //}

            //var d = from p in expr where p.Name.Contains("Day") && p.LodgingIdentify==2 select p;


            //foreach (var item in d)
            //{ 
                
            //}

            //var c = expr.Count();

            //var citys = from p in expr
            //            where p.LodgingIdentify == 2
            //            select p;

            //var a = citys.FirstOrDefault();
            
            //var d = from p in expr select p;

            return null;
            //foreach (var city in province.Lodgings)
            //{
            //    Console.WriteLine("{0}-{1}", province.Name, city.Name);
            //}
           // return province;
        }
   }
   public partial interface ILodgingRepository:IRepository<Lodging>
   {
        Destination GetSingle(int id);  
   }
}
