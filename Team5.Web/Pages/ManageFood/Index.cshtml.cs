using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageFood
{
    public class IndexModel : PageModel
    {
        private readonly DbContext _context;

        public IndexModel()
        {
            //_context = context;
        }

        public IList<Food> Food { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_context.Foods != null)
            //{
            //    Food = await _context.Foods.ToListAsync();
            //}
        }
    }
}
