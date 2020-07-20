using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Data.Steps
{
    public enum StepTypes { Meat = 1, Cut = 2, CharcoalSetup = 3 }
    public class Step
    {
        [Key]
        public int StepId { get; set; }

        public StepTypes StepType { get; set; }

        public string Name { get; set; }

        public Guid UserId { get; set; }

        public string Description { get; set; }

        public string FinalPageDetail { get; set; }

        public string ImageLink { get; set; }

        [DefaultValue(true)]
        public bool IsSaved { get; set; }

        public virtual ICollection<Plan> Plans { get; set; }
    }
}
