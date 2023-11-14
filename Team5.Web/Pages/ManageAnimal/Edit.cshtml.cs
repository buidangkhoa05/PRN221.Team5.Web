using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageAnimal
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel()
        {
            //_context = context;
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
           // if (id == null || _context.Animals == null)
           // {
           //     return NotFound();
           // }

           // var animal =  await _context.Animals.FirstOrDefaultAsync(m => m.Id == id);
           // if (animal == null)
           // {
           //     return NotFound();
           // }
           // Animal = animal;
           //ViewData["SpecieId"] = new SelectList(_context.AnimalSpecies, "Id", "Description");
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

            _context.Attach(Animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(Animal.Id))
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

        private bool AnimalExists(Guid id)
        {
            //return (_context.Animals?.Any(e => e.Id == id)).GetValueOrDefault();
            return true;
        }
    }
}
