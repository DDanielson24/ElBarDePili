using Microsoft.AspNetCore.Mvc;

namespace ElBarDePili.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolaMundoController : Controller
    {
        [HttpGet]
        [Route("HolaMundo")]
        public IActionResult HolaMundo()
        {
            return Ok();
        }
    }
}
