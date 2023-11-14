﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManagerAccount
{
    public class EditModel : PageModel
    {
        //private readonly Domain1.ZooManagementContext _context;

        public EditModel()
        {
            //_context = context;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            //if (id == null || _context.Accounts == null)
            //{
            //    return NotFound();
            //}

            //var account =  await _context.Accounts.FirstOrDefaultAsync(m => m.Id == id);
            //if (account == null)
            //{
            //    return NotFound();
            //}
            //Account = account;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Account).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!AccountExists(Account.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        private bool AccountExists(Guid id)
        {
            //return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
            return false;
        }
    }
}
