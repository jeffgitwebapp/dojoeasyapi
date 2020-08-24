using Dapper;
using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos.ProdutosDisponiveis;
using DR.Infra.BD.Fabrica.ClienteBD;
using DR.Infra.Repositorios.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.ProdutosDisponiveis
{
    public class RepositorioObterProdutosDisponiveis : RepositorioSqlServer, IRepositorioObterProdutosDisponiveis
    {
        public RepositorioObterProdutosDisponiveis(ConfiguracaoConexao configuracaoConexao) : base(configuracaoConexao)
        {
        }

        public IEnumerable<Produto> Obter()
        {
            try
            {
                AtivarCliente();


                var query = @"SELECT [Id]
                              ,[Codigo]
                              ,[Descricao]
                              ,[Estoque]
                              ,[PrecoUnitario]
                              ,[ValorMinimoDeCompra]
                          FROM [dbo].[Produto]
                          where Estoque > 0";


                var result = _clienteSQL.Query<Produto>(query);

                return result;
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
