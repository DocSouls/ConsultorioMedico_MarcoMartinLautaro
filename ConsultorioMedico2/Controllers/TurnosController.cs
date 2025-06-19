using ConsultorioMedico2.Models;
using Microsoft.AspNetCore.Mvc;
using ConsultorioMedico2.Interfaces;
using ConsultorioMedico2.Services;

namespace ConsultorioMedico2.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnosService _turnosservices;

        public TurnosController(ITurnosService turnosservices)
        {
            _turnosservices = turnosservices;
        }

        [HttpGet]

        public IEnumerable<Turnos> GetTurnos() => _turnosservices.GetAll();

        [HttpPost]

        public Turnos AddTurnos([FromBody] Turnos turnos) => _turnosservices.Add(turnos);

        [HttpDelete("{id}")]
        public IActionResult DeleteTurnos(int id)
        {
            var deleted = _turnosservices.Delete(id);

            if (deleted)
                return NoContent();

            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePC(int id, [FromBody] Turnos turnos)
        {
            if (id != turnos.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del cuerpo.");
            }

            var updated = _turnosservices.Update(turnos);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }
    }
}
