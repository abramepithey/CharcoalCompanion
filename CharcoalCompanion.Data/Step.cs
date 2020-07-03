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

        [Required]
        public StepTypes StepType { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public Guid UserId { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public string ImageLink { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public virtual ICollection<Plan> Plans { get; set; }
    }
}
