using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;
using Team5.Infrastructure.DBContext;

namespace Team5.Web.Pages.ManageAnimal
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _unitOfWork.Animal.GetFirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                var itemWithInclude = (await _unitOfWork.Animal.Get(new QueryHelper<Animal>()
                {
                    Filter = t => t.Id == id,
                })).ToList();
                Animal = itemWithInclude[0];
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

                Expression<Func<Animal, bool>> filter = x => x.Id == id;
                await _unitOfWork.Animal.SoftDeleteAsync(filter);
            }
            catch
            {
                return RedirectToPage("./CanNot");
            }

            return RedirectToPage("./Index");
        }
    }
}
