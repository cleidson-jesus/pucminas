using MYCUSTOMERS.DOMAIN.Entities;

namespace MYCUSTOMERS.DOMAIN.Interfaces
{
    public  interface ITelefoneRepository
    {
        public IEnumerable<Telefone> RetornarTelefones(int idCliente);
        public void IncluirTelefones(IEnumerable<Telefone> telefones);
        public Telefone IncluirTelefone(Telefone telefone);
        public void AtualizarTelefone(Telefone telefone);

    }
}
