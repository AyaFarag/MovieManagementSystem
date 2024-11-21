namespace MovieSystem.API.Middleware
{
    public class FixedWindowRateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly Dictionary<string, (int Count, DateTime ResetTime)> RateLimits = new();
        private readonly int _requestLimit = 10; // Number of allowed requests
        private readonly TimeSpan _window = TimeSpan.FromMinutes(1); // Time window
        private readonly IConfiguration _configuration;

        public FixedWindowRateLimitingMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoints = _configuration.GetSection("RateLimiting:Endpoints").Get<List<string>>() ?? new List<string>();
            if (endpoints.Any(e => context.Request.Path.StartsWithSegments(e, StringComparison.OrdinalIgnoreCase)))
            {
                string key = GenerateClientKey(context);

                // Lock to handle concurrent requests
                lock (RateLimits)
                {
                    if (RateLimits.TryGetValue(key, out var entry))
                    {
                        // If the window has expired, reset the counter
                        if (DateTime.UtcNow > entry.ResetTime)
                        {
                            RateLimits[key] = (1, DateTime.UtcNow.Add(_window));
                        }
                        else
                        {
                            // Increment the counter if within the window
                            if (entry.Count >= _requestLimit)
                            {
                                // Too many requests
                                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                                context.Response.Headers["Retry-After"] = (entry.ResetTime - DateTime.UtcNow).TotalSeconds.ToString("F0");
                                return;
                            }

                            RateLimits[key] = (entry.Count + 1, entry.ResetTime);
                        }
                    }
                    else
                    {
                        // New client
                        RateLimits[key] = (1, DateTime.UtcNow.Add(_window));
                    }
                }

                
            }
            await _next(context);
        }

        private string GenerateClientKey(HttpContext context)
        {
            // Use IP address or user identifier as a key
            string clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            return $"{clientIp}:{context.Request.Path}";
        }
    }

}
