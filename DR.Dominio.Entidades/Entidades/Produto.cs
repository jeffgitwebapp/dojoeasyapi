using System;

namespace DR.Dominio.Entidades.Entidades
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public int Estoque { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal ValorMinimoDeCompra { get; private set; }
    }
}
