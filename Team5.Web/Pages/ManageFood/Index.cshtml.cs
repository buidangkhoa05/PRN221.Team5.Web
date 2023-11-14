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

namespace Team5.Web.Pages.ManageFood
{
    public class IndexModel : PageModel
    {
        private readonly IFoodService _foodService;

        public IndexModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [BindProperty]
        public PagedList<Food> Foods { get; set; } = default!;

        public async Task OnGetAsync(int pageIndex = 1)
        {
            Foods = await _foodService.GetAll(new PagingParameters()
            {
                PageNumber = pageIndex,
                PageSize = 10
            });
        }
    }
}
