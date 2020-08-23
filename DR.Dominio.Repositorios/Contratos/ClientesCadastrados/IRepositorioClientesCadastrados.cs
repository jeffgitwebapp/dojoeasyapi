using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.Repositorios.Contratos.ClientesCadastrados
{
    public interface IRepositorioClientesCadastrados: IRepositorio
    {
        IEnumerable<Cliente> Obter();
    }
}
