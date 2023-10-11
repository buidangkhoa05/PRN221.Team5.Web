namespace PRN221.Team5.Web.Middleware
{
    public class SeesionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public SeesionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments("/Auth/Login"))
            {
                // Check if the user is authenticated or has a valid session
                if (!context.User.Identity.IsAuthenticated)
                {
                    // Redirect to the login page
                    context.Response.Redirect("/Auth/Login");
                    return;
                }
            }

            // Continue processing the request
            await _next(context);
        }
    }
}
