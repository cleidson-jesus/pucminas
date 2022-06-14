using Microsoft.AspNetCore.Mvc;
using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.Interfaces;

namespace MYCUSTOMERS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelefoneController : Controller
    {
        private readonly ITelefoneService telefoneService;

        public TelefoneController(ITelefoneService telefoneService)
        {
            this.telefoneService = telefoneService;
        }

        [Route("{idCliente}")]
        [HttpGet]
        public IActionResult ConsultarTelefones(int idCliente)
        {
            return Ok(telefoneService.RetornarTelefones(idCliente));
        }

        [HttpPost]
        public IActionResult InserirTelefone(Telefone telefone)
        {
            return Created(string.Empty,telefoneService.IncluirTelefone(telefone));
        }

        [HttpPut]
        public IActionResult AtualizarEndereco(Telefone telefone)
        {
            telefoneService.AtualizarTelefone(telefone);
            return Ok();
        }

    }
}
