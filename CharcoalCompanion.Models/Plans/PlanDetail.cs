using CharcoalCompanion.Data.Steps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Models.Plans
{
    public class PlanDetail
    {
        [Display(Name = "Plan ID")]
        public int PlanId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Meat")]
        public virtual Step StepOne { get; set; }
        [Display(Name = "Cut")]
        public virtual Step StepTwo { get; set; }
        [Display(Name = "Charcoal Setup")]
        public virtual Step StepThree { get; set; }
    }
}
