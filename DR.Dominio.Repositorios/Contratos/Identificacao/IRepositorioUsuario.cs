
namespace DR.Dominio.Repositorios.Contratos.Identificacao
{
    public interface IRepositorioUsuario : IRepositorio
    {
        bool UsuarioAutorizado(string login, string senha);
    }
}
