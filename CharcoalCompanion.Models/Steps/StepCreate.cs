﻿using CharcoalCompanion.Data.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Steps
{
    public class StepCreate
    {
        public StepTypes StepType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
    }
}
