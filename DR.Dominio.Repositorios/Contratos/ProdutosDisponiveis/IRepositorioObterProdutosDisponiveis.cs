using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.Repositorios.Contratos.ProdutosDisponiveis
{
    public interface IRepositorioObterProdutosDisponiveis : IRepositorio
    {
        IEnumerable<Produto> Obter();
    }
}
