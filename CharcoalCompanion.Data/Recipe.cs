﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public string Directions { get; set; }

        public string Ingredients { get; set; }

        public string Steps { get; set; }

        public virtual Plan Plan { get; set; }

        [DefaultValue(false)]
        public bool IsSaved { get; set; }
    }
}
