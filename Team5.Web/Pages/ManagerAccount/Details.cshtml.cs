﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManagerAccount
{
    public class DetailsModel : PageModel
    {
      

        public DetailsModel()
        {
            //_context = context;
        }

      public Account Account { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            //if (id == null || _context.Accounts == null)
            //{
            //    return NotFound();
            //}

            //var account = await _context.Accounts.FirstOrDefaultAsync(m => m.Id == id);
            //if (account == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    Account = account;
            //}
            return Page();
        }
    }
}
