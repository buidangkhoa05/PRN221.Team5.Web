using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using Team5.Infrastructure.DBContext;

namespace Team5.Web.Pages.ManageAnimal
{
    public class CreateModel : PageModel
    {
        private readonly IAnimalService _animalService;
        private readonly IAnimalSpecieService _animalSpecieService;

        public CreateModel(IAnimalService animalService,
            IAnimalSpecieService animalSpecieService)
        {
            _animalService = animalService;
            _animalSpecieService = animalSpecieService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["SpecieId"] = new SelectList(await _animalSpecieService.GetAll(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || _context.Animals == null || Animal == null)
            //  {
            //      return Page();
            //  }

            //  _context.Animals.Add(Animal);
            //  await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
