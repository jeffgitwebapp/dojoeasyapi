using Dapper;
using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos.AtualizarEstoqueProduto;
using DR.Infra.BD.Fabrica.ClienteBD;
using DR.Infra.Repositorios.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.AtualizarEstoqueProduto
{
    public class RepositorioAtualizarEstoqueProduto : RepositorioSqlServer, IRepositorioAtualizarEstoqueProduto
    {
        public RepositorioAtualizarEstoqueProduto(ConfiguracaoConexao configuracaoConexao) : base(configuracaoConexao)
        {
        }

        public void AtualizarEstoque(Produto produto)
        {
            try
            {
                AtivarCliente();

                var comando = @"UPDATE [dbo].[Produto]
                                   SET [Estoque] = @Estoque
                                 WHERE Id = @Id";

                var @ordemParam = new
                {
                    produto.Id,
                    produto.Estoque
                };

                var result = _clienteSQL.Execute(comando, @ordemParam);

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
