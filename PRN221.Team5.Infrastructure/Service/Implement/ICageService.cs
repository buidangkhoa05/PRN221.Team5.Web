using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221.Team5.Application.Service.Implement
{
    public interface ICageService
    {
        Task<List<Cage>> GetAll();
        Task<int> GetNumberOfAnimalInCage(int cageNumber);
        Task<bool> AddAnimalToCage(Cage_Animal cageAnimal);
        Task<bool> IsAnimalInCage(IEnumerable<Guid> animalIds);
    }
}
