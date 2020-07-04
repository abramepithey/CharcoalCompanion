namespace CharcoalCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        IsSaved = c.Boolean(nullable: false),
                        Step_StepId = c.Int(),
                        StepOne_StepId = c.Int(nullable: false),
                        StepThree_StepId = c.Int(nullable: false),
                        StepTwo_StepId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.Step", t => t.Step_StepId)
                .ForeignKey("dbo.Step", t => t.StepOne_StepId, cascadeDelete: false)
                .ForeignKey("dbo.Step", t => t.StepThree_StepId, cascadeDelete: false)
                .ForeignKey("dbo.Step", t => t.StepTwo_StepId, cascadeDelete: false)
                .Index(t => t.Step_StepId)
                .Index(t => t.StepOne_StepId)
                .Index(t => t.StepThree_StepId)
                .Index(t => t.StepTwo_StepId);
            
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
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        Directions = c.String(nullable: false, maxLength: 500),
                        Ingredients = c.String(nullable: false, maxLength: 500),
                        Steps = c.String(nullable: false, maxLength: 500),
                        IsSaved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Plan", "StepTwo_StepId", "dbo.Step");
            DropForeignKey("dbo.Plan", "StepThree_StepId", "dbo.Step");
            DropForeignKey("dbo.Plan", "StepOne_StepId", "dbo.Step");
            DropForeignKey("dbo.Plan", "Step_StepId", "dbo.Step");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Plan", new[] { "StepTwo_StepId" });
            DropIndex("dbo.Plan", new[] { "StepThree_StepId" });
            DropIndex("dbo.Plan", new[] { "StepOne_StepId" });
            DropIndex("dbo.Plan", new[] { "Step_StepId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Recipe");
            DropTable("dbo.Step");
            DropTable("dbo.Plan");
        }
    }
}
