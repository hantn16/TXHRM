using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TXHRM.Model.Models;

namespace TXHRM.Data
{
    public class TXHRMDbContext : IdentityDbContext<AppUser>
    {
        public TXHRMDbContext() : base("TXHRMConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }
        public DbSet<WorkingProcess> WorkingProcesses { get; set; }
        public DbSet<Error> Errors { get; set; }

        public DbSet<Function> Functions { set; get; }
        public DbSet<Permission> Permissions { set; get; }

        public DbSet<AppRole> AppRoles { set; get; }
        public DbSet<IdentityUserRole> UserRoles { set; get; }

        public static TXHRMDbContext Create()
        {
            return new TXHRMDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasKey<string>(r => r.Id).ToTable("AppRole");
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("AppUserRole");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("AppUserLogin");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("AppUserClaim");
        }
    }
}