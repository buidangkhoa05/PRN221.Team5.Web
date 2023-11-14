using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221.Team5.Domain.Entity;
using Team5.Infrastructure.DBContext;

namespace Team5.Web.Pages.ManageAnimal
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel()
        {
            
        }

        [BindProperty]
      public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            //if (id == null || _context.Animals == null)
            //{
            //    return NotFound();
            //}

            //var animal = await _context.Animals.FirstOrDefaultAsync(m => m.Id == id);

            //if (animal == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    Animal = animal;
            //}
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            //if (id == null || _context.Animals == null)
            //{
            //    return NotFound();
            //}
            //var animal = await _context.Animals.FindAsync(id);

            //if (animal != null)
            //{
            //    Animal = animal;
            //    _context.Animals.Remove(Animal);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }
    }
}
