namespace DR.Infra.BD.Fabrica.ClienteBD.Abstracao
{
    public interface IClienteBD<ContratoClienteBD> where ContratoClienteBD : class
    {
        ContratoClienteBD ObterConexao(string stringConexao = null);
    }
}
