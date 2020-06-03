using System.Threading.Tasks;
using HttpClientFactoryProject.Models;
using Refit;

namespace HttpClientFactoryProject.Services
{
    public interface IClienteService
    {
        [Get("/cliente/ObterPorId/{clientId}")]
        Task<ClienteSofisaDireto> ObterCliente(int clientId);
    }
}