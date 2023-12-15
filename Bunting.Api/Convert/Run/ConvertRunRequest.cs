using System.ComponentModel.DataAnnotations;
using Bunting.Abstractions.Common;
using Bunting.Api.Misc;
using Microsoft.AspNetCore.Mvc;

namespace Bunting.Api.Convert.Run
{
    public sealed record ConvertRunRequest
    {
        [Required]
        [FromForm(Name = "file")]
        public IFormFile File { get; init; } = default!;

        [Required]
        [FromForm(Name = "targetMediaType")]
        public string TargetMediaType { get; init; } = string.Empty;

        [BindRemaining]
        public ConversionOptionsDictionary Options { get; init; } = [];
    }
}
