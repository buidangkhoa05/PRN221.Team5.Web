using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Team5.Application.Repository;

namespace PRN221.Team5.Web.Pages.Cage
{
    public class CageModel : PageModel
    {
        private readonly IGenericRepository<PRN221.Team5.Domain.Entity.Cage> generic;

        public CageModel(IGenericRepository<PRN221.Team5.Domain.Entity.Cage> generic)
        {
            this.generic = generic;
        }

        public IEnumerable<PRN221.Team5.Domain.Entity.Cage> Cages { get; set; }


        public async Task OnGetAsync()
        {
            Cages = (await generic.GetAllAsync()).ToList(); 
        }

        public IActionResult OnPostCreate(PRN221.Team5.Domain.Entity.Cage Cage)
        {
            generic.CreateAsync(Cage); 
            return RedirectToPage("Index");
        }

        public IActionResult OnPostEdit(PRN221.Team5.Domain.Entity.Cage Cage)
        {
            generic.UpdateAsync(Cage);
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            Expression<Func<PRN221.Team5.Domain.Entity.Cage, bool>> deletePredicate = section => section.Id == id;
            await generic.DeleteAsync(deletePredicate);

            return RedirectToPage("Index");
        }
    }
}
