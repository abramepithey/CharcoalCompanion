﻿using CharcoalCompanion.Data.Steps;
using CharcoalCompanion.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Plans
{
    public class PlanUpdate
    {
        public int PlanId { get; set; }
        public string Title { get; set; }

        public virtual Step StepOne { get; set; }

        public virtual Step StepTwo { get; set; }

        public virtual Step StepThree { get; set; }
        public bool IsSaved { get; set; }
        public IEnumerable<StepListItem> Meats { get; set; }
        public IEnumerable<StepListItem> Cuts { get; set; }
        public IEnumerable<StepListItem> CharcoalSetups { get; set; }
    }
}
