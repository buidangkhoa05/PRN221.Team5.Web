using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221.Team5.Web.Pages.Auth
{
    [AllowAnonymous]
    public class LogInModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
