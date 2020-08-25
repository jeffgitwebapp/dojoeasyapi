using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.CriarOrdemCompra
{
    public interface ICriarOrdemCompraVisaoModelo : IProcessamentoVisaoModelo
    {
         void CriarOrdem(VisaoModeloCriarOrdemCompra ordem);
    }
}
