using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Plans
{
    public class PlanSave
    {
        [Display(Name = "Plan ID")]
        public int PlanId { get; set; }
        public string Title { get; set; }
        public bool IsSaved { get; set; }
    }
}
