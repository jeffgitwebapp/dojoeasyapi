using Dapper;
using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos.ProdutoPorId;
using DR.Infra.BD.Fabrica.ClienteBD;
using DR.Infra.Repositorios.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.PordutoPorId
{
    public class RepositorioObterProdutoPorId : RepositorioSqlServer, IRepositorioObterProdutoPorId
    {
        public RepositorioObterProdutoPorId(ConfiguracaoConexao configuracaoConexao) : base(configuracaoConexao)
        {
        }

        public Produto Obter(Guid id)
        {
            try
            {
                AtivarCliente();

                var @param = new { id };

                var query = @"SELECT [Id]
                              ,[Codigo]
                              ,[Descricao]
                              ,[Estoque]
                              ,[PrecoUnitario]
                              ,[ValorMinimoDeCompra]
                          FROM [dbo].[Produto]
                          where Id = @id";

                var result = _clienteSQL.Query<Produto>(query, param);

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
