using AutoMapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Domain.Entities;
using System.Security.Claims;

namespace MovieSystem.API.Middleware
{
    public class PaidUserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public PaidUserMiddleware(RequestDelegate next, 
            IUserService userService, 
            IMovieService movieService,
            IMapper mapper)
        {
            _next = next;
            _userService = userService;
            _movieService = movieService;
            _mapper = mapper;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Check if the request is for a "Watch Movie" endpoint
            if (context.Request.Path.StartsWithSegments("/api/movies/watch") &&
                context.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
            {
                var movieId = context.Request.Query["movieId"].ToString();
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(movieId) || string.IsNullOrEmpty(userId))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Movie ID or User ID is missing.");
                    return;
                }

                // Fetch user and movie details
                var user = await _userService.GetUserById(userId); // string issue
                var movie = await _movieService.GetMovieById(movieId); // string issue

                // Validate movie access
                if (movie == null || user == null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("User or Movie not found.");
                    return;
                }
             
                // Allow if the movie is free or the user is a paid user
                if (!movie.isFree && !user.isPaid)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Only paid users can watch this movie.");
                    return;
                }
            }

            // Continue to the next middleware
            await _next(context);
        }
    }
}
