using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Listado.API.Models;

namespace Listado.API.Controllers{
  [ApiController]
  [Route("api/[controller]")]
  public class NombresController : ControllerBase{
    /*
    private static readonly string[] NombresBase = new []{
      "Carlos", "Ana", "Luis", "Maria", "Juan", "Lucía", "Pedro", "Laura", "Miguel", "Carmen", "Santiago",
      "Andrés", "Camila", "Sofía", "Daniel", "Valentina", "Esteban", "Isabella", "Mateo", "Alexander", "Benny"
    };

    [HttpGet]
    public IActionResult Get(){
      var random = new Random();
      var nombresAleatorios = NombresBase
        .OrderBy(x => random.Next())
        .Take(10)
        .ToList();
      
      return Ok(nombresAleatorios);
    }
    */
    private readonly AppDbContext _context;
    public NombresController(AppDbContext context){
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<string>>> GetNombres(){
      return await _context.Personas
        .Select(x => x.FullName)
        .ToListAsync();
    }
  }
}