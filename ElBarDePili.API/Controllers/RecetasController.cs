using Microsoft.AspNetCore.Mvc;
using ElBarDePili.DataBase;

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
        public IEnumerable<Receta> GetRecetas()
        {
            var recetas = _dbContext.Recetas.ToList();
            return recetas;
        }
    }
}
