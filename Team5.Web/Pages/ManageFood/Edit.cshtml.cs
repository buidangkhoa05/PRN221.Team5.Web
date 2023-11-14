using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageFood
{
    public class EditModel : PageModel
    {
        private readonly DbContext _context;

        public EditModel()
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

            //var food =  await _context.Foods.FirstOrDefaultAsync(m => m.Id == id);
            //if (food == null)
            //{
            //    return NotFound();
            //}
            //Food = food;
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

            _context.Attach(Food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(Food.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FoodExists(Guid id)
        {
            //return (_context.Foods?.Any(e => e.Id == id)).GetValueOrDefault();
            return true;
        }
    }
}
