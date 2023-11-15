using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221.Team5.Application.Service.Interface
{
    public class CageService : ICageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Cage>> GetAll()
        {
            try
            {
                var cages = await _unitOfWork.Cage.Get(new QueryHelper<Cage>());
                return cages.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> GetNumberOfAnimalInCage(int cageNumber)
        {
            try
            {
                var cage = await _unitOfWork.Cage.GetFirstOrDefault(new QueryHelper<Cage>()
                {
                    Filter = t => t.NumberCage == cageNumber
                });

                if (cage == null)
                    return 999;

                var cages = await _unitOfWork.CageAnimal.Get(new QueryHelper<Cage_Animal>()
                {
                    Filter = t => t.CageId == cage.Id
                        && t.IsPresent == true
                        && t.ToDate == null
                });

                return cages.Count();
            }
            catch (Exception)
            {
                return 999;
            }
        }

        public async Task<bool> AddAnimalToCage(Cage_Animal cageAnimal)
        {
            try
            {
                var result = await _unitOfWork.CageAnimal.CreateAsync(cageAnimal, isSaveChange: true);
                return result != Guid.Empty;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> IsAnimalInCage(IEnumerable<Guid> animalIds)
        {
            try
            {

                foreach (var id in animalIds)
                {
                    var cageAnimal = await _unitOfWork.CageAnimal.Get(new QueryHelper<Cage_Animal>()
                    {
                        Filter = t => t.AnimalId == id
                            && t.IsPresent == true
                            && t.ToDate == null
                            && t.IsDeleted == false
                    });

                    if (cageAnimal.Any())
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
