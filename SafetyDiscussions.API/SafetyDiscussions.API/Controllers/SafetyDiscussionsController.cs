using Microsoft.AspNetCore.Mvc;
using SafetyDiscussions.Services.DTO;
using SafetyDiscussions.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SafetyDiscussions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SafetyDiscussionsController : ControllerBase
    {
        private readonly ISafetyDiscussionsService safetyDiscussionsService;
        public SafetyDiscussionsController(ISafetyDiscussionsService safetyDiscussionsService)
        {
            this.safetyDiscussionsService = safetyDiscussionsService;
        }

        // GET: api/<SafetyDiscussionsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listOfSDs = await safetyDiscussionsService.GetAll();
            return Ok(listOfSDs);
        }

        // GET api/<SafetyDiscussionsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var safetyDiscussion = await safetyDiscussionsService.GetById(id);

            if(safetyDiscussion != null)
            {
                return Ok(safetyDiscussion);
            }

            return NotFound();
        }

        // POST api/<SafetyDiscussionsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SafetyDiscussionDTO value)
        {
            await safetyDiscussionsService.CreateOrUpdate(value);
            return Ok();
        }

        // DELETE api/<SafetyDiscussionsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await safetyDiscussionsService.DeleteById(id);
            return Ok();
        }
    }
}
