using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using ConsultorioMedico2.Models;
using ConsultorioMedico2.Interfaces;
using ConsultorioMedico2.Repositorio;
using ConsultorioMedico2.Data;

namespace ConsultorioMedico2.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly ConsultorioDBcontext _context;

        public PacienteService(ConsultorioDBcontext context)
        {
            _context = context;
        }

        public IEnumerable<Paciente> GetAll()
        {
            return _context.Paciente.ToList();
        }

        public Paciente Add(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            _context.SaveChanges();
            return paciente;
        }

        public Paciente? Update(int id, Paciente pacienteActualizado)
        {
            var pacienteExistente = _context.Paciente.FirstOrDefault(a => a.Id == id);
            if (pacienteExistente == null)
                return null;

            pacienteExistente.Nombre = pacienteActualizado.Nombre;
            pacienteExistente.Email = pacienteActualizado.Email;

            _context.SaveChanges();
            return pacienteExistente;
        }

        public bool Delete(int id)
        {
            var paciente = _context.Paciente.FirstOrDefault(a => a.Id == id);
            if (paciente == null)
                return false;

            _context.Paciente.Remove(paciente);
            _context.SaveChanges();
            return true;
        }

    }
}
