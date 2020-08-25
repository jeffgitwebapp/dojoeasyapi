using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.Repositorios.Contratos.ClientePorId
{
    public interface IRepositorioObterClientePorId : IRepositorio
    {
        Cliente Obter(Guid id);
    }
}
