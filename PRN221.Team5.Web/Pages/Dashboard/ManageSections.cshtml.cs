using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PRN221.Team5.Web.Pages.Dashboard
{
    public class ManageSections : PageModel
    {
        private readonly ILogger<ManageSections> _logger;

        public ManageSections(ILogger<ManageSections> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}