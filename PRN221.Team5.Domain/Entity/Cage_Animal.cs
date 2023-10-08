using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class Cage_Animal : BaseEntity
    {
        [Required]
        public Guid CageId { get; set; }
        public virtual Cage Cage { get; set; }

        public Guid? AnimalId { get; set; }
        public virtual Animal Animal { get; set; }

        public Guid? AnimalGroupId { get; set; }
        public virtual AnimalGroup AnimalGroup { get; set; }

        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime? ToDate { get; set; }
        public bool IsPresent { get; set; } = true;
    }
}
