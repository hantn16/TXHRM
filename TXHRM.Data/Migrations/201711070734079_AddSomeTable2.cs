namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeTable2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AppUserRole", newName: "AppUserRoles");
            RenameTable(name: "dbo.AppUserClaim", newName: "AppUserClaims");
            RenameTable(name: "dbo.AppUserLogin", newName: "AppUserLogins");
            CreateTable(
                "dbo.AppRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AppRole", "Id");
            AddForeignKey("dbo.AppRole", "Id", "dbo.AppRoles", "Id");
            DropColumn("dbo.AppRole", "Name");
            DropColumn("dbo.AppRole", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppRole", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AppRole", "Name", c => c.String());
            DropForeignKey("dbo.AppRole", "Id", "dbo.AppRoles");
            DropIndex("dbo.AppRole", new[] { "Id" });
            DropTable("dbo.AppRoles");
            RenameTable(name: "dbo.AppUserLogins", newName: "AppUserLogin");
            RenameTable(name: "dbo.AppUserClaims", newName: "AppUserClaim");
            RenameTable(name: "dbo.AppUserRoles", newName: "AppUserRole");
        }
    }
}
