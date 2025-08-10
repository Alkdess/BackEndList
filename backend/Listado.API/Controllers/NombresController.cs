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
    public async Task<ActionResult<IEnumerable<Personas>>> GetNombres(){
      var data = await _context.Personas
        .Select(p => new Personas{
          Id = p.Id,
          FullName = p.FullName,
          Address = p.Address,
          Update_Date = p.Update_Date
        })
        .ToListAsync();
      return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult> PostRegistro(Personas persona){
      var entidad = new Personas{
        FullName = persona.FullName,
        Address = persona.Address,
        Update_Date = DateTime.Now
      };

      _context.Personas.Add(entidad);
      await _context.SaveChangesAsync();
      return Ok();
    }
  }
}