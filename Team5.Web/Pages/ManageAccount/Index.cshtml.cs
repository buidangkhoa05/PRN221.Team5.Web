using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221.Team5.Application.Service.Implement;
using Team5.Domain.Common;
//using Domain1;

namespace Team5.Web.Pages.ManagerAccount
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public PagedList<Account> Account { get;set; } = default!;

        public async Task OnGetAsync(int pageIndex = 1)
        {
            try
            {
                Account = await _accountService.GetAll(new PagingParameters() 
                { 
                    PageNumber = pageIndex, 
                    PageSize = 5
                });
            }
            catch (Exception)
            {
            }
        }
    }
}
