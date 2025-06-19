namespace ConsultorioMedico2.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }


        public Paciente(int id, string nombre, string email)
        {
            Id = id;
            Nombre = nombre;
            Email = email;

        }
    }
}
