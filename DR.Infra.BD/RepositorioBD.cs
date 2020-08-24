using System.Data;

namespace DR.Infra.BD.Fabrica.ClienteBD
{
   public abstract class RepositorioBD
    {
        protected FabricaClienteBD _fabricaClienteBD { get; set; }

        protected IDbConnection _sqlServeClient { get; set; }

        public abstract void AtivarCliente();

        public abstract void DesativarCliente();
    }
}
