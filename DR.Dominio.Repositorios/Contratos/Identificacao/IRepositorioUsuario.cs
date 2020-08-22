
namespace DR.Dominio.Repositorios.Contratos.Identificacao
{
    public interface IRepositorioUsuario : IRepositorioBase<object>
    {
        bool UsuarioAutorizado(string login, string senha);
    }
}
