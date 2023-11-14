using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Security.Claims;
using Team5.Application.Repository;
using Team5.Domain.Common;

namespace PRN221.Team5.Web.Pages.Auth
{
    [AllowAnonymous]
    public class LogInModel : PageModel
    {
        private readonly IAuthService _authService;

        [BindProperty]
        [Required]
        [MinLength(5)]
        public string Username { get; set; }

        [BindProperty]
        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        public LogInModel(IAuthService authService)
        {
            _authService = authService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (string.IsNullOrEmpty(Username.Trim()) || string.IsNullOrEmpty(Password.Trim()))
                {
                    return Page();
                }

                var account = await _authService.Login(Username, Password);
                if (account == null)
                {
                    ModelState.AddModelError("invalid", "Username or password is incorrect");
                    return Page();
                }

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, account.Username),
                    new Claim(ClaimTypes.Role, account.Role.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, account.Id.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);

            }
            catch (Exception) { }

            return Page();
        }
    }


}
