namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "LeaderID", "dbo.Employee");
            DropIndex("dbo.Employee", new[] { "LeaderID" });
            AddColumn("dbo.Department", "ParentID", c => c.Int(nullable: false));
            AddColumn("dbo.Department", "LeaderID", c => c.Long(nullable: false));
            AddColumn("dbo.Position", "Alias", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Department", "ParentID");
            CreateIndex("dbo.Department", "LeaderID");
            AddForeignKey("dbo.Department", "LeaderID", "dbo.Employee", "ID");
            AddForeignKey("dbo.Department", "ParentID", "dbo.Department", "ID");
            DropColumn("dbo.Employee", "LeaderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "LeaderID", c => c.Long(nullable: false));
            DropForeignKey("dbo.Department", "ParentID", "dbo.Department");
            DropForeignKey("dbo.Department", "LeaderID", "dbo.Employee");
            DropIndex("dbo.Department", new[] { "LeaderID" });
            DropIndex("dbo.Department", new[] { "ParentID" });
            DropColumn("dbo.Position", "Alias");
            DropColumn("dbo.Department", "LeaderID");
            DropColumn("dbo.Department", "ParentID");
            CreateIndex("dbo.Employee", "LeaderID");
            AddForeignKey("dbo.Employee", "LeaderID", "dbo.Employee", "ID");
        }
    }
}
