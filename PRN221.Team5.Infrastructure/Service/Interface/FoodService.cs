using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221.Team5.Application.Service.Interface
{
    public class FoodService : IFoodService
    {

        private readonly IUnitOfWork _unitOfWork;

        public FoodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<Food>> GetAll(PagingParameters pagingParam)
        {
            try
            {
                var foods = await _unitOfWork.Food.GetWithPagination(new QueryHelper<Food>()
                {
                    PagingParams = pagingParam,
                });

                return foods;
            }
            catch (Exception)
            {

                return new PagedList<Food>();
            }
        }

        public async Task Create(Food food)
        {
            try
            {
                await _unitOfWork.Food.CreateAsync(food, isSaveChange: true);
            }
            catch (Exception)
            {
            }
        }

        public async Task<Food> GetFirtOrDefault(Guid id)
        {
            try
            {
                var food = await _unitOfWork.Food.GetFirstOrDefaultAsync(predicate: x => x.Id == id);
                return food;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
