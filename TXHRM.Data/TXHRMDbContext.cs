﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public DbSet<MenuGroup> MenuGroup { get; set; }
        public DbSet<Page> Page { get; set; }
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

        public DbSet<AppRole> AppRoles { get; set; }

        public static TXHRMDbContext Create()
        {
            return new TXHRMDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<IdentityUserRole>().HasKey(c => new { c.UserId, c.RoleId });
            dbModelBuilder.Entity<IdentityUserLogin>().HasKey(c => c.UserId);
        }
    }
}
