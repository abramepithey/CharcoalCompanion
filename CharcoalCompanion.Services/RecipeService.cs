using CharcoalCompanion.Contracts;
using CharcoalCompanion.Data;
using CharcoalCompanion.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Services
{
    public class RecipeService : IRecipeService
    {
        public bool CreateRecipe(RecipeCreate model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RecipeListItem> GetAllRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.UserId == _userId)
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
            throw new NotImplementedException();
        }

        public bool UpdateRecipe(RecipeUpdate model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRecipe(int id)
        {
            throw new NotImplementedException();
        }

        private readonly Guid _userId;
        public RecipeService(Guid userId)
        {
            _userId = userId;
        }
    }
}
