using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Directions { get; set; }

        [Required]
        [MaxLength(500)]
        public string Ingredients { get; set; }

        [Required]
        [MaxLength(500)]
        public string Steps { get; set; }

        [DefaultValue(false)]
        public bool IsSaved { get; set; }
    }
}
