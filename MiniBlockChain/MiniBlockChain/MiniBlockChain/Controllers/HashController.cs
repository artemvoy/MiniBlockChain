using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace MiniBlockChain.Controllers
{
        [ApiController]
        [Route("api/hash")]
    public class HashController : Controller
    {
            private readonly HashService _hash;

            public HashController(HashService hash)
            {
                _hash = hash;
            }

            [HttpPost]
            public IActionResult CreateHash([FromBody] string text)
            {
                var hash = _hash.CreateHash(text);
                return Ok(new { hash });
            }
        }
}
