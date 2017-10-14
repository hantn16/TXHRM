namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetUniqueAttribute : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PostCategory", "Name", unique: true);
            CreateIndex("dbo.Post", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Post", new[] { "Name" });
            DropIndex("dbo.PostCategory", new[] { "Name" });
        }
    }
}
