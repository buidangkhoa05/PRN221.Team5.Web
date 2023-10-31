using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PRN221.Team5.Domain.Dto;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;
using Team5.Infrastructure.Repository;

namespace PRN221.Team5.Web.Pages.Dashboard
{
    public class ManageAccount : PageModel
    {
        private readonly ILogger<ManageAccount> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ManageAccount(ILogger<ManageAccount> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public List<Account> Accounts { get; set; } = new List<Account>();

        [BindProperty]
        public Dictionary<Role, string> Roles { get; } = new Dictionary<Role, string>
        {
            { Role.Administrator, "Admin" },
            { Role.Staff, "Staff" },
            { Role.ZooTrainer, "Zoo Trainer" }

        };

        [BindProperty]
        public Dictionary<string, string> Statuses { get; } = new Dictionary<string, string>
        {
            { "Active", "Active" },
            { "Inactive", "Inactive" },
        };

        [BindProperty]
        public CreateAccountDto CreateAccount { get; set; } = new CreateAccountDto();

        public async Task<IActionResult> OnGetAsync()
        {

            Accounts = await _unitOfWork.Account.GetWithPagination(new QueryHelper<Account>()
            {
                PagingParams = new PagingParameters()
            });

            return Page();
        }
    }

    //public async Task<IActionResult> OnPostAsync()
    //{
    //   return PageBase();
    //}
}