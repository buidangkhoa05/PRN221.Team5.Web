using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageCage
{
    public class EditModel : PageModel
    {
        private readonly DbContext _context;

        public EditModel()
        {
            //_context = context;
        }

        [BindProperty]
        public Cage Cage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
           // if (id == null || _context.Cages == null)
           // {
           //     return NotFound();
           // }

           // var cage =  await _context.Cages.FirstOrDefaultAsync(m => m.Id == id);
           // if (cage == null)
           // {
           //     return NotFound();
           // }
           // Cage = cage;
           //ViewData["AnimalSpecieId"] = new SelectList(_context.AnimalSpecies, "Id", "Description");
           //ViewData["ZooSectionId"] = new SelectList(_context.ZooSections, "Id", "Description");
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

            _context.Attach(Cage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CageExists(Cage.Id))
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

        private bool CageExists(Guid id)
        {
            //return (_context.Cages?.Any(e => e.Id == id)).GetValueOrDefault();
            return true;
        }
    }
}
