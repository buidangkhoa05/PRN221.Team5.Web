using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Team5.Application.Repository;
using Team5.Domain.Common;
//using Domain1;

namespace Team5.Web.Pages.ManageCage
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Cage Cage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
           try
            {
                if (id == Guid.Empty)
                {
                    return NotFound();
                }

                var item = await _unitOfWork.Cage.GetFirstOrDefaultAsync(m => m.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    var itemWithInclude = (await _unitOfWork.Cage.Get(new QueryHelper<Cage>()
                    {
                        Filter = t => t.Id == id,
                        Include = t => t.Include(t => t.AnimalSpecie).Include(t => t.ZooSection)
                    })).ToList();
                    Cage = itemWithInclude[0];
                }
            }
            catch { }
            return Page();
        }
    }
}
