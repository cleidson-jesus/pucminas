using System.Data;
using Dapper;
using MYCUSTOMERS.DOMAIN.Interfaces;
using MYCUSTOMERS.DOMAIN.ViewModels;

namespace MYCUSTOMERS.INFRASTRUCTURE.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection dbConnection;

        public ClienteRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public bool ClienteExiste(string cpfCnpjCliente)
        {
            try
            {
                using (dbConnection)
                {
                    var command = $@"select 1 from myc_cliente where cpfcnpj = @cpfCnpjCliente";

                    return dbConnection.ExecuteScalar<bool>(command, new { cpfCnpjCliente });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int RetornarTipoCliente(string cpfCnpjCliente)
        {
            try
            {
                using (dbConnection)
                {
                    var command = $@"select idtipo from myc_cliente where cpfcnpj = @cpfCnpjCliente";

                    return dbConnection.ExecuteScalar<int>(command, new { cpfCnpjCliente });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int RetornarIdCliente(string cpfCnpjCliente)
        {
            try
            {
                using (dbConnection)
                {
                    var command = $@"select 1 from myc_cliente where cpfcnpj = @cpfCnpjCliente";

                    return dbConnection.ExecuteScalar<int>(command, new { cpfCnpjCliente });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ListaClientesPesquisaViewModel ConsultaPeloCpfCnpj(string cpfCnpjCliente)
        {
            try
            {
                using (dbConnection)
                {
                    var command = $@"select id
                                           ,cpfcnpj
                                           ,nome
                                           ,idTipo       
                                       from myc_cliente 
                                      where cpfcnpj = @cpfCnpjCliente";

                    return dbConnection.QuerySingle<ListaClientesPesquisaViewModel>(command, new { cpfCnpjCliente });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ListaClientesPesquisaViewModel> ConsultaPeloNome(string nomeCliente)
        {
            try
            {
                string n = string.Empty;

                using (dbConnection)
                {

                    var command = $@"select id
                                           ,cpfcnpj
                                           ,nome
                                           ,idTipo
                                       from myc_cliente 
                                      where nome like @n";

                    return dbConnection.Query<ListaClientesPesquisaViewModel>(command, new { n = nomeCliente + "%" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
