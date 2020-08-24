using Dapper;
using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Entidades.ObjetoValor;
using DR.Dominio.Repositorios.Contratos.ClientesCadastrados;
using DR.Infra.BD.Fabrica.ClienteBD;
using DR.Infra.Repositorios.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DR.Infra.Repositorios.Repositorios.ClientesCadastrados
{
    public class RepositorioClientesCadastrados : RepositorioSqlServer, IRepositorioClientesCadastrados
    {
        public RepositorioClientesCadastrados(ConfiguracaoConexao configuracaoConexao) : base(configuracaoConexao)
        {
        }

        public IEnumerable<Cliente> Obter()
        {
            try
            {
                AtivarCliente();


                var query = @"SELECT c.Id
                              ,c.[Nome]
                              ,c.[Idade]
                              ,c.[Saldo]
	                          ,e.Cidade
	                          ,e.Estado
                          FROM [dbo].[Cliente] c
                          inner join
                          [dbo].[Endereco] e
                          on c.Id = e.ClienteID";


                var result = _sqlServeClient.Query<Cliente, Endereco, Cliente>(query,
                        (cliente, endereco) =>
                        {
                            cliente.AtribuirEndereco(endereco);

                            return cliente;
                        },
                        null,
                        splitOn: "Id");

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
