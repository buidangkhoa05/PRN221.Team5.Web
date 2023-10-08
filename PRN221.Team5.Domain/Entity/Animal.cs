using Microsoft.AspNetCore.Mvc;
using PRN221.Team5.Domain.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class Animal : BaseEntity
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [Range(0.1, 12000)]
        public float Weight { get; set; } //kg
        [Required]
        [Range(0.1, 10)]
        public float Height { get; set; } //meter
        [Required]
        [Range(0, 100)]
        public float Age { get; set; }
        public Gender Gender { get; set; }
        public bool IsHerd { get; set; } //is herd animal

        public Guid SpecieId { get; set; }
        public virtual AnimalSpecie Specie { get; set; }

        public Guid? GroupId { get; set; } = null;
        public virtual AnimalGroup? Group { get; set; } = null;

        [Required]
        public Guid MealId { get; set; }
        public virtual Meal Meal { get; set; }

        public virtual ICollection<TraineerProfile> TraineerProfiles { get; set; }
    }
}
