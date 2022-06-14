using MYCUSTOMERS.DOMAIN.Entities;

namespace MYCUSTOMERS.DOMAIN.Interfaces
{
    public interface ITelefoneService
    {
        public IEnumerable<Telefone> RetornarTelefones(int idCliente);
        public Telefone IncluirTelefone(Telefone telefone);
        public void AtualizarTelefone(Telefone telefone);
    }
}
