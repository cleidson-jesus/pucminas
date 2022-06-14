using MYCUSTOMERS.DOMAIN.ViewModels;

namespace MYCUSTOMERS.DOMAIN.Interfaces
{
    public  interface IClienteRepository
    {
        int RetornarIdCliente(string cpfCnpjCliente);
        int RetornarTipoCliente(string cpfCnpjCliente);
        bool ClienteExiste(string cpfCnpjCliente);
        ListaClientesPesquisaViewModel ConsultaPeloCpfCnpj(string cpfCnpjCliente);
        IEnumerable<ListaClientesPesquisaViewModel> ConsultaPeloNome(string nomeCliente);
    }
}
