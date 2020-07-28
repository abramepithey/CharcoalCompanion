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
                    Description = "The all American, hockey puck shaped, classic.",
                    FinalPageDetail = "General:\nBurgers are traditionally made with ground beef. Which is usually packaged with a listed ratio of lean to fat by percentage. The higher the lean percentage, the less juices produced from fat, therefore, the dryer the end result will be.\n\nSafe Temperatures:\nTypically beef is considered versatile with internal temperature to achieve more rare prepared options, however, because burgers are made from ground beef, the surface of the meat is no longer the main priority to consider for safety. The USDA safe temperature to prepare ground beef is 160.\nHowever, for curiosity sake, these are the temperatures that coincide with doneness:\nRare: 120 to 125\nMedium Rare: 130 to 135\nMedium Well: 150 to 155\nWell Done: 160 to 165\n\nSuggested Charcoal Setup:\nTwo Zone\n\nSuggested Technique:\nSear burgers over the direct heat zone, with the lid off, until desired level of char is reached on both sides. Try your best to only flip once to reduce loss of internal juices.\nAlso, NEVER smash the burger down on the grill. It makes a cool noise when the juices burn up, but it leaves you with an unfortunately dry end result.\nOnce external coloring is at the desired level (which should not take long with a high heat level), move the burgers to the indirect heat zone, shut the lid, and watch for the internal temperature to reach your desired level.\nThere is no need to flip the burgers during the indirect heat phase.\nAlways use a meat thermometer, unless you like guessing (not recommended).\nAlso, consider pulling the burgers off the grill 5 degrees under the desired cooking temperature and letting them sit for 5 minutes as the external temperature will continue cooking the internal temperature after they have been pulled off the grill.\n\nWhat about the cheese?\nIf you would like tomelt cheese on your burger, it can be added any time after the burgers are moved to the indirect heat zone.\n",
                    ImageLink = "https://prods3.imgix.net/images/articles/2016_05/Feature-Image-Burger-Matrix-Cheese-Tangy-Grilling-Sweet-Blend-Cooking-Summer-Entertaining-Recipe.jpg",
                    IsSaved = true
                },
                new Step()
                {
                    StepId = 5,
                    StepType = StepTypes.Cut,
                    Name = "Ribeye Steak",
                    Description = "A great cut of steak that deserves your attention.",
                    FinalPageDetail = "General:\nThis cut of steak has a great reputation for containing a great amount of fat marbling that produces tenderness and juicy flavor.\n\nSafety Temperatures:\nThe USDA guidelines for safe ribeye steaks is an internal temperature of 145 and rested for 3 minutes.\n\nTemperatures for doneness:\nRare: 120 to 125\nMedium Rare: 130 to 135\nMedium Well: 150 to 155\nWell Done: 160 to 165\n\nSuggested charcoal set up:\nTwo Zone\n\nSuggested Technique:\nReverse Sear with cast iron skillet\n\nBefore cooking the steak, let it sit and acclimate to room temperature for about 45 minutes.\nSeason your steak 5 minutes before you put it on the grill.\nPut the steak on the indirect zone.\nWhen the internal temperature reaches 100, pull the steak and wrap it in foil.\nPlace the cast iron skillet over the direct heat zone. nWait for the cast iron to reach high heat levels (five minutes over direct heat should do).\nPlace the steak on the cast iron, and it should make a loud sizzle noise. Keep it there until desired color and bark is achieved. \nOptional: Baste the steak in butter with a spoon while it is searing on both sides.\nFlip and do the same for the other side.\nSearing each side can take anywhere from 1-3 minutes depending on temperature of the cast iron.\nWhen the internal temperature reaches 5 degrees lower than the desired result, pull the steak and let it rest for 5 minutes.\nCut against the grain and serve.",
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
                },
                new Step()
                {
                    StepId = 8,
                    StepType = StepTypes.CharcoalSetup,
                    Name = "Two Zone",
                    Description = "This versatile setup simultaneously gives your grill the functionality of both a stove top and an oven.",
                    FinalPageDetail = "Note: This setup can be used without charcoal trays, but they are suggested as they help with measuring charcoal, containing for fuel efficiency, being able to move the hot zones mid cook, and keeping hot coals from directly touching the porcelain walls of your grill.\nFirst measure out coals with the trays. Both trays are not needed every time. Depending on your cook, decide which is right for you. One tray means smaller direct zone and less intense heat. Two trays offer larger direct cook zone and more intense heat.\nTemperatures can be adjusted with both options using the bottom vent.\nPut the charcoal into the charcoal chimney and light the bottom with news paper. \nWait for all of the coals to all be ignited.\nPlace trays in the grill where you want the direct cooking zone to be.\nSafely pour the lit coals out of the chimney and into the trays. (Use tongs to grab any stray charcoal briquets as well as to spread the charcoal so it sits evenly throughout the trays.\nOpen the bottom vents, put your grill grate on, put the lid on and open the top vents. \nLet the grill heat up to desired temperature.\nClose the bottom vents to lower the temperature if desired.\nSide note: When cooking with the lid on, placement of the top vents will draw heat and smoke in that direction from the fuel source. Use this technique to also control heat exposure.",
                    ImageLink = "",
                    IsSaved = true
                }
                );
        }
    }
}
