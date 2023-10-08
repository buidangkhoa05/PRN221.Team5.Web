using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class ZooSection : BaseEntity
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        public string Description { get; set; }
        public ZooSectionStatus zooSectionStatus { get; set; } = ZooSectionStatus.Available;

        public virtual ICollection<Cage> Cages { get; set; }
    }

    public enum ZooSectionStatus
    {
        Available,
        Unavailable
    }
}
