using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageFood
{
    public class DeleteModel : PageModel
    {
        private readonly DbContext _context;

        public DeleteModel()
        {
            //_context = context;
        }

        [BindProperty]
      public Food Food { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            //if (id == null || _context.Foods == null)
            //{
            //    return NotFound();
            //}

            //var food = await _context.Foods.FirstOrDefaultAsync(m => m.Id == id);

            //if (food == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    Food = food;
            //}
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            //if (id == null || _context.Foods == null)
            //{
            //    return NotFound();
            //}
            //var food = await _context.Foods.FindAsync(id);

            //if (food != null)
            //{
            //    Food = food;
            //    _context.Foods.Remove(Food);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }
    }
}
