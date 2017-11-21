namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeAuthTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PostCategory", new[] { "ParentID" });
            DropPrimaryKey("dbo.VisitorStatistic");
            CreateTable(
                "dbo.AppRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AppRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.AppUser", t => t.AppUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Function",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        URL = c.String(nullable: false, maxLength: 256),
                        DisplayOrder = c.Int(nullable: false),
                        ParentId = c.String(maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                        IconCss = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Function", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleId = c.String(maxLength: 128),
                        FunctionId = c.String(maxLength: 50, unicode: false),
                        CanCreate = c.Boolean(nullable: false),
                        CanRead = c.Boolean(nullable: false),
                        CanUpdate = c.Boolean(nullable: false),
                        CanDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppRole", t => t.RoleId)
                .ForeignKey("dbo.Function", t => t.FunctionId)
                .Index(t => t.RoleId)
                .Index(t => t.FunctionId);
            
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        Avatar = c.String(),
                        BirthDay = c.DateTime(),
                        Status = c.Boolean(),
                        Gender = c.Boolean(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUserClaim",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AppUser", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.AppUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AppUser", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            AddColumn("dbo.Department", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Department", "CreatedBy", c => c.String());
            AddColumn("dbo.Department", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Department", "ModifiedBy", c => c.String());
            AddColumn("dbo.Department", "MetaKeyword", c => c.String());
            AddColumn("dbo.Department", "MetaDescription", c => c.String());
            AddColumn("dbo.Employee", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employee", "CreatedBy", c => c.String());
            AddColumn("dbo.Employee", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Employee", "ModifiedBy", c => c.String());
            AddColumn("dbo.Employee", "MetaKeyword", c => c.String());
            AddColumn("dbo.Employee", "MetaDescription", c => c.String());
            AddColumn("dbo.Position", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Position", "CreatedBy", c => c.String());
            AddColumn("dbo.Position", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Position", "ModifiedBy", c => c.String());
            AddColumn("dbo.Position", "MetaKeyword", c => c.String());
            AddColumn("dbo.Position", "MetaDescription", c => c.String());
            AddColumn("dbo.WorkingProcess", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkingProcess", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkingProcess", "CreatedBy", c => c.String());
            AddColumn("dbo.WorkingProcess", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.WorkingProcess", "ModifiedBy", c => c.String());
            AddColumn("dbo.WorkingProcess", "MetaKeyword", c => c.String());
            AddColumn("dbo.WorkingProcess", "MetaDescription", c => c.String());
            AddColumn("dbo.MenuGroup", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.MenuGroup", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MenuGroup", "CreatedBy", c => c.String());
            AddColumn("dbo.MenuGroup", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.MenuGroup", "ModifiedBy", c => c.String());
            AddColumn("dbo.MenuGroup", "MetaKeyword", c => c.String());
            AddColumn("dbo.MenuGroup", "MetaDescription", c => c.String());
            AddColumn("dbo.Menu", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Menu", "CreatedBy", c => c.String());
            AddColumn("dbo.Menu", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Menu", "ModifiedBy", c => c.String());
            AddColumn("dbo.Menu", "MetaKeyword", c => c.String());
            AddColumn("dbo.Menu", "MetaDescription", c => c.String());
            AddColumn("dbo.Tag", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tag", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tag", "CreatedBy", c => c.String());
            AddColumn("dbo.Tag", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Tag", "ModifiedBy", c => c.String());
            AddColumn("dbo.Tag", "MetaKeyword", c => c.String());
            AddColumn("dbo.Tag", "MetaDescription", c => c.String());
            AddColumn("dbo.Slide", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Slide", "CreatedBy", c => c.String());
            AddColumn("dbo.Slide", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Slide", "ModifiedBy", c => c.String());
            AddColumn("dbo.Slide", "MetaKeyword", c => c.String());
            AddColumn("dbo.Slide", "MetaDescription", c => c.String());
            AddColumn("dbo.SystemConfig", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.SystemConfig", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SystemConfig", "CreatedBy", c => c.String());
            AddColumn("dbo.SystemConfig", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.SystemConfig", "ModifiedBy", c => c.String());
            AddColumn("dbo.SystemConfig", "MetaKeyword", c => c.String());
            AddColumn("dbo.SystemConfig", "MetaDescription", c => c.String());
            AlterColumn("dbo.Page", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.PostCategory", "DisplayOrder", c => c.Int());
            AlterColumn("dbo.PostCategory", "ParentID", c => c.Int());
            AlterColumn("dbo.PostCategory", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Post", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.VisitorStatistic", "ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.VisitorStatistic", "ID");
            CreateIndex("dbo.PostCategory", "Name", unique: true);
            CreateIndex("dbo.PostCategory", "ParentID");
            CreateIndex("dbo.Post", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserRole", "AppUser_Id", "dbo.AppUser");
            DropForeignKey("dbo.AppUserLogin", "AppUser_Id", "dbo.AppUser");
            DropForeignKey("dbo.AppUserClaim", "AppUser_Id", "dbo.AppUser");
            DropForeignKey("dbo.AppUserRole", "IdentityRole_Id", "dbo.AppRole");
            DropForeignKey("dbo.Permissions", "FunctionId", "dbo.Function");
            DropForeignKey("dbo.Permissions", "RoleId", "dbo.AppRole");
            DropForeignKey("dbo.Function", "ParentId", "dbo.Function");
            DropIndex("dbo.AppUserLogin", new[] { "AppUser_Id" });
            DropIndex("dbo.AppUserClaim", new[] { "AppUser_Id" });
            DropIndex("dbo.Post", new[] { "Name" });
            DropIndex("dbo.PostCategory", new[] { "ParentID" });
            DropIndex("dbo.PostCategory", new[] { "Name" });
            DropIndex("dbo.Permissions", new[] { "FunctionId" });
            DropIndex("dbo.Permissions", new[] { "RoleId" });
            DropIndex("dbo.Function", new[] { "ParentId" });
            DropIndex("dbo.AppUserRole", new[] { "AppUser_Id" });
            DropIndex("dbo.AppUserRole", new[] { "IdentityRole_Id" });
            DropPrimaryKey("dbo.VisitorStatistic");
            AlterColumn("dbo.VisitorStatistic", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Post", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PostCategory", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PostCategory", "ParentID", c => c.Int(nullable: false));
            AlterColumn("dbo.PostCategory", "DisplayOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.Page", "ModifiedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.SystemConfig", "MetaDescription");
            DropColumn("dbo.SystemConfig", "MetaKeyword");
            DropColumn("dbo.SystemConfig", "ModifiedBy");
            DropColumn("dbo.SystemConfig", "ModifiedDate");
            DropColumn("dbo.SystemConfig", "CreatedBy");
            DropColumn("dbo.SystemConfig", "CreatedDate");
            DropColumn("dbo.SystemConfig", "Status");
            DropColumn("dbo.Slide", "MetaDescription");
            DropColumn("dbo.Slide", "MetaKeyword");
            DropColumn("dbo.Slide", "ModifiedBy");
            DropColumn("dbo.Slide", "ModifiedDate");
            DropColumn("dbo.Slide", "CreatedBy");
            DropColumn("dbo.Slide", "CreatedDate");
            DropColumn("dbo.Tag", "MetaDescription");
            DropColumn("dbo.Tag", "MetaKeyword");
            DropColumn("dbo.Tag", "ModifiedBy");
            DropColumn("dbo.Tag", "ModifiedDate");
            DropColumn("dbo.Tag", "CreatedBy");
            DropColumn("dbo.Tag", "CreatedDate");
            DropColumn("dbo.Tag", "Status");
            DropColumn("dbo.Menu", "MetaDescription");
            DropColumn("dbo.Menu", "MetaKeyword");
            DropColumn("dbo.Menu", "ModifiedBy");
            DropColumn("dbo.Menu", "ModifiedDate");
            DropColumn("dbo.Menu", "CreatedBy");
            DropColumn("dbo.Menu", "CreatedDate");
            DropColumn("dbo.MenuGroup", "MetaDescription");
            DropColumn("dbo.MenuGroup", "MetaKeyword");
            DropColumn("dbo.MenuGroup", "ModifiedBy");
            DropColumn("dbo.MenuGroup", "ModifiedDate");
            DropColumn("dbo.MenuGroup", "CreatedBy");
            DropColumn("dbo.MenuGroup", "CreatedDate");
            DropColumn("dbo.MenuGroup", "Status");
            DropColumn("dbo.WorkingProcess", "MetaDescription");
            DropColumn("dbo.WorkingProcess", "MetaKeyword");
            DropColumn("dbo.WorkingProcess", "ModifiedBy");
            DropColumn("dbo.WorkingProcess", "ModifiedDate");
            DropColumn("dbo.WorkingProcess", "CreatedBy");
            DropColumn("dbo.WorkingProcess", "CreatedDate");
            DropColumn("dbo.WorkingProcess", "Status");
            DropColumn("dbo.Position", "MetaDescription");
            DropColumn("dbo.Position", "MetaKeyword");
            DropColumn("dbo.Position", "ModifiedBy");
            DropColumn("dbo.Position", "ModifiedDate");
            DropColumn("dbo.Position", "CreatedBy");
            DropColumn("dbo.Position", "CreatedDate");
            DropColumn("dbo.Employee", "MetaDescription");
            DropColumn("dbo.Employee", "MetaKeyword");
            DropColumn("dbo.Employee", "ModifiedBy");
            DropColumn("dbo.Employee", "ModifiedDate");
            DropColumn("dbo.Employee", "CreatedBy");
            DropColumn("dbo.Employee", "CreatedDate");
            DropColumn("dbo.Employee", "Status");
            DropColumn("dbo.Department", "MetaDescription");
            DropColumn("dbo.Department", "MetaKeyword");
            DropColumn("dbo.Department", "ModifiedBy");
            DropColumn("dbo.Department", "ModifiedDate");
            DropColumn("dbo.Department", "CreatedBy");
            DropColumn("dbo.Department", "CreatedDate");
            DropTable("dbo.AppUserLogin");
            DropTable("dbo.AppUserClaim");
            DropTable("dbo.AppUser");
            DropTable("dbo.Permissions");
            DropTable("dbo.Function");
            DropTable("dbo.Error");
            DropTable("dbo.AppUserRole");
            DropTable("dbo.AppRole");
            AddPrimaryKey("dbo.VisitorStatistic", "ID");
            CreateIndex("dbo.PostCategory", "ParentID");
        }
    }
}
