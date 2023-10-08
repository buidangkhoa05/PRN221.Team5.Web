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
        public Guid FoodId { get; set; }
        public virtual Food Food { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float FoodFrequency { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<AnimalGroup> AnimalGroups { get; set; }
    }
}
