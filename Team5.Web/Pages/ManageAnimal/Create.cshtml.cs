using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Infrastructure.DBContext;

namespace Team5.Web.Pages.ManageAnimal
{
    public class CreateModel : PageModel
    {
        private readonly IAnimalService _animalService;
        private readonly IAnimalSpecieService _animalSpecieService;
        private readonly IFoodService _foodService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IAnimalService animalService, IAnimalSpecieService animalSpecieService, IFoodService foodService, IUnitOfWork unitOfWork)
        {
            _animalService = animalService;
            _animalSpecieService = animalSpecieService;
            _foodService = foodService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Foods = await _foodService.GetAll(new Domain.Common.PagingParameters(1,20));
            ViewData["FoodId"] = new SelectList(Foods, "Id", "Name");
            ViewData["SpecieId"] = new SelectList(await _animalSpecieService.GetAll(), "Id", "Name");
            return Page();
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


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || _context.Animals == null || Animal == null)
            //{
            //    return Page();
            //}

            try
            {
                Meal.CreatedDate = DateTime.Now;
                Meal.UpdatedDate = DateTime.Now;
                Guid isCreateMealSuccess = await _unitOfWork.Meal.CreateAsync(Meal, false);

                Meal_Food.MealId = Meal.Id;
                Guid isCreateMeal_FoodSuccess = await _unitOfWork.Meal_Food.CreateAsync(Meal_Food, false);

                Guid isCreateAnimalSuccess = await _unitOfWork.Animal.CreateAsync(Animal, false);

                Guid isCreateMealAnimalSuccess = await _unitOfWork.Meal_Animal.CreateAsync(new Meal_Animal
                {
                    MealId = Meal.Id,
                    AnimalId = Animal.Id
                }, false);
                
                if (isCreateAnimalSuccess != Guid.Empty && 
                    isCreateMealAnimalSuccess != Guid.Empty && 
                    isCreateMealSuccess != Guid.Empty &&
                    isCreateMeal_FoodSuccess != Guid.Empty)
                await _unitOfWork.SaveChangeAsync();
            }
            catch
            {

            }



            //_context.Animals.Add(Animal);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
