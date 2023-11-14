using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class Cage : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int NumberCage { get; set; }
        [Required]
        [Range(1, Double.MaxValue)]
        public int Capacity { get; set; }
        [Required]
        public CageStatus Status { get; set; } = CageStatus.Available;

        public Guid ZooSectionId { get; set; }
        public virtual ZooSection ZooSection { get; set; }

        public Guid AnimalSpecieId { get; set; }
        public virtual AnimalSpecie AnimalSpecie { get; set; }

        public virtual ICollection<Cage_Animal> Cage_Animals { get; set; }
    }

    public enum CageStatus
    {
        Available,
        Unavailable
    }
}
