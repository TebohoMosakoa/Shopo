using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using SystemAPI.Models;
using SystemAPI.Repositories;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        public readonly ISettingsRepository _repository;

        public SettingsController(ISettingsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));    
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Settings>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Settings>> GetSettings() 
        { 
            var settings = await _repository.GetSettingsAsync();
            return settings;
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Settings), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Settings>> GetSettings(string id)
        {
            var settings = await _repository.GetSettingsAsync(id);
            if(settings == null)
            {
                return NotFound();
            }
            return Ok(settings);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Settings), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Settings>> CreateSettings([FromBody] Settings settings)
        {
            await _repository.createSettings(settings);
            
            return Ok(settings);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Settings), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Settings>> UpdateSettings([FromBody] Settings settings)
        {
            return Ok(await _repository.updateSettings(settings));
        }

        [HttpDelete("id")]
        [ProducesResponseType(typeof(Settings), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Settings>> DeleteSettings(String Id)
        {
            return Ok(await _repository.deleteSettings(Id));
        }
    }
}
