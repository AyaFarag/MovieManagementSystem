namespace MovieSystem.API.Middleware
{
    public class LoginAttemptThrottlingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly Dictionary<string, (int AttemptCount, DateTime LastAttemptTime)> _failedLoginAttempts = new();

        private readonly int _maxAttempts = 5;  // Max number of allowed login attempts
        private readonly TimeSpan _timeWindow = TimeSpan.FromMinutes(15);  // Time window for attempts

        public LoginAttemptThrottlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();

            if (!string.IsNullOrEmpty(ipAddress) && IsLoginAttemptExcessive(ipAddress))
            {
                context.Response.StatusCode = 429;  // Too many requests
                await context.Response.WriteAsync("Too many login attempts. Please try again later.");
                return;
            }

            await _next(context);
        }

        private bool IsLoginAttemptExcessive(string ipAddress)
        {
            var currentTime = DateTime.UtcNow;

            if (_failedLoginAttempts.ContainsKey(ipAddress))
            {
                var (attemptCount, lastAttemptTime) = _failedLoginAttempts[ipAddress];

                // If the time window has passed, reset the counter
                if (currentTime - lastAttemptTime > _timeWindow)
                {
                    _failedLoginAttempts[ipAddress] = (0, currentTime);
                    return false;
                }

                // If the max attempts are exceeded, return true to throttle
                if (attemptCount >= _maxAttempts)
                    return true;
            }

            // Record the attempt
            _failedLoginAttempts[ipAddress] = (_failedLoginAttempts.GetValueOrDefault(ipAddress).AttemptCount + 1, currentTime);
            return false;
        }
    }

}
