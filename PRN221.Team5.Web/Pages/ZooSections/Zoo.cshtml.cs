using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;

namespace PRN221.Team5.Web.Pages.ZooSections
{
    public class ZooModel : PageModel
    {

        //private readonly IGenericRepository<ZooSection> genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ZooModel(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ZooSection> ZooSections { get; set; }


        public async Task OnGetAsync()
        {
            ZooSections = (await _unitOfWork.ZooSection.Get(new QueryHelper<ZooSection>())).ToList(); // Sử dụng hàm GetAllAsync của GenericRepository
        }

        public async Task<IActionResult> OnPostCreate(ZooSection zooSection)
        {
            await _unitOfWork.ZooSection.CreateAsync(zooSection, isSaveChange: true); // Sử dụng hàm CreateAsync của GenericRepository
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostEdit(ZooSection zooSection)
        {
            await _unitOfWork.ZooSection.UpdateAsync(zooSection); // Sử dụng hàm UpdateAsync của GenericRepository
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            await _unitOfWork.ZooSection.SoftDeleteAsync(t => t.Id == id);

            return RedirectToPage("Index");
        }
    }
}
