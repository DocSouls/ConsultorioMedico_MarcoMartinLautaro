using Microsoft.AspNetCore.Mvc;
using ConsultorioMedico2.Models;
using ConsultorioMedico2.Interfaces;
using ConsultorioMedico2.Repositorio;

namespace ConsultorioMedico2.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class DoctoresController : ControllerBase
    {
        private readonly IDoctoresService _doctoresService;

        public DoctoresController(IDoctoresService doctoresService)
        {
            _doctoresService = doctoresService;
        }

        [HttpGet]

        public IEnumerable<Doctores> GetDoctores() => _doctoresService.GetAll();

        [HttpPost]

        public Doctores AddDoctores([FromBody] Doctores doctores) => _doctoresService.Add(doctores);


        [HttpPut("{id}")]
        public IActionResult UpdateDoctores(int id, [FromBody] Doctores doctores)
        {
            if (id != doctores.Id)
            {
                return BadRequest("El ID no coincide con el Doctores.");
            }

            var updated = _doctoresService.Update(id, doctores);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctores(int id)
        {
            var deleted = _doctoresService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
