namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIDtoId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropIndex("dbo.Employee", new[] { "LeaderID" });
            DropIndex("dbo.Employee", new[] { "PositionID" });
            DropIndex("dbo.Menu", new[] { "GroupID" });
            DropIndex("dbo.PostCategory", new[] { "ParentID" });
            DropIndex("dbo.PostTag", new[] { "TagID" });
            DropIndex("dbo.PostTag", new[] { "PostID" });
            DropIndex("dbo.WorkingProcess", new[] { "EmployeeID" });
            DropIndex("dbo.WorkingProcess", new[] { "DepartmentID" });
            DropIndex("dbo.WorkingProcess", new[] { "PositionID" });
            CreateIndex("dbo.Employee", "DepartmentId");
            CreateIndex("dbo.Employee", "LeaderId");
            CreateIndex("dbo.Employee", "PositionId");
            CreateIndex("dbo.Menu", "GroupId");
            CreateIndex("dbo.PostCategory", "ParentId");
            CreateIndex("dbo.PostTag", "TagId");
            CreateIndex("dbo.PostTag", "PostId");
            CreateIndex("dbo.WorkingProcess", "EmployeeId");
            CreateIndex("dbo.WorkingProcess", "DepartmentId");
            CreateIndex("dbo.WorkingProcess", "PositionId");
            DropColumn("dbo.PostCategory", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostCategory", "Image", c => c.String(maxLength: 256));
            DropIndex("dbo.WorkingProcess", new[] { "PositionId" });
            DropIndex("dbo.WorkingProcess", new[] { "DepartmentId" });
            DropIndex("dbo.WorkingProcess", new[] { "EmployeeId" });
            DropIndex("dbo.PostTag", new[] { "PostId" });
            DropIndex("dbo.PostTag", new[] { "TagId" });
            DropIndex("dbo.PostCategory", new[] { "ParentId" });
            DropIndex("dbo.Menu", new[] { "GroupId" });
            DropIndex("dbo.Employee", new[] { "PositionId" });
            DropIndex("dbo.Employee", new[] { "LeaderId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            CreateIndex("dbo.WorkingProcess", "PositionID");
            CreateIndex("dbo.WorkingProcess", "DepartmentID");
            CreateIndex("dbo.WorkingProcess", "EmployeeID");
            CreateIndex("dbo.PostTag", "PostID");
            CreateIndex("dbo.PostTag", "TagID");
            CreateIndex("dbo.PostCategory", "ParentID");
            CreateIndex("dbo.Menu", "GroupID");
            CreateIndex("dbo.Employee", "PositionID");
            CreateIndex("dbo.Employee", "LeaderID");
            CreateIndex("dbo.Employee", "DepartmentID");
        }
    }
}
