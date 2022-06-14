using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.Interfaces;

namespace MYCUSTOMERS.DOMAIN.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IUnitOfWork unitOfWork;

        public EnderecoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Endereco> RetornarEnderecos(int idCliente)
        {
            return unitOfWork.EnderecoRepository.RetornarEnderecos(idCliente);
        }

        public void IncluirEnderecos(IEnumerable<Endereco> enderecos)
        {
            unitOfWork.EnderecoRepository.IncluirEnderecos(enderecos);
        }

        public Endereco IncluirEndereco(Endereco endereco)
        {
            return unitOfWork.EnderecoRepository.IncluirEndereco(endereco);
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            unitOfWork.EnderecoRepository.AtualizarEndereco(endereco);
        }
    }
}
