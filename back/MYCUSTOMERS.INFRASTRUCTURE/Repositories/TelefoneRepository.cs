using MYCUSTOMERS.DOMAIN.Entities;
using MYCUSTOMERS.DOMAIN.Interfaces;
using Dapper;
using System.Data;

namespace MYCUSTOMERS.INFRASTRUCTURE.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly IDbConnection dbConnection;

        public TelefoneRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public IEnumerable<Telefone> RetornarTelefones(int idCliente)
        {
            try
            {
                using (dbConnection)
                {
                    var command = $@"select id
                                           ,idcliente
                                           ,idtipo
                                           ,ddd
                                           ,numero
                                           ,enviosms
                                    from myc_telefone 
                                    where idcliente = @idCliente;";

                    return dbConnection.Query<Telefone>(command, new { idCliente });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Telefone IncluirTelefone(Telefone telefone)
        {
            string command;
            DynamicParameters parameters;

            try
            {
                using (dbConnection)
                {

                    parameters = new DynamicParameters();

                    parameters.Add("@id", 1, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@idcliente", telefone.IdCliente, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@idtipo", telefone.IdTipo, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@ddd", telefone.Ddd, DbType.String, ParameterDirection.Input);
                    parameters.Add("@numero", telefone.Numero, DbType.String, ParameterDirection.Input);
                    parameters.Add("@enviosms", telefone.EnvioSms, DbType.Int32, ParameterDirection.Input);

                    command = $@"insert
                                    into myc_telefone
                                        (idcliente
                                        ,idtipo
                                        ,ddd
                                        ,numero
                                        ,enviosms)
                                    values (@idcliente
                                        ,@idtipo
                                        ,@ddd
                                        ,@numero
                                        ,@enviosms);";

                    dbConnection.Execute(command, parameters);

                    command = $@"select id
                                       ,idcliente
                                       ,idtipo
                                       ,ddd
                                       ,numero
                                       ,enviosms
                                   from myc_telefone
                                  where idCliente = @idCliente
                                    and id = (select max(id) from myc_telefone where idCliente = @idCliente)";

                    return dbConnection.QuerySingle<Telefone>(command, new { telefone.IdCliente });

                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void IncluirTelefones(IEnumerable<Telefone> telefones)
        {
            string command;
            DynamicParameters parameters;

            try
            {
                using (dbConnection)
                {
                    foreach (Telefone telefone in telefones)
                    {
                        parameters = new DynamicParameters();

                        parameters.Add("@idcliente", telefone.IdCliente, DbType.Int32, ParameterDirection.Input);
                        parameters.Add("@idtipo", telefone.IdTipo, DbType.Int32, ParameterDirection.Input);
                        parameters.Add("@ddd", telefone.Ddd, DbType.String, ParameterDirection.Input);
                        parameters.Add("@numero", telefone.Numero, DbType.String, ParameterDirection.Input);
                        parameters.Add("@enviosms", telefone.EnvioSms, DbType.Int32, ParameterDirection.Input);

                        command = $@"insert
                                       into myc_telefone
                                            (idcliente
                                            ,idtipo
                                            ,ddd
                                            ,numero
                                            ,enviosms)
                                     values (@idcliente
                                            ,@idtipo
                                            ,@ddd
                                            ,@numero
                                            ,@enviosms);";

                        dbConnection.Execute(command, parameters);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AtualizarTelefone(Telefone telefone)
        {
            string command;
            DynamicParameters parameters;

            try
            {
                using (dbConnection)
                {
                    parameters = new DynamicParameters();

                    parameters.Add("@id", telefone.Id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@idcliente", telefone.IdCliente, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@idtipo", telefone.IdTipo, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@ddd", telefone.Ddd, DbType.String, ParameterDirection.Input);
                    parameters.Add("@numero", telefone.Numero, DbType.String, ParameterDirection.Input);
                    parameters.Add("@enviosms", telefone.EnvioSms, DbType.Int32, ParameterDirection.Input);

                    command = $@"update myc_telefone
                                    set idtipo = @idtipo
                                       ,ddd = @ddd
                                       ,numero = @numero
                                       ,enviosms = @enviosms
                                  where id = @id
                                    and idcliente = @idcliente";

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
