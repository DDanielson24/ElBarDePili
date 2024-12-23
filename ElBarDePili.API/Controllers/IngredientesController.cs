using ElBarDePili.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElBarDePili.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientesController : Controller
    {
        private readonly ElbardepiliContext _dbContext;
        public IngredientesController(ElbardepiliContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetIngredientes")]
        public async Task<IActionResult> GetIngredientes()
        {
            List<Ingredientes> ingredientes = await _dbContext.Ingredientes.ToListAsync();

            if (ingredientes != null) return Ok(ingredientes);
            else return BadRequest("No se han obtenido ingredientes.");
        }

        [HttpPost]
        [Route("AddIngrediente")]
        public async Task<IActionResult> AddIngrediente([FromBody] Ingredientes? ingrediente)
        {
            if (ingrediente == null) return BadRequest("No se ha proporcionado ningún ingrediente a añadir.");

            List<Ingredientes> ingredientes = await _dbContext.Ingredientes.ToListAsync();
            if (ingredientes != null && ingredientes.Any(x => x.Id.Equals(ingrediente.Id))) return BadRequest("El ingrediente que intentas añadir ya existe.");

            await _dbContext.Ingredientes.AddAsync(ingrediente);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("UpdateIngrediente")]
        public async Task<IActionResult> UpdateIngrediente([FromBody] Ingredientes? ingrediente)
        {
            if (ingrediente == null) return BadRequest("No se ha proporcionado ningún ingrediente a actualizar.");

            List<Ingredientes> ingredientes = await _dbContext.Ingredientes.ToListAsync();
            if (ingredientes == null || !ingredientes.Any(x => x.Id.Equals(ingrediente.Id))) return BadRequest("El ingrediente que intentas actualizar no existe.");

            _dbContext.Ingredientes.Update(ingrediente);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("DeleteIngrediente")]
        public async Task<IActionResult> DeleteIngrediente([FromBody] Guid? id)
        {
            if (id == null) return BadRequest("No se ha proporcionado ningún identificador de ingrediente a eliminar.");

            List<Ingredientes> ingredientes = await _dbContext.Ingredientes.ToListAsync();
            if (ingredientes == null || !ingredientes.Any(x => x.Id.Equals(id))) return BadRequest("El ingrediente que intentas eliminar no existe.");

            Ingredientes ingrediente = ingredientes.First(x => x.Id.Equals(id));
            _dbContext.Ingredientes.Remove(ingrediente);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
