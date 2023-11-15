using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;
//using Domain1;

namespace Team5.Web.Pages.ManageTraineerProfile
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TraineerProfile TraineerProfile { get; set; } = default!;
        public IList<Animal> Animal { get; set; } = default!;
        public IList<AnimalTraining> AnimalTraining { get; set; } = default!;
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public string? SearchString { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id, string? searchString, int? pageIndex)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return NotFound();
                }

                var traineerProfile = (await _unitOfWork.TrainerProfile.Get(
                    new QueryHelper<TraineerProfile>()
                    {
                        Filter = t => t.Id == id,
                        Include = t => t.Include(t => t.Account)
                    })).ToList();
                if (traineerProfile == null)
                {
                    return NotFound();
                }

                TraineerProfile = traineerProfile[0];
                if (pageIndex != null)
                {
                    PageIndex = pageIndex.Value;
                }
                if (searchString != null)
                {
                }
                else
                {
                    AnimalTraining = (await _unitOfWork.AnimalTraining.GetWithPagination(new QueryHelper<AnimalTraining>()
                    {
                        Filter = t => t.TrainerId == id,
                        PagingParams = new PagingParameters(PageIndex, PageSize),
                        OrderByFields = new List<string>
                        {
                            $"UpdatedDate:desc"
                        }.ToArray(),
                        Include = t => t.Include(t => t.Animal)
                    })).ToList();
                }
                var count = (await _unitOfWork.AnimalTraining.Get(new QueryHelper<AnimalTraining>() { Filter = t => t.TrainerId == id })).ToList().Count;
                TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            }
            catch { }
            return Page();
        }
    }
}
