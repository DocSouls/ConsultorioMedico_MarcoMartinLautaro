using System.Collections.Generic;
using System.Collections.Generic;
using ConsultorioMedico2.Models;

namespace ConsultorioMedico2.Interfaces
{
    public interface IDoctoresService
    {
        IEnumerable<Doctores> GetAll();
        Doctores Add(Doctores doctores);
        Doctores? Update(int id, Doctores doctoresActualizado);
        bool Delete(int id);
    }
}
