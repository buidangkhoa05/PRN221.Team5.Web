using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class AnimalTraining : BaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; } = null;

        public bool IsTraining { get; set; } = true;

        public Guid TrainerId { get; set; }
        public virtual TraineerProfile Trainer { get; set; }

        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
