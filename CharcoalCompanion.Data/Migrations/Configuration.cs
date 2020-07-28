namespace CharcoalCompanion.Data.Migrations
{
    using CharcoalCompanion.Data.Steps;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CharcoalCompanion.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CharcoalCompanion.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Steps.AddOrUpdate(x => x.StepId,
                new Step()
                {
                    StepId = 1,
                    StepType = StepTypes.Meat,
                    Name = "Beef",
                    Description = "Red meat with lots of versatility.",
                    FinalPageDetail = "Many beef cuts are traditionally served at a variety of preferential temperatures to achieve anything from well done to rare. However, not all cuts of beef are safe to be served below an internal temperature of 165 degrees Fahrenheit.",
                    ImageLink = "https://www.certifiedangusbeef.com/images/2020/short-ribs-stack-mobile.jpg",
                    IsSaved = true
                },
                new Step()
                {
                    StepId = 2,
                    StepType = StepTypes.Meat,
                    Name = "Pork",
                    Description = "The “other” white meat",
                    FinalPageDetail = "Some pork options need to be cooked to an internal temperature of 160 while others are safe at an internal temperature of 145. Make sure to pay attention to the USDA safe temperatures for each cut.",
                    ImageLink = "https://barbecuebible.com/wp-content/uploads/2014/05/featured-barbecued-pork-belly.jpg",
                    IsSaved = true
                },
                new Step()
                {
                    StepId = 3,
                    StepType = StepTypes.Meat,
                    Name = "Chicken",
                    Description = "White meat with high availability and high versatility.",
                    FinalPageDetail = "All chicken is required to meet an internal temperature of 165 for safe consumption. However, some cuts of chicken lose their tenderness the further they go past 165, where as others maintain tenderness and juiciness past even 200.",
                    ImageLink = "https://i.ytimg.com/vi/Hq2pavmew58/maxresdefault.jpg",
                    IsSaved = true
                },
                new Step()
                {
                    StepId = 4,
                    StepType = StepTypes.Cut,
                    Name = "Burger",
                    Description = "",
                    FinalPageDetail = "",
                    ImageLink = "https://prods3.imgix.net/images/articles/2016_05/Feature-Image-Burger-Matrix-Cheese-Tangy-Grilling-Sweet-Blend-Cooking-Summer-Entertaining-Recipe.jpg",
                    IsSaved = true
                },
                new Step()
                {
                    StepId = 5,
                    StepType = StepTypes.Cut,
                    Name = "Steak",
                    Description = "",
                    FinalPageDetail = "Let it rest at room temperature for at least 30 minutes before cooking. Reach an internal temperature of 125 degrees for rare, 135 for medium rare, 145 for medium, 150 for medium well, and 160 for well done. Remove from heat at 5 degrees below target, it will continue to cook with residual heat.",
                    ImageLink = "https://www.dalesseasoning.com/wp-content/uploads/Tbone.jpg",
                    IsSaved = true
                },
                new Step()
                {
                    StepId = 6,
                    StepType = StepTypes.CharcoalSetup,
                    Name = "Vortex",
                    Description = "",
                    FinalPageDetail = "",
                    ImageLink = "https://weberkettleclub.com/wp-content/uploads/2015/10/bbq-vortex.jpg",
                    IsSaved = true
                },
                new Step()
                {
                    StepId = 7,
                    StepType = StepTypes.CharcoalSetup,
                    Name = "Snake",
                    Description = "",
                    FinalPageDetail = "",
                    ImageLink = "https://s.hdnux.com/photos/01/06/24/14/18432815/7/gallery_medium.jpg",
                    IsSaved = true
                }
                );
        }
    }
}
