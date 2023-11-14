using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221.Team5.Application.Service.Implement;
//using Domain1;

namespace Team5.Web.Pages.ManagerAccount
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DeleteModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var account = await _accountService.GetById(id);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var account = await _accountService.GetById(id);

            if (account != null)
            {
                Account = account;
                await _accountService.Delete(id);
            }
            else
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
