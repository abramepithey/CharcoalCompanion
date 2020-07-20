using CharcoalCompanion.Data.Steps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Steps
{
    public class StepUpdate
    {
        public int StepId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Information for Final Page")]
        public string FinalPageDetail { get; set; }

        [Display(Name = "Image Link")]
        public string ImageLink { get; set; }
    }
}
