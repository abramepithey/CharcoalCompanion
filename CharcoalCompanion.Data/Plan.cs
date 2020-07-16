using CharcoalCompanion.Data.Steps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Data
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public virtual Step StepOne { get; set; }

        public virtual Step StepTwo { get; set; }

        public virtual Step StepThree { get; set; }

        [DefaultValue(true)]
        public bool IsSaved { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
