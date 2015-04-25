using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using EFFrameTest2.Data.Infrastructure;
using EFFrameTest2.Model;
using EFFrameTest2.Model.Entites;
using System;
using System.Linq;
using System.Collections.Generic;
using EFFrameTest2.Model.Utils;
using EFFrameTest2.Model.Enum;
using System.Collections;
using Autofac.Features.Indexed;
using System.Threading;




namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1:TestBase
    {

        [TestMethod]
        public void AutoFacTest()
        {
            //ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterType<ArrayList>().As<IEnumerable>();
            //var container=builder.Build();
            //ArrayList al = (ArrayList)container.Resolve<IEnumerable>();
            //Console.WriteLine(0);


            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ArrayList>().Keyed<IEnumerable>(ListType.array);
            builder.RegisterType<SortedList>().Keyed<IEnumerable>(ListType.sort);

            //builder.RegisterType<ArrayList>().Named<IEnumerable>("array");
            //builder.RegisterType<SortedList>().Named<IEnumerable>("sort");

            //builder.RegisterType<ArrayList>().Named<IEnumerable>(ListType.array.ToString());
            //builder.RegisterType<SortedList>().Named<IEnumerable>(ListType.sort.ToString());

            var container = builder.Build();
            
            //ArrayList al = (ArrayList)container.ResolveNamed<IEnumerable>("array");
            //SortedList sl = (SortedList)container.ResolveNamed<IEnumerable>("sort");

            //ArrayList a2 = (ArrayList)container.ResolveNamed<IEnumerable>(ListType.array.ToString());
            //SortedList s2 = (SortedList)container.ResolveNamed<IEnumerable>(ListType.sort.ToString());


            //ArrayList a3 = (ArrayList)container.ResolveKeyed<IEnumerable>(ListType.array);
            //SortedList s3 = (SortedList)container.ResolveKeyed<IEnumerable>(ListType.sort);

            IIndex<ListType,IEnumerable> list=container.Resolve<IIndex<ListType,IEnumerable>>();

            ArrayList al = (ArrayList)list[ListType.array];
            SortedList sl = (SortedList)list[ListType.sort];


            Console.WriteLine(0);




        }

        public enum ListType
        {
            array,
            sort
        }

        [TestMethod]
        public void TestEnum()
        {
            IDictionary<int, string> dict = Extension.EnumToDict(typeof(PrdoductStatus));
            Console.Write(2);
        }

        [TestMethod]
        public void QueryLocal()
        {
            var d = this.contact.QueryLocal();
            Assert.AreEqual(1, 23);
        }

        [TestMethod]
        public void FindSingleObj(){
            var d = this.contact.FindSingleObj(2);
            Assert.AreEqual(2, 2);
        }

        [TestMethod]
        public void OrderByTest()
        {
            var rest = this.contact.OrderByTest();
            Assert.AreEqual(1, 2);
        }

        [TestMethod]
        public void GetCustomContactlist()
        {
            //var d = this.contact.GetCustomContactList();
            var d = this.contact.GetContactListByProc(3);
            Assert.AreEqual(1,2);
        }

        [TestMethod]
        public void AddContactTest()
        {
            var contact = new Contact { ContactId=0, Age=28, Address="江西省瑞昌市横立山乡青领村上邹12组" , Mobile="15313150410", Name="邹大侠", Sex=false};
           

            var res= this.contact.InsertContact(contact);


            AutoMapper.Mapper.CreateMap<Contact, Person>().ForMember(dest => dest.PersonId, options => options.MapFrom(source => source.ContactId));

            var personmap = AutoMapper.Mapper.Map<Person>(contact);
            Assert.IsTrue(res>0);
        }

        [TestMethod]
        public void CategoryTest()
        {

            //var cate = new Category
            //{
            //    Picture = null,
            //    Description = "分类测试2",
            //    CategoryName = "分类2"
            //};

            //var product = new Product
            //{
            //    ProductName = "product three",
            //    UnitPrice = 30.0M,
            //    UnitsInStock = 300,
            //    Discontinued = true,
            //    //CategoryId=1,
            //    Category = cate
            //};
            var product2 = new Product {
             ProductName="product five",
              UnitPrice=25,
               Discontinued=true,
                UnitsInStock=550,
                 CategoryId=1
            };

            //int result= this.productsvc.Addproduct(product);
            int result2 = this.productsvc.Addproduct(product2);
            Assert.AreEqual(true,result2>0);
        }


        [TestMethod]
        public void GetProductList()
        {
            var list= this.productsvc.GetProductByCate(1);
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void GetList()
        {
            var res= this.contact.GetList();
            Assert.IsTrue(res.Count()>0);
        }

        [TestMethod]
        public void GetSingle()
        {
            var d = this.lodgingsvc.GetSingle(1);
            Assert.AreEqual(2, 2);
        }


        [TestMethod]
        public void InsertLoding()
        {
            //var Lodging = new Lodging
            //{
            //    Name = "Rainy Day Motel",
            //    Destination = new Destination
            //    {
            //        Name = "Seattle, Washington",
            //        Country = "USA"
            //    }
            //};

           
            var Lodging = new Lodging
            {
                Name = "adfasdf advb Motel2",
                Owner = "aaa",
                MilesFromNearestAirport = 20,
                DestinationIdentify = 1,
            };
            var result= this.lodgingsvc.InserLodging(Lodging);
            Assert.IsTrue(result > 0);

        }



        [TestMethod]
        public void InsertResort()
        {
            var resort = new Resort
            { 
                  LodgingIdentify =1,
                Name = "Top Notch Resort and Spa",
                MilesFromNearestAirport = 30,
                Activities = "Spa, Hiking, Skiing, Ballooning",
                Destination = new Destination
                {
                    Name = "Stowe, Vermont",
                    Country = "USA"
                }
            };
            var rows= this.lodgingsvc.InserLodging(resort);
            Assert.IsTrue(rows > 0);

            Thread signup = new Thread(new ParameterizedThreadStart((x) => { var a="";}));

        }


        [TestMethod]
        public void InsertRoleModule()
        {
            var model = new PermissionReRoleModule {
             RoleId=1,
              ModuleId=1,
               FuncCode=1,
                OptScope=1
            };

            var result = this.permissionSvc.AddOrUpdateReRoleModule(model);
            Assert.IsTrue(result>0);
        }

        [TestMethod]
        public void InsertModule()
        {
            var module = new PermissionModule {
                Name = "提交申请",
                IsMenu=1,
                OptCode="1,2,3"
            };
           var result= this.permissionSvc.AddOrUpdateModules(module);
           Assert.IsTrue(result>0);
        }


        [TestMethod]
        public void InsertRole()
        { 
            var role=new PermissionRole{
             Name="普通用户",
              Description="测试用只能看到自己的数据"
            };
            var result= this.permissionSvc.AddOrUpdateRole(role);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void TestRedisService()
        {
           string a=  RedisCaching.Get("aa", () => "aa11111");
           Assert.AreEqual("aa11111", a);
        }
    }
}
