using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class Account : BaseEntity
    {
        [Required]
        public string Username { get; set; }
        [MinLength(5)]
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }
        [Required]
        [Range(16, 100)]
        public string Age { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public Role Role { get; set; }

        public virtual ICollection<ZooNews> ZooNews { get; set; }
        public virtual ICollection<TraineerProfile> TraineerProfiles { get; set; }

    }

    public enum Role
    {
        Guest = 100,
        ZooTrainer = 101,
        Staff = 102,
        Administrator = 103
    }
}
