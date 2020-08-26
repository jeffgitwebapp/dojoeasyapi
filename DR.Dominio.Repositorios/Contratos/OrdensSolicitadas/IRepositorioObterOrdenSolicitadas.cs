using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.Repositorios.Contratos.OrdensSolicitadas
{
    public interface IRepositorioObterOrdenSolicitadas: IRepositorio
    {
        IEnumerable<OrdemCompra> Obter();
    }
}
