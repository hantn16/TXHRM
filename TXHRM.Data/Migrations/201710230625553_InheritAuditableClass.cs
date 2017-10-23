namespace TXHRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InheritAuditableClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Department", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Department", "CreatedBy", c => c.String());
            AddColumn("dbo.Department", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Department", "ModifiedBy", c => c.String());
            AddColumn("dbo.Department", "MetaKeyword", c => c.String());
            AddColumn("dbo.Department", "MetaDescription", c => c.String());
            AddColumn("dbo.Employee", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employee", "CreatedBy", c => c.String());
            AddColumn("dbo.Employee", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Employee", "ModifiedBy", c => c.String());
            AddColumn("dbo.Employee", "MetaKeyword", c => c.String());
            AddColumn("dbo.Employee", "MetaDescription", c => c.String());
            AddColumn("dbo.Position", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Position", "CreatedBy", c => c.String());
            AddColumn("dbo.Position", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Position", "ModifiedBy", c => c.String());
            AddColumn("dbo.Position", "MetaKeyword", c => c.String());
            AddColumn("dbo.Position", "MetaDescription", c => c.String());
            AddColumn("dbo.MenuGroup", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.MenuGroup", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MenuGroup", "CreatedBy", c => c.String());
            AddColumn("dbo.MenuGroup", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.MenuGroup", "ModifiedBy", c => c.String());
            AddColumn("dbo.MenuGroup", "MetaKeyword", c => c.String());
            AddColumn("dbo.MenuGroup", "MetaDescription", c => c.String());
            AddColumn("dbo.Menu", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Menu", "CreatedBy", c => c.String());
            AddColumn("dbo.Menu", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Menu", "ModifiedBy", c => c.String());
            AddColumn("dbo.Menu", "MetaKeyword", c => c.String());
            AddColumn("dbo.Menu", "MetaDescription", c => c.String());
            AddColumn("dbo.Tag", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tag", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tag", "CreatedBy", c => c.String());
            AddColumn("dbo.Tag", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Tag", "ModifiedBy", c => c.String());
            AddColumn("dbo.Tag", "MetaKeyword", c => c.String());
            AddColumn("dbo.Tag", "MetaDescription", c => c.String());
            AddColumn("dbo.Slide", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Slide", "CreatedBy", c => c.String());
            AddColumn("dbo.Slide", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Slide", "ModifiedBy", c => c.String());
            AddColumn("dbo.Slide", "MetaKeyword", c => c.String());
            AddColumn("dbo.Slide", "MetaDescription", c => c.String());
            AddColumn("dbo.SystemConfig", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.SystemConfig", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SystemConfig", "CreatedBy", c => c.String());
            AddColumn("dbo.SystemConfig", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.SystemConfig", "ModifiedBy", c => c.String());
            AddColumn("dbo.SystemConfig", "MetaKeyword", c => c.String());
            AddColumn("dbo.SystemConfig", "MetaDescription", c => c.String());
            AddColumn("dbo.WorkingProcess", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkingProcess", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkingProcess", "CreatedBy", c => c.String());
            AddColumn("dbo.WorkingProcess", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.WorkingProcess", "ModifiedBy", c => c.String());
            AddColumn("dbo.WorkingProcess", "MetaKeyword", c => c.String());
            AddColumn("dbo.WorkingProcess", "MetaDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkingProcess", "MetaDescription");
            DropColumn("dbo.WorkingProcess", "MetaKeyword");
            DropColumn("dbo.WorkingProcess", "ModifiedBy");
            DropColumn("dbo.WorkingProcess", "ModifiedDate");
            DropColumn("dbo.WorkingProcess", "CreatedBy");
            DropColumn("dbo.WorkingProcess", "CreatedDate");
            DropColumn("dbo.WorkingProcess", "Status");
            DropColumn("dbo.SystemConfig", "MetaDescription");
            DropColumn("dbo.SystemConfig", "MetaKeyword");
            DropColumn("dbo.SystemConfig", "ModifiedBy");
            DropColumn("dbo.SystemConfig", "ModifiedDate");
            DropColumn("dbo.SystemConfig", "CreatedBy");
            DropColumn("dbo.SystemConfig", "CreatedDate");
            DropColumn("dbo.SystemConfig", "Status");
            DropColumn("dbo.Slide", "MetaDescription");
            DropColumn("dbo.Slide", "MetaKeyword");
            DropColumn("dbo.Slide", "ModifiedBy");
            DropColumn("dbo.Slide", "ModifiedDate");
            DropColumn("dbo.Slide", "CreatedBy");
            DropColumn("dbo.Slide", "CreatedDate");
            DropColumn("dbo.Tag", "MetaDescription");
            DropColumn("dbo.Tag", "MetaKeyword");
            DropColumn("dbo.Tag", "ModifiedBy");
            DropColumn("dbo.Tag", "ModifiedDate");
            DropColumn("dbo.Tag", "CreatedBy");
            DropColumn("dbo.Tag", "CreatedDate");
            DropColumn("dbo.Tag", "Status");
            DropColumn("dbo.Menu", "MetaDescription");
            DropColumn("dbo.Menu", "MetaKeyword");
            DropColumn("dbo.Menu", "ModifiedBy");
            DropColumn("dbo.Menu", "ModifiedDate");
            DropColumn("dbo.Menu", "CreatedBy");
            DropColumn("dbo.Menu", "CreatedDate");
            DropColumn("dbo.MenuGroup", "MetaDescription");
            DropColumn("dbo.MenuGroup", "MetaKeyword");
            DropColumn("dbo.MenuGroup", "ModifiedBy");
            DropColumn("dbo.MenuGroup", "ModifiedDate");
            DropColumn("dbo.MenuGroup", "CreatedBy");
            DropColumn("dbo.MenuGroup", "CreatedDate");
            DropColumn("dbo.MenuGroup", "Status");
            DropColumn("dbo.Position", "MetaDescription");
            DropColumn("dbo.Position", "MetaKeyword");
            DropColumn("dbo.Position", "ModifiedBy");
            DropColumn("dbo.Position", "ModifiedDate");
            DropColumn("dbo.Position", "CreatedBy");
            DropColumn("dbo.Position", "CreatedDate");
            DropColumn("dbo.Employee", "MetaDescription");
            DropColumn("dbo.Employee", "MetaKeyword");
            DropColumn("dbo.Employee", "ModifiedBy");
            DropColumn("dbo.Employee", "ModifiedDate");
            DropColumn("dbo.Employee", "CreatedBy");
            DropColumn("dbo.Employee", "CreatedDate");
            DropColumn("dbo.Employee", "Status");
            DropColumn("dbo.Department", "MetaDescription");
            DropColumn("dbo.Department", "MetaKeyword");
            DropColumn("dbo.Department", "ModifiedBy");
            DropColumn("dbo.Department", "ModifiedDate");
            DropColumn("dbo.Department", "CreatedBy");
            DropColumn("dbo.Department", "CreatedDate");
        }
    }
}
