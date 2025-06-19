using Microsoft.EntityFrameworkCore;
using ConsultorioMedico2.Models;

namespace ConsultorioMedico2.Data
{
    public class ConsultorioDBcontext : DbContext
    {
        public ConsultorioDBcontext (DbContextOptions<ConsultorioDBcontext> options) : base(options) { }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Doctores> Doctores { get; set; }

        public DbSet<Turnos> Turnos { get; set; }
    }
}
