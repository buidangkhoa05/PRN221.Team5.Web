using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageCage
{
    public class IndexModel : PageModel
    {
        private readonly DbContext _context;

        public IndexModel()
        {
            //_context = context;
        }

        public IList<Cage> Cage { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_context.Cages != null)
            //{
            //    Cage = await _context.Cages
            //    .Include(c => c.AnimalSpecie)
            //    .Include(c => c.ZooSection).ToListAsync();
            //}
        }
    }
}
