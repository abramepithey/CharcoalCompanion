using CharcoalCompanion.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Contracts
{
    public interface IRecipeService
    {
        bool CreateRecipe(RecipeCreate model);
        RecipeDetail GetRecipeById(int id);
        IEnumerable<RecipeListItem> GetAllRecipes();
        bool UpdateRecipe(RecipeUpdate model);
        bool DeleteRecipe(int id);
    }
}
