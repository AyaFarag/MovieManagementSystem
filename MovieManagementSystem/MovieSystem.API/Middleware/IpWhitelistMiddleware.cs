namespace MovieSystem.API.Middleware
{
    public class IpWhitelistMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<string> _whitelistedIps;

        public IpWhitelistMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            // Load the whitelisted IPs from configuration
            _whitelistedIps = configuration.GetSection("WhitelistedIPs").Get<List<string>>() ?? new List<string>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Check if the request is for the Swagger endpoint
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                // Get the client IP address
                var clientIp = context.Connection.RemoteIpAddress?.ToString();

                // Check if the client IP is in the whitelist
                if (!_whitelistedIps.Contains(clientIp))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Access to Swagger documentation is restricted.");
                    return;
                }
            }

            // Continue to the next middleware
            await _next(context);
        }
    }
}
