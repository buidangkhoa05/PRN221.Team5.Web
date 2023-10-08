using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5.Domain.Entity;

namespace PRN221.Team5.Domain.Entity
{
    public class FoodType : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
