using Microsoft.AspNetCore.Mvc;
using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.Interfaces;

namespace MYCUSTOMERS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            this.enderecoService = enderecoService;
        }

        [Route("{idCliente}")]
        [HttpGet]
        public IActionResult ConsultarEnderecos(int idCliente)
        {
            return Ok(enderecoService.RetornarEnderecos(idCliente));
        }

        [Route("")]
        [HttpPost]
        public IActionResult InserirEndereco(Endereco endereco)
        {
            return Created(string.Empty,enderecoService.IncluirEndereco(endereco));
        }

        [Route("")]
        [HttpPut]
        public IActionResult AtualizarEndereco(Endereco endereco)
        {
            enderecoService.AtualizarEndereco(endereco);
            return Ok();
        }
    }
}
