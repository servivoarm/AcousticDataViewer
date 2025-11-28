using PF_VNR.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PF_VNR.Forms.Service
{
    internal class ApiClient
    {
        private readonly string _baseUrl;

        public ApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        private async Task<T> GetAsync<T>(string endpoint)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_baseUrl + endpoint);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public Task<List<LugarDto>> ObtenerLugares()
            => GetAsync<List<LugarDto>>("api/Lugar");

        public Task<List<MedicionRuidoDto>> ObtenerMediciones()
            => GetAsync<List<MedicionRuidoDto>>("api/MedicionRuido");

        public Task<List<MedicionRuidoDto>> ObtenerMedicionesPorLugar(int id)
            => GetAsync<List<MedicionRuidoDto>>($"api/MedicionRuido/por-lugar/{id}");
    }
}
