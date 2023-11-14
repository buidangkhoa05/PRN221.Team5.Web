using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221.Team5.Application.Service.Implement;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Team5.Web.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;

        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        public string ErrorMessage { get; set; }

        [BindProperty]
        public Account Account { get; set; }


        public async Task<IActionResult> OnPostLoginAsync()
        {
            try
            {
                var account = await _authService.Login(Account.Username, Account.Password);
                if (account is null)
                {
                    ErrorMessage = "Email or password is incorrect";
                    return Page();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, account.Role.ToString()),
                    new Claim(ClaimTypes.Name, account.Username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToPage("/Index");
            }
            catch (Exception)
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}
