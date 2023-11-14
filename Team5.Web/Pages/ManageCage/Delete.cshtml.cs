using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Team5.Application.Repository;
using Team5.Domain.Common;
//using Domain1;

namespace Team5.Web.Pages.ManageCage
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
      public Cage Cage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _unitOfWork.Cage.GetFirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                var itemWithInclude = (await _unitOfWork.Cage.Get(new QueryHelper<Cage>()
                {
                    Filter = t => t.Id == id,
                    Include = t => t.Include(t => t.AnimalSpecie).Include(t => t.ZooSection)
                })).ToList();
                Cage = itemWithInclude[0];
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

            Expression<Func<Cage, bool>> filter = x => x.Id == id;
            await _unitOfWork.Cage.DeleteAsync(filter);
            }
            catch
            {
                return RedirectToPage("./CanNot");
            }

            return RedirectToPage("./Index");
        }
    }
}
