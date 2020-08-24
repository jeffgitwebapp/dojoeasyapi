using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.ProdutosDisponiveis
{
    public interface IMapProdutosDisponiveis: IVisaoModeloResultado
    {
        IEnumerable<VisaoModeloProdutosDisponiveis> Resultado();
    }
}
