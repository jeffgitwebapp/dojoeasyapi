using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.CriarOrdemCompra
{
    public class VisaoModeloCriarOrdemCompra
    {
        public Guid ClienteId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
