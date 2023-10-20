using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PRN221.Team5.Web.Pages.Dashboard
{
    public class ManageAccount : PageModel
    {
        private readonly ILogger<ManageAccount> _logger;

        public ManageAccount(ILogger<ManageAccount> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}