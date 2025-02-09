using ElBarDePili.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElBarDePili.API.Controllers
{
    [ApiController]
    public class IngredientesController : Controller
    {
        private readonly ElbardepiliContext _dbContext;
        public IngredientesController(ElbardepiliContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region GET

        [HttpGet]
        [Route("Ingredientes")]
        public async Task<IActionResult> GetIngredientes()
        {
            List<Ingredientes> ingredientes = await _dbContext.Ingredientes.ToListAsync();

            if (ingredientes != null) return Ok(ingredientes);
            else return BadRequest("No se han obtenido ingredientes.");
        }

        [HttpGet]
        [Route("Ingrediente/{id}")]
        public async Task<IActionResult> GetIngrediente(Guid? id)
        {
            if (id == null) return BadRequest("No se ha proporcionado ningún identificador de ingrediente.");

            Ingredientes? ingrediente = await _dbContext.Ingredientes.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (ingrediente != null) return Ok(ingrediente);
            else return NotFound("No se ha encontrado ningún ingrediente con el identificador proporcionado.");
        }

        #endregion

        #region POST

        [HttpPost]
        [Route("Ingrediente")]
        public async Task<IActionResult> PostIngrediente([FromBody] Ingredientes? ingrediente)
        {
            if (ingrediente == null) return BadRequest("No se ha proporcionado ningún ingrediente a añadir.");
            
            if (await _dbContext.Ingredientes.AnyAsync(x => x.Id.Equals(ingrediente.Id))) return BadRequest("El ingrediente que intentas añadir ya existe.");

            await _dbContext.Ingredientes.AddAsync(ingrediente);
            await _dbContext.SaveChangesAsync();

            return Ok(ingrediente);
        }

        #endregion

        #region PUT

        [HttpPut]
        [Route("Ingrediente/{id}")]
        public async Task<IActionResult> PutIngrediente(Guid? id, [FromBody] Ingredientes? ingrediente)
        {
            if (id == null || ingrediente == null) return BadRequest("No se ha proporcionado ningún ID o ingrediente a actualizar.");

            Ingredientes? ingredienteAActualizar = await _dbContext.Ingredientes.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (ingredienteAActualizar == null) return NotFound("El ingrediente que intentas actualizar no existe.");

            ingredienteAActualizar.Nombre = ingrediente.Nombre;
            ingredienteAActualizar.Disponibilidad = ingrediente.Disponibilidad;

            _dbContext.Ingredientes.Update(ingredienteAActualizar);
            await _dbContext.SaveChangesAsync();

            return Ok(ingredienteAActualizar);
        }

        #endregion

        #region DELETE

        [HttpDelete]
        [Route("Ingrediente/{id}")]
        public async Task<IActionResult> DeleteIngrediente(Guid? id)
        {
            if (id == null) return BadRequest("No se ha proporcionado ningún identificador de ingrediente a eliminar.");

            Ingredientes? ingrediente = await _dbContext.Ingredientes.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (ingrediente == null) return NotFound("El ingrediente que intentas eliminar no existe.");

            _dbContext.Ingredientes.Remove(ingrediente);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        #endregion
    }
}
