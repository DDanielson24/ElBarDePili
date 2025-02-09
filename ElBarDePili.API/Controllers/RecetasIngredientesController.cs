using ElBarDePili.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElBarDePili.API.Controllers
{
    [ApiController]
    public class RecetasIngredientesController : ControllerBase
    {
        private readonly ElbardepiliContext _dbContext;
        public RecetasIngredientesController(ElbardepiliContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region POST

        [HttpPost]
        [Route("RecetaIngrediente")]
        public async Task<IActionResult> PostRecetaIngrediente([FromBody] RecetasIngredientes? recetaIngrediente)
        {
            if (recetaIngrediente == null) return BadRequest("No se ha proporcionado ningún ingrediente a añadir a la receta.");
            
            if (await _dbContext.RecetasIngredientes.AnyAsync(x => x.Id.Equals(recetaIngrediente.Id))) return BadRequest("El ingrediente que intentas añadir a la receta ya existe.");
            
            await _dbContext.RecetasIngredientes.AddAsync(recetaIngrediente);
            await _dbContext.SaveChangesAsync();
            
            return Ok(recetaIngrediente);
        }

        #endregion

        #region DELETE

        [HttpDelete]
        [Route("RecetaIngrediente/{id}")]
        public async Task<IActionResult> DeleteRecetaIngrediente(Guid? id)
        {
            if (id == null) return BadRequest("No se ha proporcionado ningún id de ingrediente a eliminar.");

            var recetaIngrediente = await _dbContext.RecetasIngredientes.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (recetaIngrediente == null) return NotFound("El ingrediente que intentas eliminar no existe.");

            _dbContext.RecetasIngredientes.Remove(recetaIngrediente);
            await _dbContext.SaveChangesAsync();

            return Ok(recetaIngrediente);
        }

        #endregion
    }
}
