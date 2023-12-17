using Bunting.Abstractions.File;
using Bunting.Api.Convert.Run;
using Bunting.Conversion.Conversion;
using Microsoft.AspNetCore.Mvc;

namespace Bunting.Api.Controllers
{
    [ApiController]
    [Route("convert")]
    public sealed class ConvertController(IConversionFactory factory)
        : ControllerBase
    {
        private readonly IConversionFactory _factory = factory;

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
        public async Task RunAsync([FromForm] ConvertRunRequest request, CancellationToken cancellationToken)
        {
            var sourceExtension = FileExtension.ByMediaType(request.File.ContentType);
            var targetExtension = FileExtension.ByMediaType(request.TargetMediaType);

            using var stream = request.File.OpenReadStream();

            var engine = await _factory.CreateEngineAsync(
                stream,
                sourceExtension,
                targetExtension,
                request.Options,
                cancellationToken);

            await engine.ConvertAsync(cancellationToken);

            Ok();
        }

        [HttpPost("valid")]
        public Task IsTransformValid()
        {
            return Task.CompletedTask;
        }
    }
}
