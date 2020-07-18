using CharcoalCompanion.Data;
using CharcoalCompanion.Models.Plans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Recipes
{
    public class RecipeCreate
    {
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

        [Display(Name = "Connected Plan")]
        public int? PlanId { get; set; }

        public IEnumerable<PlanListItem> Plans { get; set; }
    }
}
