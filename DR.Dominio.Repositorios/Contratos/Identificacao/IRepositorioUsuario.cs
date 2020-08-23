
namespace DR.Dominio.Repositorios.Contratos.Identificacao
{
    public interface IRepositorioUsuario : IRepositorio<object>
    {
        bool UsuarioAutorizado(string login, string senha);
    }
}
