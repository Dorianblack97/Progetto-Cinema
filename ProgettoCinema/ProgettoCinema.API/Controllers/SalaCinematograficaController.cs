using Microsoft.AspNetCore.Mvc;
using ProgettoCinema.API.Extensions;
using ProgettoCinema.API.Repository;
using ProgettoCinema.Domain;

namespace ProgettoCinema.API.Controllers;
public class SalaCinematograficaController : Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GenericRepository<SalaCinematografica> _salaCinematograficaRepository;

        public UserController(GenericRepository<SalaCinematografica> salaCinematograficaRepository)
        {
            _salaCinematograficaRepository = salaCinematograficaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string expand = "", string filter = "")
        {
            try
            {
                var filterQuery = filter.GetFilterQuery<SalaCinematografica>();
                var user = await _salaCinematograficaRepository.Get(includeProperties: expand, filter: filterQuery);
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
                var user = await _salaCinematograficaRepository.GetById(id, includeProperties: expand);
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
        public async Task<IActionResult> Post([FromBody] SalaCinematografica salaCinematografica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var created = await _salaCinematograficaRepository.Create(salaCinematografica);
                return Ok(created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromBody] SalaCinematografica salaCinematografica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _salaCinematograficaRepository.Update(salaCinematografica);
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
                await _salaCinematograficaRepository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
