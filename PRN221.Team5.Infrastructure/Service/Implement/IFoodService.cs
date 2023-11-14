using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221.Team5.Application.Service.Implement
{
    public interface IFoodService
    {
        Task<PagedList<Food>> GetAll(PagingParameters pagingParam);
        Task Create(Food food);
        Task<Food> GetFirtOrDefault(Guid id);
    }
}
