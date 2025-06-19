using System.Collections.Generic;
using System.Diagnostics.Contracts;
using ConsultorioMedico2.Models;
using ConsultorioMedico2.Interfaces;
using ConsultorioMedico2.Repositorio;
using ConsultorioMedico2.Data;

namespace ConsultorioMedico2.Services
{
    public class DoctoresService : IDoctoresService
    {
        private readonly ConsultorioDBcontext _context;

        public DoctoresService(ConsultorioDBcontext context)
        {
            _context = context;
        }

        public IEnumerable<Doctores> GetAll()
        {
            return _context.Doctores.ToList();
        }

        public Doctores Add(Doctores profesional)
        {
            _context.Doctores.Add(profesional);
            _context.SaveChanges();
            return profesional;
        }

        public Doctores? Update(int id, Doctores doctoresActualizado)
        {
            var doctoresExistente = _context.Doctores.FirstOrDefault(p => p.Id == id);
            if (doctoresExistente == null)
                return null;

            doctoresExistente.Nombre = doctoresActualizado.Nombre;
            doctoresExistente.Especialidad = doctoresActualizado.Especialidad;

            _context.SaveChanges();
            return doctoresExistente;
        }

        public bool Delete(int id)
        {
            var doctores = _context.Doctores.FirstOrDefault(p => p.Id == id);
            if (doctores == null)
                return false;

            _context.Doctores.Remove(doctores);
            _context.SaveChanges();
            return true;
        }

    }
}
