using DR.Dominio.Entidades.Enums;
using System;

namespace DR.Dominio.Entidades.Entidades
{
    public class OrdemCompra
    {
        public Guid Id { get; private set; }
        public DateTime DataOperacao { get; private set; }
        public Produto Produto { get; private set; }
        public Cliente Cliente { get; private set; }
        public int QuantidadeSolicitada { get; private set; }
        public decimal ValorOperacao { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public OrdemCompraStatus Status { get; private set; }
    }
}
