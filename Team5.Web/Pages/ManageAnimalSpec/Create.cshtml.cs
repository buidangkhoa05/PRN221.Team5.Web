using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Domain1;

namespace Team5.Web.Pages.ManageAnimalSpec
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel()
        {
            //_context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AnimalSpecie AnimalSpecy { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid || _context.AnimalSpecies == null || AnimalSpecy == null)
          //  {
          //      return Page();
          //  }

          //  _context.AnimalSpecies.Add(AnimalSpecy);
          //  await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
