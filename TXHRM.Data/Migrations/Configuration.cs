namespace TXHRM.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TXHRM.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TXHRM.Data.TXHRMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TXHRM.Data.TXHRMDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TXHRMDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TXHRMDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "admin",
                Email = "hantn16@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Han Trinh"

            };
            manager.Create(user, "anhhan");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("hantn16@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}
