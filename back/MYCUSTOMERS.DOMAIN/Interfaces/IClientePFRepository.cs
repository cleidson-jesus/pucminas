using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.ViewModels;

namespace MYCUSTOMERS.DOMAIN.Interfaces
{
    public interface IClientePFRepository
    {
        public ClientePF Consultar(int idCliente);
        public int InserirCliente(ClientePF cliente);
        public void AtualizarCliente(ClientePFUpdateViewModel cliente);
    }
}
