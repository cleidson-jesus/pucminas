using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.Interfaces;

namespace MYCUSTOMERS.DOMAIN.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly IUnitOfWork unitOfWork;

        public TelefoneService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Telefone> RetornarTelefones(int idCliente)
        {
            return unitOfWork.TelefoneRepository.RetornarTelefones(idCliente);
        }

        public Telefone IncluirTelefone(Telefone telefone)
        {
            return unitOfWork.TelefoneRepository.IncluirTelefone(telefone);
        }

        public void AtualizarTelefone(Telefone telefone)
        {
            unitOfWork.TelefoneRepository.AtualizarTelefone(telefone);
        }
    }
}
