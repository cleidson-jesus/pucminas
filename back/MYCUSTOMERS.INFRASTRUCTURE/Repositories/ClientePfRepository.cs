using System.Data;
using Dapper;
using MYCUSTOMERS.DOMAIN.Interfaces;
using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.ViewModels;

namespace MYCUSTOMERS.INFRASTRUCTURE.Repositories
{
    public class ClientePfRepository : IClientePFRepository
    {

        private readonly IDbConnection dbConnection;

        public ClientePfRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public ClientePF Consultar(int idCliente)
        {
            try
            {
                using (dbConnection)
                {
                    var command = $@"select cli.id
                                           ,cpfcnpj
                                           ,nome
                                           ,idtipo
                                           ,datahorainclusao
                                           ,datahoraatualizacao
                                           ,datafichacadastral
                                           ,idrating
                                           ,exposicaomidia
                                           ,email
                                           ,pessoapep
                                           ,idgenero
                                           ,datanascimento
                                           ,idcidadenascimento
                                           ,numerodocidentificacao
                                           ,renda
                                       from myc_cliente cli
                                      inner join myc_pessoa_fisica pf
                                         on cli.id = pf.id
                                      where cli.id = @idCliente;";

                    return dbConnection.QuerySingle<ClientePF>(command, new { idCliente });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InserirCliente(ClientePF cliente)
        {

            DynamicParameters parameters;
            string command;

            try
            {

                parameters = new DynamicParameters();

                parameters.Add("@cpfcnpj", cliente.CpfCnpj, DbType.String, ParameterDirection.Input);
                parameters.Add("@nome", cliente.Nome, DbType.String, ParameterDirection.Input);
                parameters.Add("@idtipo", cliente.IdTipo, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@idrating", cliente.Idrating, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@exposicaomidia", cliente.ExposicaoMidia, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@email", cliente.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("@pessoapep", cliente.PessoaPep, DbType.Int32, ParameterDirection.Input);

                command = $@"insert 
                               into myc_cliente
                                    (cpfcnpj
                                    ,nome
                                    ,idtipo
                                    ,datahorainclusao
                                    ,datahoraatualizacao
                                    ,datafichacadastral
                                    ,idrating
                                    ,exposicaomidia
                                    ,email
                                    ,pessoapep)
                             values (@cpfcnpj
                                    ,@nome
                                    ,@idtipo
                                    ,now()
                                    ,now()
                                    ,now()
                                    ,@idrating
                                    ,@exposicaomidia
                                    ,@email
                                    ,@pessoapep);";

                dbConnection.Execute(command, parameters);

                cliente.Id = dbConnection.ExecuteScalar<int>("select id from myc_cliente where cpfcnpj = " + cliente.CpfCnpj);

                parameters = new DynamicParameters();

                parameters.Add("@id", cliente.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@idgenero", cliente.IdGenero, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@datanascimento", cliente.DataNascimento, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@idcidadenascimento", cliente.IdCidadeNascimento, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@numerodocidentificacao", cliente.NumeroDocIdentificacao, DbType.String, ParameterDirection.Input);
                parameters.Add("@renda", cliente.Renda, DbType.Decimal, ParameterDirection.Input);

                command = $@"insert 
                               into myc_pessoa_fisica
                             values (@id
                                    ,@idgenero
                                    ,@datanascimento
                                    ,@idcidadenascimento
                                    ,@numerodocidentificacao
                                    ,@renda);";

                dbConnection.Execute(command, parameters);

                return cliente.Id;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AtualizarCliente(ClientePFUpdateViewModel cliente)
        {
            DynamicParameters parameters;
            string command;

            try
            {
                parameters = new DynamicParameters();

                parameters.Add("@id", cliente.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@datafichacadastral", cliente.DataFichaCadastral, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@nome", cliente.Nome, DbType.String, ParameterDirection.Input);
                parameters.Add("@idtipo", cliente.IdTipo, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@idrating", cliente.Idrating, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@exposicaomidia", cliente.ExposicaoMidia, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@email", cliente.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("@pessoapep", cliente.PessoaPep, DbType.Int32, ParameterDirection.Input);

                command = $@"update myc_cliente 
                                set  nome = @nome
                                    ,idtipo = @idtipo
                                    ,datahoraatualizacao = now()
                                    ,datafichacadastral = @datafichacadastral
                                    ,idrating = @idrating
                                    ,exposicaomidia = @exposicaomidia
                                    ,email = @email
                                    ,pessoapep = @pessoapep
                               where id = @id;";

                dbConnection.Execute(command, parameters);

                parameters = new DynamicParameters();

                parameters.Add("@id", cliente.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@idgenero", cliente.IdGenero, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@datanascimento", cliente.DataNascimento, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@idcidadenascimento", cliente.IdCidadeNascimento, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@numerodocidentificacao", cliente.NumeroDocIdentificacao, DbType.String, ParameterDirection.Input);
                parameters.Add("@renda", cliente.Renda, DbType.Decimal, ParameterDirection.Input);

                command = $@"update myc_pessoa_fisica
                                set  idgenero = @idgenero
                                    ,datanascimento = @datanascimento
                                    ,idcidadenascimento = @idcidadenascimento
                                    ,numerodocidentificacao = @numerodocidentificacao
                                    ,renda = @renda;";

                dbConnection.Execute(command, parameters);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
