using CharcoalCompanion.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Recipes
{
    public class RecipeUpdate
    {
        public int RecipeId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Must be 30 characters or less")]
        public string Name { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Must be 200 characters or less")]
        public string Directions { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Must be 200 characters or less")]
        public string Ingredients { get; set; }

        [MaxLength(200, ErrorMessage = "Must be 200 characters or less")]
        public string Steps { get; set; }
        public virtual Plan Plan { get; set; }
    }
}
