using JobRestService.Manager;
using JobRestService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobRestService.Controllers
{
    [Route("api/jobscheduler")]
    [ApiController]
    public class JobScheduler : ControllerBase
    {
        IJobManager manager;

        public JobScheduler(IJobManager _manager)
        {
            manager = _manager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Job job)
        {
            var IncMsg =  await manager.StoreMessage(job);

            await manager.PublishMessage(job);

            return Ok(IncMsg);
        }
    }
}
