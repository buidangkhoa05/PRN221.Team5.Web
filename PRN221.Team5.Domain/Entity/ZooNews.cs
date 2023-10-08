using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class ZooNews : BaseEntity
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [MinLength(10)]
        public string Content { get; set; }
        public string ImageLink { get; set; }

        public Guid OwnerId { get; set; }
        public virtual Account Owner { get; set; }

    }
}
