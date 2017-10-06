namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rdEdit : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.VisitorStatistic");
            AlterColumn("dbo.VisitorStatistic", "ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.VisitorStatistic", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.VisitorStatistic");
            AlterColumn("dbo.VisitorStatistic", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.VisitorStatistic", "ID");
        }
    }
}
