using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;
//using Domain1;

namespace Team5.Web.Pages.ManageAnimal
{
    public class EditModel : PageModel
    {
        private readonly IAnimalService _animalService;
        private readonly IAnimalSpecieService _animalSpecieService;
        private readonly IFoodService _foodService;
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IAnimalService animalService, IAnimalSpecieService animalSpecieService, IFoodService foodService, IUnitOfWork unitOfWork)
        {
            _animalService = animalService;
            _animalSpecieService = animalSpecieService;
            _foodService = foodService;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;

        [BindProperty]
        public Meal Meal { get; set; } = default!;

        [BindProperty]
        public Meal_Food Meal_Food { get; set; } = default!;

        [BindProperty]
        public IList<Food> Foods { get; set; } = default!;

        public string ErrorMessage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var animalId = id ?? Guid.Empty;

            Animal = await _unitOfWork.Animal.GetById(animalId, new QueryHelper<Animal>()
            {
                Include = t => t.Include(t => t.Meal_Animals)
                                    .ThenInclude(t => t.Meal)
            });

            if (Animal == null)
            {
                return NotFound();
            }

            Foods = await _foodService.GetAll(new Domain.Common.PagingParameters(1, 20));
            ViewData["FoodId"] = new SelectList(Foods, "Id", "Name");
            ViewData["SpecieId"] = new SelectList(await _animalSpecieService.GetAll(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            Animal.UpdatedDate = DateTime.Now;
            Animal.UpdatedBy = User.Identity.Name;

            try
            {
                var animal = await _unitOfWork.Animal.GetById(Animal.Id, new QueryHelper<Animal>()
                {
                    Include = t => t.Include(t => t.Meal_Animals)
                                        .ThenInclude(t => t.Meal)
                });

                Animal.Meal_Animals = animal.Meal_Animals;

                var mealId = await _unitOfWork.Meal.CreateAsync(Meal, true);
                Meal_Food.MealId = mealId;

                var mealFoodId = await _unitOfWork.Meal_Food.CreateAsync(Meal_Food, true);

                Animal.Meal_Animals.ForEach(t => t.IsDeleted = true);

                //await _unitOfWork.Animal.UpdateAsync(Animal, true);

                //animal = await _unitOfWork.Animal.GetById(Animal.Id, new QueryHelper<Animal>()
                //{
                //    Include = t => t.Include(t => t.Meal_Animals)
                //                        .ThenInclude(t => t.Meal)
                //});

                Animal.Meal_Animals.Add(new Meal_Animal()
                {
                    MealId = mealId,
                    AnimalId = Animal.Id
                });

                await _unitOfWork.Animal.UpdateAsync(animal, true);
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
