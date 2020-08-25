using Dapper;
using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos.ClientePorId;
using DR.Infra.BD.Fabrica.ClienteBD;
using DR.Infra.Repositorios.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.ClientesPorId
{
    public class RepositorioObterClientePorId : RepositorioSqlServer, IRepositorioObterClientePorId
    {
        public RepositorioObterClientePorId(ConfiguracaoConexao configuracaoConexao) : base(configuracaoConexao)
        {
        }

        public Cliente Obter(Guid id)
        {
            try
            {
                AtivarCliente();

                var @param = new { id };

                var query = @"SELECT [Id]
                                      ,[Nome]
                                      ,[Idade]
                                      ,[Saldo]
                                  FROM [dbo].[Cliente]
                          where Id = @id";

                var result = _clienteSQL.Query<Cliente>(query, param);

                return result?.FirstOrDefault();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                DesativarCliente();
            }
        }
    }
}
