using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageAnimalSpec
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel()
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

            //var animalspecy =  await _context.AnimalSpecies.FirstOrDefaultAsync(m => m.Id == id);
            //if (animalspecy == null)
            //{
            //    return NotFound();
            //}
            //AnimalSpecy = animalspecy;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AnimalSpecy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalSpecyExists(AnimalSpecy.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AnimalSpecyExists(Guid id)
        {
            //return (_context.AnimalSpecies?.Any(e => e.Id == id)).GetValueOrDefault();
            return true;
        }
    }
}
