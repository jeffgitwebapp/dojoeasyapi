using System;

namespace DR.Dominio.Entidades.Entidades
{
    public class Produto
    {

        public Produto()
        {
            Id = Guid.NewGuid();
        }

        public Produto(Guid produtoId)
        {
            Id = produtoId;
        }

        public Guid Id { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public int Estoque { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal ValorMinimoDeCompra { get; private set; }

        public bool ExisteEstoque(int quantidadeSolicitada)
        {
            return Estoque >= quantidadeSolicitada;
        }

        public void AtualizarEstoque(int quantidadeSolicitada)
        {
            if (ExisteEstoque(quantidadeSolicitada))
            {
                Estoque = Estoque - quantidadeSolicitada;
            } 
        }
    }
}
