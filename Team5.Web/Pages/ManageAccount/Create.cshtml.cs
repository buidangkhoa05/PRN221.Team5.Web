using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221.Team5.Application.Service.Implement;
using Team5.Application.Repository;
//using Domain1;

namespace Team5.Web.Pages.ManagerAccount
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IAccountService accountService, IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
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

                if (Account.Role == Role.ZooTrainer)
                {
                    var trainer = new TraineerProfile
                    {
                        Id = Guid.NewGuid(),
                        AccountId = Account.Id,
                        JoinDate = DateTime.Now,
                        Exprerience = "0",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    };
                    await _unitOfWork.TrainerProfile.CreateAsync(trainer, true);
                }
            }
            catch (Exception)
            { }

            return RedirectToPage("./Index");
        }
    }
}
