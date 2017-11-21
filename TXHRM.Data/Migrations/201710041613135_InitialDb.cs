namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Alias = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: false)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: false)
                .ForeignKey("dbo.Position", t => t.PositionID, cascadeDelete: false)
                .Index(t => t.EmployeeID)
                .Index(t => t.DepartmentID)
                .Index(t => t.PositionID);
            
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
                "dbo.MenuGroup",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Description = c.String(maxLength: 512),
                        DisplayOrder = c.Int(nullable: false),
                        ParentID = c.Int(nullable: false),
                        HomeFlag = c.Boolean(),
                        Image = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostCategory", t => t.ParentID)
                .Index(t=>t.Name,"NameIndex",true,false,null)
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
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostCategory", t => t.CategoryId, cascadeDelete: true)
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
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitorStatistic",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        VisitedDate = c.DateTime(nullable: false),
                        IPAddress = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostTag", "TagID", "dbo.Tag");
            DropForeignKey("dbo.PostTag", "PostID", "dbo.Post");
            DropForeignKey("dbo.Post", "CategoryId", "dbo.PostCategory");
            DropForeignKey("dbo.PostCategory", "ParentID", "dbo.PostCategory");
            DropForeignKey("dbo.Menu", "GroupID", "dbo.MenuGroup");
            DropForeignKey("dbo.WorkingProcess", "PositionID", "dbo.Position");
            DropForeignKey("dbo.WorkingProcess", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.WorkingProcess", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Employee", "PositionID", "dbo.Position");
            DropForeignKey("dbo.Employee", "LeaderID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropIndex("dbo.PostTag", new[] { "PostID" });
            DropIndex("dbo.PostTag", new[] { "TagID" });
            DropIndex("dbo.Post", new[] { "CategoryId" });
            DropIndex("dbo.PostCategory", new[] { "ParentID" });
            DropIndex("dbo.Menu", new[] { "GroupID" });
            DropIndex("dbo.WorkingProcess", new[] { "PositionID" });
            DropIndex("dbo.WorkingProcess", new[] { "DepartmentID" });
            DropIndex("dbo.WorkingProcess", new[] { "EmployeeID" });
            DropIndex("dbo.Employee", new[] { "PositionID" });
            DropIndex("dbo.Employee", new[] { "LeaderID" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropTable("dbo.VisitorStatistic");
            DropTable("dbo.SystemConfig");
            DropTable("dbo.Slide");
            DropTable("dbo.Tag");
            DropTable("dbo.PostTag");
            DropTable("dbo.Post");
            DropTable("dbo.PostCategory");
            DropTable("dbo.Page");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuGroup");
            DropTable("dbo.Footer");
            DropTable("dbo.WorkingProcess");
            DropTable("dbo.Position");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
