using MovieSystem.Application.Contracts.Interface;
using System.Security.Claims;

namespace MovieSystem.API.Middleware
{
    public class MovieWatchMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMovieService _movieService;

        public MovieWatchMiddleware(RequestDelegate next, IMovieService movieService)
        {
            _next = next;
            _movieService = movieService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Check if the request is for the "WriteReview" endpoint
            if (context.Request.Path.StartsWithSegments("/api/reviews") &&
                context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                // Get the movie ID and user ID from the request (assuming they're passed in the request)
                var movieId = context.Request.Query["movieId"].ToString();
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(movieId) || string.IsNullOrEmpty(userId))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Movie ID or User ID is missing.");
                    return;
                }
               
                // Check if the user has watched the movie
                var hasWatched = await _movieService.HasUserWatchedMovieAsync(userId,movieId);
                if (!hasWatched)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Only users who have watched the movie can write a review.");
                    return;
                }
            }
            await _next(context);
        }
    }

}
