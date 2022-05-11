using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CanteraSoftWeb.Models;
using Newtonsoft.Json;

namespace CanteraSoftWeb.Services
{
    public class ClienteService
    {
        private readonly string apiName = "/Api/Cliente";
        private readonly HttpClient _http;
        IEnumerable<ClienteModel> _lstClieenteModel;

        public ClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<ClienteModel>> SeleccionarTodos()
        {
            var clientes = await _http.GetFromJsonAsync<IEnumerable<ClienteModel>>($"{apiName}/SeleccionarTodos");
            return clientes;
        }

    }
}
