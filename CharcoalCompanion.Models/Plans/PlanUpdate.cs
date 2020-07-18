using CharcoalCompanion.Data.Steps;
using CharcoalCompanion.Models.Steps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Plans
{
    public class PlanUpdate
    {
        public int PlanId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Meat")]
        public int StepOneId { get; set; }

        [Display(Name = "Cut")]
        public int StepTwoId { get; set; }

        [Display(Name = "Charcoal Setup")]
        public int StepThreeId { get; set; }

        public IEnumerable<StepListItem> Meats { get; set; }
        public IEnumerable<StepListItem> Cuts { get; set; }
        public IEnumerable<StepListItem> CharcoalSetups { get; set; }
    }
}
