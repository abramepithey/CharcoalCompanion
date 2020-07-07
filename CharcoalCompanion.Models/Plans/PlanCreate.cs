using CharcoalCompanion.Data.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Plans
{
    public class PlanCreate
    {
        public virtual Step Step1 { get; set; }
        public virtual Step Step2 { get; set; }
        public virtual Step Step3 { get; set; }
    }
}
