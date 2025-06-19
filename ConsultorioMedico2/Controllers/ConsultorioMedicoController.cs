using Microsoft.AspNetCore.Mvc;
using ConsultorioMedico2.Models;
using ConsultorioMedico2.Interfaces;
using ConsultorioMedico2.Repositorio;


namespace ConsultorioMedico2.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ConsultorioMedicoController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public ConsultorioMedicoController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]

        public IEnumerable<Paciente> GetUsuario() => _pacienteService.GetAll();

        [HttpPost]

        public Paciente AddPaciente([FromBody] Paciente paciente) => _pacienteService.Add(paciente);

        [HttpPut("{id}")]
        public IActionResult UpdatePaciente(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest("El ID no coincide con el Paciente.");
            }

            var updated = _pacienteService.Update(id, paciente);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePaciente(int id)
        {
            var deleted = _pacienteService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
