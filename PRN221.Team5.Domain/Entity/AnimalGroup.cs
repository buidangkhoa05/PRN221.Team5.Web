using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class AnimalGroup : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public float FoodQuantity { get; set; }

        [Required]
        public Guid MealId { get; set; }
        public virtual Meal Meal { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
