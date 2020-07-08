using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Plans
{
    public class PlanSave
    {
        public int PlanId { get; set; }
        public string Title { get; set; }
        public bool IsSaved { get; set; }
    }
}
