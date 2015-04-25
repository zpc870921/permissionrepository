
using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using EFFrameTest2.Data.Infrastructure;
using EFFrameTest2.Services;
using EFFrameTest2.Data;
using Autofac.Integration.Wcf;
using EFFrameTest2.Data.Repository;

[assembly: OwinStartup(typeof(EFFrameTest2.SvcApp.Startup))]

namespace EFFrameTest2.SvcApp
{
    public class Startup
    {
        public static void Configuration()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UnityOfWork>().As<IUnitOfWork>();

            builder.RegisterType<ContactRepostory>().AsImplementedInterfaces();
            builder.RegisterType<ContactServices>().AsSelf();

            #region 权限
            builder.RegisterType<PermissionModuleRepository>().AsImplementedInterfaces();
            builder.RegisterType<PermissionRoleRepository>().AsImplementedInterfaces();
            builder.RegisterType<PermissionReRoleModuleRepostory>().AsImplementedInterfaces();
            builder.RegisterType<UserRepository>().AsImplementedInterfaces();
            builder.RegisterType<UserReRoleRepository>().AsImplementedInterfaces();
            builder.RegisterType<PermissionSvc>().AsSelf();
            
            #endregion
            

            AutofacHostFactory.Container = builder.Build();
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
