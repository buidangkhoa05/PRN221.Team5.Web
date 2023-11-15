using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;
using Team5.Infrastructure.DBContext;
//using Domain1;

namespace Team5.Web.Pages.ManageAnimal
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var item = await _unitOfWork.Animal.GetFirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                var itemWithInclude = (await _unitOfWork.Animal.Get(new QueryHelper<Animal>()
                {
                    Filter = t => t.Id == id,
                    Include = t => t.Include(t => t.Specie)
                })).ToList();
                Animal = itemWithInclude[0];
            }
            return Page();
        }
    }
}
