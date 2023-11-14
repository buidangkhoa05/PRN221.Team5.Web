using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221.Team5.Application.Service.Implement;
//using Domain1;

namespace Team5.Web.Pages.ManagerAccount
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;

        public CreateModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public string ErrorMessage { get; set; } = default!;
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Account.DateOfBirth > DateTime.Now.AddDays(-365))
                {
                    ErrorMessage = "Date of birth is invalid";
                    return Page();
                }

                var account = await _accountService.Get(t => t.Username == Account.Username);
                if (account is not null)
                {
                    ErrorMessage = "Username is exist";
                    return Page();
                }

                var result = await _accountService.Create(Account);
            }
            catch (Exception)
            { }

            return RedirectToPage("./Index");
        }
    }
}
