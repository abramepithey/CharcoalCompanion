using CharcoalCompanion.Contracts;
using CharcoalCompanion.Data;
using CharcoalCompanion.Models.Plans;
using CharcoalCompanion.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Services
{
    public class RecipeService : IRecipeService
    {
        public bool CreateRecipe(RecipeCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var plan = ConnectPlanToRecipe(model.PlanId);

                var entity = new Recipe
                {
                    UserId = _userId,
                    Name = model.Name,
                    Ingredients = model.Ingredients,
                    Steps = model.Steps,
                    Directions = model.Directions,
                    IsSaved = true,
                    Plan = plan
                };

                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<RecipeListItem> GetAllRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.UserId == _userId && e.IsSaved == true)
                        .Select(e =>
                            new RecipeListItem
                            {
                                RecipeId = e.RecipeId,
                                Name = e.Name
                            });

                return query.ToArray();
            }
        }

        public RecipeDetail GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == id && e.UserId == _userId && e.IsSaved == true);

                return
                    new RecipeDetail
                    {
                        RecipeId = entity.RecipeId,
                        Name = entity.Name,
                        Directions = entity.Directions,
                        Ingredients = entity.Ingredients,
                        Steps = entity.Steps,
                        Plan = entity.Plan
                    };
            }
        }

        public bool UpdateRecipe(RecipeUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == model.RecipeId && e.UserId == _userId && e.IsSaved == true);

                entity.Name = model.Name;
                entity.Directions = model.Directions;
                entity.Ingredients = model.Ingredients;
                entity.Steps = model.Steps;
                entity.Plan = ConnectPlanToRecipe(model.PlanId);

                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeleteRecipe(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == id && e.UserId == _userId && e.IsSaved == true);

                entity.IsSaved = false;

                return ctx.SaveChanges() == 1;
            }
        }

        public RecipeCreate CreateRecipeModelLoadPlans(RecipeCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plans
                        .Where(plan => plan.UserId == _userId && plan.IsSaved == true)
                        .Select(plan =>
                            new PlanListItem
                            {
                                PlanId = plan.PlanId,
                                Title = plan.Title
                            }).ToList();

                if (query.Count == 0)
                {
                    throw new ObjectNotFoundException();
                }

                model.Plans = query;

                return model;
            }
        }

        public RecipeUpdate UpdateRecipeModelLoadPlans(RecipeUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plans
                        .Where(plan => plan.UserId == _userId && plan.IsSaved == true)
                        .Select(plan =>
                            new PlanListItem
                            {
                                PlanId = plan.PlanId,
                                Title = plan.Title
                            }).ToList();

                if (query.Count == 0)
                {
                    throw new ObjectNotFoundException();
                }

                model.Plans = query;

                return model;
            }
        }

        public Plan ConnectPlanToRecipe(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var plan =
                    ctx
                        .Plans
                        .Single(p => p.PlanId == id);

                    return plan;
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
        }

        private readonly Guid _userId;
        public RecipeService(Guid userId)
        {
            _userId = userId;
        }
    }
}
