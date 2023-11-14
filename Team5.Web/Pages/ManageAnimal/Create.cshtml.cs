using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221.Team5.Domain.Entity;
using Team5.Infrastructure.DBContext;

namespace Team5.Web.Pages.ManageAnimal
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel()
        {
           
        }

        public IActionResult OnGet()
        {
        //ViewData["SpecieId"] = new SelectList(_context.AnimalSpecies, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid || _context.Animals == null || Animal == null)
          //  {
          //      return Page();
          //  }

          //  _context.Animals.Add(Animal);
          //  await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
