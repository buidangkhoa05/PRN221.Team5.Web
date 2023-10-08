using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class Food : BaseEntity
    {
        [Required]
        public Guid TypeId { get; set; }
        public virtual FoodType Type { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }
    }
}
