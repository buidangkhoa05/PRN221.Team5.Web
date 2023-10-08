using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class TraineerProfile : BaseEntity
    {
        [Required]
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime? End { get; set; } = null;
        [DataType(DataType.Text)]
        public string Experience { get; set; }
        [Required]
        public bool IsTraning { get; set; } = true;

        public Guid TraineerId { get; set; }
        public virtual Account Traineer { get; set; }

        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
