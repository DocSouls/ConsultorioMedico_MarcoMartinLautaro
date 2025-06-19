using System.Collections.Generic;
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static ConsultorioMedico2.Services.TurnosService;
using ConsultorioMedico2.Models;
using ConsultorioMedico2.Interfaces;
using ConsultorioMedico2.Repositorio;
using ConsultorioMedico2.Data;


namespace ConsultorioMedico2.Services
{
    public class TurnosService : ITurnosService
    {
        private readonly ConsultorioDBcontext _context;

        public TurnosService(ConsultorioDBcontext context)
        {
            _context = context;
        }

        public IEnumerable<Turnos> GetAll()
        {
            return _context.Turnos.ToList();
        }

        public Turnos Add(Turnos turnos)
        {
            _context.Turnos.Add(turnos);
            _context.SaveChanges();
            return turnos;
        }

        public Turnos? Update(int id, Turnos turnoActualizado)
        {
            var turnoExistente = _context.Turnos.FirstOrDefault(t => t.Id == id);
            if (turnoExistente == null)
                return null;

            turnoExistente.Nombre = turnoActualizado.Nombre;
            turnoExistente.Fecha = turnoActualizado.Fecha;

            _context.SaveChanges();
            return turnoExistente;
        }

        public bool Delete(int id)
        {
            var turno = _context.Turnos.FirstOrDefault(t => t.Id == id);
            if (turno == null)
                return false;

            _context.Turnos.Remove(turno);
            _context.SaveChanges();
            return true;
        }

        public Turnos Update(Turnos turno)
        {
            throw new NotImplementedException();
        }
    }
}
