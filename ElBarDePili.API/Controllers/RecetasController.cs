using Microsoft.AspNetCore.Mvc;
using ElBarDePili.DataBase;
using Microsoft.EntityFrameworkCore;

namespace ElBarDePili.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecetasController : Controller
    {
        private readonly ElbardepiliContext _dbContext;
        public RecetasController(ElbardepiliContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetRecetas")]
        public async Task<IActionResult> GetRecetas()
        {
            List<Receta> recetas = await _dbContext.Recetas.ToListAsync();

            if (recetas != null) return Ok(recetas);
            else return BadRequest("No se han obtenido recetas.");
        }

        [HttpPost]
        [Route("AddReceta")]
        public async Task<IActionResult> AddReceta([FromBody] Receta? receta)
        {
            if (receta == null) return BadRequest("No se ha proporcionado ninguna receta a añadir.");

            List<Receta> recetas = await _dbContext.Recetas.ToListAsync();
            if (recetas != null && recetas.Any(x => x.Id.Equals(receta.Id))) return BadRequest("La receta que intentas añadir ya existe.");

            await _dbContext.Recetas.AddAsync(receta);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("UpdateReceta")]
        public async Task<IActionResult> UpdateReceta([FromBody] Receta? receta)
        {
            if (receta == null) return BadRequest("No se ha proporcionado ninguna receta a actualizar.");
            
            List<Receta> recetas = await _dbContext.Recetas.ToListAsync();
            if (recetas == null || !recetas.Any(x => x.Id.Equals(receta.Id))) return BadRequest("La receta que intentas actualizar no existe.");
            
            _dbContext.Recetas.Update(receta);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("DeleteReceta")]
        public async Task<IActionResult> DeleteReceta([FromBody] Guid? id)
        {
            if (id == null) return BadRequest("No se ha proporcionado ningún identificador de receta a eliminar.");
            
            List<Receta> recetas = await _dbContext.Recetas.ToListAsync();
            if (recetas == null || !recetas.Any(x => x.Id.Equals(id))) return BadRequest("La receta que intentas eliminar no existe.");
            
            Receta receta = recetas.First(x => x.Id.Equals(id));
            _dbContext.Recetas.Remove(receta);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("GetRecetaIngredientes")]
        public async Task<IActionResult> GetRecetaIngredientes([FromBody] Guid? id)
        {
            if (id == null) return BadRequest("No se ha proporcionado ningún identificador de receta para obtener sus ingredientes.");

            List<RecetasIngredientes> recetasIngredientes = await _dbContext.RecetasIngredientes
                .Include(c => c.IdingredienteNavigation).ThenInclude(ci => ci.RecetasIngredientes).ToListAsync();
            if (recetasIngredientes == null || !recetasIngredientes.Any(x => x.Idreceta.Equals(id))) return BadRequest("La receta que intentas obtener no tiene ingredientes.");

            List<Ingrediente> recetaIngredientes = recetasIngredientes.Where(x => x.Idreceta.Equals(id)).Select(x => x.IdingredienteNavigation).ToList();
            return Ok(recetaIngredientes);
        }

        [HttpPost]
        [Route("AddRecetaIngrediente")]
        public async Task<IActionResult> AddRecetaIngrediente([FromBody] RecetasIngredientes? recetasIngrediente)
        {
           if (recetasIngrediente == null) return BadRequest("No se ha proporcionado ningún ingrediente a añadir a la receta.");

            List<RecetasIngredientes> recetasIngredientes = await _dbContext.RecetasIngredientes.ToListAsync();
            if (recetasIngredientes != null && recetasIngredientes.Any(x => x.Id.Equals(recetasIngrediente.Id))) return BadRequest("El ingrediente que intentas añadir a la receta ya existe.");
            
            await _dbContext.RecetasIngredientes.AddAsync(recetasIngrediente);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("DeleteRecetaIngrediente")]
        public async Task<IActionResult> DeleteRecetaIngrediente([FromBody] Guid? id)
        {
            if (id == null) return BadRequest("No se ha proporcionado ningún identificador de receta-ingrediente.");

            List<RecetasIngredientes> recetasIngredientes = await _dbContext.RecetasIngredientes.ToListAsync();
            if (recetasIngredientes == null || !recetasIngredientes.Any(x => x.Id.Equals(id))) return BadRequest("El ingrediente que intentas eliminar de la receta no existe.");

            RecetasIngredientes recetaIngrediente = recetasIngredientes.First(x => x.Id.Equals(id));
            _dbContext.RecetasIngredientes.Remove(recetaIngrediente);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
