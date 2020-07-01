using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Data.Steps
{
    public class Cut : StepTemplate
    {
        [Key]
        public int CutId { get; set; }

        [Display(Name = "Allowed Meats")]
        public virtual ICollection<Meat> Meats { get; set; } = new List<Meat>();

        [Display(Name = "Allowed Charcoal Setups")]
        public virtual ICollection<CharcoalSetup> CharcoalSetups { get; set; } = new List<CharcoalSetup>();
    }
}
