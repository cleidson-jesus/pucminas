using Microsoft.AspNetCore.Mvc;
using MYCUSTOMERS.DOMAIN.Interfaces;
using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.ViewModels;

namespace MYCUSTOMERS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet(("cpfcnpj/{cpfCnpjCliente}"))]
        public IActionResult ConsultarPeloCpfCnpj(string cpfCnpjCliente)
        {
            return Ok(clienteService.ConsultarPeloCpfCnpj(cpfCnpjCliente));
        }

        [HttpGet(("nome/{nomeCliente}"))]
        public IActionResult ConsultarPeloNome(string nomeCliente)
        {
            return Ok(clienteService.ConsultarPeloNome(nomeCliente));
        }
    }
}
