using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;
using Team5.Infrastructure.DBContext;

namespace Team5.Web.Pages.ManageAnimal
{
    public class AddTrainerModel : PageModel
    {
        private readonly IAnimalService _animalService;
        private readonly IAnimalSpecieService _animalSpecieService;
        private readonly IFoodService _foodService;
        private readonly IUnitOfWork _unitOfWork;

        public AddTrainerModel(IAnimalService animalService, IAnimalSpecieService animalSpecieService, IFoodService foodService, IUnitOfWork unitOfWork)
        {
            _animalService = animalService;
            _animalSpecieService = animalSpecieService;
            _foodService = foodService;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;
        [BindProperty]
        public TraineerProfile TraineerProfile { get; set; } = default!;
        [BindProperty]
        public AnimalTraining AnimalTraining { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return NotFound();
                }

                //check animal is already have trainer
                var animalHaveTrainer = await _unitOfWork.AnimalTraining.GetFirstOrDefaultAsync(a => a.AnimalId == id);
                if (animalHaveTrainer != null)
                {
                    return RedirectToPage("./HaveTrainer");
                }
                Animal = await _unitOfWork.Animal.GetFirstOrDefaultAsync(a => a.Id == id);

                ViewData["TrainnerProfile"] = new SelectList(
                    await _unitOfWork.TrainerProfile.Get(new QueryHelper<TraineerProfile>()
                    {
                        Include = t => t.Include(t => t.Account)
                    }
                ), "Id", "Account.Username");
            }
            catch { }
            
            return Page();
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Animal.UpdatedDate = DateTime.Now;
            try
            {
                AnimalTraining.AnimalId = Animal.Id;
                await _unitOfWork.AnimalTraining.CreateAsync(AnimalTraining, true);
            }
            catch (Exception)
            {
            }

            return RedirectToPage("./Index");
        }
        private bool AnimalExists(Guid id)
        {
            //return (_context.Animals?.Any(e => e.Id == id)).GetValueOrDefault();
            return false;
        }
    }
}
