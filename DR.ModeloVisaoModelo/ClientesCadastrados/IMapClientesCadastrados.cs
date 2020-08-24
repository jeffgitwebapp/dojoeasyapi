using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.ClientesCadastrados
{
    public interface IMapClientesCadastrados : IVisaoModeloResultado
    {
        IEnumerable<VisaoModeloClientesCadastrados> Resultado();
    }
}
