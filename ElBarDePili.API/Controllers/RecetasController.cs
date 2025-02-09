using Microsoft.AspNetCore.Mvc;
using ElBarDePili.DataBase;
using Microsoft.EntityFrameworkCore;

namespace ElBarDePili.API.Controllers
{
    [ApiController]
    public class RecetasController : Controller
    {
        private readonly ElbardepiliContext _dbContext;
        public RecetasController(ElbardepiliContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region GET

        [HttpGet]
        [Route("Recetas")]
        public async Task<IActionResult> GetRecetas()
        {
            List<Recetas> recetas = await _dbContext.Recetas.ToListAsync();

            if (recetas != null) return Ok(recetas);
            else return BadRequest("No se han obtenido recetas.");
        }

        [HttpGet]
        [Route("Receta/{id}")]
        public async Task<IActionResult> GetReceta(Guid? id)
        {
            if (id == null) return BadRequest("No se ha proporcionado ningún identificador de receta.");
            
            Recetas? receta = await _dbContext.Recetas.FirstOrDefaultAsync(x => x.Id.Equals(id));
            
            if (receta != null) return Ok(receta);
            else return NotFound("No se ha encontrado ninguna receta con el identificador proporcionado.");
        }

        #endregion

        #region POST

        [HttpPost]
        [Route("Receta")]
        public async Task<IActionResult> AddReceta([FromBody] Recetas? receta)
        {
            if (receta == null) return BadRequest("No se ha proporcionado ninguna receta a añadir.");

            if (await _dbContext.Recetas.AnyAsync(x => x.Id.Equals(receta.Id))) return BadRequest("La receta que intentas añadir ya existe.");

            await _dbContext.Recetas.AddAsync(receta);
            await _dbContext.SaveChangesAsync();

            return Ok(receta);
        }

        #endregion

        #region PUT

        [HttpPut]
        [Route("Receta/{id}")]
        public async Task<IActionResult> UpdateReceta(Guid? id, [FromBody] Recetas? receta)
        {
            if (id == null || receta == null) return BadRequest("No se ha proporcionado ningún ID o receta a actualizar.");
            
            Recetas? recetaAActualizar = await _dbContext.Recetas.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (recetaAActualizar == null) return NotFound("La receta que intentas actualizar no existe.");

            recetaAActualizar.Nombre = receta.Nombre;
            recetaAActualizar.Descripcion = receta.Descripcion;
            recetaAActualizar.Imagen = receta.Imagen;
            recetaAActualizar.Duracion = receta.Duracion;
            recetaAActualizar.Dificultad = receta.Dificultad;

            _dbContext.Recetas.Update(receta);
            await _dbContext.SaveChangesAsync();

            return Ok(recetaAActualizar);
        }

        #endregion

        #region DELETE

        [HttpDelete]
        [Route("Receta/{id}")]
        public async Task<IActionResult> DeleteReceta(Guid? id)
        {
            if (id == null) return BadRequest("No se ha proporcionado ningún identificador de receta a eliminar.");
            
            Recetas? receta = await _dbContext.Recetas.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (receta == null) return NotFound("La receta que intentas eliminar no existe.");
            
            _dbContext.Recetas.Remove(receta);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        #endregion
    }
}
