using Autofac;
using Autofac.Integration.Wcf;
using EFFrameTest2.Data;
using EFFrameTest2.Services;
using EFFrameTest2.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace EFFrameTest2.SvcApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Startup.Configuration();
            //var builder = new ContainerBuilder();
            //builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();
            //builder.RegisterType<UnityOfWork>().As<IUnitOfWork>();

            //builder.RegisterType<ContactRepostory>().AsImplementedInterfaces();
            //builder.RegisterType<ContactServices>().AsSelf();
            //AutofacHostFactory.Container = builder.Build();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}