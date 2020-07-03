namespace CharcoalCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CutCharcoalSetup", "Cut_CutId", "dbo.Cut");
            DropForeignKey("dbo.CutCharcoalSetup", "CharcoalSetup_CharcoalSetupId", "dbo.CharcoalSetup");
            DropForeignKey("dbo.MeatCharcoalSetup", "Meat_MeatId", "dbo.Meat");
            DropForeignKey("dbo.MeatCharcoalSetup", "CharcoalSetup_CharcoalSetupId", "dbo.CharcoalSetup");
            DropForeignKey("dbo.MeatCut", "Meat_MeatId", "dbo.Meat");
            DropForeignKey("dbo.MeatCut", "Cut_CutId", "dbo.Cut");
            DropForeignKey("dbo.Plan", "CharcoalSetupId", "dbo.CharcoalSetup");
            DropForeignKey("dbo.Plan", "CutId", "dbo.Cut");
            DropForeignKey("dbo.Plan", "MeatId", "dbo.Meat");
            DropIndex("dbo.Plan", new[] { "MeatId" });
            DropIndex("dbo.Plan", new[] { "CutId" });
            DropIndex("dbo.Plan", new[] { "CharcoalSetupId" });
            DropIndex("dbo.CutCharcoalSetup", new[] { "Cut_CutId" });
            DropIndex("dbo.CutCharcoalSetup", new[] { "CharcoalSetup_CharcoalSetupId" });
            DropIndex("dbo.MeatCharcoalSetup", new[] { "Meat_MeatId" });
            DropIndex("dbo.MeatCharcoalSetup", new[] { "CharcoalSetup_CharcoalSetupId" });
            DropIndex("dbo.MeatCut", new[] { "Meat_MeatId" });
            DropIndex("dbo.MeatCut", new[] { "Cut_CutId" });
            CreateTable(
                "dbo.Step",
                c => new
                    {
                        StepId = c.Int(nullable: false, identity: true),
                        StepType = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        UserId = c.Guid(nullable: false),
                        Description = c.String(maxLength: 100),
                        ImageLink = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StepId);
            
            AddColumn("dbo.Plan", "Step_StepId", c => c.Int());
            AddColumn("dbo.Plan", "StepOne_StepId", c => c.Int(nullable: false));
            AddColumn("dbo.Plan", "StepThree_StepId", c => c.Int(nullable: false));
            AddColumn("dbo.Plan", "StepTwo_StepId", c => c.Int(nullable: false));
            CreateIndex("dbo.Plan", "Step_StepId");
            CreateIndex("dbo.Plan", "StepOne_StepId");
            CreateIndex("dbo.Plan", "StepThree_StepId");
            CreateIndex("dbo.Plan", "StepTwo_StepId");
            AddForeignKey("dbo.Plan", "Step_StepId", "dbo.Step", "StepId");
            AddForeignKey("dbo.Plan", "StepOne_StepId", "dbo.Step", "StepId", cascadeDelete: false);
            AddForeignKey("dbo.Plan", "StepThree_StepId", "dbo.Step", "StepId", cascadeDelete: false);
            AddForeignKey("dbo.Plan", "StepTwo_StepId", "dbo.Step", "StepId", cascadeDelete: false);
            DropColumn("dbo.Plan", "MeatId");
            DropColumn("dbo.Plan", "CutId");
            DropColumn("dbo.Plan", "CharcoalSetupId");
            DropTable("dbo.CharcoalSetup");
            DropTable("dbo.Cut");
            DropTable("dbo.Meat");
            DropTable("dbo.CutCharcoalSetup");
            DropTable("dbo.MeatCharcoalSetup");
            DropTable("dbo.MeatCut");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MeatCut",
                c => new
                    {
                        Meat_MeatId = c.Int(nullable: false),
                        Cut_CutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meat_MeatId, t.Cut_CutId });
            
            CreateTable(
                "dbo.MeatCharcoalSetup",
                c => new
                    {
                        Meat_MeatId = c.Int(nullable: false),
                        CharcoalSetup_CharcoalSetupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meat_MeatId, t.CharcoalSetup_CharcoalSetupId });
            
            CreateTable(
                "dbo.CutCharcoalSetup",
                c => new
                    {
                        Cut_CutId = c.Int(nullable: false),
                        CharcoalSetup_CharcoalSetupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cut_CutId, t.CharcoalSetup_CharcoalSetupId });
            
            CreateTable(
                "dbo.Meat",
                c => new
                    {
                        MeatId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        UserId = c.Guid(nullable: false),
                        Description = c.String(maxLength: 100),
                        ImageLink = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MeatId);
            
            CreateTable(
                "dbo.Cut",
                c => new
                    {
                        CutId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        UserId = c.Guid(nullable: false),
                        Description = c.String(maxLength: 100),
                        ImageLink = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CutId);
            
            CreateTable(
                "dbo.CharcoalSetup",
                c => new
                    {
                        CharcoalSetupId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        UserId = c.Guid(nullable: false),
                        Description = c.String(maxLength: 100),
                        ImageLink = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CharcoalSetupId);
            
            AddColumn("dbo.Plan", "CharcoalSetupId", c => c.Int(nullable: false));
            AddColumn("dbo.Plan", "CutId", c => c.Int(nullable: false));
            AddColumn("dbo.Plan", "MeatId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Plan", "StepTwo_StepId", "dbo.Step");
            DropForeignKey("dbo.Plan", "StepThree_StepId", "dbo.Step");
            DropForeignKey("dbo.Plan", "StepOne_StepId", "dbo.Step");
            DropForeignKey("dbo.Plan", "Step_StepId", "dbo.Step");
            DropIndex("dbo.Plan", new[] { "StepTwo_StepId" });
            DropIndex("dbo.Plan", new[] { "StepThree_StepId" });
            DropIndex("dbo.Plan", new[] { "StepOne_StepId" });
            DropIndex("dbo.Plan", new[] { "Step_StepId" });
            DropColumn("dbo.Plan", "StepTwo_StepId");
            DropColumn("dbo.Plan", "StepThree_StepId");
            DropColumn("dbo.Plan", "StepOne_StepId");
            DropColumn("dbo.Plan", "Step_StepId");
            DropTable("dbo.Step");
            CreateIndex("dbo.MeatCut", "Cut_CutId");
            CreateIndex("dbo.MeatCut", "Meat_MeatId");
            CreateIndex("dbo.MeatCharcoalSetup", "CharcoalSetup_CharcoalSetupId");
            CreateIndex("dbo.MeatCharcoalSetup", "Meat_MeatId");
            CreateIndex("dbo.CutCharcoalSetup", "CharcoalSetup_CharcoalSetupId");
            CreateIndex("dbo.CutCharcoalSetup", "Cut_CutId");
            CreateIndex("dbo.Plan", "CharcoalSetupId");
            CreateIndex("dbo.Plan", "CutId");
            CreateIndex("dbo.Plan", "MeatId");
            AddForeignKey("dbo.Plan", "MeatId", "dbo.Meat", "MeatId", cascadeDelete: true);
            AddForeignKey("dbo.Plan", "CutId", "dbo.Cut", "CutId", cascadeDelete: true);
            AddForeignKey("dbo.Plan", "CharcoalSetupId", "dbo.CharcoalSetup", "CharcoalSetupId", cascadeDelete: true);
            AddForeignKey("dbo.MeatCut", "Cut_CutId", "dbo.Cut", "CutId", cascadeDelete: true);
            AddForeignKey("dbo.MeatCut", "Meat_MeatId", "dbo.Meat", "MeatId", cascadeDelete: true);
            AddForeignKey("dbo.MeatCharcoalSetup", "CharcoalSetup_CharcoalSetupId", "dbo.CharcoalSetup", "CharcoalSetupId", cascadeDelete: true);
            AddForeignKey("dbo.MeatCharcoalSetup", "Meat_MeatId", "dbo.Meat", "MeatId", cascadeDelete: true);
            AddForeignKey("dbo.CutCharcoalSetup", "CharcoalSetup_CharcoalSetupId", "dbo.CharcoalSetup", "CharcoalSetupId", cascadeDelete: true);
            AddForeignKey("dbo.CutCharcoalSetup", "Cut_CutId", "dbo.Cut", "CutId", cascadeDelete: true);
        }
    }
}
