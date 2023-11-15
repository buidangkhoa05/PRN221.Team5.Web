using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221.Team5.Application.Service.Implement;
//using Domain1;

namespace Team5.Web.Pages.ManagerAccount
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService;

        public EditModel(IAccountService accountService)
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
            Account = account;
            return Page();
        }

        public string ErrorMessage { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (Account.DateOfBirth > DateTime.Now.AddDays(-365))
            {
                ErrorMessage = "Date of birth is invalid";
                return Page();
            }

            try
            {
                var isSuccess= await _accountService.Update(Account);
                if (!isSuccess)
                {
                    ErrorMessage = "Update failed";
                    return Page();
                }
            }
            catch (Exception)
            {
            }

            return RedirectToPage("./Index");
        }

        private bool AccountExists(Guid id)
        {
            //return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
            return false;
        }
    }
}
