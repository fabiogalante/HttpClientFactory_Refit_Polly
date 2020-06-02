using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFactoryProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        //Injetar o servico de Todo
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("ObterCliente/{clientId}")]
        public async Task<ActionResult> ObterCliente(int clientId)
        {
            return Ok(await _clienteService.ObterCliente(clientId));
        }
    }
}