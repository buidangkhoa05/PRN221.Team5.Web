using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public ManageAnimals(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [BindProperty]
        public PagedList<Animal> Animals { get; set; }

        public async Task<IActionResult> OnGetAsync(int pageIndex = 1)
        {
            try
            {
                Animals = await _animalService.GetAll(new PagingParameters()
                {
                    PageNumber = pageIndex,
                    PageSize = 1
                }) ?? new PagedList<Animal>();
            }
            catch (Exception)
            {
            }

            return Page();
        }
    }
}