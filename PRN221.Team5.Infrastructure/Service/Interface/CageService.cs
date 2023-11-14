using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
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
    }
}
