using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221.Team5.Domain.Entity;
using Team5.Infrastructure.DBContext;
//using Domain1;

namespace Team5.Web.Pages.ManageAnimal
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel()
        {
            //_context = context;
        }

      public Animal Animal { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            //if (id == null || _context.Animals == null)
            //{
            //    return NotFound();
            //}

            //var animal = await _context.Animals.FirstOrDefaultAsync(m => m.Id == id);
            //if (animal == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    Animal = animal;
            //}
            return Page();
        }
    }
}
