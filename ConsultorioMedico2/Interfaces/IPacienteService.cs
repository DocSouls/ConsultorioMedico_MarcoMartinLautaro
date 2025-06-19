using System.Collections.Generic;
using ConsultorioMedico2.Models;
using ConsultorioMedico2.Services;

namespace ConsultorioMedico2.Interfaces
{
    public interface IPacienteService
    {
        IEnumerable<Paciente> GetAll();
        Paciente Add(Paciente paciente);
        Paciente Update(int id, Paciente pacienteActualizado);
        bool Delete(int id);
    }
}
