using Microsoft.AspNetCore.Mvc;
using ProgettoCinema.API.Extensions;
using ProgettoCinema.API.Repository;
using ProgettoCinema.Domain;

namespace ProgettoCinema.API.Controllers;
public class GenereFilmController : Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GenericRepository<GenereFilm> _genereFilmRepository;

        public UserController(GenericRepository<GenereFilm> genereFilmRepository)
        {
            _genereFilmRepository = genereFilmRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string expand = "", string filter = "")
        {
            try
            {
                var filterQuery = filter.GetFilterQuery<GenereFilm>();
                var user = await _genereFilmRepository.Get(includeProperties: expand, filter: filterQuery);
                return user is not null
                    ? Ok(user)
                    : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, string expand = "")
        {
            try
            {
                var user = await _genereFilmRepository.GetById(id, includeProperties: expand);
                return user is not null
                    ? Ok(user)
                    : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GenereFilm generefilm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await _genereFilmRepository.Create(generefilm);
                return Ok(created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromBody] GenereFilm generefilm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _genereFilmRepository.Update(generefilm);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _genereFilmRepository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
