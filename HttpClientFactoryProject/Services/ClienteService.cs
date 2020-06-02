using HttpClientFactoryProject.Configuration;
using HttpClientFactoryProject.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HttpClientFactoryProject.Controllers;

namespace HttpClientFactoryProject.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IApiConfig _config;
        private readonly HttpClient _httpClient;

        public ClienteService(IApiConfig config, HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
        }


        public async Task<ClienteSofisaDireto> ObterCliente(int clienteId)
        {
            return await _httpClient.GetFromJsonAsync<ClienteSofisaDireto>(
                $"{_config.BaseUrl}Cliente/ObterPorId/{clienteId}"
            );
        }
    }
}
