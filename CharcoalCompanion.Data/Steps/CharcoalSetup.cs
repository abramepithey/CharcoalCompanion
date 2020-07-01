using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Data.Steps
{
    public class CharcoalSetup : StepTemplate
    {
        [Key]
        public int CharcoalSetupId { get; set; }

        [Display(Name = "Allowed Meats")]
        public virtual ICollection<Meat> Meats { get; set; } = new List<Meat>();

        [Display(Name = "Allowed Cuts")]
        public virtual ICollection<Cut> Cuts { get; set; } = new List<Cut>();
    }
}
