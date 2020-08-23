using System.Data;

namespace DR.Infra.BD.Fabrica.ClienteBD.Abstracao
{
    public abstract class FabricaAbstrataClienteBD
    {
        public abstract IClienteBD<IDbConnection> ObterClienteSqlServerBD(string stringConexao = null);
    }
}
