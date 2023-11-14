using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class Food : BaseEntity
    {
        [Required]
        [DisallowNull]
        [MinLength(1)]
        public string Type { get; set; }

        [Required]
        [MinLength(1)]
        [DisallowNull]
        public string Name { get; set; }

        public virtual ICollection<Meal_Food> Meal_Foods { get; set; }
    }
}
