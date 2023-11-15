using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class Meal : BaseEntity
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; } = "Name of meal";

        [DataType(DataType.Text)]
        public string Description { get; set; } = "Description of meal";

        [Required]
        [Range(1, 50)]
        public int Quantity { get; set; }

        [Required]
        [Range(1, 50)]
        public float FoodFrequency { get; set; }

        public virtual ICollection<Meal_Animal> Meal_Animals{ get; set; }

        public virtual ICollection<Meal_Food> Meal_Foods { get; set; }
    }
}
