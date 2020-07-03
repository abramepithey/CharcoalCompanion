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
        [Display(Name = "Which type of Step:")]
        public int StepNumberChoice { get; set; }
        public int StepId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
    }
}
