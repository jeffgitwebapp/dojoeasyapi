using Dapper;
using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos.CriarOrdemCompra;
using DR.Infra.BD.Fabrica.ClienteBD;
using DR.Infra.Repositorios.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.CriarOrdemCompra
{
    public class RepositorioCriarOrdemCompra : RepositorioSqlServer, IRepositorioCriarOrdemCompra
    {
        public RepositorioCriarOrdemCompra(ConfiguracaoConexao configuracaoConexao) : base(configuracaoConexao)
        {
        }

        public void CriarOrdem(OrdemCompra novaOrdemCompra)
        {
            try
            {
                AtivarCliente();

                var comando = @"INSERT INTO [dbo].[OrdemCompra]
                                                       ([Id]
                                                       ,[DataOperacao]
                                                       ,[QuantidadeSolicitada]
                                                       ,[ValorOperacao]
                                                       ,[PrecoUnitario]
                                                       ,[ClienteID]
                                                       ,[ProdutoID]
                                                       ,[Status])
                                                 VALUES
                                                       (@Id
                                                       ,@DataOperacao
                                                       ,@QuantidadeSolicitada
                                                       ,@ValorOperacao
                                                       ,@PrecoUnitario
                                                       ,@ClienteID
                                                       ,@ProdutoID
                                                       ,@Status)";

                var @ordem = new
                {
                    novaOrdemCompra.Id,
                    novaOrdemCompra.DataOperacao,
                    novaOrdemCompra.QuantidadeSolicitada,
                    novaOrdemCompra.ValorOperacao,
                    novaOrdemCompra.PrecoUnitario,
                    ClienteID = novaOrdemCompra.Cliente.Id,
                    ProdutoID = novaOrdemCompra.Produto.Id,
                    Status = novaOrdemCompra.Status.ToString()
                };

                var result = _clienteSQL.Execute(comando, @ordem);

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
