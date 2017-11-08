namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameApplicationUserModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUsers", newName: "AppUsers");
            RenameColumn(table: "dbo.IdentityUserClaims", name: "ApplicationUser_Id", newName: "AppUser_Id");
            RenameColumn(table: "dbo.IdentityUserLogins", name: "ApplicationUser_Id", newName: "AppUser_Id");
            RenameColumn(table: "dbo.IdentityUserRoles", name: "ApplicationUser_Id", newName: "AppUser_Id");
            RenameIndex(table: "dbo.IdentityUserRoles", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.IdentityUserClaims", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.IdentityUserLogins", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.IdentityUserLogins", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.IdentityUserClaims", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.IdentityUserRoles", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserRoles", name: "AppUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserLogins", name: "AppUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserClaims", name: "AppUser_Id", newName: "ApplicationUser_Id");
            RenameTable(name: "dbo.AppUsers", newName: "ApplicationUsers");
        }
    }
}
