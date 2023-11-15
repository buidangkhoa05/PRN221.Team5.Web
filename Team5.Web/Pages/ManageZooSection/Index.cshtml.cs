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
using Team5.Infrastructure.Repository;
//using Domain1;

namespace Team5.Web.Pages.ManageZooSection
{
    //[Authorize(Roles = "3")]
    public class IndexModel : PageModel
	{
		//private readonly Domain1.ZooManagementContext _context;
		private readonly IUnitOfWork _unitOfWork;

		public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IList<ZooSection> ZooSection { get; set; } = default!;

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
                    ZooSection = (await _unitOfWork.ZooSection.GetWithPagination(new QueryHelper<ZooSection>()
                    {
                        PagingParams = new PagingParameters(PageIndex, PageSize),
                        OrderByFields = new List<string>
                {
                    $"UpdatedDate:desc"
                }.ToArray(),
                    })).ToList();
                }
                else
                {
                    ZooSection = (await _unitOfWork.ZooSection.GetWithPagination(new QueryHelper<ZooSection>()
                    {
                        PagingParams = new PagingParameters(PageIndex, PageSize),
                        OrderByFields = new List<string>
                {
                    $"UpdatedDate:desc"
                }.ToArray(),
                    })).ToList();
                }
                var count = (await _unitOfWork.ZooSection.Get()).ToList().Count;
                TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            }
			catch { }
		
		}
	}
}


