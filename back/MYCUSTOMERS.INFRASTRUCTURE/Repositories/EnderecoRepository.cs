using System.Data;
using Dapper;
using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.Interfaces;

namespace MYCUSTOMERS.INFRASTRUCTURE.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IDbConnection dbConnection;

        public EnderecoRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public Endereco RetornarEndereco(int idCliente, int idEndereco)
        {
            try
            {
                using (dbConnection)
                {
                    var command = $@"select id
                                           ,idcliente
                                           ,cep
                                           ,logradouro
                                           ,numero
                                    from myc_endereco
                                    where id = @idEndereco
                                      and idcliente = @idCliente;";

                    return dbConnection.QuerySingle<Endereco>(command, new { idEndereco,idCliente });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Endereco> RetornarEnderecos(int idCliente)
        {
            try
            {
                using (dbConnection)
                {
                    var command = $@"select id
                                           ,idcliente
                                           ,cep
                                           ,logradouro
                                           ,numero
                                    from myc_endereco
                                    where idcliente = @idCliente;";

                    return dbConnection.Query<Endereco>(command, new { idCliente });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void IncluirEnderecos(IEnumerable<Endereco> enderecos)
        {
            string command;
            DynamicParameters parameters;

            try
            {
                using (dbConnection)
                {
                    foreach (Endereco endereco in enderecos)
                    {
                        parameters = new DynamicParameters();

                        parameters.Add("@idcliente", endereco.IdCliente, DbType.Int32, ParameterDirection.Input);
                        parameters.Add("@cep", endereco.Cep, DbType.Int32, ParameterDirection.Input);
                        parameters.Add("@logradouro", endereco.Logradouro, DbType.String, ParameterDirection.Input);
                        parameters.Add("@numero", endereco.Numero, DbType.String, ParameterDirection.Input);

                        command = $@"insert
                                       into myc_endereco
                                            (idcliente
                                            ,cep
                                            ,logradouro
                                            ,numero)
                                     values (@idcliente
                                            ,@cep
                                            ,@logradouro
                                            ,@numero);";

                        dbConnection.Execute(command, parameters);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Endereco IncluirEndereco(Endereco endereco)
        {
            string command;
            DynamicParameters parameters;

            try
            {
                using (dbConnection)
                {
                    parameters = new DynamicParameters();

                    parameters.Add("@idcliente", endereco.IdCliente, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@cep", endereco.Cep, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@logradouro", endereco.Logradouro, DbType.String, ParameterDirection.Input);
                    parameters.Add("@numero", endereco.Numero, DbType.String, ParameterDirection.Input);

                    command = $@"insert
                                    into myc_endereco
                                        (idcliente
                                        ,cep
                                        ,logradouro
                                        ,numero)
                                    values (@idcliente
                                        ,@cep
                                        ,@logradouro
                                        ,@numero);";

                    dbConnection.Execute(command, parameters);


                    command = $@"select id
                                       ,idcliente
                                       ,cep
                                       ,logradouro
                                       ,numero
                                   from myc_endereco
                                  where idCliente = @idCliente
                                    and id = (select max(id) from myc_endereco where idCliente = @idCliente)";

                    return dbConnection.QuerySingle<Endereco>(command, new { endereco.IdCliente });

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AtualizarEndereco(Endereco endereco)
        {

            DynamicParameters parameters;

            try
            {
                using (dbConnection)
                {
                        parameters = new DynamicParameters();

                        parameters.Add("@id", endereco.Id, DbType.Int32, ParameterDirection.Input);
                        parameters.Add("@idcliente", endereco.IdCliente, DbType.Int32, ParameterDirection.Input);
                        parameters.Add("@cep", endereco.Cep, DbType.Int32, ParameterDirection.Input);
                        parameters.Add("@logradouro", endereco.Logradouro, DbType.String, ParameterDirection.Input);
                        parameters.Add("@numero", endereco.Numero, DbType.String, ParameterDirection.Input);

                        var command = $@"update myc_endereco
                                            set cep = @cep
                                               ,logradouro = @logradouro
                                               ,numero = @numero
                                          where id = @id
                                            and idCliente = @idcliente";

                        dbConnection.Execute(command, parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
