namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IdentityRoles", newName: "AppRole");
            RenameTable(name: "dbo.IdentityUserRoles", newName: "AppUserRole");
            RenameTable(name: "dbo.ApplicationUsers", newName: "AppUser");
            RenameTable(name: "dbo.IdentityUserClaims", newName: "AppUserClaim");
            RenameTable(name: "dbo.IdentityUserLogins", newName: "AppUserLogin");
            DropForeignKey("dbo.Department", "LeaderID", "dbo.Employee");
            DropForeignKey("dbo.WorkingProcess", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.Department", new[] { "LeaderID" });
            DropIndex("dbo.WorkingProcess", new[] { "EmployeeID" });
            RenameColumn(table: "dbo.AppUserClaim", name: "ApplicationUser_Id", newName: "AppUser_Id");
            RenameColumn(table: "dbo.AppUserLogin", name: "ApplicationUser_Id", newName: "AppUser_Id");
            RenameColumn(table: "dbo.AppUserRole", name: "ApplicationUser_Id", newName: "AppUser_Id");
            RenameIndex(table: "dbo.AppUserRole", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.AppUserClaim", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.AppUserLogin", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
            DropPrimaryKey("dbo.Employee");
            DropPrimaryKey("dbo.AppUserClaim");
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Functions", t => t.ParentId)
                .Index(t => t.ParentId);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppRole", t => t.RoleId)
                .ForeignKey("dbo.Functions", t => t.FunctionId)
                .Index(t => t.RoleId)
                .Index(t => t.FunctionId);
            
            AddColumn("dbo.AppRole", "Description", c => c.String());
            AddColumn("dbo.AppRole", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Slide", "Content", c => c.String());
            AddColumn("dbo.AppUser", "Status", c => c.Boolean());
            AddColumn("dbo.AppUser", "Gender", c => c.Boolean());
            AlterColumn("dbo.Department", "LeaderID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AppUserClaim", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.AppUserClaim", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.WorkingProcess", "EmployeeID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Employee", "ID");
            AddPrimaryKey("dbo.AppUserClaim", "UserId");
            CreateIndex("dbo.Department", "LeaderID");
            CreateIndex("dbo.WorkingProcess", "EmployeeID");
            AddForeignKey("dbo.Department", "LeaderID", "dbo.Employee", "ID", cascadeDelete: false);
            AddForeignKey("dbo.WorkingProcess", "EmployeeID", "dbo.Employee", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkingProcess", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Department", "LeaderID", "dbo.Employee");
            DropForeignKey("dbo.Permission", "FunctionId", "dbo.Functions");
            DropForeignKey("dbo.Permission", "RoleId", "dbo.AppRole");
            DropForeignKey("dbo.Functions", "ParentId", "dbo.Functions");
            DropIndex("dbo.Permission", new[] { "FunctionId" });
            DropIndex("dbo.Permission", new[] { "RoleId" });
            DropIndex("dbo.Functions", new[] { "ParentId" });
            DropIndex("dbo.WorkingProcess", new[] { "EmployeeID" });
            DropIndex("dbo.Department", new[] { "LeaderID" });
            DropPrimaryKey("dbo.AppUserClaim");
            DropPrimaryKey("dbo.Employee");
            AlterColumn("dbo.WorkingProcess", "EmployeeID", c => c.Long(nullable: false));
            AlterColumn("dbo.AppUserClaim", "UserId", c => c.String());
            AlterColumn("dbo.AppUserClaim", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Employee", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Department", "LeaderID", c => c.Long(nullable: false));
            DropColumn("dbo.AppUser", "Gender");
            DropColumn("dbo.AppUser", "Status");
            DropColumn("dbo.Slide", "Content");
            DropColumn("dbo.AppRole", "Discriminator");
            DropColumn("dbo.AppRole", "Description");
            DropTable("dbo.Permission");
            DropTable("dbo.Functions");
            AddPrimaryKey("dbo.AppUserClaim", "Id");
            AddPrimaryKey("dbo.Employee", "ID");
            RenameIndex(table: "dbo.AppUserLogin", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.AppUserClaim", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.AppUserRole", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.AppUserRole", name: "AppUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.AppUserLogin", name: "AppUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.AppUserClaim", name: "AppUser_Id", newName: "ApplicationUser_Id");
            CreateIndex("dbo.WorkingProcess", "EmployeeID");
            CreateIndex("dbo.Department", "LeaderID");
            AddForeignKey("dbo.WorkingProcess", "EmployeeID", "dbo.Employee", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Department", "LeaderID", "dbo.Employee", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.AppUserLogin", newName: "IdentityUserLogins");
            RenameTable(name: "dbo.AppUserClaim", newName: "IdentityUserClaims");
            RenameTable(name: "dbo.AppUser", newName: "ApplicationUsers");
            RenameTable(name: "dbo.AppUserRole", newName: "IdentityUserRoles");
            RenameTable(name: "dbo.AppRole", newName: "IdentityRoles");
        }
    }
}
