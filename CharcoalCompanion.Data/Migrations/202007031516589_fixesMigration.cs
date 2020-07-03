namespace CharcoalCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixesMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharcoalSetup", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cut", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Meat", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meat", "IsActive");
            DropColumn("dbo.Cut", "IsActive");
            DropColumn("dbo.CharcoalSetup", "IsActive");
        }
    }
}
