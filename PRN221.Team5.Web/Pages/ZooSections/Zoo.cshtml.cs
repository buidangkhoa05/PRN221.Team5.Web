using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;

namespace PRN221.Team5.Web.Pages.ZooSections
{
    public class ZooModel : PageModel
    {

        private readonly IGenericRepository<ZooSection> genericRepository;

        public ZooModel(IGenericRepository<ZooSection> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public IEnumerable<ZooSection> ZooSections { get; set; }


        public async Task OnGetAsync()
        {
            ZooSections = (await genericRepository.GetAllAsync()).ToList(); // Sử dụng hàm GetAllAsync của GenericRepository
        }

        public IActionResult OnPostCreate(ZooSection zooSection)
        {
            genericRepository.CreateAsync(zooSection); // Sử dụng hàm CreateAsync của GenericRepository
            return RedirectToPage("Index");
        }

        public IActionResult OnPostEdit(ZooSection zooSection)
        {
            genericRepository.UpdateAsync(zooSection); // Sử dụng hàm UpdateAsync của GenericRepository
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            Expression<Func<ZooSection, bool>> deletePredicate = section => section.Id == id;
            await genericRepository.DeleteAsync(deletePredicate);

            return RedirectToPage("Index");
        }
    }
}
