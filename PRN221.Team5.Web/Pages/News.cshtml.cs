using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PRN221.Team5.Web.Pages
{
    public class News : PageModel
    {
        private readonly ILogger<News> _logger;

        public News(ILogger<News> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}