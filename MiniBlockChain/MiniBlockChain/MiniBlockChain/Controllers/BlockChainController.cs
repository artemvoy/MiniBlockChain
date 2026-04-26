using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace MiniBlockChain.Controllers
{
    [ApiController]
    [Route("api/blockchain")]
    public class BlockchainController : ControllerBase
    {
        private readonly BlockchainService _service;

        public BlockchainController(BlockchainService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] string document)
        {
            var block = await _service.AddBlock(document);
            return Ok(block);
        }

        [HttpGet("validate")]
        public async Task<IActionResult> Validate()
        {
            var result = await _service.ValidateChain();
            return Ok(new { isValid = result });
        }
    }
}
