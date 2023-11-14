using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageTraineerProfile
{
    public class DetailsModel : PageModel
    {
        //private readonly Domain1.ZooManagementContext _context;

        //public DetailsModel(Domain1.ZooManagementContext context)
        //{
        //    _context = context;
        //}

      public TraineerProfile TraineerProfile { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            //if (id == null || _context.TraineerProfiles == null)
            //{
            //    return NotFound();
            //}

            //var traineerprofile = await _context.TraineerProfiles.FirstOrDefaultAsync(m => m.Id == id);
            //if (traineerprofile == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    TraineerProfile = traineerprofile;
            //}
            return Page();
        }
    }
}
