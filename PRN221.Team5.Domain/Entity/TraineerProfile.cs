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
        [DataType(DataType.Text)]
        public string Exprerience { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        public DateTime? OutDate { get; set; } = null;

        [Required]
        public Guid AccountId { get; set; } 
        public virtual Account Account { get; set; }

        public virtual ICollection<AnimalTraining> AnimalTrainings { get; set; }
    }
}
