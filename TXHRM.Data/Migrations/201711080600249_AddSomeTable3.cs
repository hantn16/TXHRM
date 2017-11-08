namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeTable3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AppUserRoles", newName: "AppUserRole");
            RenameTable(name: "dbo.AppUserClaims", newName: "AppUserClaim");
            RenameTable(name: "dbo.AppUserLogins", newName: "AppUserLogin");
            DropForeignKey("dbo.AppRole", "Id", "dbo.AppRoles");
            DropIndex("dbo.AppRole", new[] { "Id" });
            AddColumn("dbo.AppRole", "Name", c => c.String());
            AddColumn("dbo.AppRole", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Error", "CreatedDate", c => c.DateTime());
            DropTable("dbo.AppRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AppRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Error", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AppRole", "Discriminator");
            DropColumn("dbo.AppRole", "Name");
            CreateIndex("dbo.AppRole", "Id");
            AddForeignKey("dbo.AppRole", "Id", "dbo.AppRoles", "Id");
            RenameTable(name: "dbo.AppUserLogin", newName: "AppUserLogins");
            RenameTable(name: "dbo.AppUserClaim", newName: "AppUserClaims");
            RenameTable(name: "dbo.AppUserRole", newName: "AppUserRoles");
        }
    }
}
