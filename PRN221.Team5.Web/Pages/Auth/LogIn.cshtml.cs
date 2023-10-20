using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221.Team5.Domain.Entity;
using System.Linq.Expressions;
using System.Security.Claims;
using Team5.Application.Repository;
using Team5.Domain.Common;

namespace PRN221.Team5.Web.Pages.Auth
{
    [AllowAnonymous]
    public class LogInModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        
        public LogInModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var queryHelper = new QueryHelper<Account>()
                {
                    Filter = x => x.Username == Username && x.Password == Password,
                };

                var user = (await _unitOfWork.Account.Get(queryHelper)).FirstOrDefault();

                if (user == null)
                {
                    ModelState.AddModelError("invalid", "Username or password is incorrect");
                    return Page();
                }
                else
                {
                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                }
            }
            catch (Exception)
            {

            }

            return Page();
        }
    }


}
