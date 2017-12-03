namespace TXHRM.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
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
            CreateUser(context);
            CreateFunction(context);
            CreateConfigTitle(context);
            SetPerMission(context);
        }
        private void CreateUser(TXHRMDbContext context)
        {
            var manager = new UserManager<AppUser>(new UserStore<AppUser>(new TXHRMDbContext()));
            if (manager.Users.Count() == 0)
            {
                var roleManager = new RoleManager<AppRole>(new RoleStore<AppRole>(new TXHRMDbContext()));

                var user = new AppUser()
                {
                    UserName = "admin",
                    Email = "hantn16@gmail.com",
                    EmailConfirmed = true,
                    BirthDay = DateTime.Now,
                    FullName = "Trịnh Ngọc Hân",
                    Avatar = "/assets/images/img.jpg",
                    Gender = true,
                    Status = true
                };
                if (manager.Users.Count(x => x.UserName == "admin") == 0)
                {
                    manager.Create(user, "123654$");

                    if (!roleManager.Roles.Any())
                    {
                        roleManager.Create(new AppRole { Name = "Admin", Description = "Quản trị viên" });
                        roleManager.Create(new AppRole { Name = "Member", Description = "Người dùng" });
                    }

                    var adminUser = manager.FindByName("admin");

                    manager.AddToRoles(adminUser.Id, new string[] { "Admin", "Member" });
                }
            }
        }
        private void CreateFunction(TXHRMDbContext context)
        {
            if (context.Functions.Count() == 0)
            {
                context.Functions.AddRange(new List<Function>()
                {
                    new Function() {Id = "SYSTEM", Name = "Hệ thống",ParentId = null,DisplayOrder = 1,Status = true,URL = "/",IconCss = "fa-desktop"  },
                    new Function() {Id = "ROLE", Name = "Nhóm",ParentId = "SYSTEM",DisplayOrder = 1,Status = true,URL = "/main/role/index",IconCss = "fa-home"  },
                    new Function() {Id = "FUNCTION", Name = "Chức năng",ParentId = "SYSTEM",DisplayOrder = 2,Status = true,URL = "/main/function/index",IconCss = "fa-home"  },
                    new Function() {Id = "USER", Name = "Người dùng",ParentId = "SYSTEM",DisplayOrder =3,Status = true,URL = "/main/user/index",IconCss = "fa-home"  },
                    new Function() {Id = "ACTIVITY", Name = "Nhật ký",ParentId = "SYSTEM",DisplayOrder = 4,Status = true,URL = "/main/activity/index",IconCss = "fa-home"  },
                    new Function() {Id = "ERROR", Name = "Lỗi",ParentId = "SYSTEM",DisplayOrder = 5,Status = true,URL = "/main/error/index",IconCss = "fa-home"  },
                    new Function() {Id = "SETTING", Name = "Cấu hình",ParentId = "SYSTEM",DisplayOrder = 6,Status = true,URL = "/main/setting/index",IconCss = "fa-home"  },

                    new Function() {Id = "ORGANIZATION",Name = "Cơ cấu, tổ chức",ParentId = null,DisplayOrder = 2,Status = true,URL = "/",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "DEPARTMENT",Name = "Phòng ban",ParentId = "ORGANIZATION",DisplayOrder =1,Status = true,URL = "/main/department/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "POSITION",Name = "Chức vụ",ParentId = "ORGANIZATION",DisplayOrder = 2,Status = true,URL = "/main/position/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "EMPLOYEE",Name = "Nhân viên",ParentId = "ORGANIZATION",DisplayOrder = 3,Status = true,URL = "/main/employee/index",IconCss = "fa-chevron-down"  },

                    new Function() {Id = "CONTENT",Name = "Nội dung",ParentId = null,DisplayOrder = 3,Status = true,URL = "/",IconCss = "fa-table"  },
                    new Function() {Id = "POST_CATEGORY",Name = "Danh mục",ParentId = "CONTENT",DisplayOrder = 1,Status = true,URL = "/main/post-category/index",IconCss = "fa-table"  },
                    new Function() {Id = "POST",Name = "Bài viết",ParentId = "CONTENT",DisplayOrder = 2,Status = true,URL = "/main/post/index",IconCss = "fa-table"  },

                    new Function() {Id = "UTILITY",Name = "Tiện ích",ParentId = null,DisplayOrder = 4,Status = true,URL = "/",IconCss = "fa-clone"  },
                    new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",DisplayOrder = 1,Status = true,URL = "/main/footer/index",IconCss = "fa-clone"  },
                    new Function() {Id = "FEEDBACK",Name = "Phản hồi",ParentId = "UTILITY",DisplayOrder = 2,Status = true,URL = "/main/feedback/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ANNOUNCEMENT",Name = "Thông báo",ParentId = "UTILITY",DisplayOrder = 3,Status = true,URL = "/main/announcement/index",IconCss = "fa-clone"  },
                    new Function() {Id = "CONTACT",Name = "Liên hệ",ParentId = "UTILITY",DisplayOrder = 4,Status = true,URL = "/main/contact/index",IconCss = "fa-clone"  },

                    new Function() {Id = "REPORT",Name = "Báo cáo",ParentId = null,DisplayOrder = 5,Status = true,URL = "/",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "SALARY",Name = "Báo cáo lương",ParentId = "REPORT",DisplayOrder = 1,Status = true,URL = "/main/report/salary",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "ACCESS",Name = "Báo cáo truy cập",ParentId = "REPORT",DisplayOrder = 2,Status = true,URL = "/main/report/visitor",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "VIEWER",Name = "Báo cáo người xem",ParentId = "REPORT",DisplayOrder = 3,Status = true,URL = "/main/report/viewer",IconCss = "fa-bar-chart-o"  },

                });
                context.SaveChanges();
            }
        }
        private void CreateConfigTitle(TXHRMDbContext context)
        {
            if (!context.SystemConfigs.Any(x => x.Code == "HomeTitle"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeTitle",
                    ValueString = "Trang chủ Quản Trị Nhân Sự Trà Xom",
                    CreatedDate = DateTime.Now,
                    Status = true
                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaKeyword"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaKeyword",
                    ValueString = "Trang chủ Quản Trị Nhân Sự Trà Xom",
                    CreatedDate = DateTime.Now,
                    Status = true
                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaDescription"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaDescription",
                    ValueString = "Trang chủ Quản Trị Nhân Sự Trà Xom",
                    CreatedDate = DateTime.Now,
                    Status = true
                });
            }
        }
        private void SetPerMission(TXHRMDbContext context)
        {
            List<Function> list = context.Functions.Where(c => c.ParentId != null).ToList();
            AppRole adminRole = context.Roles.SingleOrDefault(c => c.Name == "Admin");
            List<Permission> listPer = new List<Permission>();
            if (list.Count>0 && adminRole!=null)
            {
                foreach (Function item in list)
                {
                    Permission per = new Permission();
                    per.RoleId = adminRole.Id;
                    per.FunctionId = item.Id;
                    per.CanCreate = per.CanDelete = per.CanRead = per.CanUpdate = true;
                    listPer.Add(per);
                }
            }
            if (context.Permissions.Count()==0)
            {
                context.Permissions.AddRange(listPer);
                context.SaveChanges();
            }
        }
    }
}
