using CharcoalCompanion.Data.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Plans
{
    public class PlanDetail
    {
        public virtual Step StepOne { get; set; }
        public virtual Step StepTwo { get; set; }
        public virtual Step StepThree { get; set; }
    }
}
