using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.ViewModels;

namespace MYCUSTOMERS.DOMAIN.Interfaces
{
    public interface IClientePFService
    {
        public ClientePF Consultar(int idCliente);
        public ClientePF IncluirCliente(ClientePF cliente);
        public void AtualizarCliente(ClientePFUpdateViewModel cliente);
    }
}
