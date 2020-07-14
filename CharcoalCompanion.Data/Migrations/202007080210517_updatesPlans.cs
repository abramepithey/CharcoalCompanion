namespace CharcoalCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesPlans : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plan", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plan", "Title");
        }
    }
}
