using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Team5.Application.Repository;
using Team5.Domain.Common;
//using Domain1;

namespace Team5.Web.Pages.ManageTraineerProfile
{
    //[Authorize(Roles = "Administrator, Staff")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<TraineerProfile> TraineerProfile { get; set; } = default!;

        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public string? SearchString { get; set; }

        public async Task OnGetAsync(string? searchString, int? pageIndex)
        {
            try
            {
                if (pageIndex != null)
                {
                    PageIndex = pageIndex.Value;
                }
                if (searchString != null)
                {
                    SearchString = searchString;
                    TraineerProfile = (await _unitOfWork.TrainerProfile.GetWithPagination(new QueryHelper<TraineerProfile>()
                    {
                        PagingParams = new PagingParameters(PageIndex, PageSize),
                        OrderByFields = new List<string>
                {
                    $"UpdatedDate:desc"
                }.ToArray(),
                        Include = t => t.Include(t => t.Account)
                    })).ToList();
                }
                else
                {
                    TraineerProfile = (await _unitOfWork.TrainerProfile.GetWithPagination(new QueryHelper<TraineerProfile>()
                    {
                        PagingParams = new PagingParameters(PageIndex, PageSize),
                        OrderByFields = new List<string>
                {
                    $"UpdatedDate:desc"
                }.ToArray(),
                        Include = t => t.Include(t => t.Account)

                    })).ToList();
                }
                var count = (await _unitOfWork.TrainerProfile.Get()).ToList().Count;
                TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            }
            catch { }
        }
    }
}
