

namespace MYCUSTOMERS.DOMAIN.Interfaces
{
    public interface IUnitOfWork
    {
        IClienteRepository ClienteRepository { get; }
        IClientePFRepository ClientePFRepository { get; }
        IEnderecoRepository EnderecoRepository { get; }
        ITelefoneRepository TelefoneRepository { get; }
    }
}
