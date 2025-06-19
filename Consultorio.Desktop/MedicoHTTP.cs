using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ConsultorioMedico2.Models;
using ConsultorioMedico2.Interfaces;
using ConsultorioMedico2.Services;

namespace Consultorio.Desktop
{
    public class ConsultorioHttp
    {
        private readonly HttpClient client;

        public ConsultorioHttp()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7049/api/SistemaRegistro/")
            };
        }

        // GET
        public async Task<List<Paciente>> ObtenerUsuariosAsync()
        {
            return await client.GetFromJsonAsync<List<Paciente>>("") ?? new List<Paciente>();
        }

        // POST
        public async Task<HttpResponseMessage> CrearPacienteAsync(Paciente paciente)
        {
            return await client.PostAsJsonAsync("", paciente);
        }

        // PUT
        public async Task<HttpResponseMessage> ActualizarUsuarioAsync(int id, Paciente paciente)
        {
            return await client.PutAsJsonAsync($"{id}", paciente);
        }

        // DELETE
        public async Task<HttpResponseMessage> EliminarPacienteAsync(int id)
        {
            return await client.DeleteAsync($"{id}");
        }


    }
}
