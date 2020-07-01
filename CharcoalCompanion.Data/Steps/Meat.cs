using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Data.Steps
{
    public class Meat : StepTemplate
    {
        [Key]
        public int MeatId { get; set; }

        [Display(Name = "Allowed Cuts")]
        public virtual ICollection<Cut> Cuts { get; set; } = new List<Cut>();

        [Display(Name = "Allowed Charcoal Setups")]
        public virtual ICollection<CharcoalSetup> CharcoalSetups { get; set; } = new List<CharcoalSetup>();
    }
}
