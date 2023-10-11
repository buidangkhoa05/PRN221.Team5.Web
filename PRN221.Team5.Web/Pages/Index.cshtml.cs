using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221.Team5.Domain.Entity;

namespace PRN221.Team5.Web.Pages
{
    [Authorize(Roles = nameof(Role.Administrator))]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
