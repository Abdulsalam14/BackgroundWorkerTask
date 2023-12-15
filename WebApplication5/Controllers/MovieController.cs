using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Services.Abstract;
using WebApplication5.Services.Concrete;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService service)
        {
            _movieService= service;
        }

        [HttpGet] 
        public IActionResult Get()
        {
            var films=_movieService.GetAll();
            return  Ok(films);
        }
    }
}
