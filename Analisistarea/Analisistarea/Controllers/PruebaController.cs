
using Microsoft.AspNetCore.Mvc;

namespace Analistarea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PruebaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                mensaje = "API funcionando correctamente",
                tarea = "Despliegue de Web API en Render",
                lenguaje = "C#",
                framework = "ASP.NET Core Web API",
                estado = "Activa"
            });
        }
    }
}