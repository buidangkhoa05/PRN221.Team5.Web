using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageTraineerProfile
{
    public class EditModel : PageModel
    {
        //private readonly Domain1.ZooManagementContext _context;

        //public EditModel(Domain1.ZooManagementContext context)
        //{
        //    _context = context;
        //}

        [BindProperty]
        public TraineerProfile TraineerProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
           // if (id == null || _context.TraineerProfiles == null)
           // {
           //     return NotFound();
           // }

           // var traineerprofile =  await _context.TraineerProfiles.FirstOrDefaultAsync(m => m.Id == id);
           // if (traineerprofile == null)
           // {
           //     return NotFound();
           // }
           // TraineerProfile = traineerprofile;
           //ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Email");
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

            //_context.Attach(TraineerProfile).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TraineerProfileExists(TraineerProfile.Id))
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

        private bool TraineerProfileExists(Guid id)
        {
          //return (_context.TraineerProfiles?.Any(e => e.Id == id)).GetValueOrDefault();
          return true;
        }
    }
}
