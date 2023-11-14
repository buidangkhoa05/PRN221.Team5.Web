using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221.Team5.Application.Service.Interface
{
    public class AnimalSpecieService : IAnimalSpecieService
    {
        private readonly IUnitOfWork _uOW;
        public AnimalSpecieService(IUnitOfWork uOW)
        {
            _uOW = uOW;
        }

        public async Task<List<AnimalSpecie>> GetAll()
        {
            try
            {
                var animalSpecies = await _uOW.AnimalSpecie.Get(new QueryHelper<AnimalSpecie>());

                return animalSpecies.ToList();
            }
            catch (Exception)
            {
                return new List<AnimalSpecie>();
            }
        }
    }
}
