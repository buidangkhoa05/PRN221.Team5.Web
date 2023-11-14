using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221.Team5.Application.Service.Implement;
using Team5.Domain.Common;
//using Domain1;

namespace Team5.Web.Pages.ManageAnimal
{
    public class IndexModel : PageModel
    {
        private readonly IAnimalService _animalService;

        public IndexModel(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [BindProperty]
        public PagedList<Animal> Animal { get; set; }

        public async Task OnGetAsync(int pageIndex = 1)
        {
            try
            {
                Animal = await _animalService.GetAll(new PagingParameters()
                {
                    PageNumber = pageIndex,
                    PageSize = 5
                });
            }
            catch (Exception)
            {
            }
        }
    }
}
