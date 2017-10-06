namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1stEdit : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PostCategory", new[] { "ParentID" });
            AlterColumn("dbo.Page", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.PostCategory", "DisplayOrder", c => c.Int());
            AlterColumn("dbo.PostCategory", "ParentID", c => c.Int());
            AlterColumn("dbo.PostCategory", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Post", "ModifiedDate", c => c.DateTime());
            CreateIndex("dbo.PostCategory", "ParentID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PostCategory", new[] { "ParentID" });
            AlterColumn("dbo.Post", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PostCategory", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PostCategory", "ParentID", c => c.Int(nullable: false));
            AlterColumn("dbo.PostCategory", "DisplayOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.Page", "ModifiedDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.PostCategory", "ParentID");
        }
    }
}
