using MYCUSTOMERS.DOMAIN.Interfaces;
using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.ViewModels;
using MYCUSTOMERS.HELPERS.CustomExceptionMiddleware;

namespace MYCUSTOMERS.DOMAIN.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IClientePFService clientePFService;

        public ClienteService(IUnitOfWork unitOfWork,IClientePFService clientePFService)
        {
            this.unitOfWork = unitOfWork;
            this.clientePFService = clientePFService;
        }

        public ListaClientesPesquisaViewModel ConsultarPeloCpfCnpj(string cpfCnpjCliente)
        {
            string cpf = FormatarCpf(cpfCnpjCliente);

            return unitOfWork.ClienteRepository.ConsultaPeloCpfCnpj(cpf);
        }

        public IEnumerable<ListaClientesPesquisaViewModel> ConsultarPeloNome(string nomeCliente)
        {
            return unitOfWork.ClienteRepository.ConsultaPeloNome(nomeCliente);
        }

        private string FormatarCpf(string cpf)
        {
            return cpf.PadLeft(11, '0');
        }

    }
}
