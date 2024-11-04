using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;

namespace MovieSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
              _movieService = movieService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _movieService.GetMovieById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMovie(MovieDTO movie)
        {
      
            var result = _movieService.CreateMovie(movie);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateMovie()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteMovie()
        {
            return Ok();
        }
    }
}
