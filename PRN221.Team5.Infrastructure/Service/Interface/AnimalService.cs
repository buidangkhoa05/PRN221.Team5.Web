using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221.Team5.Application.Service.Interface
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnimalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<Animal>?> GetAll(PagingParameters pagingParam)
        {
            try
            {
                var queryHelper = new QueryHelper<Animal>()
                {
                    PagingParams = pagingParam
                };

                var animals = await _unitOfWork.Animal.GetWithPagination(queryHelper);

                return animals;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
