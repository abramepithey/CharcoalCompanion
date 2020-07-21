namespace CharcoalCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsFinalPageDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Step", "FinalPageDetail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Step", "FinalPageDetail");
        }
    }
}
