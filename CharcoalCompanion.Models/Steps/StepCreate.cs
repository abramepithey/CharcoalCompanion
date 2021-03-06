﻿using CharcoalCompanion.Data.Steps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Steps
{
    public class StepCreate
    {
        [Required]
        [Display(Name = "Type of Step")]
        public StepTypes StepType { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string FinalPageDetail { get; set; }

        [Display(Name = "Image Link")]
        public string ImageLink { get; set; }
    }
}
