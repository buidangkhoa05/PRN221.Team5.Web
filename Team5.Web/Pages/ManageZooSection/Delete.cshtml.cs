using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Team5.Application.Repository;
//using Domain1;

namespace Team5.Web.Pages.ManageZooSection
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
      public ZooSection ZooSection { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoosection = await _unitOfWork.ZooSection.GetFirstOrDefaultAsync(m => m.Id == id);

            if (zoosection == null)
            {
                return NotFound();
            }
            else
            {
                ZooSection = zoosection;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            try
            {

                Expression<Func<ZooSection, bool>> filter = x => x.Id == id;
                await _unitOfWork.ZooSection.DeleteAsync(filter);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./CanNot", new { id, saveChangesError = true });
            }

            return RedirectToPage("./Index");
        }
    }
}


