using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Team5.Application.Repository;
//using Domain1;

namespace Team5.Web.Pages.ManageZooSection
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ZooSection ZooSection { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var zoosection = await _unitOfWork.ZooSection.GetFirstOrDefaultAsync(m => m.Id == id);
            if (zoosection == null)
            {
                return NotFound();
            }
            else
            {
                ZooSection = zoosection;
            }
            return Page();
        }
    }
}
