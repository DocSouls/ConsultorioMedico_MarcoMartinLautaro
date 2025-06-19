namespace ConsultorioMedico2.Models
{
    public class Turnos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }

        public Turnos(int id, string nombre, DateTime fecha)
        {
            Id = id;
            Nombre = nombre;
            Fecha = fecha;

        }
    }
}
