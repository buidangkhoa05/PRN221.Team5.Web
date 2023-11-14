using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageZooSection
{
    public class DeleteModel : PageModel
    {
        //private readonly Domain1.ZooManagementContext _context;

        //public DeleteModel(Domain1.ZooManagementContext context)
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

            //var zoosection = await _context.ZooSections.FirstOrDefaultAsync(m => m.Id == id);

            //if (zoosection == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    ZooSection = zoosection;
            //}
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            //if (id == null || _context.ZooSections == null)
            //{
            //    return NotFound();
            //}
            //var zoosection = await _context.ZooSections.FindAsync(id);

            //if (zoosection != null)
            //{
            //    ZooSection = zoosection;
            //    _context.ZooSections.Remove(ZooSection);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }
    }
}
