﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using Domain1;

namespace Team5.Web.Pages.ManageZooNews
{
    public class DeleteModel : PageModel
    {
        //private readonly Domain1.ZooManagementContext _context;

        //public DeleteModel(Domain1.ZooManagementContext context)
        //{
        //    _context = context;
        //}

        [BindProperty]
      public ZooNews ZooNews { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            //if (id == null || _context.ZooNews == null)
            //{
            //    return NotFound();
            //}

            //var zoonews = await _context.ZooNews.FirstOrDefaultAsync(m => m.Id == id);

            //if (zoonews == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    ZooNews = zoonews;
            //}
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            //if (id == null || _context.ZooNews == null)
            //{
            //    return NotFound();
            //}
            //var zoonews = await _context.ZooNews.FindAsync(id);

            //if (zoonews != null)
            //{
            //    ZooNews = zoonews;
            //    _context.ZooNews.Remove(ZooNews);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }
    }
}
