namespace PRN221.Team5.Web.Middleware
{
    public class CheckRoleMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckRoleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //var user = context.User;
            //if (user.Identity.IsAuthenticated)
            //{
            //    var role = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            //    if (role == "Admin")
            //    {
            //        context.Response.Redirect("/Admin");
            //    }
            //    else if (role == "User")
            //    {
            //        context.Response.Redirect("/User");
            //    }
            //}
            //await _next(context);
        }
    }
}
