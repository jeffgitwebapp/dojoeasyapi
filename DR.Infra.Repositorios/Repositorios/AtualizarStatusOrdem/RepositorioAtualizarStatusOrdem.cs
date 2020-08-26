using Dapper;
using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos.AtualizarStatusOrdem;
using DR.Infra.BD.Fabrica.ClienteBD;
using DR.Infra.Repositorios.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.AtualizarStatusOrdem
{
    public class RepositorioAtualizarStatusOrdem : RepositorioSqlServer, IRepositorioAtualizarStatusOrdem
    {
        public RepositorioAtualizarStatusOrdem(ConfiguracaoConexao configuracaoConexao) : base(configuracaoConexao)
        {
        }

        public void AtualizarStatus(OrdemCompra ordem)
        {
            try
            {
                AtivarCliente();

                var comando = @"UPDATE [dbo].[OrdemCompra]
                                         SET [Status] = @status
                                         WHERE Id = @id";

                var @ordemParam = new
                {
                    ordem.Id,
                    Status = ordem.Status.ToString()
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
