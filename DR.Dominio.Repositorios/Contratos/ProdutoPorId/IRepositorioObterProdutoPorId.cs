using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.Repositorios.Contratos.ProdutoPorId
{
    public interface IRepositorioObterProdutoPorId : IRepositorio
    {
        Produto Obter(Guid Id);
    }
}
