using Microsoft.AspNetCore.Mvc;
using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.Interfaces;
using MYCUSTOMERS.DOMAIN.ViewModels;

namespace MYCUSTOMERS.API.Controllers
{
    [ApiController]
    [Route("pessoa-fisica")]
    public class PessoaFisicaController : Controller
    {
        private readonly IClientePFService clientePFService;

        public PessoaFisicaController(IClientePFService clientePfSerivce)
        {
            this.clientePFService = clientePfSerivce;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ConsultarCliente(int id)
        {
            return Ok(clientePFService.Consultar(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult InserirCliente(ClientePF cliente)
        {
            return Created(string.Empty, clientePFService.IncluirCliente(cliente));
        }

        [HttpPut]
        [Route("")]
        public IActionResult AtualizarCliente(ClientePFUpdateViewModel cliente)
        {
            clientePFService.AtualizarCliente(cliente);
            return Ok();
        }
    }
}
