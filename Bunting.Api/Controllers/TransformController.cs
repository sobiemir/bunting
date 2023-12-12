using Microsoft.AspNetCore.Mvc;

namespace Bunting.Api.Controllers
{
    [ApiController]
    [Route("transform")]
    public class TransformController
    {
        [HttpGet]
        public Task GetVersion()
        {
            return Task.CompletedTask;
        }

        [HttpGet("available")]
        public Task GetAvailable()
        {
            return Task.CompletedTask;
        }

        [HttpPost]
        public Task RunTransform()
        {
            return Task.CompletedTask;
        }

        [HttpPost("valid")]
        public Task IsTransformValid()
        {
            return Task.CompletedTask;
        }
    }
}
