namespace ConsultorioMedico2.Models
{
    public class Doctores
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Especialidad { get; set; }


        public Doctores(int id, string nombre, string especialidad)
        {
            Id = id;
            Nombre = nombre;
            Especialidad = especialidad;

        }

    }
}
