using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageAnimalSpec
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel()
        {
            //_context = context;
        }

        [BindProperty]
      public AnimalSpecie AnimalSpecy { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            //if (id == null || _context.AnimalSpecies == null)
            //{
            //    return NotFound();
            //}

            //var animalspecy = await _context.AnimalSpecies.FirstOrDefaultAsync(m => m.Id == id);

            //if (animalspecy == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    AnimalSpecy = animalspecy;
            //}
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            //if (id == null || _context.AnimalSpecies == null)
            //{
            //    return NotFound();
            //}
            //var animalspecy = await _context.AnimalSpecies.FindAsync(id);

            //if (animalspecy != null)
            //{
            //    AnimalSpecy = animalspecy;
            //    _context.AnimalSpecies.Remove(AnimalSpecy);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }
    }
}
