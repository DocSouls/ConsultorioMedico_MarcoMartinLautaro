using System;
using System.Collections.Generic;
using ConsultorioMedico2.Models;

namespace ConsultorioMedico2.Repositorio
{
    public static class RepositorioMedico
    {
        public static List<Doctores> Doctores = new List<Doctores>()
        {
            new Doctores (1,"Doctor", "Especialidad")
        };


        public static List<Paciente> Pacientes = new List<Paciente>()
        {
            new Paciente(1, "Paciente", "Gmail" )
        };


        public static List<Turnos> Turnos = new List<Turnos>()
        {
            new Turnos (1,"Nombre", DateTime.Now.AddHours(1) )

        };

    }
}
