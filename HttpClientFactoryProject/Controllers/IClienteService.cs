using HttpClientFactoryProject.Models;
using System.Threading.Tasks;

namespace HttpClientFactoryProject.Controllers
{
    public interface IClienteService
    {
        Task<ClienteSofisaDireto> ObterCliente(int clienteId);
    }
}