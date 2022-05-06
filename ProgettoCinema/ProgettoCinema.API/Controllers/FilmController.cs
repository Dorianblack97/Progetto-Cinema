using Microsoft.AspNetCore.Mvc;
using ProgettoCinema.API.Extensions;
using ProgettoCinema.API.Repository;
using ProgettoCinema.Domain;

namespace ProgettoCinema.API.Controllers;
public class FilmController : Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GenericRepository<Film> _filmRepository;

        public UserController(GenericRepository<Film> filmRepository)
        {
            _filmRepository = filmRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string expand = "", string filter = "")
        {
            try
            {
                var filterQuery = filter.GetFilterQuery<Film>();
                var user = await _filmRepository.Get(includeProperties: expand, filter: filterQuery);
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
                var user = await _filmRepository.GetById(id, includeProperties: expand);
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
        public async Task<IActionResult> Post([FromBody] Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await _filmRepository.Create(film);
                return Ok(created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromBody] Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _filmRepository.Update(film);
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
                await _filmRepository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
