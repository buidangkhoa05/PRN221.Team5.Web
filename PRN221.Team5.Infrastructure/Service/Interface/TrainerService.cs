using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221.Team5.Application.Service.Interface
{
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TraineerProfile>> GetAll()
        {
            try
            {
                var trainers = await _unitOfWork.TrainerProfile.Get(new QueryHelper<TraineerProfile>());
                return trainers.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
