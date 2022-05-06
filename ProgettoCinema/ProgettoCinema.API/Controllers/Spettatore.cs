using Microsoft.AspNetCore.Mvc;
using ProgettoCinema.API.Extensions;
using ProgettoCinema.API.Repository;
using ProgettoCinema.Domain;

namespace ProgettoCinema.API.Controllers;
public class SpettatoreController : Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GenericRepository<Spettatore> _spettatoreRepository;

        public UserController(GenericRepository<Spettatore> spettatoreRepository)
        {
            _spettatoreRepository = spettatoreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string expand = "", string filter = "")
        {
            try
            {
                var filterQuery = filter.GetFilterQuery<Spettatore>();
                var user = await _spettatoreRepository.Get(includeProperties: expand, filter: filterQuery);
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
                var user = await _spettatoreRepository.GetById(id, includeProperties: expand);
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
        public async Task<IActionResult> Post([FromBody] Spettatore spettatore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await _spettatoreRepository.Create(spettatore);
                return Ok(created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromBody] Spettatore spettatore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _spettatoreRepository.Update(spettatore);
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
                await _spettatoreRepository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
