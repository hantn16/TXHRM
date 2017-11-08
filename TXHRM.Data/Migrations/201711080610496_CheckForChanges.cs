namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckForChanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AppRole", newName: "IdentityRoles");
            RenameTable(name: "dbo.AppUserRole", newName: "IdentityUserRoles");
            RenameTable(name: "dbo.AppUser", newName: "ApplicationUsers");
            RenameTable(name: "dbo.AppUserClaim", newName: "IdentityUserClaims");
            RenameTable(name: "dbo.AppUserLogin", newName: "IdentityUserLogins");
            DropForeignKey("dbo.Department", "ParentID", "dbo.Department");
            DropForeignKey("dbo.Department", "LeaderID", "dbo.Employee");
            DropForeignKey("dbo.Functions", "ParentId", "dbo.Functions");
            DropForeignKey("dbo.Permission", "RoleId", "dbo.AppRole");
            DropForeignKey("dbo.Permission", "FunctionId", "dbo.Functions");
            DropForeignKey("dbo.WorkingProcess", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.Department", new[] { "ParentID" });
            DropIndex("dbo.Department", new[] { "LeaderID" });
            DropIndex("dbo.WorkingProcess", new[] { "EmployeeID" });
            DropIndex("dbo.Functions", new[] { "ParentId" });
            DropIndex("dbo.Permission", new[] { "RoleId" });
            DropIndex("dbo.Permission", new[] { "FunctionId" });
            RenameColumn(table: "dbo.IdentityUserClaims", name: "AppUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserLogins", name: "AppUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserRoles", name: "AppUser_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.IdentityUserRoles", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.IdentityUserClaims", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.IdentityUserLogins", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            DropPrimaryKey("dbo.Employee");
            DropPrimaryKey("dbo.IdentityUserClaims");
            AddColumn("dbo.Employee", "LeaderID", c => c.Long(nullable: false));
            AlterColumn("dbo.Employee", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.WorkingProcess", "EmployeeID", c => c.Long(nullable: false));
            AlterColumn("dbo.Error", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String());
            AlterColumn("dbo.IdentityUserClaims", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employee", "ID");
            AddPrimaryKey("dbo.IdentityUserClaims", "Id");
            CreateIndex("dbo.Employee", "LeaderID");
            CreateIndex("dbo.WorkingProcess", "EmployeeID");
            AddForeignKey("dbo.Employee", "LeaderID", "dbo.Employee", "ID");
            AddForeignKey("dbo.WorkingProcess", "EmployeeID", "dbo.Employee", "ID", cascadeDelete: true);
            DropColumn("dbo.IdentityRoles", "Description");
            DropColumn("dbo.IdentityRoles", "Discriminator");
            DropColumn("dbo.Department", "ParentID");
            DropColumn("dbo.Department", "LeaderID");
            DropColumn("dbo.Position", "Alias");
            DropColumn("dbo.Slide", "Content");
            DropColumn("dbo.ApplicationUsers", "Avatar");
            DropColumn("dbo.ApplicationUsers", "Status");
            DropColumn("dbo.ApplicationUsers", "Gender");
            DropTable("dbo.Functions");
            DropTable("dbo.Permission");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Permission",
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Functions",
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
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ApplicationUsers", "Gender", c => c.Boolean());
            AddColumn("dbo.ApplicationUsers", "Status", c => c.Boolean());
            AddColumn("dbo.ApplicationUsers", "Avatar", c => c.String());
            AddColumn("dbo.Slide", "Content", c => c.String());
            AddColumn("dbo.Position", "Alias", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Department", "LeaderID", c => c.Int(nullable: false));
            AddColumn("dbo.Department", "ParentID", c => c.Int(nullable: false));
            AddColumn("dbo.IdentityRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.IdentityRoles", "Description", c => c.String());
            DropForeignKey("dbo.WorkingProcess", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "LeaderID", "dbo.Employee");
            DropIndex("dbo.WorkingProcess", new[] { "EmployeeID" });
            DropIndex("dbo.Employee", new[] { "LeaderID" });
            DropPrimaryKey("dbo.IdentityUserClaims");
            DropPrimaryKey("dbo.Employee");
            AlterColumn("dbo.IdentityUserClaims", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Error", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.WorkingProcess", "EmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Employee", "LeaderID");
            AddPrimaryKey("dbo.IdentityUserClaims", "UserId");
            AddPrimaryKey("dbo.Employee", "ID");
            RenameIndex(table: "dbo.IdentityUserLogins", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.IdentityUserClaims", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.IdentityUserRoles", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
            RenameColumn(table: "dbo.IdentityUserRoles", name: "ApplicationUser_Id", newName: "AppUser_Id");
            RenameColumn(table: "dbo.IdentityUserLogins", name: "ApplicationUser_Id", newName: "AppUser_Id");
            RenameColumn(table: "dbo.IdentityUserClaims", name: "ApplicationUser_Id", newName: "AppUser_Id");
            CreateIndex("dbo.Permission", "FunctionId");
            CreateIndex("dbo.Permission", "RoleId");
            CreateIndex("dbo.Functions", "ParentId");
            CreateIndex("dbo.WorkingProcess", "EmployeeID");
            CreateIndex("dbo.Department", "LeaderID");
            CreateIndex("dbo.Department", "ParentID");
            AddForeignKey("dbo.WorkingProcess", "EmployeeID", "dbo.Employee", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Permission", "FunctionId", "dbo.Functions", "ID");
            AddForeignKey("dbo.Permission", "RoleId", "dbo.AppRole", "Id");
            AddForeignKey("dbo.Functions", "ParentId", "dbo.Functions", "ID");
            AddForeignKey("dbo.Department", "LeaderID", "dbo.Employee", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Department", "ParentID", "dbo.Department", "ID");
            RenameTable(name: "dbo.IdentityUserLogins", newName: "AppUserLogin");
            RenameTable(name: "dbo.IdentityUserClaims", newName: "AppUserClaim");
            RenameTable(name: "dbo.ApplicationUsers", newName: "AppUser");
            RenameTable(name: "dbo.IdentityUserRoles", newName: "AppUserRole");
            RenameTable(name: "dbo.IdentityRoles", newName: "AppRole");
        }
    }
}
