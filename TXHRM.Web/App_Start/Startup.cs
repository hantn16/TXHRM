using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using TXHRM.Data.Infrastructure;
using TXHRM.Data;
using TXHRM.Data.Repositories;
using TXHRM.Service;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.WebApi;
using TXHRM.Model.Models;
using Microsoft.AspNet.Identity;
using System.Web;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.AspNet.Identity.EntityFramework;
using TXHRM.Identity;

[assembly: OwinStartup(typeof(TXHRM.Web.App_Start.Startup))]

namespace TXHRM.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
            ConfigureAuth(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //Register your Web API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<TXHRMDbContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<RoleStore<AppRole>>().As<IRoleStore<AppRole, string>>();
            //Asp.net Identity
            builder.RegisterType<AppUserStore>().As<IUserStore<AppUser>>().InstancePerRequest();
            builder.RegisterType<AppUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<AppSignInManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<AppRoleManager>().AsSelf().InstancePerRequest();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            //Repositories
            builder.RegisterAssemblyTypes(typeof(PostRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            //Services
            builder.RegisterAssemblyTypes(typeof(PostService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}
