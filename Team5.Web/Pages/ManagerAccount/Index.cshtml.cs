using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManagerAccount
{
    public class IndexModel : PageModel
    {
        //private readonly Domain1.ZooManagementContext _context;

        //public IndexModel(Domain1.ZooManagementContext context)
        //{
        //    _context = context;
        //}

        public IList<Account> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_context.Accounts != null)
            //{
            //    Account = await _context.Accounts.ToListAsync();
            //}
        }
    }
}
