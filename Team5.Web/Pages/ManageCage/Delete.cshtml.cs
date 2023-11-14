using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageCage
{
    public class DeleteModel : PageModel
    {
        private readonly DbContext _context;

        public DeleteModel()
        {
            //_context = context;
        }

        [BindProperty]
      public Cage Cage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            //if (id == null || _context.Cages == null)
            //{
            //    return NotFound();
            //}

            //var cage = await _context.Cages.FirstOrDefaultAsync(m => m.Id == id);

            //if (cage == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    Cage = cage;
            //}
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            //if (id == null || _context.Cages == null)
            //{
            //    return NotFound();
            //}
            //var cage = await _context.Cages.FindAsync(id);

            //if (cage != null)
            //{
            //    Cage = cage;
            //    _context.Cages.Remove(Cage);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }
    }
}
