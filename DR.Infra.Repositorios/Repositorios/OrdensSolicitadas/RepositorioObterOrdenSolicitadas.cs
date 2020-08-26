using Dapper;
using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Entidades.Enums;
using DR.Dominio.Repositorios.Contratos.OrdensSolicitadas;
using DR.Infra.BD.Fabrica.ClienteBD;
using DR.Infra.Repositorios.Repositorios.Base;
using DR.Infra.Repositorios.Repositorios.OrdensSolicitadas.ResultadoConsultaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.OrdensSolicitadas
{
    public class RepositorioObterOrdenSolicitadas : RepositorioSqlServer, IRepositorioObterOrdenSolicitadas
    {
        public RepositorioObterOrdenSolicitadas(ConfiguracaoConexao configuracaoConexao) : base(configuracaoConexao)
        {
        }

        public IEnumerable<OrdemCompra> Obter()
        {
            try
            {
                AtivarCliente();

                var @param = new { status = OrdemCompraStatus.Solicitado.ToString() };

                var query = @"SELECT [Id]
                                  ,[DataOperacao]
                                  ,[QuantidadeSolicitada]
                                  ,[ValorOperacao]
                                  ,[PrecoUnitario]
                                  ,[ClienteID]
                                  ,[ProdutoID]
                                  ,[Status]
                              FROM [dbo].[OrdemCompra]
                          where Status = status";

                var result = _clienteSQL.Query<OrdemSolicitadaDTO>(query, param).ToList();

                List<OrdemCompra> ordens = new List<OrdemCompra>();

                if (result.Count > 0)
                {
                    foreach (var ordem in result)
                    {
                        ordens.Add(ordem.MapearOrdemDominio());
                    }
                }

                return ordens;

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
