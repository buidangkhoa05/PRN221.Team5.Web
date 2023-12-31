using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;

namespace PRN221.Team5.Web.Pages.Dashboard
{
    public class ManageAnimals : PageModel
    {
        private readonly IAnimalService _animalService;
        private readonly ICageService _cageService;
        private readonly ITrainerService _trainerService;

        public ManageAnimals(IAnimalService animalService,
            ICageService cageService,
            ITrainerService trainerService)
        {
            _animalService = animalService;
            _cageService = cageService;
            _trainerService = trainerService;
        }

        [BindProperty]
        public Guid SelectedId { get; set; }

        [BindProperty]
        public PagedList<Animal> Animals { get; set; }

        public async Task<IActionResult> OnGetAsync(int pageIndex = 1)
        {
            try
            {
                Animals = await _animalService.GetAll(new PagingParameters()
                {
                    PageNumber = pageIndex,
                    PageSize = 5
                }) ?? new PagedList<Animal>();

                ViewData["Cages"] = new SelectList(await _cageService.GetAll(), "Id", "NumberCage");
                ViewData["Trainers"] = new SelectList(await _trainerService.GetAll(), "AccountId", "AccountId");
            }
            catch (Exception)   
            {
            }

            return Page();
        }


        [BindProperty]
        public Animal CreateAnimal { get; set; }

        [BindProperty]
        public Guid CageId { get; set; }

        [BindProperty]
        public Guid TrainerId { get; set; }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            try
            {
                CreateAnimal.Cage_Animals = new List<Cage_Animal>()
                {
                    new Cage_Animal()
                    {
                        CageId = CageId,
                        AnimalId = CreateAnimal.Id
                    }
                };

                CreateAnimal.AnimalTrainings = new List<AnimalTraining>()
                {
                    new AnimalTraining()
                    {
                        StartDate = DateTime.Now,
                        TrainerId = TrainerId,
                        AnimalId = CreateAnimal.Id
                    }
                };

                var createResult = await _animalService.Create(CreateAnimal);
                return RedirectToPage("ManageAnimals");
            }
            catch (Exception)
            {
                return Page();
            }
        }
    }
}