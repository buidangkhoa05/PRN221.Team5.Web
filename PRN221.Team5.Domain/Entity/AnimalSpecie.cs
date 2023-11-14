using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class AnimalSpecie : BaseEntity
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<Cage> Cages { get; set; }
    }
}
