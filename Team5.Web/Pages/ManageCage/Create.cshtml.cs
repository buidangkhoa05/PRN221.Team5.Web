using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Domain1;

namespace Team5.Web.Pages.ManageCage
{
    public class CreateModel : PageModel
    {
        private readonly DbContext _context;

        public CreateModel()
        {
            //_context = context;
        }

        public IActionResult OnGet()
        {
        //ViewData["AnimalSpecieId"] = new SelectList(_context.AnimalSpecies, "Id", "Description");
        //ViewData["ZooSectionId"] = new SelectList(_context.ZooSections, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Cage Cage { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid || _context.Cages == null || Cage == null)
          //  {
          //      return Page();
          //  }

          //  _context.Cages.Add(Cage);
          //  await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
