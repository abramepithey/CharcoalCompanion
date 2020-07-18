using CharcoalCompanion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Recipes
{
    public class RecipeDetail
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Directions { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public virtual Plan Plan { get; set; }
    }
}
