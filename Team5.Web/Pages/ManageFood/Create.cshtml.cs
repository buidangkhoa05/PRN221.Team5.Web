using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Domain1;

namespace Team5.Web.Pages.ManageFood
{
    public class CreateModel : PageModel
    {
        private readonly DbContext _context;

        public CreateModel()
        {
            //_context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Food Food { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid || _context.Foods == null || Food == null)
          //  {
          //      return Page();
          //  }

          //  _context.Foods.Add(Food);
          //  await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
