using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221.Team5.Application.Service.Implement;
//using Domain1;

namespace Team5.Web.Pages.ManageFood
{
    public class CreateModel : PageModel
    {
        private readonly IFoodService _foodService;

        public CreateModel(IFoodService foodService)
        {
            _foodService = foodService;
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
            var createResult = _foodService.Create(Food);

            return RedirectToPage("./Index");
        }
    }
}
