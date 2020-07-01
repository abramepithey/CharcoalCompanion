namespace CharcoalCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class specifiesSteps : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CharcoalSetup", "CharcoalSetup_CharcoalSetupId", "dbo.CharcoalSetup");
            DropForeignKey("dbo.Cut", "Cut_CutId", "dbo.Cut");
            DropForeignKey("dbo.Meat", "Meat_MeatId", "dbo.Meat");
            DropIndex("dbo.CharcoalSetup", new[] { "CharcoalSetup_CharcoalSetupId" });
            DropIndex("dbo.Cut", new[] { "Cut_CutId" });
            DropIndex("dbo.Meat", new[] { "Meat_MeatId" });
            DropColumn("dbo.CharcoalSetup", "CharcoalSetup_CharcoalSetupId");
            DropColumn("dbo.Cut", "Cut_CutId");
            DropColumn("dbo.Meat", "Meat_MeatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meat", "Meat_MeatId", c => c.Int());
            AddColumn("dbo.Cut", "Cut_CutId", c => c.Int());
            AddColumn("dbo.CharcoalSetup", "CharcoalSetup_CharcoalSetupId", c => c.Int());
            CreateIndex("dbo.Meat", "Meat_MeatId");
            CreateIndex("dbo.Cut", "Cut_CutId");
            CreateIndex("dbo.CharcoalSetup", "CharcoalSetup_CharcoalSetupId");
            AddForeignKey("dbo.Meat", "Meat_MeatId", "dbo.Meat", "MeatId");
            AddForeignKey("dbo.Cut", "Cut_CutId", "dbo.Cut", "CutId");
            AddForeignKey("dbo.CharcoalSetup", "CharcoalSetup_CharcoalSetupId", "dbo.CharcoalSetup", "CharcoalSetupId");
        }
    }
}
