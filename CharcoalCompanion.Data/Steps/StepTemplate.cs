using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Data.Steps
{
    public class StepTemplate
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public Guid UserId { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public string ImageLink { get; set; }
    }
}
