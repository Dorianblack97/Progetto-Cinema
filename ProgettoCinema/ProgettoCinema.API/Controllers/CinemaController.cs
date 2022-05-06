using Microsoft.AspNetCore.Mvc;
using ProgettoCinema.API.Extensions;
using ProgettoCinema.API.Repository;
using ProgettoCinema.Domain;

namespace ProgettoCinema.API.Controllers;
public class CinemaController : Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GenericRepository<Cinema> _cinemaRepository;

        public UserController(GenericRepository<Cinema> cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string expand = "", string filter = "")
        {
            try
            {
                var filterQuery = filter.GetFilterQuery<Cinema>();
                var user = await _cinemaRepository.Get(includeProperties: expand, filter: filterQuery);
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
                var user = await _cinemaRepository.GetById(id, includeProperties: expand);
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
        public async Task<IActionResult> Post([FromBody] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await _cinemaRepository.Create(cinema);
                return Ok(created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromBody] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _cinemaRepository.Update(cinema);
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
                await _cinemaRepository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
