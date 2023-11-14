using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221.Team5.Application.Service.Implement;
//using Domain1;

namespace Team5.Web.Pages.ManageFood
{
    public class EditModel : PageModel
    {
        private readonly IFoodService _foodService;

        public EditModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [BindProperty]
        public Food Food { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var food = await _foodService.GetFirstOrDefault(id);
            if (food == null)
            {
                return NotFound();
            }
            Food = food;
            return Page();
        }

        public string ErrorMessage { get; set; } = null;

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var isSuccess = await _foodService.Update(Food);
                if (!isSuccess)
                {
                    ErrorMessage = "Update failed";
                    return Page();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return RedirectToPage("./Index");
        }

        //private bool FoodExists(Guid id)
        //{
        //    //return (_context.Foods?.Any(e => e.Id == id)).GetValueOrDefault();
        //    return true;
        //}
    }
}
