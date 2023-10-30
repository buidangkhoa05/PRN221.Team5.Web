using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class Meal_Food : BaseEntity
    {
        public Guid MealId { get; set; }
        public virtual Meal Meal { get; set; }

        public Guid FoodId { get; set; }
        public virtual Food Food { get; set; }
    }
}
