namespace CharcoalCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixesNavigations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipe", "UserId");
        }
    }
}
