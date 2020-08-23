using DR.Infra.BD.Fabrica.ClienteBD.Abstracao;
using System.Data;

namespace DR.Infra.BD.Fabrica.ClienteBD
{
    public class FabricaClienteBD : FabricaAbstrataClienteBD
    {
        public override IClienteBD<IDbConnection> ObterClienteSqlServerBD(string stringConexao = null)
        {
            return new ClienteBDSqlServer(stringConexao);
        }
    }
}
