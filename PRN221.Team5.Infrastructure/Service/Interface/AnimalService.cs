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

        public async Task<PagedList<Animal>> GetAll(PagingParameters pagingParam)
        {
            try
            {
                var queryHelper = new QueryHelper<Animal>()
                {
                    PagingParams = pagingParam,
                    OrderByFields = new string[]
                    {
                        "CreatedDate:desc"
                    },

                    Include = t => t.Include(a => a.Specie)
                                    .Include(a => a.AnimalTrainings)
                                        .ThenInclude(a => a.Trainer)
                                            .ThenInclude(a => a.Account)
                };

                var animals = await _unitOfWork.Animal.GetWithPagination(queryHelper);

                return animals ?? new PagedList<Animal>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Guid> Create(Animal animal)
        {
            try
            {
                animal.CreatedBy = "System";

                var result = await _unitOfWork.Animal.CreateAsync(animal, isSaveChange: true);
                return result;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }


        public async Task<List<Animal>> GetAllNotInCage()
        {
            try
            {
                var queryHelper = new QueryHelper<Animal>()
                {
                    OrderByFields = new string[]
                    {
                        "CreatedDate:desc"
                    },

                    Include = t => t.Include(a => a.Specie)
                                    .Include(a => a.AnimalTrainings)
                                        .ThenInclude(a => a.Trainer)
                                            .ThenInclude(a => a.Account)
                                    .Include(a => a.Cage_Animals),
                    Filter = t => t.Cage_Animals == null || t.Cage_Animals.Count == 0
                };

                var animals = await _unitOfWork.Animal.Get(queryHelper);

                return animals?.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
