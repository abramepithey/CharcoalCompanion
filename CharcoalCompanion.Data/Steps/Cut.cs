using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Data.Steps
{
    public class Cut : StepTemplate
    {
        [Key]
        public int CutId { get; set; }
    }
}
