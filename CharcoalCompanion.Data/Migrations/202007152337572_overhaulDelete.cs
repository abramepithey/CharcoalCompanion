namespace CharcoalCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class overhaulDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Step", "IsSaved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Step", "Name", c => c.String());
            AlterColumn("dbo.Step", "Description", c => c.String());
            DropColumn("dbo.Step", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Step", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Step", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Step", "Name", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Step", "IsSaved");
        }
    }
}
