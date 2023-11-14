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
        public PagedList<Animal> Animals { get; set; }

        [BindProperty]
        public Animal CreateAnimal { get; set; }

        [BindProperty] Cage_Animal CreateCageAnimal { get; set; }

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
    }
}