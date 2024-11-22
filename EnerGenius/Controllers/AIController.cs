using EnerGenius.Services;
using EnerGenius.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnerGenius.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        readonly IGenerativeAIService _generativeAIService;

        public AIController(IGenerativeAIService generativeAIService)
        {
            _generativeAIService = generativeAIService;
        }

        [HttpPost("generate-text")]
        public async Task<IActionResult> GenerateText([FromBody] string prompt)
        {
            var response = await _generativeAIService.GenerateText(prompt);
            return Ok(response);
        }
    }
}
