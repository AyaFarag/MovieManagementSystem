namespace MovieSystem.API.Middleware
{
    public class CustomRateLimitMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomRateLimitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 429)
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(new
                {
                    error = "Too Many Requests",
                    details = "You have exceeded the allowed number of requests. Please try again later."
                }.ToString());
            }
        }
    }

}
