using MYCUSTOMERS.DOMAIN.ViewModels;

namespace MYCUSTOMERS.DOMAIN.Interfaces
{
    public  interface IClienteService
    {
        public ListaClientesPesquisaViewModel ConsultarPeloCpfCnpj(string cpfCnpjCliente);
        public IEnumerable<ListaClientesPesquisaViewModel> ConsultarPeloNome(string nomeCliente);
    }
}
