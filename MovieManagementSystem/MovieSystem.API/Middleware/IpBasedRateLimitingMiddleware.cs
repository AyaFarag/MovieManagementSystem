namespace MovieSystem.API.Middleware
{
    public class IpBasedRateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly Dictionary<string, (int Count, DateTime ResetTime)> RateLimits = new();
        private readonly int _requestLimit = 10; // Number of allowed requests
        private readonly TimeSpan _window = TimeSpan.FromMinutes(1); // Time window

        public IpBasedRateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string clientIp = GetClientIp(context);

            if (string.IsNullOrEmpty(clientIp))
            {
                // If unable to determine IP, allow the request to pass through
                await _next(context);
                return;
            }

            lock (RateLimits)
            {
                if (RateLimits.TryGetValue(clientIp, out var entry))
                {
                    // Reset counter if window expired
                    if (DateTime.UtcNow > entry.ResetTime)
                    {
                        RateLimits[clientIp] = (1, DateTime.UtcNow.Add(_window));
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

                        RateLimits[clientIp] = (entry.Count + 1, entry.ResetTime);
                    }
                }
                else
                {
                    // New IP
                    RateLimits[clientIp] = (1, DateTime.UtcNow.Add(_window));
                }
            }

            await _next(context);
        }

        private string GetClientIp(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return context.Request.Headers["X-Forwarded-For"].ToString().Split(',').First().Trim();
            }
            // Try to get the IP address from the HTTP context
            return context.Connection.RemoteIpAddress?.ToString();
        }
    }

}
