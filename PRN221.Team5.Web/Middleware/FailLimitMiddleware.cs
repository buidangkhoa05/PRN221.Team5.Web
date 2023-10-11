namespace PRN221.Team5.Web.Middleware
{
    public class FailLimitMiddleware
    {
        private readonly RequestDelegate _next;

        public FailLimitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/Auth/Login") ||
                context.Request.Method.Equals("post", StringComparison.OrdinalIgnoreCase))
            {
               
            }

            await _next(context);
        }

    }
}
