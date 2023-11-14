using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Domain1;

namespace Team5.Web.Pages.ManageTraineerProfile
{
    public class CreateModel : PageModel
    {
        //private readonly Domain1.ZooManagementContext _context;

        //public CreateModel(Domain1.ZooManagementContext context)
        //{
        //    _context = context;
        //}

        //public IActionResult OnGet()
        //{
        //ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Email");
        //    return Page();
        //}

        [BindProperty]
        public TraineerProfile TraineerProfile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //  if (!ModelState.IsValid || _context.TraineerProfiles == null || TraineerProfile == null)
            //    {
            //        return Page();
            //    }

            //    _context.TraineerProfiles.Add(TraineerProfile);
            //    await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
