namespace CharcoalCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsRecipes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "Name", c => c.String());
            AddColumn("dbo.Recipe", "Plan_PlanId", c => c.Int());
            AlterColumn("dbo.Recipe", "Directions", c => c.String());
            AlterColumn("dbo.Recipe", "Ingredients", c => c.String());
            AlterColumn("dbo.Recipe", "Steps", c => c.String());
            CreateIndex("dbo.Recipe", "Plan_PlanId");
            AddForeignKey("dbo.Recipe", "Plan_PlanId", "dbo.Plan", "PlanId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipe", "Plan_PlanId", "dbo.Plan");
            DropIndex("dbo.Recipe", new[] { "Plan_PlanId" });
            AlterColumn("dbo.Recipe", "Steps", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Recipe", "Ingredients", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Recipe", "Directions", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Recipe", "Plan_PlanId");
            DropColumn("dbo.Recipe", "Name");
        }
    }
}
