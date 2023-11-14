using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team5.Application.Repository;
//using Domain1;

namespace Team5.Web.Pages.ManageAnimalSpec
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public AnimalSpecie AnimalSpecie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var item = await _unitOfWork.AnimalSpecie.GetFirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            AnimalSpecie = item;

            return Page();
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            AnimalSpecie.UpdatedDate = DateTime.Now;
            await _unitOfWork.AnimalSpecie.UpdateAsync(AnimalSpecie, true);

            return RedirectToPage("./Index");
        }
        private bool AnimalSpecieExists(Guid id)
        {
            //return (_context.AnimalSpecies?.Any(e => e.Id == id)).GetValueOrDefault();
            return false;
        }
    }
}
