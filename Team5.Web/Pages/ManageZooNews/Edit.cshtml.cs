using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageZooNews
{
    public class EditModel : PageModel
    {
        //private readonly Domain1.ZooManagementContext _context;

        //public EditModel(Domain1.ZooManagementContext context)
        //{
        //    _context = context;
        //}

        [BindProperty]
        public ZooNews ZooNews { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
           // if (id == null || _context.ZooNews == null)
           // {
           //     return NotFound();
           // }

           // var zoonews =  await _context.ZooNews.FirstOrDefaultAsync(m => m.Id == id);
           // if (zoonews == null)
           // {
           //     return NotFound();
           // }
           // ZooNews = zoonews;
           //ViewData["OwnerId"] = new SelectList(_context.Accounts, "Id", "Email");
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

            //_context.Attach(ZooNews).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ZooNewsExists(ZooNews.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        private bool ZooNewsExists(Guid id)
        {
            //return (_context.ZooNews?.Any(e => e.Id == id)).GetValueOrDefault();
            return true;
        }
    }
}
