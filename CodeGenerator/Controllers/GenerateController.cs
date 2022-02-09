using CodeGenerator.ResourceParameters;
using CodeGenerator.Services;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet(Name = "Get")]
        [MapToApiVersion("1.0")]
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
