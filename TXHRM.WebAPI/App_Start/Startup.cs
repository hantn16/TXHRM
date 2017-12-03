using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Autofac;
using System.Web.Mvc;
using System.Reflection;
using TXHRM.Service;
using TXHRM.Data.Repositories;
using TXHRM.Data.Infrastructure;
using TXHRM.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using TXHRM.Model.Models;
using Microsoft.AspNet.Identity;
using TXHRM.Identity;
using System.Web;
using Microsoft.Owin.Security.DataProtection;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

[assembly: OwinStartup(typeof(TXHRM.WebAPI.App_Start.Startup))]

namespace TXHRM.WebAPI.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //HttpConfiguration config = new HttpConfiguration();
            //WebApiConfig.Register(config);
            //app.UseWebApi(config);

            ConfigAutofac(app);
            ConfigureAuth(app);

        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

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

            // Repositories
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}
