using CodeGenerator.ResourceParameters;
using CodeGenerator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Versioning;
using Tyrrrz.Extensions;
using ZXing;

namespace CodeGenerator.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class GenerateController : ControllerBase
    {
        private readonly IGeneratorService _generator;
        private readonly ILogger _logger;

        public GenerateController(IGeneratorService generator, ILogger<GenerateController> logger)
        {
            _generator = generator;
            _logger = logger;
        }

        /// <summary>
        /// Generate and return requested code as PNG image.
        /// </summary>
        /// <returns>Generated code as PNG image.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns code as png</response>
        /// <response code="400">If parameters validation failed or something went wrong during generation.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet(Name = "Get")]
        [MapToApiVersion("1.0")]
        [SupportedOSPlatform("windows")]
        public IActionResult Get([FromQuery] GenerateResourceParameters request)
        {
            Byte[] byteArray;

            try
            {
                using (var ms = new MemoryStream())
                {
                    var bitmap = _generator.Generate(request);
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byteArray = ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return File(byteArray, "image/png");
        }
    }
}
