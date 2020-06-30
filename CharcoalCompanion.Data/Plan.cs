using CharcoalCompanion.Data.Steps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Data
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("Meat")]
        public int MeatId { get; set; }
        public virtual Meat Meat { get; set; }

        [ForeignKey("Cut")]
        public int CutId { get; set; }
        public virtual Cut Cut { get; set; }

        [ForeignKey("CharcoalSetup")]
        public int CharcoalSetupId { get; set; }
        public virtual CharcoalSetup CharcoalSetup { get; set; }

        [DefaultValue(false)]
        public bool IsSaved { get; set; }
    }
}
