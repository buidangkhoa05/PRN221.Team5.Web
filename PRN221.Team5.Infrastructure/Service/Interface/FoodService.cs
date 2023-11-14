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

        public async Task<Food> GetFirstOrDefault(Guid id)
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

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _unitOfWork.Food.DeleteAsync(t => t.Id == id);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Food food)
        {
            try
            {
                var result = await _unitOfWork.Food.UpdateAsync(food, isSaveChange: true);
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
