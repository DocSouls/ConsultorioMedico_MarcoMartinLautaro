using static System.Runtime.InteropServices.JavaScript.JSType;
using ConsultorioMedico2.Models;
using ConsultorioMedico2.Interfaces;
using ConsultorioMedico2.Services;

namespace ConsultorioMedico2.Interfaces
{
    public interface ITurnosService
    {
        IEnumerable<Turnos> GetAll();
        Turnos Add(Turnos turno);
        Turnos Update(Turnos turno);
        bool Delete(int id);


    }
}
