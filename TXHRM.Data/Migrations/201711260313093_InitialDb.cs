namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        AppUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AppUser", t => t.AppUser_Id)
                .ForeignKey("dbo.AppRole", t => t.IdentityRole_Id)
                .Index(t => t.AppUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Alias = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        IDCardNo = c.String(),
                        DateIssued = c.DateTime(nullable: false),
                        PlaceIssued = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        LeaderID = c.Long(nullable: false),
                        PositionID = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.LeaderID)
                .ForeignKey("dbo.Position", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.LeaderID)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.Footer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
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
                "dbo.MenuGroup",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        DisplayOrder = c.Int(),
                        GroupID = c.Int(nullable: false),
                        Target = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuGroup", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Content = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.PostCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Description = c.String(maxLength: 512),
                        DisplayOrder = c.Int(),
                        ParentID = c.Int(),
                        HomeFlag = c.Boolean(),
                        Image = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostCategory", t => t.ParentID)
                .Index(t => t.Name, unique: true)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 512),
                        Alias = c.String(nullable: false, maxLength: 512, unicode: false),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        Description = c.String(maxLength: 512),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        Tags = c.String(maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostCategory", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.PostTag",
                c => new
                    {
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagID, t.PostID })
                .ForeignKey("dbo.Post", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                        Image = c.String(maxLength: 256),
                        Url = c.String(maxLength: 256),
                        DisplayOrder = c.Int(),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfig",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50, unicode: false),
                        ValueString = c.String(maxLength: 50),
                        ValueInt = c.Int(),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            CreateTable(
                "dbo.VisitorStatistic",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        VisitedDate = c.DateTime(nullable: false),
                        IPAddress = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WorkingProcess",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        EmployeeID = c.Long(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        PositionID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: false)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: false)
                .ForeignKey("dbo.Position", t => t.PositionID, cascadeDelete: false)
                .Index(t => t.EmployeeID)
                .Index(t => t.DepartmentID)
                .Index(t => t.PositionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserRole", "IdentityRole_Id", "dbo.AppRole");
            DropForeignKey("dbo.WorkingProcess", "PositionID", "dbo.Position");
            DropForeignKey("dbo.WorkingProcess", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.WorkingProcess", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.AppUserRole", "AppUser_Id", "dbo.AppUser");
            DropForeignKey("dbo.AppUserLogin", "AppUser_Id", "dbo.AppUser");
            DropForeignKey("dbo.AppUserClaim", "AppUser_Id", "dbo.AppUser");
            DropForeignKey("dbo.PostTag", "TagID", "dbo.Tag");
            DropForeignKey("dbo.PostTag", "PostID", "dbo.Post");
            DropForeignKey("dbo.Post", "CategoryId", "dbo.PostCategory");
            DropForeignKey("dbo.PostCategory", "ParentID", "dbo.PostCategory");
            DropForeignKey("dbo.Permissions", "FunctionId", "dbo.Function");
            DropForeignKey("dbo.Permissions", "RoleId", "dbo.AppRole");
            DropForeignKey("dbo.Menu", "GroupID", "dbo.MenuGroup");
            DropForeignKey("dbo.Function", "ParentId", "dbo.Function");
            DropForeignKey("dbo.Employee", "PositionID", "dbo.Position");
            DropForeignKey("dbo.Employee", "LeaderID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropIndex("dbo.WorkingProcess", new[] { "PositionID" });
            DropIndex("dbo.WorkingProcess", new[] { "DepartmentID" });
            DropIndex("dbo.WorkingProcess", new[] { "EmployeeID" });
            DropIndex("dbo.AppUserLogin", new[] { "AppUser_Id" });
            DropIndex("dbo.AppUserClaim", new[] { "AppUser_Id" });
            DropIndex("dbo.PostTag", new[] { "PostID" });
            DropIndex("dbo.PostTag", new[] { "TagID" });
            DropIndex("dbo.Post", new[] { "CategoryId" });
            DropIndex("dbo.Post", new[] { "Name" });
            DropIndex("dbo.PostCategory", new[] { "ParentID" });
            DropIndex("dbo.PostCategory", new[] { "Name" });
            DropIndex("dbo.Permissions", new[] { "FunctionId" });
            DropIndex("dbo.Permissions", new[] { "RoleId" });
            DropIndex("dbo.Menu", new[] { "GroupID" });
            DropIndex("dbo.Function", new[] { "ParentId" });
            DropIndex("dbo.Employee", new[] { "PositionID" });
            DropIndex("dbo.Employee", new[] { "LeaderID" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropIndex("dbo.AppUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.AppUserRole", new[] { "AppUser_Id" });
            DropTable("dbo.WorkingProcess");
            DropTable("dbo.VisitorStatistic");
            DropTable("dbo.AppUserLogin");
            DropTable("dbo.AppUserClaim");
            DropTable("dbo.AppUser");
            DropTable("dbo.SystemConfig");
            DropTable("dbo.Slide");
            DropTable("dbo.Tag");
            DropTable("dbo.PostTag");
            DropTable("dbo.Post");
            DropTable("dbo.PostCategory");
            DropTable("dbo.AppRole");
            DropTable("dbo.Permissions");
            DropTable("dbo.Page");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuGroup");
            DropTable("dbo.Function");
            DropTable("dbo.Footer");
            DropTable("dbo.Error");
            DropTable("dbo.Position");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.AppUserRole");
        }
    }
}
