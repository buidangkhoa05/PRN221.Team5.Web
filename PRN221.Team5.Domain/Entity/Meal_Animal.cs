using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class Meal_Animal : BaseEntity
    {
        [Required]
        public Guid MealId { get; set; }
        public virtual Meal Meal { get; set; }

        [Required]
        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
