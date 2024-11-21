namespace MovieSystem.API.Middleware
{
    public class UserPaymentBasedRateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly Dictionary<string, (int Count, DateTime ResetTime)> RateLimits = new();
        private readonly int _requestLimit = 10; // Number of allowed requests
        private readonly TimeSpan _window = TimeSpan.FromMinutes(1); // Time window

        public UserPaymentBasedRateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments("/api/auth/payment", StringComparison.OrdinalIgnoreCase))
            {
            }
            // Ensure user is authenticated
            if (context.User.Identity?.IsAuthenticated == true)
            {
                string key = GenerateUserKey(context);

                lock (RateLimits)
                {
                    if (RateLimits.TryGetValue(key, out var entry))
                    {
                        // Reset counter if window expired
                        if (DateTime.UtcNow > entry.ResetTime)
                        {
                            RateLimits[key] = (1, DateTime.UtcNow.Add(_window));
                        }
                        else
                        {
                            // Increment or block request if limit exceeded
                            if (entry.Count >= _requestLimit)
                            {
                                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                                context.Response.Headers["Retry-After"] = (entry.ResetTime - DateTime.UtcNow).TotalSeconds.ToString("F0");
                                context.Response.WriteAsync("Too many requests. Please wait before trying again.");
                                return;
                            }

                            RateLimits[key] = (entry.Count + 1, entry.ResetTime);
                        }
                    }
                    else
                    {
                        // New user
                        RateLimits[key] = (1, DateTime.UtcNow.Add(_window));
                    }
                }
            }

            await _next(context);
        }

        private string GenerateUserKey(HttpContext context)
        {
            // Use authenticated user's unique identifier
            return context.User.FindFirst("sub")?.Value ?? context.User.Identity?.Name ?? "anonymous";
        }
    }

}
