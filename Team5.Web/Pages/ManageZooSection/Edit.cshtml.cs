using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageZooSection
{
    public class EditModel : PageModel
    {
        //private readonly Domain1.ZooManagementContext _context;

        //public EditModel(Domain1.ZooManagementContext context)
        //{
        //    _context = context;
        //}

        [BindProperty]
        public ZooSection ZooSection { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            //if (id == null || _context.ZooSections == null)
            //{
            //    return NotFound();
            //}

            //var zoosection =  await _context.ZooSections.FirstOrDefaultAsync(m => m.Id == id);
            //if (zoosection == null)
            //{
            //    return NotFound();
            //}
            //ZooSection = zoosection;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(ZooSection).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ZooSectionExists(ZooSection.Id))
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

        private bool ZooSectionExists(Guid id)
        {
          //return (_context.ZooSections?.Any(e => e.Id == id)).GetValueOrDefault();
          return false;
        }
    }
}
