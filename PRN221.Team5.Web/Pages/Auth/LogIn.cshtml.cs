using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;

namespace PRN221.Team5.Web.Pages.Auth
{
    [AllowAnonymous]
    public class LogInModel : PageModel
    {


        public LogInModel()
        {

        }

        public void OnGet()
        {

        }
    }
}
