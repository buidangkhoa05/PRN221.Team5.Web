using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;

namespace PRN221.Team5.Web.Pages.Cages
{
    public class CageModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CageModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Cage> Cages { get; set; }


        public async Task OnGetAsync()
        {
            var result = await _unitOfWork.Cage.GetWithPagination(new QueryHelper<Cage>());
        }

        public async Task<IActionResult> OnPostCreate(Cage Cage)
        {
            await _unitOfWork.Cage.CreateAsync(Cage);
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostEdit(Cage Cage)
        {
            await _unitOfWork.Cage.UpdateAsync(Cage);
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            await _unitOfWork.Cage.SoftDeleteAsync(t => t.Id == id);

            return RedirectToPage("Index");
        }
    }
}
