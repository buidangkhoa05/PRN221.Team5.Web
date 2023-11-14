using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageAnimalSpec
{
    public class IndexModel : PageModel
    {
        private readonly DbContext _context;

        public IndexModel()
        {
            //_context = context;
        }

        public IList<AnimalSpecie> AnimalSpecy { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_context.AnimalSpecies != null)
            //{
            //    AnimalSpecy = await _context.AnimalSpecies.ToListAsync();
            //}
        }
    }
}
