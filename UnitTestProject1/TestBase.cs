using Autofac;
using EFFrameTest2.Data;
using EFFrameTest2.Data.Repository;
using EFFrameTest2.Model;
using EFFrameTest2.Model.Entites;
using EFFrameTest2.Services;
using EFFrameTest2.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
   public class TestBase
    {
        protected IContainer container;
        protected IUnitOfWork unitOfWork;
        protected IContact contact;
        protected IProduct productsvc;
        protected ILodging lodgingsvc;
        protected IResort resortSvc;
        protected IPermission permissionSvc;
       public TestBase()
       {
           var builder = new ContainerBuilder();
           builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
           builder.RegisterType<UnityOfWork>().As<IUnitOfWork>();

           builder.RegisterType<ContactRepostory>().AsImplementedInterfaces();
           builder.RegisterType<ContactServices>().AsImplementedInterfaces();
           builder.RegisterType<ProductRepository>().AsImplementedInterfaces();
           builder.RegisterType<LodgingRepository>().AsImplementedInterfaces();
           builder.RegisterType<ResortRepository>().AsImplementedInterfaces();

           builder.RegisterType<ProductService>().AsImplementedInterfaces();
           builder.RegisterType<LodgingService>().AsImplementedInterfaces();
           builder.RegisterType<ResortService>().AsImplementedInterfaces();

           #region 权限
           builder.RegisterType<PermissionModuleRepository>().AsImplementedInterfaces();
           builder.RegisterType<PermissionRoleRepository>().AsImplementedInterfaces();
           builder.RegisterType<PermissionReRoleModuleRepostory>().AsImplementedInterfaces();
           builder.RegisterType<PermissionSvc>().AsImplementedInterfaces();
           #endregion
           container= builder.Build();
           this.unitOfWork = container.Resolve<IUnitOfWork>();
           this.contact=container.Resolve<IContact>();
           this.productsvc=container.Resolve<IProduct>();
           this.resortSvc = container.Resolve<IResort>();
           this.lodgingsvc = container.Resolve<ILodging>();
           this.permissionSvc = container.Resolve<IPermission>();
         //  StartUp();

       }
       public static void StartUp()
       {
           AutoMapper.Mapper.CreateMap<Contact,Person>().ForMember(dest=>dest.PersonId,options=>options.MapFrom(source=>source.ContactId));
       }
    }
}
