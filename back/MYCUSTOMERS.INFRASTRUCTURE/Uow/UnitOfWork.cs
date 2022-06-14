namespace MYCUSTOMERS.INFRASTRUCTURE.Uow
{
    using System.Data;
    using MySql.Data.MySqlClient;
    using MYCUSTOMERS.DOMAIN.Interfaces;
    using MYCUSTOMERS.INFRASTRUCTURE.Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection connection;

        public UnitOfWork()
        {
            connection = new MySqlConnection("Server=localhost;Database=mycustomers;Uid=u_mycustomers;Pwd=password");
        }

        public IClienteRepository ClienteRepository => new ClienteRepository(connection);
        public IClientePFRepository ClientePFRepository => new ClientePfRepository(connection);
        public IEnderecoRepository EnderecoRepository => new EnderecoRepository(connection);
        public ITelefoneRepository TelefoneRepository => new TelefoneRepository(connection);

    }
}