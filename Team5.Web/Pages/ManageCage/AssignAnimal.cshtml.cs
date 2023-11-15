using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221.Team5.Application.Service.Implement;
using Team5.Domain.Common;

namespace Team5.Web.Pages.ManageCage
{
    public class AssignAnimalModel : PageModel
    {
        private readonly IAnimalService _animalService;
        private readonly ICageService _cageService;

        public AssignAnimalModel(IAnimalService animalService, ICageService cageService)
        {
            _animalService = animalService;
            _cageService = cageService;
        }

        public string ErrorMessage { get; set; } = null;
        public Guid CageId { get; set; }

        public async Task OnGetAsync(int cageNumber)
        {
            try
            {
                var cages = await _cageService.GetAll();

                var cage = cages.FirstOrDefault(c => c.NumberCage == cageNumber);
                if (cage == null)
                {
                    ErrorMessage = "Cage not found";
                }

                var nbOfAnimalInCage = await _cageService.GetNumberOfAnimalInCage(cageNumber);
                if ((cage.Capacity - nbOfAnimalInCage) < 1)
                {
                    ErrorMessage = "Cage is full";
                }

                Animals = await _animalService.GetAllNotInCage();

                ViewData["Animals"] = new SelectList(Animals, "Id", "Name");

                CreateCageAnimal = new Cage_Animal()
                {
                    CageId = cage.Id,
                };
                CageId = cage.Id;
            }
            catch (Exception)
            {
            }
        }

        public List<Animal> Animals { get; set; } = default!;
        [BindProperty]
        public Cage_Animal CreateCageAnimal { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (CreateCageAnimal?.AnimalId != null)
                {
                    var animalIds = new List<Guid>();
                    animalIds.Add(CreateCageAnimal.AnimalId ?? Guid.Empty);

                    var isAnimalInCage = await _cageService.IsAnimalInCage(animalIds);

                    if (isAnimalInCage)
                    {
                        ErrorMessage = "Animal is in cage";
                        return Page();
                    }
                }

                var isSuccess = await _cageService.AddAnimalToCage(CreateCageAnimal);
                if (!isSuccess)
                {
                    ErrorMessage = "Add animal to cage fail";
                    return Page();
                }

            }
            catch (Exception)
            {
            }
            return RedirectToPage("./Index");
        }
    }
}
