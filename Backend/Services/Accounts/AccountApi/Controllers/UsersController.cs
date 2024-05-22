using AccountApi.DTOs;
using AccountApi.Models;
using AccountApi.Parameters;
using AccountApi.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QueryStringParameters parameters)
        {
            List<AppUser> results = new List<AppUser>();
            try
            {
                var entities = await _repo.GetAll(parameters);

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(entities.MeteData));

                results = entities;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(results);
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(String id)
        {
            var item = _repo.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            var user = _mapper.Map<ProfileDto>(item);

            return Ok(user);
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(String id, [FromBody] ProfileDto entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            var user = _repo.Get(id);
            user.Name = entity.Name;
            user.Surname = entity.Surname;
            user.Email = entity.Email;
            await _repo.Update(user);
            return NoContent();
        }


        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(String id)
        {
            var item = _repo.Get(id);
            if (item == null)
                return NotFound();

            await _repo.Delete(item.Id);

            return NoContent();
        }
    }
}
