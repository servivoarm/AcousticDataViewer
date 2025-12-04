using Newtonsoft.Json;
using PF_VNR.ClienteWinForms1.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PF_VNR.ClienteWinForms1.Service
{
    public class AuthApiService
    {

        private readonly HttpClient _http;

        public AuthApiService()
        {

            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
(sender, cert, chain, errors) => true;
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7101/")
            };
        }

        public async Task<LoginResponse> LoginAsync(string usuario, string contrasena)
        {
            var login = new LoginRequest
            {
                Usuario = usuario,
                Contrasena = contrasena
            };

            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("/api/usuario/login", content);

            if (!response.IsSuccessStatusCode)
                return null;

            var jsonResp = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginResponse>(jsonResp);
        }
    }
}
