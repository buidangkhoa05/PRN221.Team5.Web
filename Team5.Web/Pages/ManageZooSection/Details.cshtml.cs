using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Team5.Application.Repository;
using Team5.Domain.Common;
//using Domain1;

namespace Team5.Web.Pages.ManageZooSection
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ZooSection ZooSection { get; set; } = default!;
        public IList<Cage> Cage { get; set; } = default!;
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public string? SearchString { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id, string? searchString, int? pageIndex)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var zoosection = await _unitOfWork.ZooSection.GetFirstOrDefaultAsync(m => m.Id == id);
            if (zoosection == null)
            {
                return NotFound();
            }
            
            ZooSection = zoosection;
            if (pageIndex != null)
            {
                PageIndex = pageIndex.Value;
            }
            if (searchString != null)
            {
                SearchString = searchString;
                Cage = (await _unitOfWork.Cage.GetWithPagination(new QueryHelper<Cage>()
                {
                    Filter = t => t.ZooSectionId == id,
                    PagingParams = new PagingParameters(PageIndex, PageSize),
                    OrderByFields = new List<string>
                {
                    $"UpdatedDate:desc"
                }.ToArray(),
                    Include = t => t.Include(t => t.AnimalSpecie).Include(t => t.ZooSection)
                })).ToList();
            }
            else
            {
                Cage = (await _unitOfWork.Cage.GetWithPagination(new QueryHelper<Cage>()
                {
                    Filter = t => t.ZooSectionId == id,
                    PagingParams = new PagingParameters(PageIndex, PageSize),
                    OrderByFields = new List<string>
                {
                    $"UpdatedDate:desc"
                }.ToArray(),
                    Include = t => t.Include(t => t.AnimalSpecie).Include(t => t.ZooSection)

                })).ToList();
            }
            var count = (await _unitOfWork.Cage.Get(new QueryHelper<Cage>() { Filter = t => t.ZooSectionId == id})).ToList().Count;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            return Page();
        }
    }
}
