namespace CharcoalCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CutCharcoalSetup",
                c => new
                    {
                        Cut_CutId = c.Int(nullable: false),
                        CharcoalSetup_CharcoalSetupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cut_CutId, t.CharcoalSetup_CharcoalSetupId })
                .ForeignKey("dbo.Cut", t => t.Cut_CutId, cascadeDelete: true)
                .ForeignKey("dbo.CharcoalSetup", t => t.CharcoalSetup_CharcoalSetupId, cascadeDelete: true)
                .Index(t => t.Cut_CutId)
                .Index(t => t.CharcoalSetup_CharcoalSetupId);
            
            CreateTable(
                "dbo.MeatCharcoalSetup",
                c => new
                    {
                        Meat_MeatId = c.Int(nullable: false),
                        CharcoalSetup_CharcoalSetupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meat_MeatId, t.CharcoalSetup_CharcoalSetupId })
                .ForeignKey("dbo.Meat", t => t.Meat_MeatId, cascadeDelete: true)
                .ForeignKey("dbo.CharcoalSetup", t => t.CharcoalSetup_CharcoalSetupId, cascadeDelete: true)
                .Index(t => t.Meat_MeatId)
                .Index(t => t.CharcoalSetup_CharcoalSetupId);
            
            CreateTable(
                "dbo.MeatCut",
                c => new
                    {
                        Meat_MeatId = c.Int(nullable: false),
                        Cut_CutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meat_MeatId, t.Cut_CutId })
                .ForeignKey("dbo.Meat", t => t.Meat_MeatId, cascadeDelete: true)
                .ForeignKey("dbo.Cut", t => t.Cut_CutId, cascadeDelete: true)
                .Index(t => t.Meat_MeatId)
                .Index(t => t.Cut_CutId);
            
            AddColumn("dbo.CharcoalSetup", "CharcoalSetup_CharcoalSetupId", c => c.Int());
            AddColumn("dbo.Cut", "Cut_CutId", c => c.Int());
            AddColumn("dbo.Meat", "Meat_MeatId", c => c.Int());
            CreateIndex("dbo.CharcoalSetup", "CharcoalSetup_CharcoalSetupId");
            CreateIndex("dbo.Cut", "Cut_CutId");
            CreateIndex("dbo.Meat", "Meat_MeatId");
            AddForeignKey("dbo.CharcoalSetup", "CharcoalSetup_CharcoalSetupId", "dbo.CharcoalSetup", "CharcoalSetupId");
            AddForeignKey("dbo.Cut", "Cut_CutId", "dbo.Cut", "CutId");
            AddForeignKey("dbo.Meat", "Meat_MeatId", "dbo.Meat", "MeatId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meat", "Meat_MeatId", "dbo.Meat");
            DropForeignKey("dbo.MeatCut", "Cut_CutId", "dbo.Cut");
            DropForeignKey("dbo.MeatCut", "Meat_MeatId", "dbo.Meat");
            DropForeignKey("dbo.MeatCharcoalSetup", "CharcoalSetup_CharcoalSetupId", "dbo.CharcoalSetup");
            DropForeignKey("dbo.MeatCharcoalSetup", "Meat_MeatId", "dbo.Meat");
            DropForeignKey("dbo.Cut", "Cut_CutId", "dbo.Cut");
            DropForeignKey("dbo.CutCharcoalSetup", "CharcoalSetup_CharcoalSetupId", "dbo.CharcoalSetup");
            DropForeignKey("dbo.CutCharcoalSetup", "Cut_CutId", "dbo.Cut");
            DropForeignKey("dbo.CharcoalSetup", "CharcoalSetup_CharcoalSetupId", "dbo.CharcoalSetup");
            DropIndex("dbo.MeatCut", new[] { "Cut_CutId" });
            DropIndex("dbo.MeatCut", new[] { "Meat_MeatId" });
            DropIndex("dbo.MeatCharcoalSetup", new[] { "CharcoalSetup_CharcoalSetupId" });
            DropIndex("dbo.MeatCharcoalSetup", new[] { "Meat_MeatId" });
            DropIndex("dbo.CutCharcoalSetup", new[] { "CharcoalSetup_CharcoalSetupId" });
            DropIndex("dbo.CutCharcoalSetup", new[] { "Cut_CutId" });
            DropIndex("dbo.Meat", new[] { "Meat_MeatId" });
            DropIndex("dbo.Cut", new[] { "Cut_CutId" });
            DropIndex("dbo.CharcoalSetup", new[] { "CharcoalSetup_CharcoalSetupId" });
            DropColumn("dbo.Meat", "Meat_MeatId");
            DropColumn("dbo.Cut", "Cut_CutId");
            DropColumn("dbo.CharcoalSetup", "CharcoalSetup_CharcoalSetupId");
            DropTable("dbo.MeatCut");
            DropTable("dbo.MeatCharcoalSetup");
            DropTable("dbo.CutCharcoalSetup");
        }
    }
}
