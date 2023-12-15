using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.Media;
using Bunting.Api.Convert.Run;
using Bunting.Conversion.Conversion;
using Microsoft.AspNetCore.Mvc;

namespace Bunting.Api.Controllers
{
    [ApiController]
    [Route("convert")]
    public sealed class ConvertController
    {
        private readonly IConversionFactory _factory;

        public ConvertController(IConversionFactory factory)
        {
            _factory = factory;
        }

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
            var sourceMediaType = MediaFormat.Of(request.File.ContentType);
            var targetMediaType = MediaFormat.Of(request.TargetMediaType);

            var format = new ConversionFormat(sourceMediaType, targetMediaType);

            using var stream = request.File.OpenReadStream();

            var engine = await _factory.CreateEngineAsync(stream, format, request.Options, cancellationToken);

            await engine.ConvertAsync(cancellationToken);
        }

        [HttpPost("valid")]
        public Task IsTransformValid()
        {
            return Task.CompletedTask;
        }
    }
}
